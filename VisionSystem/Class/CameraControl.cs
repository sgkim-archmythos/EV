/*
 * @file CameraControl.cs
 *
 * Copyright (c) 2019 KEYENCE CORPORATION.
 * All rights reserved.
 *
 */

using Keyence.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public class CameraControl
{
    [DllImport("kernel32.dll")]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    public static CameraControl instance = new CameraControl();

    private List<CameraInfo> _cameraList = new List<CameraInfo>();

    //private DeviceDisconnectedDelegate gOnDeviceDisconnected;
    //private DeviceEventGenICamDelegate gOnDeviceEventGenICam;

    public class CameraInfo
    {
        public string sIpAddress;
        public KglDevice kglDevice;
        public KglStream kglStream;
        public KglBuffer kglBuffer;
    }

    public CameraInfo GetCameraInfo(string IpAddress)
    {
        foreach (CameraInfo camera in _cameraList)
        {
            if (camera.sIpAddress == IpAddress)
            {
                return camera;
            }
        }
        return null;
    }

    #region DeviceControl
    public bool Connect(string IpAddress, DeviceListControl oContext)
    {
        KglDevice kglDevice = new KglDevice();
        KglStream kglStream = new KglStream();

        if (KglResult.KGL_SUCCESS != kglDevice.connect(IpAddress))
        {
            return false;
        }

        if (KglResult.KGL_SUCCESS != kglStream.open(kglDevice))
        {
            return false;
        }

        KglDevice.KglDeviceDisconnectedDelegate _OnDeviceDisconnectedWrapper = new KglDevice.KglDeviceDisconnectedDelegate(OnDeviceDisconnectedWrapper);
        KglDevice.KglDeviceEventGenICamDelegate _OnDeviceEventGenICamWrapper = new KglDevice.KglDeviceEventGenICamDelegate(OnDeviceEventGenICamWrapper);

        kglDevice.addDeviceDisconnectedDelegate(_OnDeviceDisconnectedWrapper);
        kglDevice.addDeviceEventGenICamDelegate(_OnDeviceEventGenICamWrapper);

        //gOnDeviceDisconnected = OnDeviceDisconnected;
        //gOnDeviceEventGenICam = OnDeviceEventGenICam;

        CameraInfo camera = new CameraInfo
        {
            sIpAddress = IpAddress,
            kglDevice = kglDevice,
            kglStream = kglStream
        };

        _cameraList.Add(camera);

        return true;
    }

    public bool Disconnect(string IpAddress)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        camera.kglStream.close(camera.kglDevice);
        camera.kglDevice.disconnect();

        _cameraList.Remove(camera);
        return true;
    }

    public void OnDeviceDisconnectedWrapper(KglDevice device)
    {
        string sDevicePAddress = device.getIPAddress();
        //gOnDeviceDisconnected(sDevicePAddress);
    }

    public void OnDeviceEventGenICamWrapper(KglDevice device, ushort eventID, ushort channel, ulong blockID, ulong timeStamp, List<KglGenParameter> featureNodes)
    {
        string sDevicePAddress = device.getIPAddress();
        string sEventMessage = "";

        KglGenParameterArray paramArray = device.getDeviceParameters();

        sEventMessage += "eventID: 0x" + eventID.ToString("X2") + "\n";
        for (int i = 0; i < featureNodes.Count(); i++)
        {
            KglGenParameter node = featureNodes.ElementAt(i);
            string str = node.Name;
            sEventMessage += (str + ": " + paramArray[str] + "\n");
        }

        //gOnDeviceEventGenICam(sDevicePAddress, sEventMessage);
    }
    #endregion

    #region FileAccess
    public bool ImportDeviceParameters(string IpAddress, string sFilePath)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        KglResult result = camera.kglDevice.importDeviceParameters(sFilePath);
        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }
        return true;
    }

    public bool ExportDeviceParameters(string IpAddress, string sFilePath)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        KglResult result = camera.kglDevice.exportDeviceParameters(sFilePath);
        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }
        return true;
    }

    public bool ImportFile(string IpAddress, string sFilePath)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        KglResult result;
        string sExtention;
        sExtention = System.IO.Path.GetExtension(sFilePath).ToLower();
        if ((sExtention == ".bmp") || (sExtention == ".jpg"))
        {
            result = camera.kglDevice.importFile(KglDeviceFileType.ModelImage, System.IO.Path.GetFileName(sFilePath), sFilePath, KglOverwriteOption.Overwrite);
        }
        else if (sExtention == ".dat")
        {
            result = camera.kglDevice.importFile(KglDeviceFileType.Calibration, System.IO.Path.GetFileName(sFilePath), sFilePath, KglOverwriteOption.Overwrite);
        }
        else
        {
            return false;
        }

        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }
        return true;
    }

    public bool ExportFile(string IpAddress, string sFolderPath, string sFileName)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        KglResult result;
        string sExtention;
        sExtention = System.IO.Path.GetExtension(sFileName).ToLower();
        if ((sExtention == ".bmp") || (sExtention == ".jpg"))
        {
            result = camera.kglDevice.exportFile(KglDeviceFileType.ModelImage, sFileName, (sFolderPath + "\\" + sFileName), KglOverwriteOption.Overwrite);
        }
        else if (sExtention == ".trdv")
        {
            result = camera.kglDevice.exportFile(KglDeviceFileType.TraceLog, sFileName, (sFolderPath + "\\" + sFileName), KglOverwriteOption.Overwrite);
        }
        else if (sExtention == ".dat")
        {
            result = camera.kglDevice.exportFile(KglDeviceFileType.Calibration, sFileName, (sFolderPath + "\\" + sFileName), KglOverwriteOption.Overwrite);
        }
        else
        {
            return false;
        }

        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }
        return true;
    }
    #endregion

    #region FeatureAccess
    public void SetFeatureValue(string IpAddress, string sFeatureName, object oFeatureValue)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return;
        }

        KglGenParameterArray parameters = camera.kglDevice.DeviceParameters;
        if (parameters == null)
        {
            return;
        }

        parameters[sFeatureName] = oFeatureValue;
    }

    public void SetFeatureValue(string IpAddress, string sFeatureName, object oFeatureValue, ref string sConfigurationLastFailureCause)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return;
        }

        KglGenParameterArray parameters = camera.kglDevice.DeviceParameters;
        if (parameters == null)
        {
            return;
        }

        try
        {
            if (parameters.getFeatureType(sFeatureName) == KglFeatureType.KGL_TYPE_REGISTER)
            {
                string sRegString = (string)oFeatureValue;
                Match matche = Regex.Match(sRegString, "[^a-fA-F0-9]");
                if (matche != Match.Empty)
                {
                    throw new Exception();
                }
                if ((sRegString.Count() % 2) == 1)
                {
                    throw new Exception();
                }
                int cnt = sRegString.Count() / 2;
                byte[] oArray = new byte[cnt];
                List<byte> oList = new List<byte>();
                for (int i = 0; i < cnt; i++)
                {
                    string sub = sRegString.ToString().Substring(i * 2, 2);
                    oArray[i] = (byte)Convert.ToInt32(sub, 16);
                }
                oList.AddRange(oArray);

                parameters[sFeatureName] = oList;
            }
            else
            {
                parameters[sFeatureName] = oFeatureValue;
            }
        }
        catch (KglResultException ex)
        {
            string sResult = ex.result.ToString();
            if (ex.result == KglResult.KGL_GENERIC_ERROR)
            {
                string sCause = GetFeatureValue(IpAddress, "ConfigurationLastFailureCause").ToString();
                sConfigurationLastFailureCause = sResult + ": " + "ConfigurationLastFailureCause : " + sCause;
            }
            else
            {
                sConfigurationLastFailureCause = sResult;
            }
            throw;
        }
    }

    public object GetFeatureValue(string IpAddress, string sFeatureName)
    {
        object oFeatureValue;

        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return "";
        }

        KglGenParameterArray parameters = camera.kglDevice.DeviceParameters;
        if (parameters == null)
        {
            return "";
        }

        oFeatureValue = parameters[sFeatureName];

        return (oFeatureValue);
    }

    public object GetFeatureValue(string IpAddress, string sFeatureName, ref string sConfigurationLastFailureCause)
    {
        object oFeatureValue;

        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return "";
        }

        KglGenParameterArray parameters = camera.kglDevice.DeviceParameters;
        if (parameters == null)
        {
            return "";
        }

        try
        {
            if (parameters.getFeatureType(sFeatureName) == KglFeatureType.KGL_TYPE_REGISTER)
            {
                string sRegString = "";
                IList<byte> oList = (IList<byte>)parameters[sFeatureName];
                foreach (object obj in oList)
                {
                    sRegString = sRegString + string.Format("{0, 2:X2}", obj);
                }
                oFeatureValue = sRegString;
            }
            else
            {
                oFeatureValue = parameters[sFeatureName];
            }
        }
        catch (KglResultException ex)
        {
            string sResult = ex.result.ToString();
            sConfigurationLastFailureCause = sResult;
            throw;
        }

        return (oFeatureValue);
    }
    #endregion

    #region AcquisitionControl
    public void BufferCaptureAcquisitionStart(string IpAddress)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return;
        }

        SetFeatureValue(IpAddress, "BufferCaptureAcquisitionStart", true);
    }

    public void BufferCaptureAcquisitionStop(string IpAddress)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return;
        }

        SetFeatureValue(IpAddress, "BufferCaptureAcquisitionStop", true);
    }

    public void QueueBuffer(string IpAddress, IntPtr bmpBuff, string sBufferMode)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);

        uint bufferCount = camera.kglStream.getQueuedBufferCount();

        if (bufferCount == 0)
        {
            camera.kglBuffer = new KglBuffer();

            uint payloadSize = camera.kglDevice.getPayloadSize();

            if (sBufferMode == "Attach")
            {
                camera.kglBuffer.attach(bmpBuff, payloadSize);
            }
            else
            {
                camera.kglBuffer.allocate(payloadSize);
            }

            try
            {
                camera.kglStream.queueBuffer(camera.kglBuffer);
            }
            catch (KglResultException ex)
            {
                if (ex.result != KglResult.KGL_PENDING)
                {
                    throw;
                }
            }
        }
    }

    public void FreeBuffer(string IpAddress, string sBufferMode)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);

        if (sBufferMode == "Attach")
        {
            camera.kglBuffer.detach();
        }
        else
        {
            camera.kglBuffer.free();
        }
    }

    public bool AcquisitionStart(string IpAddress)
    {
        KglResult result;

        CameraInfo camera = GetCameraInfo(IpAddress);

        result = camera.kglStream.startAcquisition(camera.kglDevice);
        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }

        return true;
    }

    public bool AcquisitionStop(string IpAddress)
    {
        KglResult result;

        CameraInfo camera = GetCameraInfo(IpAddress);

        result = camera.kglStream.stopAcquisition(camera.kglDevice);
        if (result != KglResult.KGL_SUCCESS)
        {
            return false;
        }

        return true;
    }

    public bool RetrieveBuffer(string IpAddress, IntPtr bmpBuff, string sBufferMode, EnumAcquisitionMode eMode)
    {
        KglBuffer Buffer;
        KglResult result;
        KglResult operationResult;

        CameraInfo camera = GetCameraInfo(IpAddress);

        result = camera.kglStream.retrieveBuffer(out Buffer, out operationResult, 10000);
        if ((KglResult.KGL_SUCCESS != result) || (KglResult.KGL_SUCCESS != operationResult))
        {
            FreeBuffer(IpAddress, sBufferMode);
            return false;
        }

        if (sBufferMode != "Attach")
        {
            uint bmpSize = camera.kglBuffer.getAcquiredSize();

            CopyMemory(bmpBuff, camera.kglBuffer.getDataPointer(), bmpSize);
        }

        if (eMode == EnumAcquisitionMode.Continuous)
        {
            try
            {
                camera.kglStream.queueBuffer(camera.kglBuffer);
            }
            catch (KglResultException ex)
            {
                if (ex.result != KglResult.KGL_PENDING)
                {
                    return false;
                }
            }
        }
        else
        {
            FreeBuffer(IpAddress, sBufferMode);
        }

        return true;
    }

    public bool TriggerSoftware(string IpAddress)
    {
        CameraInfo camera = GetCameraInfo(IpAddress);
        if (camera == null)
        {
            return false;
        }

        try
        {
            SetFeatureValue(IpAddress, "TriggerSoftware", true);
        }
        catch (KglResultException)
        {
            string sCause = GetFeatureValue(IpAddress, "ConfigurationLastFailureCause").ToString();
            return false;
        }

        return true;
    }
    #endregion
}
