/*
 * @file CameraItems.cs
 *
 * Copyright (c) 2019 KEYENCE CORPORATION.
 * All rights reserved.
 *
 */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

public class EnumConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string parameterString = parameter as string;
        if (null == parameterString)
        {
            return DependencyProperty.UnsetValue;
        }

        if (!Enum.IsDefined(value.GetType(), value))
        {
            return DependencyProperty.UnsetValue;
        }

        object parameterValue = Enum.Parse(value.GetType(), parameterString);
        return parameterValue.Equals(value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string parameterString = parameter as string;
        if (null == parameterString)
        {
            return DependencyProperty.UnsetValue;
        }

        if (true.Equals(value))
        {
            return Enum.Parse(targetType, parameterString);
        }
        else
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

public enum EnumAcquisitionMode
{
    SingleFrame,
    Continuous
};

public enum EnumBGAcquisitionMode
{
    Off,
    On
};

public enum EnumTiggerMode
{
    Off,
    OnSoftware,
    OnLine
};

public enum EnumCaptureMode
{
    Fixed,
    Fixed_MultipleImages,
    Continuous
};

public class CameraItems : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        field = value;
        PropertyChangedEventHandler h = PropertyChanged;
        if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
    }

    public string IPAddress { get; set; }

    public string ModelName { get; set; }

    public string Header { get { return string.Format("[{0}] {1}", IPAddress, ModelName); } }

    private Int32 _DeviceManifestXMLMajorVersion = 0;
    public Int32 DeviceManifestXMLMajorVersion
    {
        get { return _DeviceManifestXMLMajorVersion; }

        set { SetProperty(ref _DeviceManifestXMLMajorVersion, value); }
    }

    private bool _V2Supported = false;
    public bool V2Supported
    {
        get { return _V2Supported; }

        set { SetProperty(ref _V2Supported, value); }
    }

    private int _TabCaptureIndex = 0;
    public int TabCaptureIndex
    {
        get { return _TabCaptureIndex; }

        set { SetProperty(ref _TabCaptureIndex, value); }
    }

    private string _CaptureName1 = "";
    public string CaptureName1
    {
        get { return _CaptureName1; }

        set { SetProperty(ref _CaptureName1, value); }
    }

    private string _CaptureName2 = "";
    public string CaptureName2
    {
        get { return _CaptureName2; }

        set { SetProperty(ref _CaptureName2, value); }
    }

    private string _CaptureName3 = "";
    public string CaptureName3
    {
        get { return _CaptureName3; }

        set { SetProperty(ref _CaptureName3, value); }
    }

    private string _CaptureName4 = "";
    public string CaptureName4
    {
        get { return _CaptureName4; }

        set { SetProperty(ref _CaptureName4, value); }
    }

    private string _CaptureName5 = "";
    public string CaptureName5
    {
        get { return _CaptureName5; }

        set { SetProperty(ref _CaptureName5, value); }
    }

    private string _CaptureName6 = "";
    public string CaptureName6
    {
        get { return _CaptureName6; }

        set { SetProperty(ref _CaptureName6, value); }
    }

    private string _CaptureName7 = "";
    public string CaptureName7
    {
        get { return _CaptureName7; }

        set { SetProperty(ref _CaptureName7, value); }
    }

    private string _CaptureName8 = "";
    public string CaptureName8
    {
        get { return _CaptureName8; }

        set { SetProperty(ref _CaptureName8, value); }
    }

    private string _CaptureName9 = "";
    public string CaptureName9
    {
        get { return _CaptureName9; }

        set { SetProperty(ref _CaptureName9, value); }
    }

    private string _CaptureName10 = "";
    public string CaptureName10
    {
        get { return _CaptureName10; }

        set { SetProperty(ref _CaptureName10, value); }
    }

    private bool _CaptureVisible1 = false;
    public bool CaptureVisible1
    {
        get { return _CaptureVisible1; }

        set { SetProperty(ref _CaptureVisible1, value); }
    }

    private bool _CaptureVisible2 = false;
    public bool CaptureVisible2
    {
        get { return _CaptureVisible2; }

        set { SetProperty(ref _CaptureVisible2, value); }
    }

    private bool _CaptureVisible3 = false;
    public bool CaptureVisible3
    {
        get { return _CaptureVisible3; }

        set { SetProperty(ref _CaptureVisible3, value); }
    }

    private bool _CaptureVisible4 = false;
    public bool CaptureVisible4
    {
        get { return _CaptureVisible4; }

        set { SetProperty(ref _CaptureVisible4, value); }
    }

    private bool _CaptureVisible5 = false;
    public bool CaptureVisible5
    {
        get { return _CaptureVisible5; }

        set { SetProperty(ref _CaptureVisible5, value); }
    }

    private bool _CaptureVisible6 = false;
    public bool CaptureVisible6
    {
        get { return _CaptureVisible6; }

        set { SetProperty(ref _CaptureVisible6, value); }
    }

    private bool _CaptureVisible7 = false;
    public bool CaptureVisible7
    {
        get { return _CaptureVisible7; }

        set { SetProperty(ref _CaptureVisible7, value); }
    }

    private bool _CaptureVisible8 = false;
    public bool CaptureVisible8
    {
        get { return _CaptureVisible8; }

        set { SetProperty(ref _CaptureVisible8, value); }
    }

    private bool _CaptureVisible9 = false;
    public bool CaptureVisible9
    {
        get { return _CaptureVisible9; }

        set { SetProperty(ref _CaptureVisible9, value); }
    }

    private bool _CaptureVisible10 = false;
    public bool CaptureVisible10
    {
        get { return _CaptureVisible10; }

        set { SetProperty(ref _CaptureVisible10, value); }
    }

    private ImageSource _Image1 = null;
    public ImageSource Image1
    {
        get { return _Image1; }

        set { SetProperty(ref _Image1, value); }
    }

    private ImageSource _Image2 = null;
    public ImageSource Image2
    {
        get { return _Image2; }

        set { SetProperty(ref _Image2, value); }
    }

    private ImageSource _Image3 = null;
    public ImageSource Image3
    {
        get { return _Image3; }

        set { SetProperty(ref _Image3, value); }
    }

    private ImageSource _Image4 = null;
    public ImageSource Image4
    {
        get { return _Image4; }

        set { SetProperty(ref _Image4, value); }
    }

    private ImageSource _Image5 = null;
    public ImageSource Image5
    {
        get { return _Image5; }

        set { SetProperty(ref _Image5, value); }
    }

    private ImageSource _Image6 = null;
    public ImageSource Image6
    {
        get { return _Image6; }

        set { SetProperty(ref _Image6, value); }
    }

    private ImageSource _Image7 = null;
    public ImageSource Image7
    {
        get { return _Image7; }

        set { SetProperty(ref _Image7, value); }
    }

    private ImageSource _Image8 = null;
    public ImageSource Image8
    {
        get { return _Image8; }

        set { SetProperty(ref _Image8, value); }
    }

    private ImageSource _Image9 = null;
    public ImageSource Image9
    {
        get { return _Image9; }

        set { SetProperty(ref _Image9, value); }
    }

    private ImageSource _Image10 = null;
    public ImageSource Image10
    {
        get { return _Image10; }

        set { SetProperty(ref _Image10, value); }
    }

    private string _FeaturName = "";
    public string FeaturName
    {
        get { return _FeaturName; }

        set
        {
            if (Regex.IsMatch(value, @"[^\x01-\x7f]"))
            {
                MessageBox.Show("Only ASCII code can be entered.");
                _FeaturName = "";
            }
            else
            {
                SetProperty(ref _FeaturName, value);
            }
        }
    }

    private string _FeaturValue = "";
    public string FeaturValue
    {
        get { return _FeaturValue; }

        set
        {
            if (Regex.IsMatch(value, @"[^\x01-\x7f]"))
            {
                MessageBox.Show("Only ASCII code can be entered.");
                _FeaturValue = "";
            }
            else
            {
                SetProperty(ref _FeaturValue, value);
            }
        }
    }

    private string _ConfigurationLastFailureCause = "";
    public string ConfigurationLastFailureCause
    {
        get { return _ConfigurationLastFailureCause; }

        set { SetProperty(ref _ConfigurationLastFailureCause, value); }
    }

    private string _ImportDeviceParametersFilePath = "";
    public string ImportDeviceParametersFilePath
    {
        get { return _ImportDeviceParametersFilePath; }

        set { SetProperty(ref _ImportDeviceParametersFilePath, value); }
    }

    private string _ExportDeviceParametersFolderPath = "";
    public string ExportDeviceParametersFolderPath
    {
        get { return _ExportDeviceParametersFolderPath; }

        set { SetProperty(ref _ExportDeviceParametersFolderPath, value); }
    }

    private string _ImportFilePath = "";
    public string ImportFilePath
    {
        get { return _ImportFilePath; }

        set { SetProperty(ref _ImportFilePath, value); }
    }

    private string _ExportFolderPath = "";
    public string ExportFolderPath
    {
        get { return _ExportFolderPath; }

        set { SetProperty(ref _ExportFolderPath, value); }
    }

    private string _ExportFilePath = "";
    public string ExportFilePath
    {
        get { return _ExportFilePath; }

        set { SetProperty(ref _ExportFilePath, value); }
    }

    private EnumAcquisitionMode _AcquisitionMode;
    public EnumAcquisitionMode AcquisitionMode
    {
        get { return _AcquisitionMode; }

        set { SetProperty(ref _AcquisitionMode, value); }
    }

    private EnumBGAcquisitionMode _BGAcquisitionMode;
    public EnumBGAcquisitionMode BGAcquisitionMode
    {
        get { return _BGAcquisitionMode; }

        set { SetProperty(ref _BGAcquisitionMode, value); }
    }

    private EnumTiggerMode _TriggerMode;
    public EnumTiggerMode TriggerMode
    {
        get { return _TriggerMode; }

        set { SetProperty(ref _TriggerMode, value); }
    }

    private EnumCaptureMode _CaptureMode;
    public EnumCaptureMode CaptureMode
    {
        get { return _CaptureMode; }

        set { SetProperty(ref _CaptureMode, value); }
    }

    private string _BGAcquisitionControlButtonContent = "BufferCaptureAcquisitionStart";
    public string BGAcquisitionControlButtonContent
    {
        get { return _BGAcquisitionControlButtonContent; }

        set { SetProperty(ref _BGAcquisitionControlButtonContent, value); }
    }

    private bool _BGAcquisitionControlButtonIsChecked = false;
    public bool BGAcquisitionControlButtonIsChecked
    {
        get { return _BGAcquisitionControlButtonIsChecked; }

        set { SetProperty(ref _BGAcquisitionControlButtonIsChecked, value); }
    }

    private string _AcquisitionControlButtonContent = "AcquisitionStart";
    public string AcquisitionControlButtonContent
    {
        get { return _AcquisitionControlButtonContent; }

        set { SetProperty(ref _AcquisitionControlButtonContent, value); }
    }

    private bool _AcquisitionControlButtonIsChecked = false;
    public bool AcquisitionControlButtonIsChecked
    {
        get { return _AcquisitionControlButtonIsChecked; }

        set { SetProperty(ref _AcquisitionControlButtonIsChecked, value); }
    }

    public bool _AcquisitionLoopIsChecked = false;
    public bool AcquisitionLoopIsChecked
    {
        get { return _AcquisitionLoopIsChecked; }

        set { SetProperty(ref _AcquisitionLoopIsChecked, value); }
    }

    private bool _SoftTriggerEnable = false;
    public bool SoftTriggerEnable
    {
        get { return _SoftTriggerEnable; }

        set { SetProperty(ref _SoftTriggerEnable, value); }
    }

    private bool _ResultsEnable = false;
    public bool ResultsEnable
    {
        get { return _ResultsEnable; }

        set { SetProperty(ref _ResultsEnable, value); }
    }

    private bool _BGAcqEnable = false;
    public bool BGAcqEnable
    {
        get { return _BGAcqEnable; }

        set { SetProperty(ref _BGAcqEnable, value); }
    }

    private bool _SettingsEnable = true;
    public bool SettingsEnable
    {
        get { return _SettingsEnable; }

        set { SetProperty(ref _SettingsEnable, value); }
    }

    private string _EventMessage = "";
    public string EventMessage
    {
        get { return _EventMessage; }

        set { SetProperty(ref _EventMessage, value); }
    }

    public bool IsHLMXCamera
    {
        get
        {
            if (string.Equals(ModelName, "CA-HL02MX") ||
                string.Equals(ModelName, "CA-HL04MX") ||
                string.Equals(ModelName, "CA-HL08MX"))
            {
                return true;
            }
            return false;
        }
    }

    public bool IsXTCamera
    {
        get
        {
            if (string.Equals(ModelName, "XT-024") ||
                string.Equals(ModelName, "XT-060"))
            {
                return true;
            }
            return false;
        }
    }

    public bool IsRBCamera
    {
        get
        {
            if (string.Equals(ModelName, "RB-500") ||
                string.Equals(ModelName, "RB-800") ||
                string.Equals(ModelName, "RB-1200"))
            {
                return true;
            }
            return false;
        }
    }

    public void ClearCaptureImage()
    {
        CaptureName1 = "";
        CaptureName2 = "";
        CaptureName3 = "";
        CaptureName4 = "";
        CaptureName5 = "";
        CaptureName6 = "";
        CaptureName7 = "";
        CaptureName8 = "";
        CaptureName9 = "";
        CaptureName10 = "";
        CaptureVisible1 = false;
        CaptureVisible2 = false;
        CaptureVisible3 = false;
        CaptureVisible4 = false;
        CaptureVisible5 = false;
        CaptureVisible6 = false;
        CaptureVisible7 = false;
        CaptureVisible8 = false;
        CaptureVisible9 = false;
        CaptureVisible10 = false;
        Image1 = null;
        Image2 = null;
        Image3 = null;
        Image4 = null;
        Image5 = null;
        Image6 = null;
        Image7 = null;
        Image8 = null;
        Image9 = null;
        Image10 = null;
    }
}
