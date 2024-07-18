using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using static GlovalVar;
using QWhale.Editor.Dialogs;
using System.Reflection.Emit;
using System.Windows.Forms;
using VisionSystem;
using DevExpress.Utils.MVVM;
using DevExpress.XtraGauges.Core.Customization;
using System.Security.Policy;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraReports.Design;
using DevExpress.XtraCharts.Native;
using System.Drawing;
using DevExpress.Data.Mask;
using DevExpress.XtraRichEdit.Mouse;

using System.Net.NetworkInformation;
using System.Net;
using DevExpress.XtraCharts.Designer.Native;
//using com.wibu.xpm.AxpNet;

public class SQL
{
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }

    public bool DBConnect(ref SqlConnection Conn, DBInfo dbInfo)
    {
        bool bConnect = false;

        try
        {
            string strConn = string.Format("Server={0};Database={1};User Id={2};Password={3}", dbInfo.strIP, dbInfo.strDBName, dbInfo.strID, dbInfo.strPW);
            Conn = new SqlConnection(strConn);

            Conn.Open();

            if (Conn.State == ConnectionState.Open)
                bConnect = true;

        }
        catch { return false; }

        return bConnect;
    }

    public void GetPGMInfo(string strProcessName, DBInfo dbInfo, ref int nSceenCnt)
    {
        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from PGMINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow data = ds.Tables[0].Rows[0];
                                int.TryParse(data["SCREENCNT"].ToString(), out nSceenCnt);
                                
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SavePGMInfo(string strProcessName, DBInfo dbInfo, int nSceenCnt)
    {
        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from PGMINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update PGMINFO Set [SCREENCNT] = @SCREENCNT where [PROCESSNAME] = @PROCESSNAME";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@SCREENCNT", nSceenCnt);                                
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO PGMINFO ([PROCESSNAME], [SCREENCNT]) VALUES (@PROCESSNAME, @SCREENCNT)";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                                CMD.Parameters.AddWithValue("@SCREENCNT", nSceenCnt);
                                
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveLineInfo(string strLineInfo, string strProcessName, DBInfo dbInfo)
    {
        if (string.IsNullOrEmpty(strProcessName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LINEINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@LINEINFO", strLineInfo);
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update LINEINFO Set [LINEINFO] = @LINEINFO";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@LINEINFO", strLineInfo);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO LINEINFO ([LINEINFO], [PROCESSNAME]) VALUES (@LINEINFO, @PROCESSNAME)";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@LINEINFO", strLineInfo);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetLineInfo(string strProcName, DBInfo dbInfo, ref string strLineInfo)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        strLineInfo = "";

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LINEINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                                strLineInfo = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }


    public void SaveDBInfo(string strProcessName, DBInfo dbInfo)
    {
        if (string.IsNullOrEmpty(strProcessName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from DBINFOPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update DBINFOPARAM Set [IP] = @IP, [PORT] = @PORT, [ID] = @ID, [PW] = @PW, [DBNAME] = @DBNAME where [PROCESSNAME] = @PROCESSNAME";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@IP", dbInfo.strIP);
                                CMD.Parameters.AddWithValue("@PORT", dbInfo.nPort);
                                CMD.Parameters.AddWithValue("@ID", dbInfo.strID);
                                CMD.Parameters.AddWithValue("@PW", dbInfo.strPW);
                                CMD.Parameters.AddWithValue("@DBNAME", dbInfo.strDBName);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO DBINFOPARAM ([PROCESSNAME], [IP], [PORT], [ID], [PW], [DBNAME]) VALUES (@PROCESSNAME, @ID, @PORT, @ID, @PW, @DBNAME)";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                                CMD.Parameters.AddWithValue("@IP", dbInfo.strIP);
                                CMD.Parameters.AddWithValue("@PORT", dbInfo.nPort);
                                CMD.Parameters.AddWithValue("@ID", dbInfo.strID);
                                CMD.Parameters.AddWithValue("@PW", dbInfo.strPW);
                                CMD.Parameters.AddWithValue("@DBNAME", dbInfo.strDBName);
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetDBInfo(string strProcName, ref DBInfo dbInfo)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from DBINFOPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dbInfo.strIP = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[3].ToString(), out dbInfo.nPort);
                                dbInfo.strID = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                                dbInfo.strPW = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                                dbInfo.strDBName = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();

    }

    public void GetIMGParam(string strProcessName, DBInfo dbInfo, ref SaveImageParam saveImgParam)
    {
        if (string.IsNullOrEmpty(strProcessName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from SAVEIMGPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                saveImgParam._strSaveImagePath = ds.Tables[0].Rows[0].ItemArray[2].ToString();

                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[3].ToString(), out saveImgParam._bOriginImageSave);

                                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0].ItemArray[4].ToString()))
                                    saveImgParam._OriginImageFormat = IMGFormat.bmp;
                                else
                                    saveImgParam._OriginImageFormat = (IMGFormat)Enum.Parse(typeof(IMGFormat), ds.Tables[0].Rows[0].ItemArray[4].ToString());

                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[5].ToString(), out saveImgParam._nOriginImgCompRate);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[6].ToString(), out saveImgParam._bResultImageSave);

                                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0].ItemArray[7].ToString()))
                                    saveImgParam._ResultImageFormat = IMGFormat.bmp;
                                else
                                    saveImgParam._ResultImageFormat = (IMGFormat)Enum.Parse(typeof(IMGFormat), ds.Tables[0].Rows[0].ItemArray[7].ToString());

                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[8].ToString(), out saveImgParam._nResultImgCompRate);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[9].ToString(), out saveImgParam._bAutoImageDelete);
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[10].ToString(), out saveImgParam._nDiskDelete);
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveIMGParam(string strProcessName, DBInfo dbInfo, SaveImageParam saveImgParam)
    {
        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from SAVEIMGPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update SAVEIMGPARAM Set [IMGPATH] = @IMGPATH, [ORIGINIMGSAVE] = @ORIGINIMGSAVE, " +
                                    "[ORIGINIMGFORMAT] = @ORIGINIMGFORMAT, [ORIGINIMGCOMPRESSION] = @ORIGINIMGCOMPRESSION, [RESULTIMGSAVE] = @RESULTIMGSAVE, [RESULTIMGFORMAT] = @RESULTIMGFORMAT," +
                                    "[RESULTIMGCOMPRESSION] = @RESULTIMGCOMPRESSION, [AUTODELETE] = @AUTODELETE, [IMGDELETELIMIT] = @IMGDELETELIMIT" +
                                    " where [PROCESSNAME] = @PROCESSNAME";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@IMGPATH", saveImgParam._strSaveImagePath);
                                CMD.Parameters.AddWithValue("@ORIGINIMGSAVE", saveImgParam._bOriginImageSave.ToString());
                                CMD.Parameters.AddWithValue("@ORIGINIMGFORMAT", saveImgParam._OriginImageFormat.ToString());
                                CMD.Parameters.AddWithValue("@ORIGINIMGCOMPRESSION", saveImgParam._nOriginImgCompRate);
                                CMD.Parameters.AddWithValue("@RESULTIMGSAVE", saveImgParam._bResultImageSave.ToString());
                                CMD.Parameters.AddWithValue("@RESULTIMGFORMAT", saveImgParam._ResultImageFormat.ToString());
                                CMD.Parameters.AddWithValue("@RESULTIMGCOMPRESSION", saveImgParam._nResultImgCompRate.ToString());
                                CMD.Parameters.AddWithValue("@AUTODELETE", saveImgParam._bAutoImageDelete.ToString());
                                CMD.Parameters.AddWithValue("@IMGDELETELIMIT", saveImgParam._nDiskDelete.ToString());
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO SAVEIMGPARAM ([PROCESSNAME], [IMGPATH], [ORIGINIMGSAVE], [ORIGINIMGFORMAT], [ORIGINIMGCOMPRESSION], " +
                                    "[RESULTIMGSAVE], [RESULTIMGFORMAT], [RESULTIMGCOMPRESSION], [AUTODELETE], [IMGDELETELIMIT]) VALUES " +
                                    "(@PROCESSNAME, @IMGPATH, @ORIGINIMGSAVE, @ORIGINIMGFORMAT, @ORIGINIMGCOMPRESSION, @RESULTIMGSAVE, " +
                                    "@RESULTIMGFORMAT, @RESULTIMGCOMPRESSION, @AUTODELETE, @IMGDELETELIMIT)";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                                CMD.Parameters.AddWithValue("@IMGPATH", saveImgParam._strSaveImagePath);
                                CMD.Parameters.AddWithValue("@ORIGINIMGSAVE", saveImgParam._bOriginImageSave.ToString());
                                CMD.Parameters.AddWithValue("@ORIGINIMGFORMAT", saveImgParam._OriginImageFormat.ToString());
                                CMD.Parameters.AddWithValue("@ORIGINIMGCOMPRESSION", saveImgParam._nOriginImgCompRate);
                                CMD.Parameters.AddWithValue("@RESULTIMGSAVE", saveImgParam._bResultImageSave.ToString());
                                CMD.Parameters.AddWithValue("@RESULTIMGFORMAT", saveImgParam._ResultImageFormat.ToString());
                                CMD.Parameters.AddWithValue("@RESULTIMGCOMPRESSION", saveImgParam._nResultImgCompRate.ToString());
                                CMD.Parameters.AddWithValue("@AUTODELETE", saveImgParam._bAutoImageDelete.ToString());
                                CMD.Parameters.AddWithValue("@IMGDELETELIMIT", saveImgParam._nDiskDelete.ToString());

                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetModelInfo(string strProcess, DBInfo dbInfo, ref string strModelList, ref int nModelNo, ref string strLotNo)
    {
        if (string.IsNullOrEmpty(strProcess))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from MODELINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strModelList = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[3].ToString(), out nModelNo);
                                strLotNo = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveModelInfo(string strProcess, DBInfo dbInfo, string strModelList, int nModelNo, string strLotNo)
    {
        if (string.IsNullOrEmpty(strProcess))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from MODELINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update MODELINFO Set [MODELLIST] = @MODELLIST, [LASTMODELNO] = @LASTMODELNO, [LASTLOTNO] = @LASTLOTNO where [PROCESSNAME] = @PROCESSNAME";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@MODELLIST", strModelList);
                                CMD.Parameters.AddWithValue("@LASTMODELNO", nModelNo);
                                CMD.Parameters.AddWithValue("@LASTLOTNO", strLotNo);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO MODELINFO ([PROCESSNAME], [MODELLIST], [LASTMODELNO], [LASTLOTNO]) Values " +
                                    "(@PROCESSNAME, @MODELLIST, @LASTMODELNO, @LASTLOTNO)";

                                CMD.Parameters.Clear();
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);
                                CMD.Parameters.AddWithValue("@MODELLIST", strModelList);
                                CMD.Parameters.AddWithValue("@LASTMODELNO", nModelNo);
                                CMD.Parameters.AddWithValue("@LASTLOTNO", strLotNo);
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetCamInfo(string strProcName, int nCamNo, DBInfo dbInfo, ref CamPram camParam)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONCAMINFO where [PROCESSNAME] = @PROCESSNAME and [CAMNO] = @CAMNO ", Conn))
                {
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                camParam.strVender = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                camParam.strCamNo = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                                camParam.strModel = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                                camParam.strResolution = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                                camParam.strSerial = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                                camParam.camInterface = ds.Tables[0].Rows[0].ItemArray[9].ToString() == "" ? CameraInterface.NONE : (CameraInterface)Enum.Parse(typeof(CameraInterface), ds.Tables[0].Rows[0].ItemArray[9].ToString());
                                camParam.strCopy = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                                camParam.strIP = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[12].ToString(), out camParam.dExpose);
                                camParam.strCamType = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                                camParam.strCamFormat = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                                camParam.strPixelFormats = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch
        {
        }

        Conn.Dispose();
    }

    public void SavePLCInfo(string strProcess, DBInfo dbInfo, PLCPram plcParam)
    {
        if (string.IsNullOrEmpty(strProcess))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from PLCINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update PLCINFO Set [PLCTYPE] = @PLCTYPE, [IP] = @IP, [PORT] = @PORT, [RACKNO] = @RACKNO, [SLOTNO] = @SLOTNO," +
                                    "[HEARTBEAT] = @HEARTBEAT, [HEARTTIME] = @HEARTTIME, [TRIGGERSIGNAL] = @TRIGGERSIGNAL, [OKSIGNAL] = @OKSIGNAL, " +
                                    "[NGSIGNAL] = @NGSIGNAL, [SIGNALFORMAT] = @SIGNALFORMAT, [READTIME] = @READTIME, [READADDR] = @READADDR, [READADDRDEV] = @READADDRDEV, [READCNT] = @READCNT, " +
                                    "[READFORMAT] = @READFORMAT, [READTRIGGERADDR] = @READTRIGGERADDR, [READTRIGGERCNTADDR] = @READTRIGGERCNTADDR, [READMODELADDR] = @READMODELADDR, [READMODELCNTADDR] = @READMODELCNTADDR, [READLOTNOADDR] = @READLOTNOADDR, [READNOTNOCNTADDR] = @READNOTNOCNTADDR, " +
                                    "[WRITESTARTADDR] = @WRITESTARTADDR, [WRITEDEVICE] = @WRITEDEVICE, [WRITEGRABCOMPLETEADDR] = @WRITEGRABCOMPLETEADDR, [WRITEMODELADDR] = @WRITEMODELADDR, [WRITELOTADDR] = @WRITELOTADDR," +
                                    "[WRITEPOINTRESADDR] = @WRITEPOINTRESADDR, [WRITETOTALRESADDR] = @WRITETOTALRESADDR, [WRITEBCRDATAADDR] = @WRITEBCRDATAADDR, [WRITEALIGNXADDR] = @WRITEALIGNXADDR, [WRITEALIGNYADDR] = @WRITEALIGNYADDR," +
                                    "[WRITEALIGNRADDR] = @WRITEALIGNRADDR, [WRITEWIDTHADDR] = @WRITEWIDTHADDR, [WRITEHEIGHTADDR] = @WRITEHEIGHTADDR, [WRITEPINCHANGEADDR] = @WRITEPINCHANGEADDR, [STATUS] = @STATUS," +
                                    "where [PROCESSNAME] = @PROCESSNAME";


                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PLCTYPE", plcParam.plcType.ToString());
                                CMD.Parameters.AddWithValue("@IP", plcParam.strPLCIP);
                                CMD.Parameters.AddWithValue("@PORT", plcParam.strPLCPort);
                                CMD.Parameters.AddWithValue("@RACKNO", (int)plcParam.shRack);
                                CMD.Parameters.AddWithValue("@SLOTNO", (int)plcParam.shSlot);
                                CMD.Parameters.AddWithValue("@HEARTBEAT", plcParam.strWriteHeartbeat);
                                CMD.Parameters.AddWithValue("@HEARTTIME", plcParam.strWriteHeartbeatInterval);
                                CMD.Parameters.AddWithValue("@TRIGGERSIGNAL", plcParam.strTriggerSignal);
                                CMD.Parameters.AddWithValue("@OKSIGNAL", plcParam.strOKSignal);
                                CMD.Parameters.AddWithValue("@NGSIGNAL", plcParam.strNGSignal);
                                CMD.Parameters.AddWithValue("@SIGNALFORMAT", plcParam.SignalFormat.ToString());
                                CMD.Parameters.AddWithValue("@READTIME", plcParam.strReadInterval);
                                CMD.Parameters.AddWithValue("@READADDR", plcParam.strRead);
                                CMD.Parameters.AddWithValue("@READADDRDEV", plcParam.strReadDev);
                                CMD.Parameters.AddWithValue("@READCNT", plcParam.strReadCnt);
                                CMD.Parameters.AddWithValue("@READFORMAT", plcParam.ReadFormat.ToString());
                                CMD.Parameters.AddWithValue("@READTRIGGERADDR", plcParam.strReadTrigger);
                                CMD.Parameters.AddWithValue("@READTRIGGERCNTADDR", plcParam.strReadTriggerCnt);
                                CMD.Parameters.AddWithValue("@READMODELADDR", plcParam.strReadModel);
                                CMD.Parameters.AddWithValue("@READMODELCNTADDR", plcParam.strReadModelCnt);
                                CMD.Parameters.AddWithValue("@READLOTNOADDR", plcParam.strReadLot);
                                CMD.Parameters.AddWithValue("@READNOTNOCNTADDR", plcParam.strReadLotCnt);
                                CMD.Parameters.AddWithValue("@WRITESTARTADDR", plcParam.strWrite);
                                CMD.Parameters.AddWithValue("@WRITEDEVICE", plcParam.strWriteDev);
                                CMD.Parameters.AddWithValue("@WRITEGRABCOMPLETEADDR", plcParam.strWriteGrabComplete);
                                CMD.Parameters.AddWithValue("@WRITEMODELADDR", plcParam.strWriteModelChange);
                                CMD.Parameters.AddWithValue("@WRITELOTADDR", plcParam.strWriteLotComplete);
                                CMD.Parameters.AddWithValue("@WRITEPOINTRESADDR", plcParam.strWritePointResult);
                                CMD.Parameters.AddWithValue("@WRITETOTALRESADDR", plcParam.strWriteTotalResult);
                                CMD.Parameters.AddWithValue("@WRITEBCRDATAADDR", plcParam.strWrite2DData);
                                CMD.Parameters.AddWithValue("@WRITEALIGNXADDR", plcParam.strWriteAlignX);
                                CMD.Parameters.AddWithValue("@WRITEALIGNYADDR", plcParam.strWriteAlignY);
                                CMD.Parameters.AddWithValue("@WRITEALIGNRADDR", plcParam.strWriteAlignR);
                                CMD.Parameters.AddWithValue("@WRITEWIDTHADDR", plcParam.strWriteWidth);
                                CMD.Parameters.AddWithValue("@WRITEHEIGHTADDR", plcParam.strWriteHeight);
                                CMD.Parameters.AddWithValue("@WRITEPINCHANGEADDR", plcParam.strWritePinChange);
                                CMD.Parameters.AddWithValue("@STATUS", plcParam.bConnect);
                               
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO PLCINFO ([PROCESSNAME], [PLCTYPE], [IP], [PORT], [RACKNO], [SLOTNO]," +
                                    "[HEARTBEAT], [HEARTTIME], [TRIGGERSIGNAL], [OKSIGNAL], [NGSIGNAL], [SIGNALFORMAT], [READTIME], [READADDR], [READADDRDEV], [READCNT], " +
                                    "[READFORMAT], [READTRIGGERADDR], [READTRIGGERCNTADDR], [READMODELADDR], [READMODELCNTADDR], [READLOTNOADDR], [READNOTNOCNTADDR], [WRITESTARTADDR], [WRITEDEVICE], [WRITEGRABCOMPLETEADDR], [WRITEMODELADDR], [WRITELOTADDR]," +
                                    "[WRITEPOINTRESADDR], [WRITETOTALRESADDR], [WRITEBCRDATAADDR], [WRITEALIGNXADDR], [WRITEALIGNYADDR],[WRITEALIGNRADDR], [WRITEWIDTHADDR], [WRITEHEIGHTADDR], [WRITEPINCHANGEADDR], [STATUS])" +
                                    "Values (@PROCESSNAME, @PLCTYPE, @IP, @PORT, @RACKNO, @SLOTNO, @HEARTBEAT, @HEARTTIME, @TRIGGERSIGNAL, @OKSIGNAL, @NGSIGNAL, @SIGNALFORMAT, @READTIME, @READADDR, @READADDRDEV, @READCNT, " +
                                    "@READFORMAT, @READTRIGGERADDR, @READTRIGGERCNTADDR, @READMODELADDR, @READMODELCNTADDR, @READLOTNOADDR, @READNOTNOCNTADDR, @WRITESTARTADDR, @WRITEDEVICE, @WRITEGRABCOMPLETEADDR, @WRITEMODELADDR, @WRITELOTADDR," +
                                    "@WRITEPOINTRESADDR, @WRITETOTALRESADDR, @WRITEBCRDATAADDR, @WRITEALIGNXADDR, @WRITEALIGNYADDR, @WRITEALIGNRADDR, @WRITEWIDTHADDR, @WRITEHEIGHTADDR, @WRITEPINCHANGEADDR, @STATUS)";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);
                                CMD.Parameters.AddWithValue("@PLCTYPE", plcParam.plcType.ToString());
                                CMD.Parameters.AddWithValue("@IP", plcParam.strPLCIP);
                                CMD.Parameters.AddWithValue("@PORT", plcParam.strPLCPort);
                                CMD.Parameters.AddWithValue("@RACKNO", (int)plcParam.shRack);
                                CMD.Parameters.AddWithValue("@SLOTNO", (int)plcParam.shSlot);
                                CMD.Parameters.AddWithValue("@HEARTBEAT", plcParam.strWriteHeartbeat);
                                CMD.Parameters.AddWithValue("@HEARTTIME", plcParam.strWriteHeartbeatInterval);
                                CMD.Parameters.AddWithValue("@TRIGGERSIGNAL", plcParam.strTriggerSignal);
                                CMD.Parameters.AddWithValue("@OKSIGNAL", plcParam.strOKSignal);
                                CMD.Parameters.AddWithValue("@NGSIGNAL", plcParam.strNGSignal);
                                CMD.Parameters.AddWithValue("@SIGNALFORMAT", plcParam.SignalFormat.ToString());
                                CMD.Parameters.AddWithValue("@READTIME", plcParam.strReadInterval);
                                CMD.Parameters.AddWithValue("@READADDR", plcParam.strRead);
                                CMD.Parameters.AddWithValue("@READADDRDEV", plcParam.strReadDev);
                                CMD.Parameters.AddWithValue("@READCNT", plcParam.strReadCnt);
                                CMD.Parameters.AddWithValue("@READFORMAT", plcParam.ReadFormat.ToString());
                                CMD.Parameters.AddWithValue("@READTRIGGERADDR", plcParam.strReadTrigger);
                                CMD.Parameters.AddWithValue("@READTRIGGERCNTADDR", plcParam.strReadTrigger);
                                CMD.Parameters.AddWithValue("@READMODELADDR", plcParam.strReadModel);
                                CMD.Parameters.AddWithValue("@READMODELCNTADDR", plcParam.strReadModelCnt);
                                CMD.Parameters.AddWithValue("@READLOTNOADDR", plcParam.strReadLot);
                                CMD.Parameters.AddWithValue("@READNOTNOCNTADDR", plcParam.strReadLotCnt);
                                CMD.Parameters.AddWithValue("@WRITESTARTADDR", plcParam.strWrite);
                                CMD.Parameters.AddWithValue("@WRITEDEVICE", plcParam.strWriteDev);
                                CMD.Parameters.AddWithValue("@WRITEGRABCOMPLETEADDR", plcParam.strWriteGrabComplete);
                                CMD.Parameters.AddWithValue("@WRITEMODELADDR", plcParam.strWriteModelChange);
                                CMD.Parameters.AddWithValue("@WRITELOTADDR", plcParam.strWriteLotComplete);
                                CMD.Parameters.AddWithValue("@WRITEPOINTRESADDR", plcParam.strWritePointResult);
                                CMD.Parameters.AddWithValue("@WRITETOTALRESADDR", plcParam.strWriteTotalResult);
                                CMD.Parameters.AddWithValue("@WRITEBCRDATAADDR", plcParam.strWrite2DData);
                                CMD.Parameters.AddWithValue("@WRITEALIGNXADDR", plcParam.strWriteAlignX);
                                CMD.Parameters.AddWithValue("@WRITEALIGNYADDR", plcParam.strWriteAlignY);
                                CMD.Parameters.AddWithValue("@WRITEALIGNRADDR", plcParam.strWriteAlignR);
                                CMD.Parameters.AddWithValue("@WRITEWIDTHADDR", plcParam.strWriteWidth);
                                CMD.Parameters.AddWithValue("@WRITEHEIGHTADDR", plcParam.strWriteHeight);
                                CMD.Parameters.AddWithValue("@WRITEPINCHANGEADDR", plcParam.strWritePinChange);
                                CMD.Parameters.AddWithValue("@STATUS", plcParam.bConnect.ToString());
                                

                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetPLCParam(string strProcess, DBInfo dbInfo, ref PLCPram plcParam)
    {
        if (string.IsNullOrEmpty(strProcess))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from PLCINFO where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcess);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                plcParam.plcType = (ds.Tables[0].Rows[0].ItemArray[2].ToString() == "") ? PLCType.MX : (PLCType)Enum.Parse(typeof(PLCType), ds.Tables[0].Rows[0].ItemArray[2].ToString());
                                plcParam.strPLCIP = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                                plcParam.strPLCPort = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                                Int16.TryParse(ds.Tables[0].Rows[0].ItemArray[5].ToString(), out plcParam.shRack);
                                Int16.TryParse(ds.Tables[0].Rows[0].ItemArray[6].ToString(), out plcParam.shSlot);
                                plcParam.strWriteHeartbeat = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                                plcParam.strWriteHeartbeatInterval = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                                plcParam.strTriggerSignal = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                                plcParam.strOKSignal = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                                plcParam.strNGSignal = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                                plcParam.SignalFormat = (ds.Tables[0].Rows[0].ItemArray[12].ToString() == "") ? SignalFormat.DEC : (SignalFormat)Enum.Parse(typeof(SignalFormat), ds.Tables[0].Rows[0].ItemArray[12].ToString());
                                plcParam.strReadInterval = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                                plcParam.strRead = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                                plcParam.strReadDev = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                                plcParam.strReadCnt = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                                plcParam.ReadFormat = (ds.Tables[0].Rows[0].ItemArray[17].ToString() == "") ? PLCDataType.Binary : (PLCDataType)Enum.Parse(typeof(PLCDataType), ds.Tables[0].Rows[0].ItemArray[17].ToString());
                                plcParam.strReadTrigger = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                                plcParam.strReadTriggerCnt = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                                plcParam.strReadModel = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                                plcParam.strReadModelCnt = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                                plcParam.strReadLot = ds.Tables[0].Rows[0].ItemArray[22].ToString();
                                plcParam.strReadLotCnt = ds.Tables[0].Rows[0].ItemArray[23].ToString();
                                plcParam.strWrite = ds.Tables[0].Rows[0].ItemArray[24].ToString();
                                plcParam.strWriteDev = ds.Tables[0].Rows[0].ItemArray[25].ToString();
                                plcParam.strWriteGrabComplete = ds.Tables[0].Rows[0].ItemArray[26].ToString();
                                plcParam.strWriteModelChange = ds.Tables[0].Rows[0].ItemArray[27].ToString();
                                plcParam.strWriteLotComplete = ds.Tables[0].Rows[0].ItemArray[28].ToString();
                                plcParam.strWritePointResult = ds.Tables[0].Rows[0].ItemArray[29].ToString();
                                plcParam.strWriteTotalResult = ds.Tables[0].Rows[0].ItemArray[30].ToString();
                                plcParam.strWrite2DData = ds.Tables[0].Rows[0].ItemArray[31].ToString();
                                plcParam.strWriteAlignX = ds.Tables[0].Rows[0].ItemArray[32].ToString();
                                plcParam.strWriteAlignY = ds.Tables[0].Rows[0].ItemArray[33].ToString();
                                plcParam.strWriteAlignR = ds.Tables[0].Rows[0].ItemArray[34].ToString();
                                plcParam.strWriteWidth = ds.Tables[0].Rows[0].ItemArray[35].ToString();
                                plcParam.strWriteHeight = ds.Tables[0].Rows[0].ItemArray[36].ToString();
                                plcParam.strWritePinChange = ds.Tables[0].Rows[0].ItemArray[37].ToString();
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[38].ToString(), out plcParam.bConnect);
                                
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveGraphicToolParam(string strProcName, string strModelName, int nCamNo, DBInfo dbInfo, GraphicToolParam graphicTool)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from GRAPHICTOOLPARAM where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            for (var i = 0; i < graphicTool.strName.Length; i++)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    CMD.CommandText = "Update GRAPHICTOOLPARAM Set [TOOLNAME] = @TOOLNAME, [GRAPHICUSE] = @GRAPHICUSE, [GRAPHICOKCOLOR] = @GRAPHICOKCOLOR, [GRAPHICNGCOLOR] = @GRAPHICNGCOLOR, [GRAPHICLINETHICKNESS] = @GRAPHICLINETHICKNESS, " +
                                        "where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO and [TOOLNO] = @TOOLNO";

                                    CMD.Parameters.Clear();

                                    CMD.Parameters.AddWithValue("@TOOLNAME", graphicTool.strName[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICUSE", graphicTool.bUse[i].ToString());
                                    CMD.Parameters.AddWithValue("@GRAPHICOKCOLOR", graphicTool.strOKColor[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICNGCOLOR", graphicTool.strNGColor[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICLINETHICKNESS", graphicTool.nLineThick[i]);
                                    
                                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);
                                    CMD.Parameters.AddWithValue("@TOOLNO", i);
                                }
                                else
                                {
                                    CMD.CommandText = "INSERT INTO GRAPHICTOOLPARAM ([PROCESSNAME], [MODELNAME], [CAMNO], [TOOLNO], [TOOLNAME], [GRAPHICUSE]," +
                                        "[GRAPHICOKCOLOR], [GRAPHICNGCOLOR], [GRAPHICLINETHICKNESS]) " +
                                        "Values (@PROCESSNAME, @MODELNAME, @CAMNO, @TOOLNO, @TOOLNAME, @GRAPHICUSE,@GRAPHICOKCOLOR, @GRAPHICNGCOLOR, @GRAPHICLINETHICKNESS)";

                                    CMD.Parameters.Clear();

                                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);
                                    CMD.Parameters.AddWithValue("@TOOLNO", i);
                                    CMD.Parameters.AddWithValue("@TOOLNAME", graphicTool.strName[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICUSE", graphicTool.bUse[i].ToString());
                                    CMD.Parameters.AddWithValue("@GRAPHICOKCOLOR", graphicTool.strOKColor[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICNGCOLOR", graphicTool.strNGColor[i]);
                                    CMD.Parameters.AddWithValue("@GRAPHICLINETHICKNESS", graphicTool.nLineThick[i]);
                                    

                                }
                                CMD.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch (Exception ex) { }

        Conn.Dispose();
    }

    public void GetGraphicToolParam(string strProcName, string strModelName, int nCamNo, DBInfo dbInfo, ref GraphicToolParam graphicTool)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from GRAPHICTOOLPARAM where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO order by TOOLNO", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);
                    

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            graphicTool.strName = new string[ds.Tables[0].Rows.Count];
                            graphicTool.bUse = new bool[ds.Tables[0].Rows.Count];
                            graphicTool.strOKColor = new string[ds.Tables[0].Rows.Count];
                            graphicTool.strNGColor = new string[ds.Tables[0].Rows.Count];
                            graphicTool.nLineThick = new int[ds.Tables[0].Rows.Count];
                            


                            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                graphicTool.strName[i] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                                bool.TryParse(ds.Tables[0].Rows[i].ItemArray[6].ToString(), out graphicTool.bUse[i]);
                                graphicTool.strOKColor[i] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                                graphicTool.strNGColor[i] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                                int.TryParse(ds.Tables[0].Rows[i].ItemArray[9].ToString(), out graphicTool.nLineThick[i]);

                               
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveGraphicResViewlParam(string strProcName, string strModelName, int nCamNo, DBInfo dbInfo, GraphicResViewParam graphicResView)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from GRAPHICRESVIEWPARAM where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update GRAPHICRESVIEWPARAM Set [TXTALIGN] = @TXTALIGN, [FONTSIZE] = @FONTSIZE," +
                                    "[TXTPOSX] = @TXTPOSX, [TXTPOSY] = @TXTPOSY, [RESULTFONTSIZE] = @RESULTFONTSIZE, [RESULTTXTPOSX] = @RESULTTXTPOSX, [RESULTTXTPOSY] = @RESULTTXTPOSY" +
                                    " where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO";


                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@TXTALIGN", graphicResView.strAlign);
                                CMD.Parameters.AddWithValue("@FONTSIZE", graphicResView.nFontSize);
                                CMD.Parameters.AddWithValue("@TXTPOSX", graphicResView.dPosX);
                                CMD.Parameters.AddWithValue("@TXTPOSY", graphicResView.dPosY);
                                CMD.Parameters.AddWithValue("@RESULTFONTSIZE", graphicResView.nSubFontSize);
                                CMD.Parameters.AddWithValue("@RESULTTXTPOSX", graphicResView.dSubPosX);
                                CMD.Parameters.AddWithValue("@RESULTTXTPOSY", graphicResView.dSubPosY);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO GRAPHICRESVIEWPARAM ([PROCESSNAME], [MODELNAME], [CAMNO], [TXTALIGN], [FONTSIZE]," +
                                    "[TXTPOSX], [TXTPOSY], [RESULTFONTSIZE], [RESULTTXTPOSX], [RESULTTXTPOSY]) Values " +
                                    "(@PROCESSNAME, @MODELNAME, @CAMNO, @TXTALIGN, @FONTSIZE, @TXTPOSX, @TXTPOSY, @RESULTFONTSIZE, @RESULTTXTPOSX, @RESULTTXTPOSY)";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo);
                                CMD.Parameters.AddWithValue("@TXTALIGN", graphicResView.strAlign);
                                CMD.Parameters.AddWithValue("@FONTSIZE", graphicResView.nFontSize);
                                CMD.Parameters.AddWithValue("@TXTPOSX", graphicResView.dPosX);
                                CMD.Parameters.AddWithValue("@TXTPOSY", graphicResView.dPosY);
                                CMD.Parameters.AddWithValue("@RESULTFONTSIZE", graphicResView.nSubFontSize);
                                CMD.Parameters.AddWithValue("@RESULTTXTPOSX", graphicResView.dSubPosX);
                                CMD.Parameters.AddWithValue("@RESULTTXTPOSY", graphicResView.dSubPosY);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                            }
                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetGraphicResViewParam(string strProcName, string strModelName, int nCamNo, DBInfo dbInfo, ref GraphicResViewParam graphicResView)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from GRAPHICRESVIEWPARAM where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [CAMNO] = @CAMNO", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                graphicResView.strAlign = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[5].ToString(), out graphicResView.nFontSize);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[6].ToString(), out graphicResView.dPosX);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[7].ToString(), out graphicResView.dPosY);
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[8].ToString(), out graphicResView.nSubFontSize);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[9].ToString(), out graphicResView.dSubPosX);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[10].ToString(), out graphicResView.dSubPosY);
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void SaveCamInfo(int nCamNo, string strProcName, DateTime dateTime, CamPram camParam, DBInfo dbInfo)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONCAMINFO where [CAMNO] = @CAMNO and [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update VISIONCAMINFO Set [VENDER] = @VENDER, [CAMNO] = @CAMNO, [STATUS] = @STATUS, [MODEL] = @MODEL, [RESOLUTION] = @RESOLUTION, " +
                                    "[SERIALNO] = @SERIALNO, [CONNECTTYPE] = @CONNECTTYPE, [COPYTYPE] = @COPYTYPE, [IP] = @IP, [EXPOSURE] = @EXPOSURE, [CAMERATYPE] = @CAMERATYPE, [PIXELFORMAT] = @PIXELFORMAT, [FORMATVALUE] = @FORMATVALUE" +
                                    " where [PROCESSNAME] = @PROCESSNAME";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@VENDER", camParam.strVender);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                                CMD.Parameters.AddWithValue("@STATUS", camParam.bConnect ? "CONNECTED" : "DISCONNECTED");
                                CMD.Parameters.AddWithValue("@Model", camParam.strModel);
                                CMD.Parameters.AddWithValue("@RESOLUTION", camParam.strResolution);
                                CMD.Parameters.AddWithValue("@SERIALNO", camParam.strSerial);
                                CMD.Parameters.AddWithValue("@CONNECTTYPE", camParam.camInterface.ToString());
                                CMD.Parameters.AddWithValue("@COPYTYPE", camParam.strCopy);
                                CMD.Parameters.AddWithValue("@IP", camParam.strIP);
                                CMD.Parameters.AddWithValue("@EXPOSURE", camParam.dExpose.ToString());
                                CMD.Parameters.AddWithValue("@CAMERATYPE", camParam.strCamType);
                                CMD.Parameters.AddWithValue("@PIXELFORMAT", camParam.strCamFormat);
                                CMD.Parameters.AddWithValue("@FORMATVALUE", camParam.strPixelFormats);
                                
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO VISIONCAMINFO ([PROCESSNAME], [VENDER], [CAMNO], [STATUS], [SETDATE], [MODEL], [RESOLUTION], [SERIALNO], [CONNECTTYPE], [COPYTYPE], [IP], [EXPOSURE], [CAMERATYPE], [PIXELFORMAT], [FORMATVALUE]) " +
                                    "VALUES (@PROCESSNAME, @VENDER, @CAMNO, @STATUS, @SETDATE, @MODEL, @RESOLUTION, @SERIALNO, @CONNECTTYPE, @COPYTYPE, @IP, @EXPOSURE, @CAMERATYPE, @PIXELFORMAT, @FORMATVALUE)";
                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@VENDER", camParam.strVender);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                                CMD.Parameters.AddWithValue("@STATUS", camParam.bConnect ? "CONNECTED" : "DISCONNECTED");
                                CMD.Parameters.AddWithValue("@SETDATE", dateTime);
                                CMD.Parameters.AddWithValue("@MODEL", camParam.strModel);
                                CMD.Parameters.AddWithValue("@RESOLUTION", camParam.strResolution);
                                CMD.Parameters.AddWithValue("@SERIALNO", camParam.strSerial);
                                CMD.Parameters.AddWithValue("@CONNECTTYPE", camParam.camInterface.ToString());
                                CMD.Parameters.AddWithValue("@COPYTYPE", camParam.strCopy);
                                CMD.Parameters.AddWithValue("@IP", camParam.strIP);
                                CMD.Parameters.AddWithValue("@EXPOSURE", camParam.dExpose.ToString());
                                CMD.Parameters.AddWithValue("@CAMERATYPE", camParam.strCamType);
                                CMD.Parameters.AddWithValue("@PIXELFORMAT", camParam.strCamFormat);
                                CMD.Parameters.AddWithValue("@FORMATVALUE", camParam.strPixelFormats);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch
        {
        }

        Conn.Dispose();
    }

    public void DeleteRecipe(string strProcName, DBInfo dbInfo, string strModelName)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Delete from MODELRECIPE where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch
        {
        }

        Conn.Dispose();
    }


    public void DeleteGraphicResParam(string strProcName, DBInfo dbInfo, string strModelName)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Delete from GRAPHICRESVIEWPARAM where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch
        {
        }

        Conn.Dispose();
    }

    public void GetRecipe(string strProcName, DBInfo dbInfo, int nCamNo, string strModelName, ref ModelParam modelParam)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from MODELRECIPE where [PROCESSNAME] = @PROCESSNAME and [CAMNO] = @CAMNO and [MODELNAME] = @MODELNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                modelParam.strCode = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[5].ToString(), out modelParam.nInspCnt);
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[6].ToString(), out modelParam.nGrabdelay);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[7].ToString(), out modelParam.dExpose);
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[8].ToString(), out modelParam.nDefectCnt);
                                modelParam.strExposeInc = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[10].ToString(), out modelParam.bDefectInsp);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[11].ToString(), out modelParam.bBCRInsp);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[12].ToString(), out modelParam.bAlingInsp);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[13].ToString(), out modelParam.bDimens);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[14].ToString(), out modelParam.bPinChange);
                                
                                
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[17].ToString(), out modelParam.dResoluton);
                                modelParam.strTriggerNo = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                                modelParam.strLightNo = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                                modelParam.strBCRData = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                                modelParam.strBCRLen = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[22].ToString(), out modelParam.bAlignFormula);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[23].ToString(), out modelParam.dCenterMass);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[24].ToString(), out modelParam.dAlignMasterX);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[25].ToString(), out modelParam.dAlignMasterY);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[26].ToString(), out modelParam.dAlignMasterR);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[27].ToString(), out modelParam.dAlignOffsetX);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[28].ToString(), out modelParam.dAlignOffsetY);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[29].ToString(), out modelParam.dAlignOffsetR);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[30].ToString(), out modelParam.dAlignUnit);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[31].ToString(), out modelParam.dWidthMin);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[32].ToString(), out modelParam.dWidthMax);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[33].ToString(), out modelParam.dHeightMin);
                                double.TryParse(ds.Tables[0].Rows[0].ItemArray[34].ToString(), out modelParam.dHeightMax);
                                modelParam.strPinMaster = ds.Tables[0].Rows[0].ItemArray[35].ToString();
                                
                                
                                

                               

                                if (ds.Tables[0].Rows[0].ItemArray[45] != null)
                                    double.TryParse(ds.Tables[0].Rows[0].ItemArray[45].ToString(), out modelParam.dMaxX);

                                if (ds.Tables[0].Rows[0].ItemArray[46] != null)
                                    double.TryParse(ds.Tables[0].Rows[0].ItemArray[46].ToString(), out modelParam.dMaxY);
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch
        {
        }

        Conn.Dispose();
    }

    public void SaveRecipe(string strProcName, DBInfo dbInfo, int nCamNo, string strModelName, ModelParam modelParam)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from MODELRECIPE where [PROCESSNAME] = @PROCESSNAME and [CAMNO] = @CAMNO and [MODELNAME] = @MODELNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update MODELRECIPE Set [CODE] = @CODE, [INSPCNT] = @INSPCNT, [GRABDELAY] = @GRABDELAY, [EXPOSURE] = @EXPOSURE, [DEFECTGRABCNT] = @DEFECTGRABCNT, " +
                                    "[EXPOSUREINC] = @EXPOSUREINC, [DEFECTINSP] = @DEFECTINSP, [DEFECTBCR] = @DEFECTBCR, [DEFECTALIGN] = @DEFECTALIGN, [DEFECTDIMENSION] = @DEFECTDIMENSION, [DEFECTPINCHANGE] = @DEFECTPINCHANGE, [DEFECTPININFOCHANGE] = @DEFECTPININFOCHANGE," +
                                    "[RESOLUTION] = @RESOLUTION, [TRIGGERNO] = @TRIGGERNO, [LIGHTNO] = @LIGHTNO, [BCRDATA] = @BCRDATA, [BCRCNT] = @BCRCNT, [ALIGNFORMULA] = @ALIGNFORMULA, [CENTERMASS] = @CENTERMASS, [ALIGNMASTERX] = @ALIGNMASTERX," +
                                    "[ALIGNMASTERY] = @ALIGNMASTERY, [ALIGNMASTERR] = @ALIGNMASTERR, [ALIGNOFFSETX] = @ALIGNOFFSETX, [ALIGNOFFSETY] = @ALIGNOFFSETY, [ALIGNOFFSETR] = @ALIGNOFFSETR, [ALIGNUNIT] = @ALIGNUNIT, [WIDTHMIN] = @WIDTHMIN, [WIDTHMAX] = @WIDTHMAX," +
                                    "[HEIGHTMIN] = @HEIGHTMIN, [HEIGHTMAX] = @HEIGHTMAX, [PINMASTER] = @PINMASTER," +
                                    "[MAXX] = @MAXX, [MAXY] = @MAXY" +
                                    " where [PROCESSNAME] = @PROCESSNAME and [CAMNO] = @CAMNO and [MODELNAME] = @MODELNAME";

                                CMD.Parameters.Clear();
                                CMD.Parameters.AddWithValue("@CODE", modelParam.strCode);
                                CMD.Parameters.AddWithValue("@INSPCNT", modelParam.nInspCnt);
                                CMD.Parameters.AddWithValue("@GRABDELAY", modelParam.nGrabdelay);
                                CMD.Parameters.AddWithValue("@EXPOSURE", modelParam.dExpose);
                                CMD.Parameters.AddWithValue("@DEFECTGRABCNT", modelParam.nDefectCnt);
                                CMD.Parameters.AddWithValue("@EXPOSUREINC", modelParam.strExposeInc);
                                CMD.Parameters.AddWithValue("@DEFECTINSP", modelParam.bDefectInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTBCR", modelParam.bBCRInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTALIGN", modelParam.bAlingInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTDIMENSION", modelParam.bDimens.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTPINCHANGE", modelParam.bPinChange.ToString());
                                
                                
                                CMD.Parameters.AddWithValue("@RESOLUTION", modelParam.dResoluton);
                                CMD.Parameters.AddWithValue("@TRIGGERNO", modelParam.strTriggerNo);
                                CMD.Parameters.AddWithValue("@LIGHTNO", modelParam.strLightNo);
                                CMD.Parameters.AddWithValue("@BCRDATA", modelParam.strBCRData);
                                CMD.Parameters.AddWithValue("@BCRCNT", modelParam.strBCRLen);
                                CMD.Parameters.AddWithValue("@ALIGNFORMULA", modelParam.bAlignFormula.ToString());
                                CMD.Parameters.AddWithValue("@CENTERMASS", modelParam.dCenterMass);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERX", modelParam.dAlignMasterX);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERY", modelParam.dAlignMasterY);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERR", modelParam.dAlignMasterR);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETX", modelParam.dAlignOffsetX);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETY", modelParam.dAlignOffsetY);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETR", modelParam.dAlignOffsetR);
                                CMD.Parameters.AddWithValue("@ALIGNUNIT", modelParam.dAlignUnit);
                                CMD.Parameters.AddWithValue("@WIDTHMIN", modelParam.dWidthMin);
                                CMD.Parameters.AddWithValue("@WIDTHMAX", modelParam.dWidthMax);
                                CMD.Parameters.AddWithValue("@HEIGHTMIN", modelParam.dHeightMin);
                                CMD.Parameters.AddWithValue("@HEIGHTMAX", modelParam.dHeightMax);
                                CMD.Parameters.AddWithValue("@PINMASTER", modelParam.strPinMaster);
                                
                                
                                
                                
                                CMD.Parameters.AddWithValue("@MAXX", modelParam.dMaxX);
                                CMD.Parameters.AddWithValue("@MAXY", modelParam.dMaxY);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO MODELRECIPE ([PROCESSNAME], [MODELNAME], [CAMNO], [CODE], [INSPCNT], [GRABDELAY], [EXPOSURE], [DEFECTGRABCNT], [EXPOSUREINC], [DEFECTINSP], [DEFECTBCR], [DEFECTALIGN], [DEFECTDIMENSION], [DEFECTPINCHANGE]," +
                                    "[RESOLUTION], [TRIGGERNO], [LIGHTNO], [BCRDATA], [BCRCNT], [ALIGNFORMULA], [CENTERMASS], [ALIGNMASTERX], [ALIGNMASTERY], [ALIGNMASTERR], [ALIGNOFFSETX], [ALIGNOFFSETY], [ALIGNOFFSETR], [ALIGNUNIT], [WIDTHMIN], [WIDTHMAX]," +
                                    "[HEIGHTMIN], [HEIGHTMAX], [PINMASTER], [MAXX], [MAXY])" +
                                    " VALUES (@PROCESSNAME, @MODELNAME, @CAMNO, @CODE, @INSPCNT, @GRABDELAY, @EXPOSURE, @DEFECTGRABCNT, @EXPOSUREINC, @DEFECTINSP, @DEFECTBCR, @DEFECTALIGN, @DEFECTDIMENSION, @DEFECTPINCHANGE," +
                                    "@RESOLUTION, @TRIGGERNO, @LIGHTNO, @BCRDATA, @BCRCNT, @ALIGNFORMULA, @CENTERMASS, @ALIGNMASTERX, @ALIGNMASTERY, @ALIGNMASTERR, @ALIGNOFFSETX, @ALIGNOFFSETY, @ALIGNOFFSETR, @ALIGNUNIT, @WIDTHMIN, @WIDTHMAX," +
                                    "@HEIGHTMIN, @HEIGHTMAX, @PINMASTER, @MAXX,@MAXY)";

                                CMD.Parameters.Clear();
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                                CMD.Parameters.AddWithValue("@CODE", modelParam.strCode);
                                CMD.Parameters.AddWithValue("@INSPCNT", modelParam.nInspCnt);
                                CMD.Parameters.AddWithValue("@GRABDELAY", modelParam.nGrabdelay);
                                CMD.Parameters.AddWithValue("@EXPOSURE", modelParam.dExpose);
                                CMD.Parameters.AddWithValue("@DEFECTGRABCNT", modelParam.nDefectCnt);
                                CMD.Parameters.AddWithValue("@EXPOSUREINC", modelParam.strExposeInc);
                                CMD.Parameters.AddWithValue("@DEFECTINSP", modelParam.bDefectInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTBCR", modelParam.bBCRInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTALIGN", modelParam.bAlingInsp.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTDIMENSION", modelParam.bDimens.ToString());
                                CMD.Parameters.AddWithValue("@DEFECTPINCHANGE", modelParam.bPinChange.ToString());
                                
                                
                                CMD.Parameters.AddWithValue("@RESOLUTION", modelParam.dResoluton);
                                CMD.Parameters.AddWithValue("@TRIGGERNO", modelParam.strTriggerNo);
                                CMD.Parameters.AddWithValue("@LIGHTNO", modelParam.strLightNo);
                                CMD.Parameters.AddWithValue("@BCRDATA", modelParam.strBCRData);
                                CMD.Parameters.AddWithValue("@BCRCNT", modelParam.strBCRLen);
                                CMD.Parameters.AddWithValue("@ALIGNFORMULA", modelParam.bAlignFormula.ToString());
                                CMD.Parameters.AddWithValue("@CENTERMASS", modelParam.dCenterMass);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERX", modelParam.dAlignMasterX);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERY", modelParam.dAlignMasterY);
                                CMD.Parameters.AddWithValue("@ALIGNMASTERR", modelParam.dAlignMasterR);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETX", modelParam.dAlignOffsetX);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETY", modelParam.dAlignOffsetY);
                                CMD.Parameters.AddWithValue("@ALIGNOFFSETR", modelParam.dAlignOffsetR);
                                CMD.Parameters.AddWithValue("@ALIGNUNIT", modelParam.dAlignUnit);
                                CMD.Parameters.AddWithValue("@WIDTHMIN", modelParam.dWidthMin);
                                CMD.Parameters.AddWithValue("@WIDTHMAX", modelParam.dWidthMax);
                                CMD.Parameters.AddWithValue("@HEIGHTMIN", modelParam.dHeightMin);
                                CMD.Parameters.AddWithValue("@HEIGHTMAX", modelParam.dHeightMax);
                                CMD.Parameters.AddWithValue("@PINMASTER", modelParam.strPinMaster);
                                
                                
                                
                                
                                CMD.Parameters.AddWithValue("@MAXX", modelParam.dMaxX);
                                CMD.Parameters.AddWithValue("@MAXY", modelParam.dMaxY);
                            }

                            CMD.ExecuteNonQuery();
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch (Exception ex)
        {
        }

        Conn.Dispose();

    }

    public bool Login(DBInfo dbInfo, string strID, string strPW, ref UserLevel userLevel)
    {
        bool bLogin = false;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LOGIN where [USERID] = @USERID and [PASSWORD] = @PASSWORD", Conn))
                {
                    CMD.Parameters.AddWithValue("@USERID", strID);
                    CMD.Parameters.AddWithValue("@PASSWORD", strPW);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                userLevel = (ds.Tables[0].Rows[0].ItemArray[3].ToString() == "") ? UserLevel.OPERATOR : (UserLevel)Enum.Parse(typeof(UserLevel), ds.Tables[0].Rows[0].ItemArray[3].ToString());
                                bLogin = true;
                            }
                        }
                    }
                }
                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();

        return bLogin;
    }

    public DataSet GetUser(DBInfo dbInfo)
    {
        DataSet ds = new DataSet();

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LOGIN", Conn))
                {
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = CMD;
                        adapter.SelectCommand.ExecuteNonQuery();

                        ds.Clear();
                        adapter.Fill(ds);
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();

        return ds;
    }

    public bool UserChk(DBInfo dbInfo, string strID)
    {
        bool bUserEnable = false;
        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LOGIN where [USERID] = @USERID", Conn))
                {
                    CMD.Parameters.AddWithValue("@USERID", strID);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                bUserEnable = true;
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();

        return bUserEnable;
    }

    public void UserAdd(DBInfo dbInfo, string strID, string strPW, string strLevel)
    {
        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Insert into LOGIN ([USERID], [PASSWORD], [USERLEVEL]) Values (@USERID, @PASSWORD, @USERLEVEL)", Conn))
                {
                    CMD.Parameters.AddWithValue("@USERID", strID);
                    CMD.Parameters.AddWithValue("@PASSWORD", strPW);
                    CMD.Parameters.AddWithValue("@USERLEVEL", strLevel);

                    CMD.ExecuteNonQuery();
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void UserEdit(DBInfo dbInfo, string strID, string strPW, string strLevel)
    {
        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Update LOGIN Set [PASSWORD] = @PASSWORD, [USERLEVEL] = @USERLEVEL Where [USERID] = @USERID", Conn))
                {
                    CMD.Parameters.AddWithValue("@PASSWORD", strPW);
                    CMD.Parameters.AddWithValue("@USERLEVEL", strLevel);
                    CMD.Parameters.AddWithValue("@USERID", strID);

                    CMD.ExecuteNonQuery();
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public void GetCount(string strProcName, string strModelname, DateTime dateTimeStart, DateTime dateTimeEnd, DBInfo dbInfo, ref int[] nTotalCnt, ref int[] nOKCnt, ref int[] nNGCnt)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONCOUNT where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [DATE] >= @DATE1 and [DATE] <= @DATE2", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelname);
                    CMD.Parameters.AddWithValue("@DATE1", dateTimeStart);
                    CMD.Parameters.AddWithValue("@DATE2", dateTimeEnd);

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (i == 1)
                                    break;

                                var nIdx = 0;
                                for (var j = 0; j < 16; j++)
                                {
                                    nIdx = 4 + (j * 3);

                                    int.TryParse(ds.Tables[0].Rows[i].ItemArray[nIdx].ToString(), out nTotalCnt[j]);
                                    int.TryParse(ds.Tables[0].Rows[i].ItemArray[nIdx + 1].ToString(), out nOKCnt[j]);
                                    int.TryParse(ds.Tables[0].Rows[i].ItemArray[nIdx + 2].ToString(), out nNGCnt[j]);
                                }
                            }
                        }
                    }

                }

                Conn.Close();
            }
        }
        catch (Exception ex)
        {

        }

        Conn.Dispose();
    }

    public void SaveAlarm(string strProcName, DBInfo dbInfo, DateTime dateTime, string strMsgType, string strMsg)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Insert into VISIONALARM ([PROCESSNAME], [DATE], [MSGTYPE], [MESSAGE]) Values (@PROCESSNAME, @DATE, @MSGTYPE, @MESSAGE)", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@DATE", dateTime);
                    CMD.Parameters.AddWithValue("@MSGTYPE", strMsgType);
                    CMD.Parameters.AddWithValue("@MESSAGE", strMsg);

                    CMD.ExecuteNonQuery();
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
    }

    public DataSet GetAlarm(string strProcName, DBInfo dbInfo, DateTime dateTimeStart, DateTime dateTimeEnd, string strMstType)
    {
        DataSet ds = new DataSet();

        if (string.IsNullOrEmpty(strProcName))
            return ds;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONALARM where [PROCESSNAME] = @PROCESSNAME and [DATE] >= @DATE1 and [DATE] <= @DATE2", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@DATE1", dateTimeStart);
                    CMD.Parameters.AddWithValue("@DATE2", dateTimeEnd);

                    if (strMstType != "ALL")
                    {
                        CMD.CommandText += " Where [MSGTYPE] = @MSGTYPE";
                        CMD.Parameters.AddWithValue("@MSGTYPE", strMstType);
                    }

                    using (var adpter = new SqlDataAdapter())
                    {
                        adpter.SelectCommand = CMD;
                        adpter.SelectCommand.ExecuteNonQuery();

                        ds.Clear();
                        adpter.Fill(ds);
                    }
                }
            }
        }
        catch { }

        return ds;
    }

    public void SaveLightParam(int nIdx, string strProcName, DBInfo dbInfo, LightParam lightParam)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LIGHTPARAM where [CONTROL_NO] = @CONTROL_NO and [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@CONTROL_NO", nIdx);
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adpter = new SqlDataAdapter())
                    {
                        adpter.SelectCommand = CMD;
                        adpter.SelectCommand.ExecuteNonQuery();

                        using (var ds = new DataSet())
                        {
                            adpter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update LIGHTPARAM Set [CONNECTMODE] = @CONNECTMODE, [PORT] = @PORT, [BAUDRATE] = @BAUDRATE, [VALUE_1] = @VALUE_1, [VALUE_2] = @VALUE_2, " +
                                    "[LIGHTUSE_1] = @LIGHTUSE_1,[LIGHTUSE_2] = @LIGHTUSE_2 where [CONTROL_NO] = @CONTROL_NO and [PROCESSNAME] = @PROCESSNAME";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@CONNECTMODE", lightParam.strConnectMode);
                                CMD.Parameters.AddWithValue("@PORT", lightParam.strPortName);
                                CMD.Parameters.AddWithValue("@BAUDRATE", lightParam.strBaudrate);
                                CMD.Parameters.AddWithValue("@VALUE_1", lightParam.nValue);
                                CMD.Parameters.AddWithValue("@LIGHTUSE_1", lightParam.bLightUse[0].ToString());
                                CMD.Parameters.AddWithValue("@LIGHTUSE_2", lightParam.bLightUse[1].ToString());
                                CMD.Parameters.AddWithValue("@CONTROL_NO", nIdx);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                                adpter.UpdateCommand = CMD;
                                adpter.UpdateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO LIGHTPARAM ([CONTROL_NO], [PROCESSNAME], [CONNECTMODE], [PORT], [BAUDRATE], [VALUE_1], [VALUE_2]" +
                                    ", [LIGHTUSE_1], [LIGHTUSE_2]";
                                CMD.CommandText += ") VALUES (@CONTROL_NO, @PROCESSNAME, @CONNECTMODE, @PORT, @BAUDRATE, @VALUE_1, @VALUE_2," +
                                    "@LIGHTUSE_1, @LIGHTUSE_2)";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@CONTROL_NO", nIdx);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@CONNECTMODE", lightParam.strConnectMode);
                                CMD.Parameters.AddWithValue("@PORT", lightParam.strPortName);
                                CMD.Parameters.AddWithValue("@BAUDRATE", lightParam.strBaudrate);
                                CMD.Parameters.AddWithValue("@VALUE_1", lightParam.nValue);
                                CMD.Parameters.AddWithValue("@LIGHTUSE_1", lightParam.bLightUse[0].ToString());
                                CMD.Parameters.AddWithValue("@LIGHTUSE_2", lightParam.bLightUse[1].ToString());

                                adpter.InsertCommand = CMD;
                                adpter.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
        catch(Exception ex) { }
    }

    public void GetLightParam(string strProcName, DBInfo dbInfo, ref LightParam lightParam)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from LIGHTPARAM where [CONTROL_NO] = @CONTROL_NO and [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adpter = new SqlDataAdapter())
                    {
                        adpter.SelectCommand = CMD;
                        adpter.SelectCommand.ExecuteNonQuery();

                        using(var ds = new DataSet()) 
                        {
                            adpter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0) 
                            {
                                lightParam.strConnectMode = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                                lightParam.strPortName = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                                lightParam.strBaudrate = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                                int.TryParse(ds.Tables[0].Rows[0].ItemArray[6].ToString(), out lightParam.nValue[0]);
                                
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[8].ToString(), out lightParam.bLightUse[0]);
                                bool.TryParse(ds.Tables[0].Rows[0].ItemArray[9].ToString(), out lightParam.bLightUse[1]);
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    public void SaveIOParam(string strProcName, DBInfo dbInfo, string strIOCardType)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from IOPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adpter = new SqlDataAdapter())
                    {
                        adpter.SelectCommand = CMD;
                        adpter.SelectCommand.ExecuteNonQuery();

                        using (var ds = new DataSet())
                        {
                            adpter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update IOPARAM Set [PCI_CARD] = @PCI_CARD where PROCESSNAME = @PROCESSNAME";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@PCI_CARD", strIOCardType);
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                                adpter.UpdateCommand = CMD;
                                adpter.UpdateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO IOPARAM ([PROCESSNAME], [PCI_CARD]) VALUES (@PROCESSNAME, @PCI_CARD)";

                                CMD.Parameters.Clear();
                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@PCI_CARD", strIOCardType);

                                adpter.InsertCommand = CMD;
                                adpter.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex) { }
    }

    public void GetIOParam(string strProcName, DBInfo dbInfo, ref string strIOCardType)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from IOPARAM where [PROCESSNAME] = @PROCESSNAME", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);

                    using (var adpter = new SqlDataAdapter())
                    {
                        adpter.SelectCommand = CMD;
                        adpter.SelectCommand.ExecuteNonQuery();

                        using (var ds = new DataSet())
                        {
                            adpter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                                strIOCardType = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                        }
                    }
                }
            }
        }
        catch { }
    }

    public void SaveCount(string strProcName, string strModelName, DBInfo dbInfo, int[] nTotalCount, int[] nOKCount, int[] nNGCount, DateTime dateTime)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONCOUNT Where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [DATE] >= @DATE1 and [DATE] <= @DATE2", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@DATE1", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 00:00:00")));
                    CMD.Parameters.AddWithValue("@DATE2", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 23:59:59")));

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update VISIONCOUNT Set [TOTAL_COUNT] = @TOTAL_COUNT, [TOTAL_OK] = @TOTAL_OK, [TOTAL_NG] = @TOTAL_NG";

                                for (var i = 0; i < 15; i++)
                                {
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_TOTAL] = @CAM_{1:D2}_TOTAL", i + 1, i + 1);
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_OK] = @CAM_{1:D2}_OK", i + 1, i + 1);
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_NG] = @CAM_{1:D2}_NG", i + 1, i + 1);
                                }

                                CMD.CommandText += " Where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [DATE] >= @DATE1 and [DATE] <= @DATE2";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@TOTAL_COUNT", nTotalCount[0]);
                                CMD.Parameters.AddWithValue("@TOTAL_OK", nOKCount[0]);
                                CMD.Parameters.AddWithValue("@TOTAL_NG", nNGCount[0]);

                                for (var i = 0; i < 15; i++)
                                {
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_TOTAL", i + 1), nTotalCount[i + 1]);
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_OK", i + 1), nOKCount[i + 1]);
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_NG", i + 1), nNGCount[i + 1]);
                                }

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@DATE1", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 00:00:00")));
                                CMD.Parameters.AddWithValue("@DATE2", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 23:59:59")));

                                adapter.UpdateCommand = CMD;
                                adapter.UpdateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO VISIONCOUNT ([PROCESSNAME], [MODELNAME], [DATE], [TOTAL_COUNT], [TOTAL_OK], [TOTAL_NG]";

                                for (var i = 0; i < 15; i++)
                                {
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_TOTAL]", i + 1);
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_OK]", i + 1);
                                    CMD.CommandText += string.Format(", [CAM_{0:D2}_NG]", i + 1);
                                }

                                CMD.CommandText += ") VALUES (@PROCESSNAME, @MODELNAME, @DATE, @TOTAL_COUNT, @TOTAL_OK, @TOTAL_NG";

                                for (var i = 0; i < 15; i++)
                                {
                                    CMD.CommandText += string.Format(", @CAM_{0:D2}_TOTAL", i + 1);
                                    CMD.CommandText += string.Format(", @CAM_{0:D2}_OK", i + 1);
                                    CMD.CommandText += string.Format(", @CAM_{0:D2}_NG", i + 1);
                                }

                                CMD.CommandText += ")";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue("@TOTAL_COUNT", nTotalCount[0]);
                                CMD.Parameters.AddWithValue("@TOTAL_OK", nOKCount[0]);
                                CMD.Parameters.AddWithValue("@TOTAL_NG", nNGCount[0]);

                                for (var i = 0; i < 15; i++)
                                {
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_TOTAL", i + 1), nTotalCount[i + 1]);
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_OK", i + 1), nOKCount[i + 1]);
                                    CMD.Parameters.AddWithValue(string.Format("@CAM_{0:D2}_NG", i + 1), nNGCount[i + 1]);
                                }

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@DATE", dateTime);

                                adapter.InsertCommand = CMD;
                                adapter.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch (Exception ex)
        {
        }

        Conn.Dispose();
    }

    public void SetDailyCount(string strProcName, DateTime dateTime, string strModelName, DBInfo dbInfo, string strTime, int[] nCount)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();

        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONDAILYCOUNT Where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [Date] >= @Date", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    CMD.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 00:00:00")));

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CMD.CommandText = "Update VISIONDAILYCOUNT Set " + string.Format("[TIME_{0}_TOTAL] = @TIME_{0}_TOTAL", strTime) + "," + string.Format("[TIME_{0}_OK] = @TIME_{0}_OK", strTime) + "," + string.Format("[TIME_{0}_NG] = @TIME_{0}_NG", strTime);
                                CMD.CommandText += " Where [PROCESSNAME] = @PROCESSNAME and [MODELNAME] = @MODELNAME and [Date] >= @Date1 and [Date] <= @Date2";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_TOTAL", strTime), nCount[0]);
                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_OK", strTime), nCount[1]);
                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_NG", strTime), nCount[2]);

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@Date1", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 00:00:00")));
                                CMD.Parameters.AddWithValue("@Date2", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd 23:59:59")));

                                adapter.UpdateCommand = CMD;
                                adapter.UpdateCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                CMD.CommandText = "INSERT INTO VISIONDAILYCOUNT ([PROCESSNAME], [MODELNAME], [Date]," + string.Format("[TIME_{0}_TOTAL]", strTime) + "," + string.Format("[TIME_{0}_OK]", strTime) + "," + string.Format("[TIME_{0}_NG]", strTime);
                                CMD.CommandText += ") VALUES (@PROCESSNAME, @MODELNAME, @Date," + string.Format("@TIME_{0}_TOTAL", strTime) + "," + string.Format("@TIME_{0}_OK", strTime) + "," + string.Format("@TIME_{0}_NG", strTime) + ")";

                                CMD.Parameters.Clear();

                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_TOTAL", strTime), nCount[0]);
                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_OK", strTime), nCount[1]);
                                CMD.Parameters.AddWithValue(string.Format("@TIME_{0}_NG", strTime), nCount[2]);

                                CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                                CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                                CMD.Parameters.AddWithValue("@Date", dateTime);

                                adapter.InsertCommand = CMD;
                                adapter.InsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Conn.Close();
            }

        }
        catch (Exception ex)
        {

        }

        Conn.Close();
    }

    public void GetDailyCount(string strProcName, string strModelName, bool bCollect, DateTime dateStartTime, DateTime dateEndTime, DBInfo dbInfo, ref int[] nTOTALCnt, ref int[] nOKCnt, ref int[] nNGCnt)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("Select * from VISIONDAILYCOUNT Where [PROCESSNAME] = @PROCESSNAME and [Date] >= @Date1 and [Date] <= @Date2", Conn))
                {

                    if(strModelName != "ALL")
                    {
                        CMD.CommandText += " and [MODELNAME] = @MODELNAME";
                        CMD.Parameters.AddWithValue("@MODELNAME", strModelName);
                    }
                    if(dateStartTime.ToString("yyyy-MM-dd") != dateEndTime.ToString("yyyy-MM-dd"))
                    {
                        CMD.CommandText += " order by date";
                    }

                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@Date1", dateStartTime);
                    CMD.Parameters.AddWithValue("@Date2", dateEndTime);
                    

                    using (var adapter = new SqlDataAdapter())
                    {
                        using (var ds = new DataSet())
                        {
                            adapter.SelectCommand = CMD;
                            adapter.SelectCommand.ExecuteNonQuery();

                            ds.Clear();
                            adapter.Fill(ds);

                            for (var i = 0; i < 24; i++)
                            {
                                nTOTALCnt[i] = 0;
                                nOKCnt[i] = 0;
                                nNGCnt[i] = 0;
                            }

                            if (bCollect) 
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    var bDay = true;
                                    if (dateStartTime.ToString("yyyy-MM-dd") != dateEndTime.ToString("yyyy-MM-dd"))
                                        bDay = false;

                                    var nIdx = 0;

                                    if (bDay)
                                    {
                                        for (var k = 0; k < ds.Tables[0].Rows.Count; k++)
                                        {
                                            int nTotalTemp = 0;
                                            int nOKTemp = 0;
                                            int nNGTemp = 0;
                                            for (var i = 0; i < 12; i++)
                                            {
                                                nIdx = 28 + (i * 3);

                                                int.TryParse(ds.Tables[0].Rows[k].ItemArray[nIdx].ToString(), out nTotalTemp);
                                                int.TryParse(ds.Tables[0].Rows[k].ItemArray[nIdx + 1].ToString(), out nOKTemp);
                                                int.TryParse(ds.Tables[0].Rows[k].ItemArray[nIdx + 2].ToString(), out nNGTemp);

                                                nTOTALCnt[i] += nTotalTemp;
                                                nOKCnt[i] += nOKTemp;
                                                nNGCnt[i] += nNGTemp;
                                            }
                                        }
                                        //for (var i = 0; i < 12; i++)
                                        //{
                                        //    nIdx = 28 + (i * 3);

                                        //    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx].ToString(), out nTOTALCnt[i]);
                                        //    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx + 1].ToString(), out nOKCnt[i]);
                                        //    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx + 2].ToString(), out nNGCnt[i]);
                                        //}
                                    }
                                    else
                                    {
                                        var nCnt = 0;
                                        var nIdxTemp = 0;
                                        for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                                        {
                                            //MessageBox.Show(dateStartTime.ToString("yyyy-MM-dd") + "\n" + Convert.ToDateTime(ds.Tables[0].Rows[j].ItemArray[3]).ToString("yyyy-MM-dd"));
                                            if (dateStartTime.ToString("yyyy-MM-dd") == Convert.ToDateTime(ds.Tables[0].Rows[j].ItemArray[3]).ToString("yyyy-MM-dd"))
                                            {
                                                nCnt = 4;
                                                nIdxTemp = 64;
                                            }
                                            else
                                            {
                                                nCnt = 7;
                                                nIdxTemp = 4;
                                            }
                                            int nTotalTemp = 0;
                                            int nOKTemp = 0;
                                            int nNGTemp = 0;

                                            for (var i = 0; i < nCnt; i++)
                                            {
                                                nIdx = nIdxTemp + (i * 3);

                                                int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx].ToString(), out nTotalTemp);
                                                int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx + 1].ToString(), out nOKTemp);
                                                int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx + 2].ToString(), out nNGTemp);

                                                nTOTALCnt[i] += nTotalTemp;
                                                nOKCnt[i] += nOKTemp;
                                                nNGCnt[i] += nNGTemp;
                                            }
                                        //for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                                        //{
                                        //nCnt = j == 0 ? 4 : 7;
                                        //nIdx = j == 0 ? 64 : 4;
                                        //for (var i = 0; i < nCnt; i++)
                                        //{
                                        //    nIdx += (i * 3);

                                        //    int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx].ToString(), out nTOTALCnt[i]);
                                        //    int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx + 1].ToString(), out nOKCnt[i]);
                                        //    int.TryParse(ds.Tables[0].Rows[j].ItemArray[nIdx + 2].ToString(), out nNGCnt[i]);
                                        //}
                                        //}
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var nIdx = 0;
                                for (var i = 0; i < 24; i++)
                                {
                                    nIdx = 4 + (i * 3);

                                    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx].ToString(), out nTOTALCnt[i]);
                                    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx + 1].ToString(), out nOKCnt[i]);
                                    int.TryParse(ds.Tables[0].Rows[0].ItemArray[nIdx + 2].ToString(), out nNGCnt[i]);
                                }
                            }
                        }
                    }
                }

                Conn.Close();
            }
        }
        catch (Exception e)
        {
            //MessageBox.Show(e.Message);
        }

        Conn.Dispose();
    }

    public void InsertResult(int nCamNo, string strProcessName, bool bResult, string[] strData, DateTime Time, string strModelName, string strSerialNo, string strCodeNo, string strSaveFileName, bool bManual, DBInfo dbInfo, string strResultData)
    {
        if (string.IsNullOrEmpty(strProcessName))
            return;

        var Conn = new SqlConnection();

        try
        {
            var nSel = nCamNo;
            var strProcName = strProcessName;
            var bRes = bResult;
            var strValue = strData;
            var dateTime = Time;
            var strModel = strModelName;
            var strSerial = strSerialNo;
            var strCode = strCodeNo;
            var strRes = bRes ? "OK" : "NG";
            var strFileName = strSaveFileName;
            var strResData = strResultData;

            if (strProcName == "")
                strProcName = "NO_NAME";

            if (strModel == "")
                strModel = "NO_MODEL";

            if (strSerial == "")
                strSerial = "NO_LOTNO";

            if (DBConnect(ref Conn, dbInfo))
            {
                using (SqlCommand CMD = new SqlCommand("INSERT INTO VISION ([PROCESSNAME], [MODEL], [LOTNO], [CODE], [DATE], [CAMNO], [RESULT], [DATA], [ALIGNX], [ALIGNY], [ALIGNR], [WIDTH], [HEIGHT], [PINDATA], [IMGPATH], [MODE], [RESDATA]) " +
                    "VALUES (@PROCESSNAME, @MODEL, @LOTNO, @CODE, @DATE, @CAMNO, @RESULT, @DATA, @ALIGNX, @ALIGNY, @ALIGNR, @WIDTH, @HEIGHT, @PINDATA, @IMGPATH, @MODE, @RESDATA)", Conn))
                {
                    CMD.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CMD.Parameters.AddWithValue("@MODEL", strModel);
                    CMD.Parameters.AddWithValue("@LOTNO", strSerial);
                    CMD.Parameters.AddWithValue("@CODE", strCode);
                    CMD.Parameters.AddWithValue("@DATE", Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                    CMD.Parameters.AddWithValue("@CAMNO", (nSel + 1).ToString());
                    CMD.Parameters.AddWithValue("@RESULT", strRes);

                    if (strValue != null)
                    {
                        CMD.Parameters.AddWithValue("@DATA", strValue[1]);
                        CMD.Parameters.AddWithValue("@ALIGNX", strValue[2]);
                        CMD.Parameters.AddWithValue("@ALIGNY", strValue[3]);
                        CMD.Parameters.AddWithValue("@ALIGNR", strValue[4]);
                        CMD.Parameters.AddWithValue("@WIDTH", strValue[5]);
                        CMD.Parameters.AddWithValue("@HEIGHT", strValue[6]);
                        CMD.Parameters.AddWithValue("@PINDATA", strValue[7]);
                    }
                    else
                    {
                        CMD.Parameters.AddWithValue("@DATA", "");
                        CMD.Parameters.AddWithValue("@ALIGNX", "");
                        CMD.Parameters.AddWithValue("@ALIGNY", "");
                        CMD.Parameters.AddWithValue("@ALIGNR", "");
                        CMD.Parameters.AddWithValue("@WIDTH", "");
                        CMD.Parameters.AddWithValue("@HEIGHT", "");
                        CMD.Parameters.AddWithValue("@PINDATA", "");
                    }

                    CMD.Parameters.AddWithValue("@IMGPATH", strFileName);
                    CMD.Parameters.AddWithValue("@MODE", bManual ? "MANUAL" : "AUTO");
                    CMD.Parameters.AddWithValue("@RESDATA", strResData);
                    CMD.ExecuteNonQuery();
                }
                Conn.Close();
            }


        }
        catch { }

        Conn.Dispose();
    }

    public void GetResult(string strProcName, int nCamNo, DateTime dateTime, DBInfo dbInfo, ref string[] strData, ref bool bManual)
    {
        if (string.IsNullOrEmpty(strProcName))
            return;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (var CDM = new SqlCommand())
                {
                    CDM.CommandType = CommandType.Text;
                    CDM.Connection = Conn;

                    var strQuery = "Select * from VISION where [PROCESSNAME] = @PROCESSNAME and [DATE] >= @DATE  and [CAMNO] = @CAMNO order by DATE Desc";

                    CDM.Parameters.Clear();
                    CDM.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CDM.Parameters.AddWithValue("@DATE", dateTime);
                    CDM.Parameters.AddWithValue("@CAMNO", nCamNo + 1);
                    CDM.CommandText = strQuery;

                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = CDM;
                        adapter.SelectCommand.ExecuteNonQuery();

                        using (var ds = new DataSet())
                        {
                            ds.Clear();
                            adapter.Fill(ds);

                            for (var i = 0; i < strData.Length; i++)
                                strData[i] = "";

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strData[0] = ds.Tables[0].Rows[0].ItemArray[7].ToString() == "OK" ? "1" : "0";
                                strData[1] = ds.Tables[0].Rows[0].ItemArray[8].ToString();
                                strData[2] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                                strData[3] = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                                strData[4] = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                                strData[5] = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                                strData[6] = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                                strData[7] = ds.Tables[0].Rows[0].ItemArray[14].ToString();

                                if (ds.Tables[0].Rows[0].ItemArray[16].ToString() == "MANUAL")
                                    bManual = true;
                                else
                                    bManual = false;
                            }
                        }
                    }
                }

                Conn.Close();
            }

        }
        catch { }

        Conn.Dispose();
    }

    public DataSet SearchData(string strProcName, int nCamNo, string strModel, string strLotNo, string strRes, DateTime dateTimeStart, DateTime dateTimeEnd, DBInfo dbInfo)
    {
        DataSet ds = new DataSet();

        if (string.IsNullOrEmpty(strProcName))
            return ds;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (var CDM = new SqlCommand())
                {
                    CDM.CommandType = CommandType.Text;
                    CDM.Connection = Conn;

                    var strQuery = "Select * from VISION where [PROCESSNAME] = @PROCESSNAME and [DATE] >= @DATE1 and [DATE] <= @DATE2"; //from Data where [Date] >= ? and [Date] <= ?";

                    CDM.Parameters.Clear();
                    CDM.Parameters.AddWithValue("@PROCESSNAME", strProcName);
                    CDM.Parameters.AddWithValue("@DATE1", dateTimeStart);
                    CDM.Parameters.AddWithValue("@DATE2", dateTimeEnd);

                    //if (!string.IsNullOrEmpty(strModel))
                    if(strModel != "ALL")
                    {
                        strQuery += " and [MODEL] like @MODEL";
                        CDM.Parameters.AddWithValue("@MODEL", string.Format("{0}", strModel));

                    }

                    if (!string.IsNullOrEmpty(strLotNo))
                    {
                        strQuery += " and [LOTNO] like @LOTNO";
                        CDM.Parameters.AddWithValue("@LOTNO", string.Format("%{0}%", strLotNo));
                    }

                    if (nCamNo > 0)
                    {
                        strQuery += " and [CAMNO] = @CAMNO";
                        CDM.Parameters.AddWithValue("@CAMNO", nCamNo.ToString());
                    }

                    if (strRes == "OK" || strRes == "NG")
                    {
                        strQuery += " and [RESULT] = @RESULT";
                        CDM.Parameters.AddWithValue("@RESULT", strRes);
                    }

                    strQuery += " order by Date desc";
                    CDM.CommandText = strQuery;

                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = CDM;
                        adapter.SelectCommand.ExecuteNonQuery();

                        ds.Clear();
                        adapter.Fill(ds);

                    }
                }

                Conn.Close();
            }

        }
        catch { }

        Conn.Dispose();
        return ds;
    }

    public DataSet SearchPrintData(DateTime dateTimeStart, DateTime dateTimeEnd, string strProcessName, string strModelName, string strLotNo, DBInfo dbInfo)
    {
        DataSet ds = new DataSet();

        if (string.IsNullOrEmpty(strProcessName))
            return ds;

        var Conn = new SqlConnection();
        try
        {
            if (DBConnect(ref Conn, dbInfo))
            {
                using (var CDM = new SqlCommand())
                {
                    CDM.CommandType = CommandType.Text;
                    CDM.Connection = Conn;

                    var strQuery = "Select * from PRINTDATA where [DATE] >= @DATE1 and [DATE] <= @DATE2 "; //from Data where [Date] >= ? and [Date] <= ?";

                    CDM.Parameters.Clear();
                    CDM.Parameters.AddWithValue("@PROCESSNAME", strProcessName);
                    CDM.Parameters.AddWithValue("@DATE1", dateTimeStart);
                    CDM.Parameters.AddWithValue("@DATE2", dateTimeEnd);

                    if (!string.IsNullOrEmpty(strModelName))
                    {
                        strQuery += " and [MODEL] like @MODEL";
                        CDM.Parameters.AddWithValue("@MODEL", string.Format("%{0}%", strModelName));

                    }

                    if (!string.IsNullOrEmpty(strLotNo))
                    {
                        strQuery += " and [CODE] like @CODE";
                        CDM.Parameters.AddWithValue("@CODE", string.Format("%{0}%", strLotNo));
                    }

                    strQuery += " order by Date";
                    CDM.CommandText = strQuery;

                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = CDM;
                        adapter.SelectCommand.ExecuteNonQuery();

                        ds.Clear();
                        adapter.Fill(ds);
                    }
                }

                Conn.Close();
            }
        }
        catch { }

        Conn.Dispose();
        return ds;
    }
}
