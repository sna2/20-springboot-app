using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Symbol.RFID3;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Configuration;
using CS_RFID3_Host_Sample2;
using System.Net.NetworkInformation;

namespace CS_RFID3_Host_Sample2
{
    public partial class AppForm : Form
    {
        DAccess2 d2 = new DAccess2();
        public string connectionString1 = @"Data Source=RFID-PC;Initial Catalog=Trolleycheckmulti;User ID=sa;Password=tiger;";
        public static string tagID, rfids, rfids1, rfids2, rfids3, rfids4, rfids5, rfids6, rfids7;
        public static int antena1, antena2, antena3, antena4, antena5, antena6, antena7, antena8;
        public string Constatus = string.Empty;
        public string Constatus1 = string.Empty;
        public string Constatus2 = string.Empty;
        public string Constatus3 = string.Empty;
        public string IPaddress = string.Empty;
        public string IPaddress1 = string.Empty;
        public string IPaddress2 = string.Empty;
        public string IPaddress3 = string.Empty;
        public string IPaddress4 = string.Empty;
        public string IPaddress5 = string.Empty;
        public string IPaddress6 = string.Empty;
        public string IPaddress7 = string.Empty;     
        public static string res,tags;       
        //public static int date; 
         DAccess2 data2 = new DAccess2();

        //public static Dacc data2 = new DAccess();

        public static int antennaid11;
        //int antenna = Convert.ToInt32(tag.AntennaID);

        internal RFIDReader m_ReaderAPI;
        internal bool m_IsConnected;
        internal bool m_disconnected;
        internal RFIDReader m_ReaderAPI1;
        internal bool m_IsConnected1;
        internal RFIDReader m_ReaderAPI2;
        internal bool m_IsConnected2;
        internal RFIDReader m_ReaderAPI3;
        internal bool m_IsConnected3;
        internal RFIDReader m_ReaderAPI4;
        internal bool m_IsConnected4;
        internal RFIDReader m_ReaderAPI5;
        internal bool m_IsConnected5;
        internal RFIDReader m_ReaderAPI6;
        internal bool m_IsConnected6;
        internal RFIDReader m_ReaderAPI7;
        internal bool m_IsConnected7;

        internal ReaderManagement m_ReaderMgmt;
        internal READER_TYPE m_ReaderType;

        internal AccessFilterForm m_AccessFilterForm;
        internal AntennaInfoForm m_AntennaInfoForm;
        internal ConnectionForm m_ConnectionForm;
        internal LoginForm m_LoginForm;
        internal AntennaModeForm m_AntennaModeForm;
        internal ReadPointForm m_ReadPointForm;
        internal FirmwareUpdateForm m_FirmwareUpdateForm;
        internal ReaderInfoForm m_ReaderInfoForm;

        internal PreFilterForm m_PreFilterForm;
        internal PostFilterForm m_PostFilterForm;
        internal ReadForm m_ReadForm;
        internal WriteForm m_WriteForm;
        internal LockForm m_LockForm;
        internal KillForm m_KillForm;
        internal WriteForm m_BlockWriteForm;
        internal BlockEraseForm m_BlockEraseForm;
        internal LocateForm m_LocateForm;
        internal AccessOperationResult m_AccessOpResult;
        internal TriggersForm m_TriggerForm;
        internal TagStorageSettingsForm m_TagStorageSettingsForm;
        public static string antennaid;
        internal ArrayList m_GPIStateList;
        internal string m_SelectedTagID = "";
        private delegate void UpdateStatus(Events.StatusEventData eventData);
        private UpdateStatus m_UpdateStatusHandler = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead(Events.ReadEventData eventData);
        private UpdateRead m_UpdateReadHandler = null;


        private delegate void UpdateStatus1(Events.StatusEventData eventData1);
        private UpdateStatus m_UpdateStatusHandler1 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead1(Events.ReadEventData eventData1);
        private UpdateRead m_UpdateReadHandler1 = null;


        private delegate void UpdateStatus2(Events.StatusEventData eventData2);
        private UpdateStatus m_UpdateStatusHandler2 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead2(Events.ReadEventData eventData2);
        private UpdateRead m_UpdateReadHandler2 = null;


        private delegate void UpdateStatus3(Events.StatusEventData eventData3);
        private UpdateStatus m_UpdateStatusHandler3 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead3(Events.ReadEventData eventData3);
        private UpdateRead m_UpdateReadHandler3 = null;


        private delegate void UpdateStatus4(Events.StatusEventData eventData4);
        private UpdateStatus m_UpdateStatusHandler4 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead4(Events.ReadEventData eventData4);
        private UpdateRead m_UpdateReadHandler4 = null;


        private delegate void UpdateStatus5(Events.StatusEventData eventData5);
        private UpdateStatus m_UpdateStatusHandler5 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead5(Events.ReadEventData eventData5);
        private UpdateRead m_UpdateReadHandler5 = null;


        private delegate void UpdateStatus6(Events.StatusEventData eventData6);
        private UpdateStatus m_UpdateStatusHandler6 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead6(Events.ReadEventData eventData6);
        private UpdateRead m_UpdateReadHandler6 = null;



        private delegate void UpdateStatus7(Events.StatusEventData eventData7);
        private UpdateStatus m_UpdateStatusHandler7 = null;
        //private delegate void UpdateRead_new(Events.ReadEventData eventData_new, Events rf);
        private delegate void UpdateRead7(Events.ReadEventData eventData7);
        private UpdateRead m_UpdateReadHandler7 = null;



        public TagData m_ReadTag = null;
        public TagData m_ReadTag1 = null;
        private Hashtable m_TagTable;
        private Hashtable m_TagTable1;
        private Hashtable m_TagTable2;
        private Hashtable m_TagTable3;
        private Hashtable m_TagTable4;
        private Hashtable m_TagTable5;
        private Hashtable m_TagTable6;
        private Hashtable m_TagTable7;
        //private int m_SortColumn = -1;
        private uint m_TagTotalCount;
        private uint m_TagTotalCount1;
        //  private int count1;
        //private object nIndex;

        
        internal class AccessOperationResult
        {

            public RFIDResults m_Result;
            public ACCESS_OPERATION_CODE m_OpCode;

            public AccessOperationResult()
            {

                m_Result = RFIDResults.RFID_NO_ACCESS_IN_PROGRESS;
                m_OpCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ;

            }
        }

        public AppForm()
        {

            InitializeComponent();
           // m_GPIStateList = new ArrayList();
           // m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);
          
           //m_UpdateReadHandler = new UpdateRead(myUpdateRead);

           //m_UpdateStatusHandler1 = new UpdateStatus(myUpdateStatus1);

           //m_UpdateReadHandler1 = new UpdateRead(myUpdateRead1);

           //m_UpdateStatusHandler2 = new UpdateStatus(myUpdateStatus2);

           //m_UpdateReadHandler2 = new UpdateRead(myUpdateRead2);

           //m_UpdateStatusHandler3 = new UpdateStatus(myUpdateStatus3);

           //m_UpdateReadHandler3 = new UpdateRead(myUpdateRead3);

           //m_UpdateStatusHandler4 = new UpdateStatus(myUpdateStatus4);

           //m_UpdateReadHandler4 = new UpdateRead(myUpdateRead4);

           //m_UpdateStatusHandler5 = new UpdateStatus(myUpdateStatus5);

           //m_UpdateReadHandler5 = new UpdateRead(myUpdateRead5);

           //m_UpdateStatusHandler6 = new UpdateStatus(myUpdateStatus6);

           //m_UpdateReadHandler6 = new UpdateRead(myUpdateRead6);

           //m_UpdateStatusHandler7 = new UpdateStatus(myUpdateStatus7);

           //m_UpdateReadHandler7 = new UpdateRead(myUpdateRead7);
           // m_ReadTag = new Symbol.RFID3.TagData();

           // m_ConnectionForm = new ConnectionForm(this);
           // m_ReadForm = new ReadForm(this);
           // m_AntennaInfoForm = new AntennaInfoForm(this);
           // m_PostFilterForm = new PostFilterForm(this);
           // m_AccessFilterForm = new AccessFilterForm(this);
           // m_TriggerForm = new TriggersForm(this);
           // m_ReaderMgmt = new ReaderManagement();
           // m_TagTable = new Hashtable();
           // m_TagTable1 = new Hashtable();
           // m_TagTable2 = new Hashtable();
           // m_TagTable3 = new Hashtable();
           // m_TagTable4 = new Hashtable();
           // m_TagTable5 = new Hashtable();
           // m_TagTable6 = new Hashtable();
           // m_TagTable7 = new Hashtable();
           // m_AccessOpResult = new AccessOperationResult();
           // m_IsConnected = false;
           // m_TagTotalCount = 0;
           // configureMenuItemsUponConnectDisconnect();
        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }
            return pingable;
        }

        private void myUpdateStatus(Events.StatusEventData eventData)
        {
            switch (eventData.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                   // this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                   // this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; 
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }



        private void myUpdateStatus1(Events.StatusEventData eventData1)
        {
            switch (eventData1.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                   // memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                   // this.readButton.Enabled = true;
                   // this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData1.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData1.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData1.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker1.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData1.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }


        private void myUpdateStatus2(Events.StatusEventData eventData2)
        {
            switch (eventData2.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                   // this.readButton.Text = "Stop Reading";
                   // memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData2.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData2.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData2.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker2.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData2.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }



        private void myUpdateStatus3(Events.StatusEventData eventData3)
        {
            switch (eventData3.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                   // this.readButton.Text = "Start Reading";
                    memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                   // this.readButton.Enabled = true;
                   // this.readButton.Text = "Stop Reading";
                   // memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                   // this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData3.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData3.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData3.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker3.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData3.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }


        private void myUpdateStatus4(Events.StatusEventData eventData4)
        {
            switch (eventData4.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData4.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData4.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData4.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker4.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData4.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }


        private void myUpdateStatus5(Events.StatusEventData eventData5)
        {
            switch (eventData5.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData5.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData5.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData5.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker5.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData5.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }

        private void myUpdateStatus6(Events.StatusEventData eventData6)
        {
            switch (eventData6.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData6.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData6.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData6.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker6.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData6.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }

        private void myUpdateStatus7(Events.StatusEventData eventData7)
        {
            switch (eventData7.StatusEventType)
            {
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                    functionCallStatusLabel.Text = "Inventory started";
                    //this.readButton.Enabled = true;
                    //this.readButton.Text = "Stop Reading";
                    //memBank_CB.Enabled = false; ;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                    functionCallStatusLabel.Text = "Inventory stopped";
                    //this.readButton.Enabled = true;
                   // this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                    functionCallStatusLabel.Text = "Access Operation started";
                   // this.readButton.Enabled = true;
                   // this.readButton.Text = "Stop Reading";
                   // memBank_CB.Enabled = false;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                    functionCallStatusLabel.Text = "Access Operation stopped";

                    if (this.m_SelectedTagID == string.Empty)
                    {
                        uint successCount, failureCount;
                        successCount = failureCount = 0;
                        m_ReaderAPI.Actions.TagAccess.GetLastAccessResult(ref successCount, ref failureCount);
                        functionCallStatusLabel.Text = "Access completed - Success Count: " + successCount.ToString()
                            + ", Failure Count: " + failureCount.ToString();
                    }
                    resetButtonState();
                   // this.readButton.Enabled = true;
                   // this.readButton.Text = "Start Reading";
                    //memBank_CB.Enabled = true;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.GPI_EVENT:
                    this.updateGPIState();
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.ANTENNA_EVENT:
                    string status = (eventData7.AntennaEventData.AntennaEvent == ANTENNA_EVENT_TYPE.ANTENNA_CONNECTED ? "connected" : "disconnected");
                    functionCallStatusLabel.Text = "Antenna " + eventData7.AntennaEventData.AntennaID.ToString() + " has been " + status;
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                    functionCallStatusLabel.Text = " Buffer full warning";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                    functionCallStatusLabel.Text = "Buffer full";
                    //myUpdateRead(null);
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                    functionCallStatusLabel.Text = "Disconnection Event " + eventData7.DisconnectionEventData.DisconnectEventInfo.ToString();
                    connectBackgroundWorker7.RunWorkerAsync("Disconnect");
                    break;
                case Symbol.RFID3.Events.STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                    functionCallStatusLabel.Text = "Reader ExceptionEvent " + eventData7.ReaderExceptionEventData.ReaderExceptionEventInfo.ToString();
                    break;
                default:
                    break;
            }

        }

        //public void myUpdateRead(Events.ReadEventData eventData)//withsensor
        //{
        //    if (chkin.Checked == true)
        //    {

        //        if (m_IsConnected)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                        //gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //                        if (tagData != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag in tagData)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item = new ListViewItem(tag.TagID);
        //                                ListViewItem.ListViewSubItem subItem;


        //                                subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                                item.SubItems.Add(subItem);

        //                                subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                                item.SubItems.Add(subItem);

        //                                antena1 = Convert.ToInt32(tag.AntennaID.ToString());
        //                                rfids = tag.TagID;

        //                                subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag.TagSeenCount;
        //                                item.SubItems.Add(subItem);

        //                                subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
        //                                item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable.SyncRoot)
        //                                {
        //                                    int dats = Convert.ToInt32(m_TagTable.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    lblcount.Text = final;
        //                                    m_TagTable.Add(rfids, item);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;

        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids;
        //                                row["Reader"] = m_ReaderAPI.HostName;
        //                                row["Antenna"] = antena1;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }



        //                            }

        //                            //else
        //                            //{

        //                            //}
        //                            //}
        //                        }
  
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
                
        //            //gpiLabel.BackColor = System.Drawing.Color.Red;


                              
        //    }
        //    else if (chkout.Checked == true)
        //    {
        //        if (m_IsConnected)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                       // gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //                        if (tagData != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag in tagData)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item = new ListViewItem(tag.TagID);
        //                                ListViewItem.ListViewSubItem subItem;


        //                                subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                                item.SubItems.Add(subItem);

        //                                subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                                item.SubItems.Add(subItem);
        //                                rfids = tag.TagID;

        //                                antena1 = Convert.ToInt32(tag.AntennaID.ToString());

        //                                subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag.TagSeenCount;
        //                                item.SubItems.Add(subItem);

        //                                subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
        //                                item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable.SyncRoot)
        //                                {
        //                                    int dats33 = Convert.ToInt32(m_TagTable.Count);
        //                                    string final33 = Convert.ToString(dats33);
        //                                    lblcount.Text = final33;
        //                                    m_TagTable.Add(rfids, item);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;


        //                                //DataTable tvp = new DataTable();
        //                                //DataTable tbCategories = new DataTable("FilterCategory");
        //                                //tbCategories.Columns.Add("RfidId", typeof(string));
        //                                //tbCategories.Columns.Add("Reader", typeof(string));
        //                                //tbCategories.Columns.Add("Antenna", typeof(string));
        //                                //tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                //DataTable table = new DataTable();
        //                                //DataRow row = tbCategories.NewRow();
        //                                //row["RfidId"] = rfids;
        //                                //row["Reader"] = m_ReaderAPI.HostName;
        //                                //row["Antenna"] = antena1;

        //                                ////rfids = TagID;
        //                                //row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                //tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids + "',getdate(),'" + m_ReaderAPI.HostName + "','"+antena1+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }


        //                            }


        //                            //    }
        //                            //}






        //                            //DataSet ds = new DataSet();
        //                            //       ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                            //       if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                            //       {
        //                            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                            //           Thread.Sleep(700);
        //                            //           //Thread.Sleep(700);
        //                            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                            //           Hashtable hat = new Hashtable();
        //                            //           int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                            //           if (kk > 0)
        //                            //           {

        //                            //           }


        //                            //       }
        //                            //       try
        //                            //       {
        //                            //           if (tag.TagID == "")
        //                            //           {

        //                            //           }
        //                            //           else
        //                            //           {
        //                            //               SqlConnection connection = new SqlConnection();
        //                            //               connection.ConnectionString = connectionString1;
        //                            //               connection.Open();
        //                            //               SqlCommand cmd2 = new SqlCommand();
        //                            //               cmd2.Connection = connection;
        //                            //               cmd2.CommandType = CommandType.StoredProcedure;
        //                            //               cmd2.CommandTimeout = 10000;
        //                            //               cmd2.CommandText = "InsertIntoMyTable1";
        //                            //               cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                            //               int i = cmd2.ExecuteNonQuery();
        //                            //               connection.Close();
        //                            //           }
        //                            //       }
        //                            //       catch (Exception ex)
        //                            //       {

        //                            //       }

        //                            //}
        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
                
        //    }
        //    else if (chkin.Checked == false && chkout.Checked == false)
        //    {
        //        //m_ReaderAPI.Disconnect();
        //        //m_IsConnected = false;
        //    }
        //    else
        //    {
                
        //    }
        //}
        //withoutsensormyUpdateRead
        #region withoutsensor
        public void myUpdateRead(Events.ReadEventData eventData)
        {
            if (chkin.Checked == true)
            {
                //if (m_IsConnected2)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
                if (tagData != null)
                {
                    foreach (Symbol.RFID3.TagData tag in tagData)
                    {
                        
                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                        //{
                        //    if (tagData[nIndex].ContainsLocationInfo)
                        //    {
                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                        //    }

                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                        //    {
                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                        //        tagID = tag.TagID;
                        //        bool isFound = false;

                        //        lock (m_TagTable.SyncRoot)
                        //        {
                        //            isFound = m_TagTable.ContainsKey(tagID);
                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                        //            {
                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                        //                    + tag.MemoryBankDataOffset.ToString();
                        //                isFound = m_TagTable.ContainsKey(tagID);
                        //            }
                        //        }

                        //        if (isFound)
                        //        {
                        //            uint count = 0;
                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                        //            try
                        //            {
                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                        //            }
                        //            catch (FormatException fe)
                        //            {
                        //                functionCallStatusLabel.Text = fe.Message;
                        //                break;
                        //            }
                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                        //            item.SubItems[3].Text = count.ToString();
                        //           // item.SubItems[4].Text = IPaddress;

                        //            string memoryBank = tag.MemoryBank.ToString();
                        //            int index = memoryBank.LastIndexOf('_');
                        //            if (index != -1)
                        //            {
                        //                memoryBank = memoryBank.Substring(index + 1);
                        //            }
                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                        //            {
                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                        //                //item.SubItems[7].Text = memoryBank;
                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                        //                lock (m_TagTable.SyncRoot)
                        //                {
                        //                    m_TagTable.Remove(tagID);
                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                        //                }
                        //            }
                        //            item.SubItems[1].Text = getTagEvent(tag);

                        //        }
                        //        else
                        //        {
                        ListViewItem item = new ListViewItem(tag.TagID);
                        ListViewItem.ListViewSubItem subItem;

                        subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
                        item.SubItems.Add(subItem);
                        
                        //DataSet dss = new DataSet();
                        //dss = d2.select_method_wo_parameter("select top 1 bd.VendorName,bd.PartNo,dc.palletrfid,dc.IPAdddress,dc.LogDate,Status from trolley.dbo.dc_logs_asset dc inner join trolley.dbo.locationmaster bd on bd.rfid=dc.palletrfid where dc.Statusupdate=1 and dc.IPAdddress='" + m_ReaderAPI.HostName + "' and dc.palletrfid='" + tag.TagID + "' order by LogDate desc select * from log_table where rfid='" + tag.TagID + "'  ", "spp");

                        //if (dss != null && dss.Tables[0].Rows.Count > 0)
                        //{
                           
                        //    string status = dss.Tables[1].Rows[0]["Status"].ToString();

                        //    if (status == "W/H IN")
                        //    {
                        //        Hashtable hat = new Hashtable();
                        //        int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='EMPTY' where RFID='" + tag.TagID + "'  ", hat, "spp");

                        //        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                        //    }
                        //    if (status == "EMPTY")
                        //    {
                        //        Hashtable hat = new Hashtable();
                        //        int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='W/H IN' where RFID='" + tag.TagID + "'  ", hat, "spp");

                        //        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                        //    }

                        //}
                        //else
                        //{
                        //    Hashtable hat = new Hashtable();
                        //    string status = "W/H IN";
                        //    int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag.TagID + "',getdate(),'" + status + "' ", hat, "spp");

                        //    int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");

                        //}

                        //subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                        //item.SubItems.Add(subItem);

                        antena1 = Convert.ToInt32(tag.AntennaID.ToString());
                        rfids = tag.TagID;
                        
                        //subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                        //m_TagTotalCount += tag.TagSeenCount;
                        //item.SubItems.Add(subItem);

                        //subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
                        //item.SubItems.Add(subItem);

                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                        //item.SubItems.Add(subItem);

                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                        //item.SubItems.Add(subItem);

                        //if (memBank_CB.SelectedIndex >= 1)
                        //{
                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                        //    //item.SubItems.Add(subItem);

                        //    string memoryBank = tag.MemoryBank.ToString();
                        //    int index = memoryBank.LastIndexOf('_');
                        //    if (index != -1)
                        //    {
                        //        memoryBank = memoryBank.Substring(index + 1);
                        //    }

                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                        //    //item.SubItems.Add(subItem);
                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                        //    //item.SubItems.Add(subItem);
                        //}
                        //else
                        //{
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //}
                        //inventoryList.BeginUpdate();
                        //inventoryList.Items.Add(item2);
                        //inventoryList.EndUpdate();

                        //lock (m_TagTable.SyncRoot)
                        //{
                        //    //int dats = Convert.ToInt32(m_TagTable.Count);
                        //    //string final = Convert.ToString(dats);
                        //    //lblcount.Text = final;
                        //    m_TagTable.Add(rfids, item);
                        //}

                        //inventoryList.Columns[0].Width = 250;
                        //inventoryList.Columns[1].Width = 100;
                        //inventoryList.Columns[2].Width = 100;
                        //inventoryList.Columns[3].Width = 100;
                        //inventoryList.Columns[4].Width = 150;



                        DataTable tvp = new DataTable();
                        DataTable tbCategories = new DataTable("FilterCategory");
                        tbCategories.Columns.Add("RfidId", typeof(string));
                        tbCategories.Columns.Add("Reader", typeof(string));
                        tbCategories.Columns.Add("Antenna", typeof(string));
                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                        DataTable table = new DataTable();
                        DataRow row = tbCategories.NewRow();
                        row["RfidId"] = rfids;
                        row["Reader"] = m_ReaderAPI.HostName;
                        row["Antenna"] = antena1;

                        //rfids = tag.TagID;
                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                        tbCategories.Rows.Add(row);


                        //DataSet ds = new DataSet();
                        //ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                        //if (ds != null && ds.Tables[0].Rows.Count > 0)
                        //{
                        //    //m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                        //    //Thread.Sleep(700);
                        //    //Thread.Sleep(700);
                        //    //m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                        //    Hashtable hat = new Hashtable();
                        //    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                        //    if (kk > 0)
                        //    {

                        //    }


                        //}
                        try
                        {
                            if (rfids == "")
                            {

                            }
                            else
                            {
                                SqlConnection connection = new SqlConnection();
                                connection.ConnectionString = connectionString1;
                                connection.Open();
                                SqlCommand cmd2 = new SqlCommand();
                                cmd2.Connection = connection;
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.CommandTimeout = 10000;
                                cmd2.CommandText = "InsertIntoMyTable1";
                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                int i = cmd2.ExecuteNonQuery();
                                connection.Close();


                                DataSet dsss1 = new DataSet();
                                dsss1 = d2.select_method_wo_parameter("select top 1 bd.rackname,dc.palletrfid,dc.IPAdddress,dc.LogDate from trolley.dbo.dc_logs_asset dc inner join trolley.dbo.locationmaster bd on bd.rfid=dc.palletrfid where dc.Statusupdate=1 and dc.IPAdddress='" + m_ReaderAPI.HostName + "' and dc.palletrfid='" + tag.TagID + "'  order by LogDate desc  ", "spp");

                                if (dsss1.Tables[0].Rows.Count > 0)
                                {

                                    DataSet dsss = new DataSet();
                                    dsss = d2.select_method_wo_parameter("select * from trolley.dbo.log_table where RFID='" + tag.TagID + "'", "spp");
                                    if (dsss.Tables[0].Rows.Count > 0)
                                    {
                                        string status = dsss.Tables[0].Rows[0]["Status"].ToString();
                                        if (status == "EMPTY")
                                        {
                                            Hashtable hat = new Hashtable();
                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='WAREHOUSEIN' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        }
                                        if (status == "WAREHOUSEIN")
                                        {
                                            Hashtable hat = new Hashtable();
                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='WAREHOUSEIN' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        }
                                        if (status == "DISPATCH")
                                        {
                                            Hashtable hat = new Hashtable();
                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='WAREHOUSEIN' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        }

                                        //if (status == "EMPTY")
                                        //{
                                        //    Hashtable hat = new Hashtable();
                                        //    int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='Dispatch' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                        //    int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        //}
                                    }
                                    else
                                    {
                                        Hashtable hat = new Hashtable();
                                        string status = "WAREHOUSEIN";
                                        int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag.TagID + "',getdate(),'" + status + "') ", hat, "spp");

                                        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and Statusupdate=1 ", hat, "spp");
                                    }

                                }


                                
                            }
                        }
                        catch (Exception ex)
                        {

                        }



                    }

                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}


            }
            else if (chkout.Checked == true)
            {

                //if (m_IsConnected2)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
                if (tagData != null)
                {
                    foreach (Symbol.RFID3.TagData tag in tagData)
                    {


                        //        }
                        //        else
                        //        {
                        ListViewItem item = new ListViewItem(tag.TagID);
                        ListViewItem.ListViewSubItem subItem;


                        subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
                        item.SubItems.Add(subItem);

                        DataSet dss = new DataSet();
                        dss = d2.select_method_wo_parameter("select top 1 bd.VendorName,bd.PartNo,dc.palletrfid,dc.IPAdddress,dc.LogDate,Status from trolley.dbo.dc_logs_asset dc inner join trolley.dbo.locationmaster bd on bd.rfid=dc.palletrfid where dc.Statusupdate=1 and dc.IPAdddress='" + m_ReaderAPI.HostName + "' order by LogDate desc select * from log_table where rfid='" + tag.TagID + "'  ", "spp");

                        if (dss != null && dss.Tables[0].Rows.Count > 0)
                        {
                            string status = dss.Tables[1].Rows[0]["Status"].ToString();
                            if (status == "W/H IN")
                            {
                                Hashtable hat = new Hashtable();
                                string status1 = "OUT(dispatch)";
                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                            }
                            if (status == "OUT(dispatch)")
                            {
                                Hashtable hat = new Hashtable();
                                string status1 = "W/H IN";
                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                            }
                            if (status == "EMPTY")
                            {
                                Hashtable hat = new Hashtable();
                                string status1 = "W/H Im Assembley";
                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");

                            }
                            if (status == "W/H Im Assembley")
                            {
                                Hashtable hat = new Hashtable();
                                string status1 = "EMPTY";
                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag.TagID + "'  ", hat, "spp");

                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                            }

                        }
                        else
                        {
                            Hashtable hat = new Hashtable();
                            string status = "W/H IN";
                            int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag.TagID + "',getdate(),'" + status + "' ", hat, "spp");

                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag.TagID + "' and dc.Statusupdate=1 ", hat, "spp");

                        }


                        //subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
                        //item.SubItems.Add(subItem);

                        antena1 = Convert.ToInt32(tag.AntennaID.ToString());
                        rfids = tag.TagID;

                        //subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
                        //m_TagTotalCount += tag.TagSeenCount;
                        //item.SubItems.Add(subItem);

                        //subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
                        //item.SubItems.Add(subItem);

                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                        //item.SubItems.Add(subItem);


                        //else
                        //{
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                        //    item.SubItems.Add(subItem);
                        //}
                        //inventoryList.BeginUpdate();
                        //inventoryList.Items.Add(item2);
                        //inventoryList.EndUpdate();

                        lock (m_TagTable.SyncRoot)
                        {

                            //int dats2 = Convert.ToInt32(m_TagTable.Count);
                            //string final2 = Convert.ToString(dats2);
                            //lblcount.Text = final2;
                            m_TagTable.Add(rfids, item);
                        }

                        //inventoryList.Columns[0].Width = 250;
                        //inventoryList.Columns[1].Width = 100;
                        //inventoryList.Columns[2].Width = 100;
                        //inventoryList.Columns[3].Width = 100;
                        //inventoryList.Columns[4].Width = 150;



                        DataTable tvp = new DataTable();
                        DataTable tbCategories = new DataTable("FilterCategory");
                        tbCategories.Columns.Add("RfidId", typeof(string));
                        tbCategories.Columns.Add("Reader", typeof(string));
                        tbCategories.Columns.Add("Antenna", typeof(string));
                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                        DataTable table = new DataTable();
                        DataRow row = tbCategories.NewRow();
                        row["RfidId"] = rfids;
                        row["Reader"] = m_ReaderAPI.HostName;
                        row["Antenna"] = antena1;

                        // rfids = tag.TagID;
                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                        tbCategories.Rows.Add(row);

                        //DataSet ds = new DataSet();
                        //ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                        //if (ds != null && ds.Tables[0].Rows.Count > 0)
                        //{
                        //    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                        //    Thread.Sleep(700);
                        //    //Thread.Sleep(700);
                        //    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                        //    Hashtable hat = new Hashtable();
                        //    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                        //    if (kk > 0)
                        //    {

                        //    }


                        //}




                        //btna1.BackColor = System.Drawing.Color.Green;
                        //btna2.BackColor = System.Drawing.Color.Red;
                        //btna3.BackColor = System.Drawing.Color.Red;
                        //btna4.BackColor = System.Drawing.Color.Red;
                        //btna5.BackColor = System.Drawing.Color.Red;
                        //btna6.BackColor = System.Drawing.Color.Red;
                        //btna7.BackColor = System.Drawing.Color.Red;
                        //btna8.BackColor = System.Drawing.Color.Red;


                        //DataSet dsss = new DataSet();
                        //dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids + "'", "spp");
                        //if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                        //{
                        //    Hashtable hats = new Hashtable();
                        //    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids + "'", hats, "spp");
                        //    if (up > 0)
                        //    {

                        //    }
                        //    else
                        //    {

                        //    }
                        //}
                        //else
                        //{
                        //    Hashtable hats1 = new Hashtable();
                        //    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids + "',getdate(),'" + m_ReaderAPI.HostName + "','" + antena3 + "')", hats1, "spp");
                        //    if (ups > 0)
                        //    {

                        //    }
                        //    else
                        //    {

                        //    }

                        //}



                    }
                    //}


                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}


            }
            else
            {

            }
        }
        #endregion


        //#region withsensormyUpdateRead
        //public void myUpdateRead(Events.ReadEventData eventData)
        //{
        //    if (chkin.Checked == true)
        //    {
        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //        if (tagData != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag in tagData)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item = new ListViewItem(tag.TagID);
        //                ListViewItem.ListViewSubItem subItem;


        //                subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                //item.SubItems.Add(subItem);

        //                antena1 = Convert.ToInt32(tag.AntennaID.ToString());
        //                rfids = tag.TagID;

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag.TagSeenCount;
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable.SyncRoot)
        //                {
        //                    //int dats = Convert.ToInt32(m_TagTable.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //lblcount.Text = final;
        //                    m_TagTable.Add(rfids, item);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids;
        //                row["Reader"] = m_ReaderAPI.HostName;
        //                row["Antenna"] = antena1;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }


        //    }
        //    else if (chkout.Checked == true)
        //    {

        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //        if (tagData != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag in tagData)
        //            {


        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item = new ListViewItem(tag.TagID);
        //                ListViewItem.ListViewSubItem subItem;


        //                subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                //item.SubItems.Add(subItem);

        //                antena1 = Convert.ToInt32(tag.AntennaID.ToString());
        //                rfids = tag.TagID;

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag.TagSeenCount;
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, m_ReaderAPI.HostName);
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);


        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable.SyncRoot)
        //                {

        //                    //int dats2 = Convert.ToInt32(m_TagTable.Count);
        //                    //string final2 = Convert.ToString(dats2);
        //                    //lblcount.Text = final2;
        //                    m_TagTable.Add(rfids, item);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids;
        //                row["Reader"] = m_ReaderAPI.HostName;
        //                row["Antenna"] = antena1;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids + "',getdate(),'" + m_ReaderAPI.HostName + "','" + antena3 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }
        //            //}


        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }


        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion


        //withoutsensor

        //public void myUpdateRead1(Events.ReadEventData eventData1)
        //{
        //    if (chkin1.Checked == true)
        //    {
        //        //if (m_IsConnected2)
        //        //{
        //        //    for (int index = 0; index < 8; index++)
        //        //    {
        //        //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //        //        {

        //        //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //        //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //        //            {

        //        //            }
        //        //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //        //            {
        //        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
        //        if (tagData1 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                ListViewItem.ListViewSubItem subItem1;


        //                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                item1.SubItems.Add(subItem1);

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                item1.SubItems.Add(subItem1);

        //                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                rfids1 = tag1.TagID;

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                m_TagTotalCount += tag1.TagSeenCount;
        //                item1.SubItems.Add(subItem1);

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                item1.SubItems.Add(subItem1);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable1.SyncRoot)
        //                {
        //                    //int dats = Convert.ToInt32(m_TagTable.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //lblcount.Text = final;
        //                    m_TagTable1.Add(rfids1, item1);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids1;
        //                row["Reader"] = m_ReaderAPI1.HostName;
        //                row["Antenna"] = antena2;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids1 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }



        //            }

        //        }
        //        //            }
        //        //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //        //            {

        //        //            }
        //        //        }
        //        //    }
        //        //}


        //    }
        //    else if (chkout1.Checked == true)
        //    {

        //        //if (m_IsConnected2)
        //        //{
        //        //    for (int index = 0; index < 8; index++)
        //        //    {
        //        //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //        //        {

        //        //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //        //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //        //            {

        //        //            }
        //        //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //        //            {
        //        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
        //        if (tagData1 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //            {


        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                ListViewItem.ListViewSubItem subItem1;


        //                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                item1.SubItems.Add(subItem1);

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                item1.SubItems.Add(subItem1);

        //                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                rfids1 = tag1.TagID;

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                m_TagTotalCount += tag1.TagSeenCount;
        //                item1.SubItems.Add(subItem1);

        //                subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                item1.SubItems.Add(subItem1);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);


        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable1.SyncRoot)
        //                {

        //                    //int dats2 = Convert.ToInt32(m_TagTable1.Count);
        //                    //string final2 = Convert.ToString(dats2);
        //                    //lblcount.Text = final2;
        //                    m_TagTable1.Add(rfids1, item1);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids1;
        //                row["Reader"] = m_ReaderAPI1.HostName;
        //                row["Antenna"] = antena2;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids1 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids1 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids1 + "',getdate(),'" + m_ReaderAPI1.HostName + "','" + antena3 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }
        //            //}


        //        }
        //        //            }
        //        //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //        //            {

        //        //            }
        //        //        }
        //        //    }
        //        //}


        //    }
        //    else
        //    {

        //    }
        //}
        //withsensor

        //public void myUpdateRead1(Events.ReadEventData eventData1)
        //{

        //    if (chkin1.Checked == true)
        //    {
        //        if (m_IsConnected1)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                        ///gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
        //                        if (tagData1 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)

        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                                ListViewItem.ListViewSubItem subItem1;


        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                                item1.SubItems.Add(subItem1);

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                                item1.SubItems.Add(subItem1);

        //                                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                                rfids1 = tag1.TagID;

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag1.TagSeenCount;
        //                                item1.SubItems.Add(subItem1);

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                                item1.SubItems.Add(subItem1);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);


        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item1);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable1.SyncRoot)
        //                                {
        //                                    int dats1 = Convert.ToInt32(m_TagTable1.Count);
        //                                    string final1 = Convert.ToString(dats1);
        //                                    label16.Text = final1;
        //                                    m_TagTable1.Add(rfids1, item1);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;

        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids1;
        //                                row["Reader"] = m_ReaderAPI1.HostName;
        //                                row["Antenna"] = antena2;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids1 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }



        //                            }


        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
                
        //    }
        //    else if (chkout1.Checked == true)
        //    {
        //        if (m_IsConnected1)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                        //gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
        //                        if (tagData1 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                                ListViewItem.ListViewSubItem subItem1;


        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                                item1.SubItems.Add(subItem1);

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                                item1.SubItems.Add(subItem1);

        //                                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                                rfids1 = tag1.TagID;

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag1.TagSeenCount;
        //                                item1.SubItems.Add(subItem1);

        //                                subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                                item1.SubItems.Add(subItem1);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item1);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable1.SyncRoot)
        //                                {
        //                                    int dats18 = Convert.ToInt32(m_TagTable1.Count);
        //                                    string final18 = Convert.ToString(dats18);
        //                                    label16.Text = final18;
        //                                    m_TagTable1.Add(rfids1, item1);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;

        //                                //DataTable tvp = new DataTable();
        //                                //DataTable tbCategories = new DataTable("FilterCategory");
        //                                //tbCategories.Columns.Add("RfidId", typeof(string));
        //                                //tbCategories.Columns.Add("Reader", typeof(string));
        //                                //tbCategories.Columns.Add("Antenna", typeof(string));
        //                                //tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                //DataTable table = new DataTable();
        //                                //DataRow row = tbCategories.NewRow();
        //                                //row["RfidId"] = rfids1;
        //                                //row["Reader"] = m_ReaderAPI1.HostName;
        //                                //row["Antenna"] = antena2;

        //                                //// rfids = tag.TagID;
        //                                //row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                //tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids1 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids1 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids1 + "',getdate(),'" + m_ReaderAPI1.HostName + "','"+antena2+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }




        //                            }
        //                            //}






        //                            //DataSet ds = new DataSet();
        //                            //       ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                            //       if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                            //       {
        //                            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                            //           Thread.Sleep(700);
        //                            //           //Thread.Sleep(700);
        //                            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                            //           Hashtable hat = new Hashtable();
        //                            //           int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                            //           if (kk > 0)
        //                            //           {

        //                            //           }


        //                            //       }
        //                            //       try
        //                            //       {
        //                            //           if (tag.TagID == "")
        //                            //           {

        //                            //           }
        //                            //           else
        //                            //           {
        //                            //               SqlConnection connection = new SqlConnection();
        //                            //               connection.ConnectionString = connectionString1;
        //                            //               connection.Open();
        //                            //               SqlCommand cmd2 = new SqlCommand();
        //                            //               cmd2.Connection = connection;
        //                            //               cmd2.CommandType = CommandType.StoredProcedure;
        //                            //               cmd2.CommandTimeout = 10000;
        //                            //               cmd2.CommandText = "InsertIntoMyTable1";
        //                            //               cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                            //               int i = cmd2.ExecuteNonQuery();
        //                            //               connection.Close();
        //                            //           }
        //                            //       }
        //                            //       catch (Exception ex)
        //                            //       {

        //                            //       }

        //                            //}
        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
                
        //    }
        //    else
        //    {

        //    }
        //}

        //wihthoutsensor

        #region withoutsensormyUpdateRead1

        public void myUpdateRead1(Events.ReadEventData eventData1)
        {

            if (chkin1.Checked == true)
            {
                //if (m_IsConnected1)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
                //        {
                //            //Label gpiLabel = (Label)m_GPIStateList[index];
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {
                //                ///gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
                                if (tagData1 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag1 in tagData1)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)

                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item1 = new ListViewItem(tag1.TagID);
                                        ListViewItem.ListViewSubItem subItem1;


                                        subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
                                        item1.SubItems.Add(subItem1);


                                       

                                        //    string status = dsss1.Tables[1].Rows[0]["Status"].ToString();

                                        //    if (status == "W/H IN")
                                        //    {
                                        //        Hashtable hat = new Hashtable();
                                        //        int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='Dispatch' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                        //        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                                        //    }
                                        //    if (status == "Dispatch")
                                        //    {
                                        //        Hashtable hat = new Hashtable();
                                        //        int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='EMPTY' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                        //        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        //    }
                                        //    if (status == "EMPTY")
                                        //    {
                                        //        Hashtable hat = new Hashtable();
                                        //        int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='Dispatch' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                        //        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    Hashtable hat = new Hashtable();
                                        //    string status = "EMPTY";
                                        //    int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag1.TagID + "',getdate(),'" + status + "') ", hat, "spp");

                                        //    int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");

                                        //}
                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
                                        //item1.SubItems.Add(subItem1);

                                        antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
                                        rfids1 = tag1.TagID;

                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag1.TagSeenCount;
                                        //item1.SubItems.Add(subItem1);

                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
                                        //item1.SubItems.Add(subItem1);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);


                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item1);
                                        //inventoryList.EndUpdate();

                                        //lock (m_TagTable1.SyncRoot)
                                        //{
                                        //    //int dats1 = Convert.ToInt32(m_TagTable1.Count);
                                        //    //string final1 = Convert.ToString(dats1);
                                        //    //label16.Text = final1;
                                        //    m_TagTable1.Add(rfids1, item1);
                                        //}

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;

                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids1;
                                        row["Reader"] = m_ReaderAPI1.HostName;
                                        row["Antenna"] = antena2;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        //DataSet ds = new DataSet();
                                        //ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        //if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        //{
                                        //    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                        //    Thread.Sleep(700);
                                        //    //Thread.Sleep(700);
                                        //    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                        //    Hashtable hat = new Hashtable();
                                        //    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                        //    if (kk > 0)
                                        //    {

                                        //    }


                                        //}
                                        try
                                        {
                                            if (rfids1 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable2";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();

                                                DataSet dsss1 = new DataSet();
                                                dsss1 = d2.select_method_wo_parameter("select top 1 bd.rackname,dc.palletrfid,dc.IPAdddress,dc.LogDate from trolley.dbo.dc_logs_asset dc inner join trolley.dbo.locationmaster bd on bd.rfid=dc.palletrfid where dc.Statusupdate=1 and dc.IPAdddress='" + m_ReaderAPI1.HostName + "' and dc.palletrfid='" + tag1.TagID + "'  order by LogDate desc  ", "spp");

                                                if (dsss1.Tables[0].Rows.Count > 0)
                                                {

                                                    DataSet dsss = new DataSet();
                                                    dsss = d2.select_method_wo_parameter("select * from trolley.dbo.log_table where RFID='" + tag1.TagID + "'", "spp");
                                                    if (dsss.Tables[0].Rows.Count > 0)
                                                    {
                                                        string status = dsss.Tables[0].Rows[0]["Status"].ToString();

                                                        if (status == "EMPTY")
                                                        {
                                                            Hashtable hat = new Hashtable();
                                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='EMPTY' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                        }
                                                        if (status == "DISPATCH")
                                                        {
                                                            Hashtable hat = new Hashtable();
                                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='EMPTY' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                        }
                                                        if (status == "WAREHOUSEIN")
                                                        {
                                                            Hashtable hat = new Hashtable();
                                                            int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='DISPATCH' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                        }
                                                        //if (status == "Dispatch")
                                                        //{
                                                        //    Hashtable hat = new Hashtable();
                                                        //    int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='EMPTY' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                        //    int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                        //}
                                                        //if (status == "EMPTY")
                                                        //{
                                                        //    Hashtable hat = new Hashtable();
                                                        //    int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='Dispatch' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                        //    int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                        //}
                                                    }
                                                    else
                                                    {
                                                        Hashtable hat = new Hashtable();
                                                        string status = "EMPTY";
                                                        int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag1.TagID + "',getdate(),'" + status + "') ", hat, "spp");

                                                        int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and Statusupdate=1 ", hat, "spp");
                                                    }
                                                    
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }



                                    }


                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout1.Checked == true)
            {
               // this.m_TagTable.Clear();
                //if (m_IsConnected1)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
                //        {
                //            //Label gpiLabel = (Label)m_GPIStateList[index];
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {
                //                //gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(2000);
                                if (tagData1 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag1 in tagData1)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item1 = new ListViewItem(tag1.TagID);
                                        ListViewItem.ListViewSubItem subItem1;

                                        DataSet dsss1 = new DataSet();
                                        dsss1 = d2.select_method_wo_parameter("select top 1 bd.VendorName,bd.PartNo,dc.palletrfid,dc.IPAdddress,dc.LogDate,Status from trolley.dbo.dc_logs_asset dc inner join trolley.dbo.locationmaster bd on bd.rfid=dc.palletrfid where dc.Statusupdate=1 and dc.IPAdddress='" + m_ReaderAPI1.HostName + "' order by LogDate desc select * from log_table where rfid='" + tag1.TagID + "' ", "spp");

                                        if (dsss1 != null && dsss1.Tables[0].Rows.Count > 0)
                                        {
                                            string status = dsss1.Tables[1].Rows[0]["Status"].ToString();
                                            if (status == "EMPTY")
                                            {
                                                Hashtable hat = new Hashtable();
                                                string status1 = "W/H Im Assembley";
                                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");

                                            }
                                            if (status == "W/H Im Assembley")
                                            {
                                                Hashtable hat = new Hashtable();
                                                string status1 = "EMPTY";
                                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                                            }
                                            if (status == "W/H IN")
                                            {
                                                Hashtable hat = new Hashtable();
                                                string status1 = "OUT(dispatch)";
                                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                                            }
                                            if (status == "OUT(dispatch)")
                                            {
                                                Hashtable hat = new Hashtable();
                                                string status1 = "W/H IN";
                                                int insert = d2.insert_method("update trolley.dbo.log_table set Updatedtime=getdate(),status='" + status1 + "' where RFID='" + tag1.TagID + "'  ", hat, "spp");

                                                int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");
                                            }

                                        }
                                        else
                                        {
                                            Hashtable hat = new Hashtable();
                                            string status = "EMPTY";
                                            int insert = d2.insert_method("insert into trolley.dbo.log_table(RFID,Updatedtime,Status) values('" + tag1.TagID + "',getdate(),'" + status + "' ", hat, "spp");

                                            int update = d2.insert_method("update trolley.dbo.dc_logs_asset set Statusupdate=0 where palletrfid='" + tag1.TagID + "' and dc.Statusupdate=1 ", hat, "spp");

                                        }


                                        subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
                                        item1.SubItems.Add(subItem1);

                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
                                        //item1.SubItems.Add(subItem1);

                                        antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
                                        rfids1 = tag1.TagID;

                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag1.TagSeenCount;
                                        //item1.SubItems.Add(subItem1);

                                        //subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
                                        //item1.SubItems.Add(subItem1);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item1);
                                        //inventoryList.EndUpdate();





                                        // String val = tag1.TagID;

                                        lock (m_TagTable1.SyncRoot)
                                        {

                                            m_TagTable1.Add(tag1.TagID, item1);
                                        }

                                        //int dats18 = Convert.ToInt32(m_TagTable1.Count);
                                        //string final18 = Convert.ToString(dats18);
                                        //  label16.Text = Convert.ToString(m_TagTable1.Count);

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;

                                        //DataTable tvp = new DataTable();
                                        //DataTable tbCategories = new DataTable("FilterCategory");
                                        //tbCategories.Columns.Add("RfidId", typeof(string));
                                        //tbCategories.Columns.Add("Reader", typeof(string));
                                        //tbCategories.Columns.Add("Antenna", typeof(string));
                                        //tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        //DataTable table = new DataTable();
                                        //DataRow row = tbCategories.NewRow();
                                        //row["RfidId"] = rfids1;
                                        //row["Reader"] = m_ReaderAPI1.HostName;
                                        //row["Antenna"] = antena2;

                                        //// rfids = tag.TagID;
                                        //row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        //tbCategories.Rows.Add(row);

                                        //DataSet ds = new DataSet();
                                        //ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        //if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        //{
                                        //    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                        //    Thread.Sleep(700);
                                        //    //Thread.Sleep(700);
                                        //    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                        //    Hashtable hat = new Hashtable();
                                        //    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                        //    if (kk > 0)
                                        //    {

                                        //    }


                                        //}




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        //DataSet dsss = new DataSet();
                                        //dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids1 + "'", "spp");
                                        //if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        //{
                                        //    Hashtable hats = new Hashtable();
                                        //    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids1 + "'", hats, "spp");
                                        //    if (up > 0)
                                        //    {

                                        //    }
                                        //    else
                                        //    {

                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    Hashtable hats1 = new Hashtable();
                                        //    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids1 + "',getdate(),'" + m_ReaderAPI1.HostName + "','" + antena2 + "')", hats1, "spp");
                                        //    if (ups > 0)
                                        //    {

                                        //    }
                                        //    else
                                        //    {

                                        //    }

                                        //}


                                    }

                                    //}
                                    //}






                                    //DataSet ds = new DataSet();
                                    //       ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                    //       if (ds != null && ds.Tables[0].Rows.Count > 0)
                                    //       {
                                    //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                    //           Thread.Sleep(700);
                                    //           //Thread.Sleep(700);
                                    //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                    //           Hashtable hat = new Hashtable();
                                    //           int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
                                    //           if (kk > 0)
                                    //           {

                                    //           }


                                    //       }
                                    //       try
                                    //       {
                                    //           if (tag.TagID == "")
                                    //           {

                                    //           }
                                    //           else
                                    //           {
                                    //               SqlConnection connection = new SqlConnection();
                                    //               connection.ConnectionString = connectionString1;
                                    //               connection.Open();
                                    //               SqlCommand cmd2 = new SqlCommand();
                                    //               cmd2.Connection = connection;
                                    //               cmd2.CommandType = CommandType.StoredProcedure;
                                    //               cmd2.CommandTimeout = 10000;
                                    //               cmd2.CommandText = "InsertIntoMyTable1";
                                    //               cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                    //               int i = cmd2.ExecuteNonQuery();
                                    //               connection.Close();
                                    //           }
                                    //       }
                                    //       catch (Exception ex)
                                    //       {

                                    //       }

                                    //}
                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }

        #endregion

        //#region withsensormyUpdateRead1
        //public void myUpdateRead1(Events.ReadEventData eventData1)
        //{

        //    if (chkin1.Checked == true)
        //    {
        //        if (m_IsConnected1)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                        ///gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(1000);
        //        if (tagData1 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)

        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                ListViewItem.ListViewSubItem subItem1;


        //                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                item1.SubItems.Add(subItem1);

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                //item1.SubItems.Add(subItem1);

        //                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                rfids1 = tag1.TagID;

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag1.TagSeenCount;
        //                //item1.SubItems.Add(subItem1);

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                //item1.SubItems.Add(subItem1);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);


        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item1);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable1.SyncRoot)
        //                {
        //                    //int dats1 = Convert.ToInt32(m_TagTable1.Count);
        //                    //string final1 = Convert.ToString(dats1);
        //                    //label16.Text = final1;
        //                    m_TagTable1.Add(rfids1, item1);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;

        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids1;
        //                row["Reader"] = m_ReaderAPI1.HostName;
        //                row["Antenna"] = antena2;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids1 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }



        //            }


        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout1.Checked == true)
        //    {
        //        // this.m_TagTable.Clear();
        //        if (m_IsConnected1)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI1.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    //Label gpiLabel = (Label)m_GPIStateList[index];
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI1.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
        //                        //gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData1 = m_ReaderAPI1.Actions.GetReadTags(2000);
        //        if (tagData1 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag1 in tagData1)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item1 = new ListViewItem(tag1.TagID);
        //                ListViewItem.ListViewSubItem subItem1;


        //                subItem1 = new ListViewItem.ListViewSubItem(item1, getTagEvent(tag1));
        //                item1.SubItems.Add(subItem1);

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.AntennaID.ToString());
        //                //item1.SubItems.Add(subItem1);

        //                antena2 = Convert.ToInt32(tag1.AntennaID.ToString());
        //                rfids1 = tag1.TagID;

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, tag1.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag1.TagSeenCount;
        //                //item1.SubItems.Add(subItem1);

        //                //subItem1 = new ListViewItem.ListViewSubItem(item1, m_ReaderAPI1.HostName);
        //                //item1.SubItems.Add(subItem1);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item1);
        //                //inventoryList.EndUpdate();





        //                // String val = tag1.TagID;

        //                lock (m_TagTable1.SyncRoot)
        //                {

        //                    m_TagTable1.Add(tag1.TagID, item1);
        //                }

        //                //int dats18 = Convert.ToInt32(m_TagTable1.Count);
        //                //string final18 = Convert.ToString(dats18);
        //                //  label16.Text = Convert.ToString(m_TagTable1.Count);

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;

        //                //DataTable tvp = new DataTable();
        //                //DataTable tbCategories = new DataTable("FilterCategory");
        //                //tbCategories.Columns.Add("RfidId", typeof(string));
        //                //tbCategories.Columns.Add("Reader", typeof(string));
        //                //tbCategories.Columns.Add("Antenna", typeof(string));
        //                //tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                //DataTable table = new DataTable();
        //                //DataRow row = tbCategories.NewRow();
        //                //row["RfidId"] = rfids1;
        //                //row["Reader"] = m_ReaderAPI1.HostName;
        //                //row["Antenna"] = antena2;

        //                //// rfids = tag.TagID;
        //                //row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                //tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI1.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids1 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids1 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids1 + "',getdate(),'" + m_ReaderAPI1.HostName + "','" + antena2 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }


        //            }

        //            //}
        //            //}






        //            //DataSet ds = new DataSet();
        //            //       ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //            //       if (ds != null && ds.Tables[0].Rows.Count > 0)
        //            //       {
        //            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //            //           Thread.Sleep(700);
        //            //           //Thread.Sleep(700);
        //            //           m_ReaderAPI.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //            //           Hashtable hat = new Hashtable();
        //            //           int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //            //           if (kk > 0)
        //            //           {

        //            //           }


        //            //       }
        //            //       try
        //            //       {
        //            //           if (tag.TagID == "")
        //            //           {

        //            //           }
        //            //           else
        //            //           {
        //            //               SqlConnection connection = new SqlConnection();
        //            //               connection.ConnectionString = connectionString1;
        //            //               connection.Open();
        //            //               SqlCommand cmd2 = new SqlCommand();
        //            //               cmd2.Connection = connection;
        //            //               cmd2.CommandType = CommandType.StoredProcedure;
        //            //               cmd2.CommandTimeout = 10000;
        //            //               cmd2.CommandText = "InsertIntoMyTable1";
        //            //               cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //            //               int i = cmd2.ExecuteNonQuery();
        //            //               connection.Close();
        //            //           }
        //            //       }
        //            //       catch (Exception ex)
        //            //       {

        //            //       }

        //            //}
        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion


        //withsensor
        //public void myUpdateRead2(Events.ReadEventData eventData2)
        //{
        //    if (chkin2.Checked == true)
        //    {
        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {
                            
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
                                
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
        //                        if (tagData2 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag2 in tagData2)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item2 = new ListViewItem(tag2.TagID);
        //                                ListViewItem.ListViewSubItem subItem2;


        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
        //                                item2.SubItems.Add(subItem2);

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
        //                                item2.SubItems.Add(subItem2);

        //                                antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
        //                                rfids2 = tag2.TagID;

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag2.TagSeenCount;
        //                                item2.SubItems.Add(subItem2);

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
        //                                item2.SubItems.Add(subItem2);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item2);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable2.SyncRoot)
        //                                {
        //                                    int dats = Convert.ToInt32(m_TagTable2.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label15.Text = final;
        //                                    m_TagTable2.Add(rfids2, item2);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids2;
        //                                row["Reader"] = m_ReaderAPI2.HostName;
        //                                row["Antenna"] = antena3;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids2 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

         
        //    }
        //    else if (chkout2.Checked == true)
        //    {

        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {
                           
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
                                
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
        //                        if (tagData2 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag2 in tagData2)
        //                            {


        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item2 = new ListViewItem(tag2.TagID);
        //                                ListViewItem.ListViewSubItem subItem2;


        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
        //                                item2.SubItems.Add(subItem2);

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
        //                                item2.SubItems.Add(subItem2);

        //                                antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
        //                                rfids2 = tag2.TagID;

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag2.TagSeenCount;
        //                                item2.SubItems.Add(subItem2);

        //                                subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
        //                                item2.SubItems.Add(subItem2);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);


        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item2);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable2.SyncRoot)
        //                                {

        //                                    int dats2 = Convert.ToInt32(m_TagTable2.Count);
        //                                    string final2 = Convert.ToString(dats2);
        //                                    label15.Text = final2;
        //                                    m_TagTable2.Add(rfids2, item2);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids2;
        //                                row["Reader"] = m_ReaderAPI2.HostName;
        //                                row["Antenna"] = antena3;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids2 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids2 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids2 + "',getdate(),'" + m_ReaderAPI2.HostName + "','"+antena3+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }
        //                            //}


        //                        }   
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

               
        //    }
        //    else
        //    {

        //    }
        //}


        #region withoutsensormyUpdateRead2
        public void myUpdateRead2(Events.ReadEventData eventData2)
        {
            if (chkin2.Checked == true)
            {
                //if (m_IsConnected2)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
                                if (tagData2 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag2 in tagData2)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item2 = new ListViewItem(tag2.TagID);
                                        ListViewItem.ListViewSubItem subItem2;


                                        subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
                                        item2.SubItems.Add(subItem2);

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
                                        //item2.SubItems.Add(subItem2);

                                        antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
                                        rfids2 = tag2.TagID;

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag2.TagSeenCount;
                                        //item2.SubItems.Add(subItem2);

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
                                        //item2.SubItems.Add(subItem2);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item2);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable2.SyncRoot)
                                        {
                                            //int dats = Convert.ToInt32(m_TagTable2.Count);
                                            //string final = Convert.ToString(dats);
                                            //label15.Text = final;
                                            m_TagTable2.Add(rfids2, item2);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids2;
                                        row["Reader"] = m_ReaderAPI2.HostName;
                                        row["Antenna"] = antena3;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids2 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}


            }
            else if (chkout2.Checked == true)
            {

                //if (m_IsConnected2)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
                                if (tagData2 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag2 in tagData2)
                                    {


                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item2 = new ListViewItem(tag2.TagID);
                                        ListViewItem.ListViewSubItem subItem2;


                                        subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
                                        item2.SubItems.Add(subItem2);

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
                                        //item2.SubItems.Add(subItem2);

                                        antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
                                        rfids2 = tag2.TagID;

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag2.TagSeenCount;
                                        //item2.SubItems.Add(subItem2);

                                        //subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
                                        //item2.SubItems.Add(subItem2);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);


                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item2);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable2.SyncRoot)
                                        {

                                            //int dats2 = Convert.ToInt32(m_TagTable2.Count);
                                            //string final2 = Convert.ToString(dats2);
                                            //label15.Text = final2;
                                            m_TagTable2.Add(rfids2, item2);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids2;
                                        row["Reader"] = m_ReaderAPI2.HostName;
                                        row["Antenna"] = antena3;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids2 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids2 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids2 + "',getdate(),'" + m_ReaderAPI2.HostName + "','" + antena3 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }
                                    //}


                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}


            }
            else
            {

            }
        }
        #endregion


        //#region withsensormyUpdateRead2
        //public void myUpdateRead2(Events.ReadEventData eventData2)
        //{
        //    if (chkin2.Checked == true)
        //    {
        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
        //        if (tagData2 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag2 in tagData2)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item2 = new ListViewItem(tag2.TagID);
        //                ListViewItem.ListViewSubItem subItem2;


        //                subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
        //                item2.SubItems.Add(subItem2);

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
        //                //item2.SubItems.Add(subItem2);

        //                antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
        //                rfids2 = tag2.TagID;

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag2.TagSeenCount;
        //                //item2.SubItems.Add(subItem2);

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
        //                //item2.SubItems.Add(subItem2);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable2.SyncRoot)
        //                {
        //                    //int dats = Convert.ToInt32(m_TagTable2.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label15.Text = final;
        //                    m_TagTable2.Add(rfids2, item2);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids2;
        //                row["Reader"] = m_ReaderAPI2.HostName;
        //                row["Antenna"] = antena3;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids2 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }


        //    }
        //    else if (chkout2.Checked == true)
        //    {

        //        if (m_IsConnected2)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI2.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI2.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData2 = m_ReaderAPI2.Actions.GetReadTags(1000);
        //        if (tagData2 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag2 in tagData2)
        //            {


        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item2 = new ListViewItem(tag2.TagID);
        //                ListViewItem.ListViewSubItem subItem2;


        //                subItem2 = new ListViewItem.ListViewSubItem(item2, getTagEvent(tag2));
        //                item2.SubItems.Add(subItem2);

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.AntennaID.ToString());
        //                //item2.SubItems.Add(subItem2);

        //                antena3 = Convert.ToInt32(tag2.AntennaID.ToString());
        //                rfids2 = tag2.TagID;

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, tag2.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag2.TagSeenCount;
        //                //item2.SubItems.Add(subItem2);

        //                //subItem2 = new ListViewItem.ListViewSubItem(item2, m_ReaderAPI2.HostName);
        //                //item2.SubItems.Add(subItem2);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);


        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item2);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable2.SyncRoot)
        //                {

        //                    //int dats2 = Convert.ToInt32(m_TagTable2.Count);
        //                    //string final2 = Convert.ToString(dats2);
        //                    //label15.Text = final2;
        //                    m_TagTable2.Add(rfids2, item2);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids2;
        //                row["Reader"] = m_ReaderAPI2.HostName;
        //                row["Antenna"] = antena3;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI2.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids2 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids2 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids2 + "',getdate(),'" + m_ReaderAPI2.HostName + "','" + antena3 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }
        //            //}


        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }


        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion



        //withsensor
        //public void myUpdateRead3(Events.ReadEventData eventData3)
        //{
        //    if (chkin3.Checked == true)
        //    {

        //        if (m_IsConnected3)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
        //                {
                            
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
                                
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
        //                        if (tagData3 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag3 in tagData3)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item3 = new ListViewItem(tag3.TagID);
        //                                ListViewItem.ListViewSubItem subItem3;


        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
        //                                item3.SubItems.Add(subItem3);

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
        //                                item3.SubItems.Add(subItem3);

        //                                antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
        //                                rfids3 = tag3.TagID;

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag3.TagSeenCount;
        //                                item3.SubItems.Add(subItem3);

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
        //                                item3.SubItems.Add(subItem3);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable3.SyncRoot)
        //                                {

        //                                    int dats = Convert.ToInt32(m_TagTable3.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label19.Text = final;
        //                                    m_TagTable3.Add(rfids3, item3);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids3;
        //                                row["Reader"] = m_ReaderAPI3.HostName;
        //                                row["Antenna"] = antena4;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids3 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }


        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
            
        //    }
        //    else if (chkout3.Checked == true)
        //    {
        //        if (m_IsConnected3)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
        //                {                            
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {
                                
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
        //                        if (tagData3 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag3 in tagData3)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item3 = new ListViewItem(tag3.TagID);
        //                                ListViewItem.ListViewSubItem subItem3;


        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
        //                                item3.SubItems.Add(subItem3);

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
        //                                item3.SubItems.Add(subItem3);

        //                                antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
        //                                rfids3 = tag3.TagID;

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag3.TagSeenCount;
        //                                item3.SubItems.Add(subItem3);

        //                                subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
        //                                item3.SubItems.Add(subItem3);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable3.SyncRoot)
        //                                {
        //                                    int dats3 = Convert.ToInt32(m_TagTable3.Count);
        //                                    string final3 = Convert.ToString(dats3);
        //                                    label19.Text = final3;
        //                                    m_TagTable3.Add(rfids3, item3);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids3;
        //                                row["Reader"] = m_ReaderAPI3.HostName;
        //                                row["Antenna"] = antena4;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids3 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids3 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids3 + "',getdate(),'" + m_ReaderAPI3.HostName + "','"+antena4+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }
            
        //    }
        //    else
        //    {

        //    }
        //}
        #region withoutsensormyUpdateRead3
        public void myUpdateRead3(Events.ReadEventData eventData3)
        {
            if (chkin3.Checked == true)
            {

                //if (m_IsConnected3)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
                                if (tagData3 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag3 in tagData3)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item3 = new ListViewItem(tag3.TagID);
                                        ListViewItem.ListViewSubItem subItem3;


                                        subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
                                        item3.SubItems.Add(subItem3);

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
                                        //item3.SubItems.Add(subItem3);

                                        antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
                                        rfids3 = tag3.TagID;

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag3.TagSeenCount;
                                        //item3.SubItems.Add(subItem3);

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
                                        //item3.SubItems.Add(subItem3);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable3.SyncRoot)
                                        {

                                            //int dats = Convert.ToInt32(m_TagTable3.Count);
                                            //string final = Convert.ToString(dats);
                                            //label19.Text = final;
                                            m_TagTable3.Add(rfids3, item3);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids3;
                                        row["Reader"] = m_ReaderAPI3.HostName;
                                        row["Antenna"] = antena4;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids3 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout3.Checked == true)
            {
                //if (m_IsConnected3)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
                //        {
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
                                if (tagData3 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag3 in tagData3)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item3 = new ListViewItem(tag3.TagID);
                                        ListViewItem.ListViewSubItem subItem3;


                                        subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
                                        item3.SubItems.Add(subItem3);

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
                                        //item3.SubItems.Add(subItem3);

                                        antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
                                        rfids3 = tag3.TagID;

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag3.TagSeenCount;
                                        //item3.SubItems.Add(subItem3);

                                        //subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
                                        //item3.SubItems.Add(subItem3);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable3.SyncRoot)
                                        {
                                            //int dats3 = Convert.ToInt32(m_TagTable3.Count);
                                            //string final3 = Convert.ToString(dats3);
                                            //label19.Text = final3;
                                            m_TagTable3.Add(rfids3, item3);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids3;
                                        row["Reader"] = m_ReaderAPI3.HostName;
                                        row["Antenna"] = antena4;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids3 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids3 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids3 + "',getdate(),'" + m_ReaderAPI3.HostName + "','" + antena4 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }
        #endregion

        //#region withsensormyUpdateRead3
        //public void myUpdateRead3(Events.ReadEventData eventData3)
        //{
        //    if (chkin3.Checked == true)
        //    {

        //        if (m_IsConnected3)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
        //        if (tagData3 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag3 in tagData3)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item3 = new ListViewItem(tag3.TagID);
        //                ListViewItem.ListViewSubItem subItem3;


        //                subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
        //                item3.SubItems.Add(subItem3);

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
        //                //item3.SubItems.Add(subItem3);

        //                antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
        //                rfids3 = tag3.TagID;

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag3.TagSeenCount;
        //                //item3.SubItems.Add(subItem3);

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
        //                //item3.SubItems.Add(subItem3);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable3.SyncRoot)
        //                {

        //                    //int dats = Convert.ToInt32(m_TagTable3.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label19.Text = final;
        //                    m_TagTable3.Add(rfids3, item3);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids3;
        //                row["Reader"] = m_ReaderAPI3.HostName;
        //                row["Antenna"] = antena4;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids3 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout3.Checked == true)
        //    {
        //        if (m_IsConnected3)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI3.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI3.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData3 = m_ReaderAPI3.Actions.GetReadTags(1000);
        //        if (tagData3 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag3 in tagData3)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item3 = new ListViewItem(tag3.TagID);
        //                ListViewItem.ListViewSubItem subItem3;


        //                subItem3 = new ListViewItem.ListViewSubItem(item3, getTagEvent(tag3));
        //                item3.SubItems.Add(subItem3);

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.AntennaID.ToString());
        //                //item3.SubItems.Add(subItem3);

        //                antena4 = Convert.ToInt32(tag3.AntennaID.ToString());
        //                rfids3 = tag3.TagID;

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, tag3.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag3.TagSeenCount;
        //                //item3.SubItems.Add(subItem3);

        //                //subItem3 = new ListViewItem.ListViewSubItem(item3, m_ReaderAPI3.HostName);
        //                //item3.SubItems.Add(subItem3);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable3.SyncRoot)
        //                {
        //                    //int dats3 = Convert.ToInt32(m_TagTable3.Count);
        //                    //string final3 = Convert.ToString(dats3);
        //                    //label19.Text = final3;
        //                    m_TagTable3.Add(rfids3, item3);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids3;
        //                row["Reader"] = m_ReaderAPI3.HostName;
        //                row["Antenna"] = antena4;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI3.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids3 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids3 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids3 + "',getdate(),'" + m_ReaderAPI3.HostName + "','" + antena4 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion


        //withsensor
        //public void myUpdateRead4(Events.ReadEventData eventData4)
        //{
        //    if (chkin4.Checked == true)
        //    {

        //        if (m_IsConnected4)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData4 = m_ReaderAPI4.Actions.GetReadTags(1000);
        //                        if (tagData4 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag4 in tagData4)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item4 = new ListViewItem(tag4.TagID);
        //                                ListViewItem.ListViewSubItem subItem4;


        //                                subItem4 = new ListViewItem.ListViewSubItem(item4, getTagEvent(tag4));
        //                                item4.SubItems.Add(subItem4);

        //                                subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.AntennaID.ToString());
        //                                item4.SubItems.Add(subItem4);

        //                                antena5 = Convert.ToInt32(tag4.AntennaID.ToString());
        //                                rfids4 = tag4.TagID;

        //                                subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag4.TagSeenCount;
        //                                item4.SubItems.Add(subItem4);

        //                                subItem4 = new ListViewItem.ListViewSubItem(item4, m_ReaderAPI4.HostName);
        //                                item4.SubItems.Add(subItem4);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable4.SyncRoot)
        //                                {

        //                                    int dats = Convert.ToInt32(m_TagTable4.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label23.Text = final;
        //                                    m_TagTable4.Add(rfids4, item4);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids4;
        //                                row["Reader"] = m_ReaderAPI4.HostName;
        //                                row["Antenna"] = antena5;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids4 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }


        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout4.Checked == true)
        //    {
        //        if (m_IsConnected4)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData5 = m_ReaderAPI4.Actions.GetReadTags(1000);
        //                        if (tagData5 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag5 in tagData5)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item5 = new ListViewItem(tag5.TagID);
        //                                ListViewItem.ListViewSubItem subItem5;


        //                                subItem5 = new ListViewItem.ListViewSubItem(item5, getTagEvent(tag5));
        //                                item5.SubItems.Add(subItem5);

        //                                subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.AntennaID.ToString());
        //                                item5.SubItems.Add(subItem5);

        //                                antena5 = Convert.ToInt32(tag5.AntennaID.ToString());
        //                                rfids4 = tag5.TagID;

        //                                subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag5.TagSeenCount;
        //                                item5.SubItems.Add(subItem5);

        //                                subItem5 = new ListViewItem.ListViewSubItem(item5, m_ReaderAPI4.HostName);
        //                                item5.SubItems.Add(subItem5);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable4.SyncRoot)
        //                                {
        //                                    int dats3 = Convert.ToInt32(m_TagTable4.Count);
        //                                    string final3 = Convert.ToString(dats3);
        //                                    label23.Text = final3;
        //                                    m_TagTable4.Add(rfids4, item5);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids4;
        //                                row["Reader"] = m_ReaderAPI4.HostName;
        //                                row["Antenna"] = antena5;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids4 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids4 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids4 + "',getdate(),'" + m_ReaderAPI4.HostName + "','"+antena5+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}


        #region withoutsensormyUpdateRead4
        public void myUpdateRead4(Events.ReadEventData eventData4)
        {
            if (chkin4.Checked == true)
            {

                //if (m_IsConnected4)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData4 = m_ReaderAPI4.Actions.GetReadTags(1000);
                                if (tagData4 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag4 in tagData4)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item4 = new ListViewItem(tag4.TagID);
                                        ListViewItem.ListViewSubItem subItem4;


                                        subItem4 = new ListViewItem.ListViewSubItem(item4, getTagEvent(tag4));
                                        item4.SubItems.Add(subItem4);

                                        //subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.AntennaID.ToString());
                                        //item4.SubItems.Add(subItem4);

                                        antena5 = Convert.ToInt32(tag4.AntennaID.ToString());
                                        rfids4 = tag4.TagID;

                                        //subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag4.TagSeenCount;
                                        //item4.SubItems.Add(subItem4);

                                        //subItem4 = new ListViewItem.ListViewSubItem(item4, m_ReaderAPI4.HostName);
                                        //item4.SubItems.Add(subItem4);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable4.SyncRoot)
                                        {

                                            //int dats = Convert.ToInt32(m_TagTable4.Count);
                                            //string final = Convert.ToString(dats);
                                            //label23.Text = final;
                                            m_TagTable4.Add(rfids4, item4);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids4;
                                        row["Reader"] = m_ReaderAPI4.HostName;
                                        row["Antenna"] = antena5;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids4 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout4.Checked == true)
            {
                //if (m_IsConnected4)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
                //        {
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData5 = m_ReaderAPI4.Actions.GetReadTags(1000);
                                if (tagData5 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag5 in tagData5)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item5 = new ListViewItem(tag5.TagID);
                                        ListViewItem.ListViewSubItem subItem5;


                                        subItem5 = new ListViewItem.ListViewSubItem(item5, getTagEvent(tag5));
                                        item5.SubItems.Add(subItem5);

                                        //subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.AntennaID.ToString());
                                        //item5.SubItems.Add(subItem5);

                                        antena5 = Convert.ToInt32(tag5.AntennaID.ToString());
                                        rfids4 = tag5.TagID;

                                        //subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag5.TagSeenCount;
                                        //item5.SubItems.Add(subItem5);

                                        //subItem5 = new ListViewItem.ListViewSubItem(item5, m_ReaderAPI4.HostName);
                                        //item5.SubItems.Add(subItem5);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable4.SyncRoot)
                                        {
                                            //int dats3 = Convert.ToInt32(m_TagTable4.Count);
                                            //string final3 = Convert.ToString(dats3);
                                            //label23.Text = final3;
                                            m_TagTable4.Add(rfids4, item5);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids4;
                                        row["Reader"] = m_ReaderAPI4.HostName;
                                        row["Antenna"] = antena5;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids4 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids4 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids4 + "',getdate(),'" + m_ReaderAPI4.HostName + "','" + antena5 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }
        #endregion

        //#region withsensormyUpdateRead4
        //public void myUpdateRead4(Events.ReadEventData eventData4)
        //{
        //    if (chkin4.Checked == true)
        //    {

        //        if (m_IsConnected4)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData4 = m_ReaderAPI4.Actions.GetReadTags(1000);
        //        if (tagData4 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag4 in tagData4)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item4 = new ListViewItem(tag4.TagID);
        //                ListViewItem.ListViewSubItem subItem4;


        //                subItem4 = new ListViewItem.ListViewSubItem(item4, getTagEvent(tag4));
        //                item4.SubItems.Add(subItem4);

        //                //subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.AntennaID.ToString());
        //                //item4.SubItems.Add(subItem4);

        //                antena5 = Convert.ToInt32(tag4.AntennaID.ToString());
        //                rfids4 = tag4.TagID;

        //                //subItem4 = new ListViewItem.ListViewSubItem(item4, tag4.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag4.TagSeenCount;
        //                //item4.SubItems.Add(subItem4);

        //                //subItem4 = new ListViewItem.ListViewSubItem(item4, m_ReaderAPI4.HostName);
        //                //item4.SubItems.Add(subItem4);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable4.SyncRoot)
        //                {

        //                    //int dats = Convert.ToInt32(m_TagTable4.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label23.Text = final;
        //                    m_TagTable4.Add(rfids4, item4);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids4;
        //                row["Reader"] = m_ReaderAPI4.HostName;
        //                row["Antenna"] = antena5;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids4 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout4.Checked == true)
        //    {
        //        if (m_IsConnected4)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI4.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI4.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData5 = m_ReaderAPI4.Actions.GetReadTags(1000);
        //        if (tagData5 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag5 in tagData5)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item5 = new ListViewItem(tag5.TagID);
        //                ListViewItem.ListViewSubItem subItem5;


        //                subItem5 = new ListViewItem.ListViewSubItem(item5, getTagEvent(tag5));
        //                item5.SubItems.Add(subItem5);

        //                //subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.AntennaID.ToString());
        //                //item5.SubItems.Add(subItem5);

        //                antena5 = Convert.ToInt32(tag5.AntennaID.ToString());
        //                rfids4 = tag5.TagID;

        //                //subItem5 = new ListViewItem.ListViewSubItem(item5, tag5.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag5.TagSeenCount;
        //                //item5.SubItems.Add(subItem5);

        //                //subItem5 = new ListViewItem.ListViewSubItem(item5, m_ReaderAPI4.HostName);
        //                //item5.SubItems.Add(subItem5);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable4.SyncRoot)
        //                {
        //                    //int dats3 = Convert.ToInt32(m_TagTable4.Count);
        //                    //string final3 = Convert.ToString(dats3);
        //                    //label23.Text = final3;
        //                    m_TagTable4.Add(rfids4, item5);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids4;
        //                row["Reader"] = m_ReaderAPI4.HostName;
        //                row["Antenna"] = antena5;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI4.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids4 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids4 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids4 + "',getdate(),'" + m_ReaderAPI4.HostName + "','" + antena5 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion

        //withsensor
        //public void myUpdateRead5(Events.ReadEventData eventData5)
        //{
        //    if (chkin5.Checked == true)
        //    {

        //        if (m_IsConnected5)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData14 = m_ReaderAPI5.Actions.GetReadTags(1000);
        //                        if (tagData14 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag14 in tagData14)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item14 = new ListViewItem(tag14.TagID);
        //                                ListViewItem.ListViewSubItem subItem14;


        //                                subItem14 = new ListViewItem.ListViewSubItem(item14, getTagEvent(tag14));
        //                                item14.SubItems.Add(subItem14);

        //                                subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.AntennaID.ToString());
        //                                item14.SubItems.Add(subItem14);

        //                                antena6 = Convert.ToInt32(tag14.AntennaID.ToString());
        //                                rfids5 = tag14.TagID;

        //                                subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag14.TagSeenCount;
        //                                item14.SubItems.Add(subItem14);

        //                                subItem14 = new ListViewItem.ListViewSubItem(item14, m_ReaderAPI5.HostName);
        //                                item14.SubItems.Add(subItem14);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable5.SyncRoot)
        //                                {

        //                                    int dats = Convert.ToInt32(m_TagTable5.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label21.Text = final;
        //                                    m_TagTable5.Add(rfids5, item14);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids5;
        //                                row["Reader"] = m_ReaderAPI5.HostName;
        //                                row["Antenna"] = antena6;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids5 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }


        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout5.Checked == true)
        //    {
        //        if (m_IsConnected5)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData25 = m_ReaderAPI5.Actions.GetReadTags(1000);
        //                        if (tagData25 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag25 in tagData25)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item25 = new ListViewItem(tag25.TagID);
        //                                ListViewItem.ListViewSubItem subItem25;


        //                                subItem25 = new ListViewItem.ListViewSubItem(item25, getTagEvent(tag25));
        //                                item25.SubItems.Add(subItem25);

        //                                subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.AntennaID.ToString());
        //                                item25.SubItems.Add(subItem25);

        //                                antena6 = Convert.ToInt32(tag25.AntennaID.ToString());
        //                                rfids5 = tag25.TagID;

        //                                subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag25.TagSeenCount;
        //                                item25.SubItems.Add(subItem25);

        //                                subItem25 = new ListViewItem.ListViewSubItem(item25, m_ReaderAPI5.HostName);
        //                                item25.SubItems.Add(subItem25);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable5.SyncRoot)
        //                                {
        //                                    int dats3 = Convert.ToInt32(m_TagTable5.Count);
        //                                    string final3 = Convert.ToString(dats3);
        //                                    label21.Text = final3;
        //                                    m_TagTable5.Add(rfids5, item25);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids5;
        //                                row["Reader"] = m_ReaderAPI5.HostName;
        //                                row["Antenna"] = antena6;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids5 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids5 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids5 + "',getdate(),'" + m_ReaderAPI5.HostName + "','" + antena6 + "')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}

        #region withoutsensormyUpdateRead5
        public void myUpdateRead5(Events.ReadEventData eventData5)
        {
            if (chkin5.Checked == true)
            {

                //if (m_IsConnected5)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData14 = m_ReaderAPI5.Actions.GetReadTags(1000);
                                if (tagData14 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag14 in tagData14)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item14 = new ListViewItem(tag14.TagID);
                                        ListViewItem.ListViewSubItem subItem14;


                                        subItem14 = new ListViewItem.ListViewSubItem(item14, getTagEvent(tag14));
                                        item14.SubItems.Add(subItem14);

                                        //subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.AntennaID.ToString());
                                        //item14.SubItems.Add(subItem14);

                                        antena6 = Convert.ToInt32(tag14.AntennaID.ToString());
                                        rfids5 = tag14.TagID;

                                        //subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag14.TagSeenCount;
                                        //item14.SubItems.Add(subItem14);

                                        //subItem14 = new ListViewItem.ListViewSubItem(item14, m_ReaderAPI5.HostName);
                                        //item14.SubItems.Add(subItem14);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable5.SyncRoot)
                                        {

                                            //int dats = Convert.ToInt32(m_TagTable5.Count);
                                            //string final = Convert.ToString(dats);
                                            //label21.Text = final;
                                            m_TagTable5.Add(rfids5, item14);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids5;
                                        row["Reader"] = m_ReaderAPI5.HostName;
                                        row["Antenna"] = antena6;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids5 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout5.Checked == true)
            {
                //if (m_IsConnected5)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
                //        {
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData25 = m_ReaderAPI5.Actions.GetReadTags(1000);
                                if (tagData25 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag25 in tagData25)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item25 = new ListViewItem(tag25.TagID);
                                        ListViewItem.ListViewSubItem subItem25;


                                        subItem25 = new ListViewItem.ListViewSubItem(item25, getTagEvent(tag25));
                                        item25.SubItems.Add(subItem25);

                                        //subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.AntennaID.ToString());
                                        //item25.SubItems.Add(subItem25);

                                        antena6 = Convert.ToInt32(tag25.AntennaID.ToString());
                                        rfids5 = tag25.TagID;

                                        //subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag25.TagSeenCount;
                                        //item25.SubItems.Add(subItem25);

                                        //subItem25 = new ListViewItem.ListViewSubItem(item25, m_ReaderAPI5.HostName);
                                        //item25.SubItems.Add(subItem25);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable5.SyncRoot)
                                        {
                                            //int dats3 = Convert.ToInt32(m_TagTable5.Count);
                                            //string final3 = Convert.ToString(dats3);
                                            //label21.Text = final3;
                                            m_TagTable5.Add(rfids5, item25);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids5;
                                        row["Reader"] = m_ReaderAPI5.HostName;
                                        row["Antenna"] = antena6;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids5 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids5 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids5 + "',getdate(),'" + m_ReaderAPI5.HostName + "','" + antena6 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }
        #endregion

        //#region withsensormyUpdateRead5
        //public void myUpdateRead5(Events.ReadEventData eventData5)
        //{
        //    if (chkin5.Checked == true)
        //    {

        //        if (m_IsConnected5)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData14 = m_ReaderAPI5.Actions.GetReadTags(1000);
        //        if (tagData14 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag14 in tagData14)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item14 = new ListViewItem(tag14.TagID);
        //                ListViewItem.ListViewSubItem subItem14;


        //                subItem14 = new ListViewItem.ListViewSubItem(item14, getTagEvent(tag14));
        //                item14.SubItems.Add(subItem14);

        //                //subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.AntennaID.ToString());
        //                //item14.SubItems.Add(subItem14);

        //                antena6 = Convert.ToInt32(tag14.AntennaID.ToString());
        //                rfids5 = tag14.TagID;

        //                //subItem14 = new ListViewItem.ListViewSubItem(item14, tag14.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag14.TagSeenCount;
        //                //item14.SubItems.Add(subItem14);

        //                //subItem14 = new ListViewItem.ListViewSubItem(item14, m_ReaderAPI5.HostName);
        //                //item14.SubItems.Add(subItem14);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable5.SyncRoot)
        //                {

        //                    //int dats = Convert.ToInt32(m_TagTable5.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label21.Text = final;
        //                    m_TagTable5.Add(rfids5, item14);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids5;
        //                row["Reader"] = m_ReaderAPI5.HostName;
        //                row["Antenna"] = antena6;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids5 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout5.Checked == true)
        //    {
        //        if (m_IsConnected5)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI5.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI5.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData25 = m_ReaderAPI5.Actions.GetReadTags(1000);
        //        if (tagData25 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag25 in tagData25)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item25 = new ListViewItem(tag25.TagID);
        //                ListViewItem.ListViewSubItem subItem25;


        //                subItem25 = new ListViewItem.ListViewSubItem(item25, getTagEvent(tag25));
        //                item25.SubItems.Add(subItem25);

        //                //subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.AntennaID.ToString());
        //                //item25.SubItems.Add(subItem25);

        //                antena6 = Convert.ToInt32(tag25.AntennaID.ToString());
        //                rfids5 = tag25.TagID;

        //                //subItem25 = new ListViewItem.ListViewSubItem(item25, tag25.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag25.TagSeenCount;
        //                //item25.SubItems.Add(subItem25);

        //                //subItem25 = new ListViewItem.ListViewSubItem(item25, m_ReaderAPI5.HostName);
        //                //item25.SubItems.Add(subItem25);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable5.SyncRoot)
        //                {
        //                    //int dats3 = Convert.ToInt32(m_TagTable5.Count);
        //                    //string final3 = Convert.ToString(dats3);
        //                    //label21.Text = final3;
        //                    m_TagTable5.Add(rfids5, item25);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids5;
        //                row["Reader"] = m_ReaderAPI5.HostName;
        //                row["Antenna"] = antena6;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI5.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids5 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids5 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids5 + "',getdate(),'" + m_ReaderAPI5.HostName + "','" + antena6 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion




        //withsensor
        
        //public void myUpdateRead6(Events.ReadEventData eventData6)
        //{
        //    if (chkin6.Checked == true)
        //    {

        //        if (m_IsConnected6)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData114 = m_ReaderAPI6.Actions.GetReadTags(1000);
        //                        if (tagData114 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag114 in tagData114)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item114 = new ListViewItem(tag114.TagID);
        //                                ListViewItem.ListViewSubItem subItem114;


        //                                subItem114 = new ListViewItem.ListViewSubItem(item114, getTagEvent(tag114));
        //                                item114.SubItems.Add(subItem114);

        //                                subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.AntennaID.ToString());
        //                                item114.SubItems.Add(subItem114);

        //                                antena7 = Convert.ToInt32(tag114.AntennaID.ToString());
        //                                rfids6 = tag114.TagID;

        //                                subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag114.TagSeenCount;
        //                                item114.SubItems.Add(subItem114);

        //                                subItem114 = new ListViewItem.ListViewSubItem(item114, m_ReaderAPI6.HostName);
        //                                item114.SubItems.Add(subItem114);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable6.SyncRoot)
        //                                {

        //                                    int dats = Convert.ToInt32(m_TagTable6.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label25.Text = final;
        //                                    m_TagTable6.Add(rfids6, item114);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids6;
        //                                row["Reader"] = m_ReaderAPI6.HostName;
        //                                row["Antenna"] = antena7;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids6 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }


        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout6.Checked == true)
        //    {
        //        if (m_IsConnected6)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData225 = m_ReaderAPI6.Actions.GetReadTags(1000);
        //                        if (tagData225 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag225 in tagData225)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item225 = new ListViewItem(tag225.TagID);
        //                                ListViewItem.ListViewSubItem subItem225;


        //                                subItem225 = new ListViewItem.ListViewSubItem(item225, getTagEvent(tag225));
        //                                item225.SubItems.Add(subItem225);

        //                                subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.AntennaID.ToString());
        //                                item225.SubItems.Add(subItem225);

        //                                antena7 = Convert.ToInt32(tag225.AntennaID.ToString());
        //                                rfids6 = tag225.TagID;

        //                                subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag225.TagSeenCount;
        //                                item225.SubItems.Add(subItem225);

        //                                subItem225 = new ListViewItem.ListViewSubItem(item225, m_ReaderAPI6.HostName);
        //                                item225.SubItems.Add(subItem225);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable6.SyncRoot)
        //                                {
        //                                    int dats3 = Convert.ToInt32(m_TagTable6.Count);
        //                                    string final3 = Convert.ToString(dats3);
        //                                    label25.Text = final3;
        //                                    m_TagTable6.Add(rfids6, item225);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids6;
        //                                row["Reader"] = m_ReaderAPI6.HostName;
        //                                row["Antenna"] = antena7;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids6 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids6 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids6 + "',getdate(),'" + m_ReaderAPI6.HostName + "','"+antena7+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}


        #region withoutsensormyUpdateRead6
        public void myUpdateRead6(Events.ReadEventData eventData6)
        {
            if (chkin6.Checked == true)
            {

                //if (m_IsConnected6)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData114 = m_ReaderAPI6.Actions.GetReadTags(1000);
                                if (tagData114 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag114 in tagData114)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item114 = new ListViewItem(tag114.TagID);
                                        ListViewItem.ListViewSubItem subItem114;


                                        subItem114 = new ListViewItem.ListViewSubItem(item114, getTagEvent(tag114));
                                        item114.SubItems.Add(subItem114);

                                        //subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.AntennaID.ToString());
                                        //item114.SubItems.Add(subItem114);

                                        antena7 = Convert.ToInt32(tag114.AntennaID.ToString());
                                        rfids6 = tag114.TagID;

                                        //subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag114.TagSeenCount;
                                        //item114.SubItems.Add(subItem114);

                                        //subItem114 = new ListViewItem.ListViewSubItem(item114, m_ReaderAPI6.HostName);
                                        //item114.SubItems.Add(subItem114);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable6.SyncRoot)
                                        {

                                            //int dats = Convert.ToInt32(m_TagTable6.Count);
                                            //string final = Convert.ToString(dats);
                                            //label25.Text = final;
                                            m_TagTable6.Add(rfids6, item114);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids6;
                                        row["Reader"] = m_ReaderAPI6.HostName;
                                        row["Antenna"] = antena7;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids6 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout6.Checked == true)
            {
                //if (m_IsConnected6)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
                //        {
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData225 = m_ReaderAPI6.Actions.GetReadTags(1000);
                                if (tagData225 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag225 in tagData225)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item225 = new ListViewItem(tag225.TagID);
                                        ListViewItem.ListViewSubItem subItem225;


                                        subItem225 = new ListViewItem.ListViewSubItem(item225, getTagEvent(tag225));
                                        item225.SubItems.Add(subItem225);

                                        //subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.AntennaID.ToString());
                                        //item225.SubItems.Add(subItem225);

                                        antena7 = Convert.ToInt32(tag225.AntennaID.ToString());
                                        rfids6 = tag225.TagID;

                                        //subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag225.TagSeenCount;
                                        //item225.SubItems.Add(subItem225);

                                        //subItem225 = new ListViewItem.ListViewSubItem(item225, m_ReaderAPI6.HostName);
                                        //item225.SubItems.Add(subItem225);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable6.SyncRoot)
                                        {
                                            //int dats3 = Convert.ToInt32(m_TagTable6.Count);
                                            //string final3 = Convert.ToString(dats3);
                                            //label25.Text = final3;
                                            m_TagTable6.Add(rfids6, item225);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids6;
                                        row["Reader"] = m_ReaderAPI6.HostName;
                                        row["Antenna"] = antena7;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids6 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids6 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids6 + "',getdate(),'" + m_ReaderAPI6.HostName + "','" + antena7 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }
        #endregion

        //#region withsensormyUpdateRead6
        //public void myUpdateRead6(Events.ReadEventData eventData6)
        //{
        //    if (chkin6.Checked == true)
        //    {

        //        if (m_IsConnected6)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData114 = m_ReaderAPI6.Actions.GetReadTags(1000);
        //        if (tagData114 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag114 in tagData114)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item114 = new ListViewItem(tag114.TagID);
        //                ListViewItem.ListViewSubItem subItem114;


        //                subItem114 = new ListViewItem.ListViewSubItem(item114, getTagEvent(tag114));
        //                item114.SubItems.Add(subItem114);

        //                //subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.AntennaID.ToString());
        //                //item114.SubItems.Add(subItem114);

        //                antena7 = Convert.ToInt32(tag114.AntennaID.ToString());
        //                rfids6 = tag114.TagID;

        //                //subItem114 = new ListViewItem.ListViewSubItem(item114, tag114.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag114.TagSeenCount;
        //                //item114.SubItems.Add(subItem114);

        //                //subItem114 = new ListViewItem.ListViewSubItem(item114, m_ReaderAPI6.HostName);
        //                //item114.SubItems.Add(subItem114);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable6.SyncRoot)
        //                {

        //                    //int dats = Convert.ToInt32(m_TagTable6.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label25.Text = final;
        //                    m_TagTable6.Add(rfids6, item114);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids6;
        //                row["Reader"] = m_ReaderAPI6.HostName;
        //                row["Antenna"] = antena7;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids6 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout6.Checked == true)
        //    {
        //        if (m_IsConnected6)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI6.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI6.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData225 = m_ReaderAPI6.Actions.GetReadTags(1000);
        //        if (tagData225 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag225 in tagData225)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item225 = new ListViewItem(tag225.TagID);
        //                ListViewItem.ListViewSubItem subItem225;


        //                subItem225 = new ListViewItem.ListViewSubItem(item225, getTagEvent(tag225));
        //                item225.SubItems.Add(subItem225);

        //                //subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.AntennaID.ToString());
        //                //item225.SubItems.Add(subItem225);

        //                antena7 = Convert.ToInt32(tag225.AntennaID.ToString());
        //                rfids6 = tag225.TagID;

        //                //subItem225 = new ListViewItem.ListViewSubItem(item225, tag225.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag225.TagSeenCount;
        //                //item225.SubItems.Add(subItem225);

        //                //subItem225 = new ListViewItem.ListViewSubItem(item225, m_ReaderAPI6.HostName);
        //                //item225.SubItems.Add(subItem225);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable6.SyncRoot)
        //                {
        //                    //int dats3 = Convert.ToInt32(m_TagTable6.Count);
        //                    //string final3 = Convert.ToString(dats3);
        //                    //label25.Text = final3;
        //                    m_TagTable6.Add(rfids6, item225);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids6;
        //                row["Reader"] = m_ReaderAPI6.HostName;
        //                row["Antenna"] = antena7;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI6.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids6 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids6 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids6 + "',getdate(),'" + m_ReaderAPI6.HostName + "','" + antena7 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion


        //withsensor
        //public void myUpdateRead7(Events.ReadEventData eventData7)
        //{
        //    if (chkin7.Checked == true)
        //    {
        //        if (m_IsConnected7)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData1114 = m_ReaderAPI7.Actions.GetReadTags(1000);
        //                        if (tagData1114 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag1114 in tagData1114)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item1114 = new ListViewItem(tag1114.TagID);
        //                                ListViewItem.ListViewSubItem subItem1114;


        //                                subItem1114 = new ListViewItem.ListViewSubItem(item1114, getTagEvent(tag1114));
        //                                item1114.SubItems.Add(subItem1114);

        //                                subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.AntennaID.ToString());
        //                                item1114.SubItems.Add(subItem1114);

        //                                antena8 = Convert.ToInt32(tag1114.AntennaID.ToString());
        //                                rfids7 = tag1114.TagID;

        //                                subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag1114.TagSeenCount;
        //                                item1114.SubItems.Add(subItem1114);

        //                                subItem1114 = new ListViewItem.ListViewSubItem(item1114, m_ReaderAPI7.HostName);
        //                                item1114.SubItems.Add(subItem1114);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable7.SyncRoot)
        //                                {

        //                                    int dats = Convert.ToInt32(m_TagTable7.Count);
        //                                    string final = Convert.ToString(dats);
        //                                    label27.Text = final;
        //                                    m_TagTable7.Add(rfids7, item1114);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids7;
        //                                row["Reader"] = m_ReaderAPI7.HostName;
        //                                row["Antenna"] = antena8;

        //                                //rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);


        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }
        //                                try
        //                                {
        //                                    if (rfids7 == "")
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        SqlConnection connection = new SqlConnection();
        //                                        connection.ConnectionString = connectionString1;
        //                                        connection.Open();
        //                                        SqlCommand cmd2 = new SqlCommand();
        //                                        cmd2.Connection = connection;
        //                                        cmd2.CommandType = CommandType.StoredProcedure;
        //                                        cmd2.CommandTimeout = 10000;
        //                                        cmd2.CommandText = "InsertIntoMyTable1";
        //                                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                                        int i = cmd2.ExecuteNonQuery();
        //                                        connection.Close();
        //                                    }
        //                                }
        //                                catch (Exception ex)
        //                                {

        //                                }


        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout7.Checked == true)
        //    {
        //        if (m_IsConnected7)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //                        Symbol.RFID3.TagData[] tagData2225 = m_ReaderAPI7.Actions.GetReadTags(1000);
        //                        if (tagData2225 != null)
        //                        {
        //                            foreach (Symbol.RFID3.TagData tag2225 in tagData2225)
        //                            {
        //                                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                                //{
        //                                //    if (tagData[nIndex].ContainsLocationInfo)
        //                                //    {
        //                                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                                //    }

        //                                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                                //    {
        //                                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                                //        tagID = tag.TagID;
        //                                //        bool isFound = false;

        //                                //        lock (m_TagTable.SyncRoot)
        //                                //        {
        //                                //            isFound = m_TagTable.ContainsKey(tagID);
        //                                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                                //            {
        //                                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                //                    + tag.MemoryBankDataOffset.ToString();
        //                                //                isFound = m_TagTable.ContainsKey(tagID);
        //                                //            }
        //                                //        }

        //                                //        if (isFound)
        //                                //        {
        //                                //            uint count = 0;
        //                                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                                //            try
        //                                //            {
        //                                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                                //            }
        //                                //            catch (FormatException fe)
        //                                //            {
        //                                //                functionCallStatusLabel.Text = fe.Message;
        //                                //                break;
        //                                //            }
        //                                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                                //            item.SubItems[3].Text = count.ToString();
        //                                //           // item.SubItems[4].Text = IPaddress;

        //                                //            string memoryBank = tag.MemoryBank.ToString();
        //                                //            int index = memoryBank.LastIndexOf('_');
        //                                //            if (index != -1)
        //                                //            {
        //                                //                memoryBank = memoryBank.Substring(index + 1);
        //                                //            }
        //                                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                                //            {
        //                                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                                //                //item.SubItems[7].Text = memoryBank;
        //                                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                                //                lock (m_TagTable.SyncRoot)
        //                                //                {
        //                                //                    m_TagTable.Remove(tagID);
        //                                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                                //                }
        //                                //            }
        //                                //            item.SubItems[1].Text = getTagEvent(tag);

        //                                //        }
        //                                //        else
        //                                //        {
        //                                ListViewItem item2225 = new ListViewItem(tag2225.TagID);
        //                                ListViewItem.ListViewSubItem subItem2225;


        //                                subItem2225 = new ListViewItem.ListViewSubItem(item2225, getTagEvent(tag2225));
        //                                item2225.SubItems.Add(subItem2225);

        //                                subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.AntennaID.ToString());
        //                                item2225.SubItems.Add(subItem2225);

        //                                antena8 = Convert.ToInt32(tag2225.AntennaID.ToString());
        //                                rfids7 = tag2225.TagID;

        //                                subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.TagSeenCount.ToString());
        //                                m_TagTotalCount += tag2225.TagSeenCount;
        //                                item2225.SubItems.Add(subItem2225);

        //                                subItem2225 = new ListViewItem.ListViewSubItem(item2225, m_ReaderAPI7.HostName);
        //                                item2225.SubItems.Add(subItem2225);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                                //item.SubItems.Add(subItem);

        //                                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                                //item.SubItems.Add(subItem);

        //                                //if (memBank_CB.SelectedIndex >= 1)
        //                                //{
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                                //    //item.SubItems.Add(subItem);

        //                                //    string memoryBank = tag.MemoryBank.ToString();
        //                                //    int index = memoryBank.LastIndexOf('_');
        //                                //    if (index != -1)
        //                                //    {
        //                                //        memoryBank = memoryBank.Substring(index + 1);
        //                                //    }

        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                                //    //item.SubItems.Add(subItem);
        //                                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                                //    //item.SubItems.Add(subItem);
        //                                //}
        //                                //else
        //                                //{
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                                //    item.SubItems.Add(subItem);
        //                                //}
        //                                //inventoryList.BeginUpdate();
        //                                //inventoryList.Items.Add(item3);
        //                                //inventoryList.EndUpdate();

        //                                lock (m_TagTable7.SyncRoot)
        //                                {
        //                                    int dats3 = Convert.ToInt32(m_TagTable7.Count);
        //                                    string final3 = Convert.ToString(dats3);
        //                                    label27.Text = final3;
        //                                    m_TagTable7.Add(rfids7, item2225);
        //                                }

        //                                //inventoryList.Columns[0].Width = 250;
        //                                //inventoryList.Columns[1].Width = 100;
        //                                //inventoryList.Columns[2].Width = 100;
        //                                //inventoryList.Columns[3].Width = 100;
        //                                //inventoryList.Columns[4].Width = 150;



        //                                DataTable tvp = new DataTable();
        //                                DataTable tbCategories = new DataTable("FilterCategory");
        //                                tbCategories.Columns.Add("RfidId", typeof(string));
        //                                tbCategories.Columns.Add("Reader", typeof(string));
        //                                tbCategories.Columns.Add("Antenna", typeof(string));
        //                                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                                DataTable table = new DataTable();
        //                                DataRow row = tbCategories.NewRow();
        //                                row["RfidId"] = rfids7;
        //                                row["Reader"] = m_ReaderAPI7.HostName;
        //                                row["Antenna"] = antena8;

        //                                // rfids = tag.TagID;
        //                                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                                tbCategories.Rows.Add(row);

        //                                DataSet ds = new DataSet();
        //                                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                                {
        //                                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                                    Thread.Sleep(700);
        //                                    //Thread.Sleep(700);
        //                                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                                    Hashtable hat = new Hashtable();
        //                                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1", hat, "spp");
        //                                    if (kk > 0)
        //                                    {

        //                                    }


        //                                }




        //                                //btna1.BackColor = System.Drawing.Color.Green;
        //                                //btna2.BackColor = System.Drawing.Color.Red;
        //                                //btna3.BackColor = System.Drawing.Color.Red;
        //                                //btna4.BackColor = System.Drawing.Color.Red;
        //                                //btna5.BackColor = System.Drawing.Color.Red;
        //                                //btna6.BackColor = System.Drawing.Color.Red;
        //                                //btna7.BackColor = System.Drawing.Color.Red;
        //                                //btna8.BackColor = System.Drawing.Color.Red;


        //                                DataSet dsss = new DataSet();
        //                                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids7 + "'", "spp");
        //                                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                                {
        //                                    Hashtable hats = new Hashtable();
        //                                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids7 + "'", hats, "spp");
        //                                    if (up > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    Hashtable hats1 = new Hashtable();
        //                                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids7 + "',getdate(),'" + m_ReaderAPI7.HostName + "','"+antena8+"')", hats1, "spp");
        //                                    if (ups > 0)
        //                                    {

        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }



        //                            }

        //                        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}




        #region withoutsensormyUpdateRead7
        public void myUpdateRead7(Events.ReadEventData eventData7)
        {
            if (chkin7.Checked == true)
            {
                //if (m_IsConnected7)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
                //        {

                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData1114 = m_ReaderAPI7.Actions.GetReadTags(1000);
                                if (tagData1114 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag1114 in tagData1114)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item1114 = new ListViewItem(tag1114.TagID);
                                        ListViewItem.ListViewSubItem subItem1114;


                                        subItem1114 = new ListViewItem.ListViewSubItem(item1114, getTagEvent(tag1114));
                                        item1114.SubItems.Add(subItem1114);

                                        //subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.AntennaID.ToString());
                                        //item1114.SubItems.Add(subItem1114);

                                        antena8 = Convert.ToInt32(tag1114.AntennaID.ToString());
                                        rfids7 = tag1114.TagID;

                                        //subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag1114.TagSeenCount;
                                        //item1114.SubItems.Add(subItem1114);

                                        //subItem1114 = new ListViewItem.ListViewSubItem(item1114, m_ReaderAPI7.HostName);
                                        //item1114.SubItems.Add(subItem1114);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable7.SyncRoot)
                                        {

                                            //int dats = Convert.ToInt32(m_TagTable7.Count);
                                            //string final = Convert.ToString(dats);
                                            //label27.Text = final;
                                            m_TagTable7.Add(rfids7, item1114);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids7;
                                        row["Reader"] = m_ReaderAPI7.HostName;
                                        row["Antenna"] = antena8;

                                        //rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);


                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }
                                        try
                                        {
                                            if (rfids7 == "")
                                            {

                                            }
                                            else
                                            {
                                                SqlConnection connection = new SqlConnection();
                                                connection.ConnectionString = connectionString1;
                                                connection.Open();
                                                SqlCommand cmd2 = new SqlCommand();
                                                cmd2.Connection = connection;
                                                cmd2.CommandType = CommandType.StoredProcedure;
                                                cmd2.CommandTimeout = 10000;
                                                cmd2.CommandText = "InsertIntoMyTable1";
                                                cmd2.Parameters.AddWithValue("@mytable", tbCategories);
                                                int i = cmd2.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }


                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else if (chkout7.Checked == true)
            {
                //if (m_IsConnected7)
                //{
                //    for (int index = 0; index < 8; index++)
                //    {
                //        if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
                //        {
                //            GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

                //            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                //            {

                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                //            {
                                Symbol.RFID3.TagData[] tagData2225 = m_ReaderAPI7.Actions.GetReadTags(1000);
                                if (tagData2225 != null)
                                {
                                    foreach (Symbol.RFID3.TagData tag2225 in tagData2225)
                                    {
                                        //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                                        //{
                                        //    if (tagData[nIndex].ContainsLocationInfo)
                                        //    {
                                        //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
                                        //    }

                                        //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                                        //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                        //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                                        //    {
                                        //        Symbol.RFID3.TagData tag = tagData[nIndex];

                                        //        tagID = tag.TagID;
                                        //        bool isFound = false;

                                        //        lock (m_TagTable.SyncRoot)
                                        //        {
                                        //            isFound = m_TagTable.ContainsKey(tagID);
                                        //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
                                        //            {
                                        //                tagID = tag.TagID + tag.MemoryBank.ToString()
                                        //                    + tag.MemoryBankDataOffset.ToString();
                                        //                isFound = m_TagTable.ContainsKey(tagID);
                                        //            }
                                        //        }

                                        //        if (isFound)
                                        //        {
                                        //            uint count = 0;
                                        //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
                                        //            try
                                        //            {
                                        //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
                                        //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
                                        //            }
                                        //            catch (FormatException fe)
                                        //            {
                                        //                functionCallStatusLabel.Text = fe.Message;
                                        //                break;
                                        //            }
                                        //            item.SubItems[2].Text = tag.AntennaID.ToString();
                                        //            item.SubItems[3].Text = count.ToString();
                                        //           // item.SubItems[4].Text = IPaddress;

                                        //            string memoryBank = tag.MemoryBank.ToString();
                                        //            int index = memoryBank.LastIndexOf('_');
                                        //            if (index != -1)
                                        //            {
                                        //                memoryBank = memoryBank.Substring(index + 1);
                                        //            }
                                        //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
                                        //            {
                                        //                //item.SubItems[6].Text = tag.MemoryBankData;
                                        //                //item.SubItems[7].Text = memoryBank;
                                        //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

                                        //                lock (m_TagTable.SyncRoot)
                                        //                {
                                        //                    m_TagTable.Remove(tagID);
                                        //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
                                        //                        + tag.MemoryBankDataOffset.ToString(), item);
                                        //                }
                                        //            }
                                        //            item.SubItems[1].Text = getTagEvent(tag);

                                        //        }
                                        //        else
                                        //        {
                                        ListViewItem item2225 = new ListViewItem(tag2225.TagID);
                                        ListViewItem.ListViewSubItem subItem2225;


                                        subItem2225 = new ListViewItem.ListViewSubItem(item2225, getTagEvent(tag2225));
                                        item2225.SubItems.Add(subItem2225);

                                        //subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.AntennaID.ToString());
                                        //item2225.SubItems.Add(subItem2225);

                                        antena8 = Convert.ToInt32(tag2225.AntennaID.ToString());
                                        rfids7 = tag2225.TagID;

                                        //subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.TagSeenCount.ToString());
                                        //m_TagTotalCount += tag2225.TagSeenCount;
                                        //item2225.SubItems.Add(subItem2225);

                                        //subItem2225 = new ListViewItem.ListViewSubItem(item2225, m_ReaderAPI7.HostName);
                                        //item2225.SubItems.Add(subItem2225);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
                                        //item.SubItems.Add(subItem);

                                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
                                        //item.SubItems.Add(subItem);

                                        //if (memBank_CB.SelectedIndex >= 1)
                                        //{
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
                                        //    //item.SubItems.Add(subItem);

                                        //    string memoryBank = tag.MemoryBank.ToString();
                                        //    int index = memoryBank.LastIndexOf('_');
                                        //    if (index != -1)
                                        //    {
                                        //        memoryBank = memoryBank.Substring(index + 1);
                                        //    }

                                        //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                                        //    //item.SubItems.Add(subItem);
                                        //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
                                        //    //item.SubItems.Add(subItem);
                                        //}
                                        //else
                                        //{
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //    subItem = new ListViewItem.ListViewSubItem(item, "");
                                        //    item.SubItems.Add(subItem);
                                        //}
                                        //inventoryList.BeginUpdate();
                                        //inventoryList.Items.Add(item3);
                                        //inventoryList.EndUpdate();

                                        lock (m_TagTable7.SyncRoot)
                                        {
                                            //int dats3 = Convert.ToInt32(m_TagTable7.Count);
                                            //string final3 = Convert.ToString(dats3);
                                            //label27.Text = final3;
                                            m_TagTable7.Add(rfids7, item2225);
                                        }

                                        //inventoryList.Columns[0].Width = 250;
                                        //inventoryList.Columns[1].Width = 100;
                                        //inventoryList.Columns[2].Width = 100;
                                        //inventoryList.Columns[3].Width = 100;
                                        //inventoryList.Columns[4].Width = 150;



                                        DataTable tvp = new DataTable();
                                        DataTable tbCategories = new DataTable("FilterCategory");
                                        tbCategories.Columns.Add("RfidId", typeof(string));
                                        tbCategories.Columns.Add("Reader", typeof(string));
                                        tbCategories.Columns.Add("Antenna", typeof(string));
                                        tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
                                        DataTable table = new DataTable();
                                        DataRow row = tbCategories.NewRow();
                                        row["RfidId"] = rfids7;
                                        row["Reader"] = m_ReaderAPI7.HostName;
                                        row["Antenna"] = antena8;

                                        // rfids = tag.TagID;
                                        row["Rd_time"] = DateTime.Now.ToLongTimeString();
                                        tbCategories.Rows.Add(row);

                                        DataSet ds = new DataSet();
                                        ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
                                            Thread.Sleep(700);
                                            //Thread.Sleep(700);
                                            m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

                                            Hashtable hat = new Hashtable();
                                            int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
                                            if (kk > 0)
                                            {

                                            }


                                        }




                                        //btna1.BackColor = System.Drawing.Color.Green;
                                        //btna2.BackColor = System.Drawing.Color.Red;
                                        //btna3.BackColor = System.Drawing.Color.Red;
                                        //btna4.BackColor = System.Drawing.Color.Red;
                                        //btna5.BackColor = System.Drawing.Color.Red;
                                        //btna6.BackColor = System.Drawing.Color.Red;
                                        //btna7.BackColor = System.Drawing.Color.Red;
                                        //btna8.BackColor = System.Drawing.Color.Red;


                                        DataSet dsss = new DataSet();
                                        dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids7 + "'", "spp");
                                        if (dsss != null && dsss.Tables[0].Rows.Count > 0)
                                        {
                                            Hashtable hats = new Hashtable();
                                            int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids7 + "'", hats, "spp");
                                            if (up > 0)
                                            {

                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Hashtable hats1 = new Hashtable();
                                            int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids7 + "',getdate(),'" + m_ReaderAPI7.HostName + "','" + antena8 + "')", hats1, "spp");
                                            if (ups > 0)
                                            {

                                            }
                                            else
                                            {

                                            }

                                        }



                                    }

                                }
                //            }
                //            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                //            {

                //            }
                //        }
                //    }
                //}

            }
            else
            {

            }
        }
        #endregion


        //#region withsensormyUpdateRead7
        //public void myUpdateRead7(Events.ReadEventData eventData7)
        //{
        //    if (chkin7.Checked == true)
        //    {
        //        if (m_IsConnected7)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
        //                {

        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData1114 = m_ReaderAPI7.Actions.GetReadTags(1000);
        //        if (tagData1114 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag1114 in tagData1114)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text 4= tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item1114 = new ListViewItem(tag1114.TagID);
        //                ListViewItem.ListViewSubItem subItem1114;


        //                subItem1114 = new ListViewItem.ListViewSubItem(item1114, getTagEvent(tag1114));
        //                item1114.SubItems.Add(subItem1114);

        //                //subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.AntennaID.ToString());
        //                //item1114.SubItems.Add(subItem1114);

        //                antena8 = Convert.ToInt32(tag1114.AntennaID.ToString());
        //                rfids7 = tag1114.TagID;

        //                //subItem1114 = new ListViewItem.ListViewSubItem(item1114, tag1114.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag1114.TagSeenCount;
        //                //item1114.SubItems.Add(subItem1114);

        //                //subItem1114 = new ListViewItem.ListViewSubItem(item1114, m_ReaderAPI7.HostName);
        //                //item1114.SubItems.Add(subItem1114);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable7.SyncRoot)
        //                {

        //                    //int dats = Convert.ToInt32(m_TagTable7.Count);
        //                    //string final = Convert.ToString(dats);
        //                    //label27.Text = final;
        //                    m_TagTable7.Add(rfids7, item1114);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids7;
        //                row["Reader"] = m_ReaderAPI7.HostName;
        //                row["Antenna"] = antena8;

        //                //rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);


        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.documentpartymaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.documentpartymaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }
        //                try
        //                {
        //                    if (rfids7 == "")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        SqlConnection connection = new SqlConnection();
        //                        connection.ConnectionString = connectionString1;
        //                        connection.Open();
        //                        SqlCommand cmd2 = new SqlCommand();
        //                        cmd2.Connection = connection;
        //                        cmd2.CommandType = CommandType.StoredProcedure;
        //                        cmd2.CommandTimeout = 10000;
        //                        cmd2.CommandText = "InsertIntoMyTable1";
        //                        cmd2.Parameters.AddWithValue("@mytable", tbCategories);
        //                        int i = cmd2.ExecuteNonQuery();
        //                        connection.Close();
        //                    }
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else if (chkout7.Checked == true)
        //    {
        //        if (m_IsConnected7)
        //        {
        //            for (int index = 0; index < 8; index++)
        //            {
        //                if (index < m_ReaderAPI7.ReaderCapabilities.NumGPIPorts)
        //                {
        //                    GPIs.GPI_PORT_STATE portState = m_ReaderAPI7.Config.GPI[index + 1].PortState;

        //                    if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
        //                    {

        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
        //                    {
        //        Symbol.RFID3.TagData[] tagData2225 = m_ReaderAPI7.Actions.GetReadTags(1000);
        //        if (tagData2225 != null)
        //        {
        //            foreach (Symbol.RFID3.TagData tag2225 in tagData2225)
        //            {
        //                //for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //                //{
        //                //    if (tagData[nIndex].ContainsLocationInfo)
        //                //    {
        //                //        m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                //    }

        //                //    if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                //        (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                //        tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                //    {
        //                //        Symbol.RFID3.TagData tag = tagData[nIndex];

        //                //        tagID = tag.TagID;
        //                //        bool isFound = false;

        //                //        lock (m_TagTable.SyncRoot)
        //                //        {
        //                //            isFound = m_TagTable.ContainsKey(tagID);
        //                //            if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                //            {
        //                //                tagID = tag.TagID + tag.MemoryBank.ToString()
        //                //                    + tag.MemoryBankDataOffset.ToString();
        //                //                isFound = m_TagTable.ContainsKey(tagID);
        //                //            }
        //                //        }

        //                //        if (isFound)
        //                //        {
        //                //            uint count = 0;
        //                //            ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                //            try
        //                //            {
        //                //                count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                //                m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                //            }
        //                //            catch (FormatException fe)
        //                //            {
        //                //                functionCallStatusLabel.Text = fe.Message;
        //                //                break;
        //                //            }
        //                //            item.SubItems[2].Text = tag.AntennaID.ToString();
        //                //            item.SubItems[3].Text = count.ToString();
        //                //           // item.SubItems[4].Text = IPaddress;

        //                //            string memoryBank = tag.MemoryBank.ToString();
        //                //            int index = memoryBank.LastIndexOf('_');
        //                //            if (index != -1)
        //                //            {
        //                //                memoryBank = memoryBank.Substring(index + 1);
        //                //            }
        //                //            if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                //            {
        //                //                //item.SubItems[6].Text = tag.MemoryBankData;
        //                //                //item.SubItems[7].Text = memoryBank;
        //                //                //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                //                lock (m_TagTable.SyncRoot)
        //                //                {
        //                //                    m_TagTable.Remove(tagID);
        //                //                    m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                //                        + tag.MemoryBankDataOffset.ToString(), item);
        //                //                }
        //                //            }
        //                //            item.SubItems[1].Text = getTagEvent(tag);

        //                //        }
        //                //        else
        //                //        {
        //                ListViewItem item2225 = new ListViewItem(tag2225.TagID);
        //                ListViewItem.ListViewSubItem subItem2225;


        //                subItem2225 = new ListViewItem.ListViewSubItem(item2225, getTagEvent(tag2225));
        //                item2225.SubItems.Add(subItem2225);

        //                //subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.AntennaID.ToString());
        //                //item2225.SubItems.Add(subItem2225);

        //                antena8 = Convert.ToInt32(tag2225.AntennaID.ToString());
        //                rfids7 = tag2225.TagID;

        //                //subItem2225 = new ListViewItem.ListViewSubItem(item2225, tag2225.TagSeenCount.ToString());
        //                //m_TagTotalCount += tag2225.TagSeenCount;
        //                //item2225.SubItems.Add(subItem2225);

        //                //subItem2225 = new ListViewItem.ListViewSubItem(item2225, m_ReaderAPI7.HostName);
        //                //item2225.SubItems.Add(subItem2225);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                //item.SubItems.Add(subItem);

        //                //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                //item.SubItems.Add(subItem);

        //                //if (memBank_CB.SelectedIndex >= 1)
        //                //{
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                //    //item.SubItems.Add(subItem);

        //                //    string memoryBank = tag.MemoryBank.ToString();
        //                //    int index = memoryBank.LastIndexOf('_');
        //                //    if (index != -1)
        //                //    {
        //                //        memoryBank = memoryBank.Substring(index + 1);
        //                //    }

        //                //    //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                //    //item.SubItems.Add(subItem);
        //                //    //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                //    //item.SubItems.Add(subItem);
        //                //}
        //                //else
        //                //{
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //    subItem = new ListViewItem.ListViewSubItem(item, "");
        //                //    item.SubItems.Add(subItem);
        //                //}
        //                //inventoryList.BeginUpdate();
        //                //inventoryList.Items.Add(item3);
        //                //inventoryList.EndUpdate();

        //                lock (m_TagTable7.SyncRoot)
        //                {
        //                    //int dats3 = Convert.ToInt32(m_TagTable7.Count);
        //                    //string final3 = Convert.ToString(dats3);
        //                    //label27.Text = final3;
        //                    m_TagTable7.Add(rfids7, item2225);
        //                }

        //                //inventoryList.Columns[0].Width = 250;
        //                //inventoryList.Columns[1].Width = 100;
        //                //inventoryList.Columns[2].Width = 100;
        //                //inventoryList.Columns[3].Width = 100;
        //                //inventoryList.Columns[4].Width = 150;



        //                DataTable tvp = new DataTable();
        //                DataTable tbCategories = new DataTable("FilterCategory");
        //                tbCategories.Columns.Add("RfidId", typeof(string));
        //                tbCategories.Columns.Add("Reader", typeof(string));
        //                tbCategories.Columns.Add("Antenna", typeof(string));
        //                tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //                DataTable table = new DataTable();
        //                DataRow row = tbCategories.NewRow();
        //                row["RfidId"] = rfids7;
        //                row["Reader"] = m_ReaderAPI7.HostName;
        //                row["Antenna"] = antena8;

        //                // rfids = tag.TagID;
        //                row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //                tbCategories.Rows.Add(row);

        //                DataSet ds = new DataSet();
        //                ds = d2.select_method_wo_parameter("select * from trolley.dbo.DocumentOutwardpartyMaster  where Itemstatus='Done' and AlaramFlg is null ", "spp");

        //                if (ds != null && ds.Tables[0].Rows.Count > 0)
        //                {
        //                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.TRUE;
        //                    Thread.Sleep(700);
        //                    //Thread.Sleep(700);
        //                    m_ReaderAPI7.Config.GPO[4].PortState = GPOs.GPO_PORT_STATE.FALSE;

        //                    Hashtable hat = new Hashtable();
        //                    int kk = d2.insert_method("update trolley.dbo.DocumentOutwardpartyMaster set AlaramFlg=1 where Itemstatus='Done'", hat, "spp");
        //                    if (kk > 0)
        //                    {

        //                    }


        //                }




        //                //btna1.BackColor = System.Drawing.Color.Green;
        //                //btna2.BackColor = System.Drawing.Color.Red;
        //                //btna3.BackColor = System.Drawing.Color.Red;
        //                //btna4.BackColor = System.Drawing.Color.Red;
        //                //btna5.BackColor = System.Drawing.Color.Red;
        //                //btna6.BackColor = System.Drawing.Color.Red;
        //                //btna7.BackColor = System.Drawing.Color.Red;
        //                //btna8.BackColor = System.Drawing.Color.Red;


        //                DataSet dsss = new DataSet();
        //                dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + rfids7 + "'", "spp");
        //                if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                {
        //                    Hashtable hats = new Hashtable();
        //                    int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + rfids7 + "'", hats, "spp");
        //                    if (up > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                else
        //                {
        //                    Hashtable hats1 = new Hashtable();
        //                    int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate,ReaderIP,AntennaID) values('" + rfids7 + "',getdate(),'" + m_ReaderAPI7.HostName + "','" + antena8 + "')", hats1, "spp");
        //                    if (ups > 0)
        //                    {

        //                    }
        //                    else
        //                    {

        //                    }

        //                }



        //            }

        //        }
        //                    }
        //                    else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
        //                    {

        //                    }
        //                }
        //            }
        //        }

        //    }
        //    else
        //    {

        //    }
        //}
        //#endregion
        //public void myUpdateRead(Events.ReadEventData eventData)
        //{
        //    if (chkin.Checked == true)
        //    {
        //        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //        if (tagData != null)
        //        {
        //            for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //            {
        //                if (tagData[nIndex].ContainsLocationInfo)
        //                {
        //                    m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                }

        //                if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                    (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                    tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                {
        //                    Symbol.RFID3.TagData tag = tagData[nIndex];
        //                    tagID = tag.TagID;
        //                    bool isFound = false;

        //                    lock (m_TagTable.SyncRoot)
        //                    {
        //                        isFound = m_TagTable.ContainsKey(tagID);
        //                        if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                        {
        //                            tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                + tag.MemoryBankDataOffset.ToString();
        //                            isFound = m_TagTable.ContainsKey(tagID);
        //                        }
        //                    }

        //                    if (isFound)
        //                    {
        //                        uint count = 0;
        //                        ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                        try
        //                        {
        //                            count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                            m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                        }
        //                        catch (FormatException fe)
        //                        {
        //                            functionCallStatusLabel.Text = fe.Message;
        //                            break;
        //                        }
        //                        item.SubItems[2].Text = tag.AntennaID.ToString();
        //                        item.SubItems[3].Text = count.ToString();
        //                        // item.SubItems[4].Text = tag.PeakRSSI.ToString();

        //                        string memoryBank = tag.MemoryBank.ToString();
        //                        int index = memoryBank.LastIndexOf('_');
        //                        if (index != -1)
        //                        {
        //                            memoryBank = memoryBank.Substring(index + 1);
        //                        }
        //                        if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                        {
        //                            //item.SubItems[6].Text = tag.MemoryBankData;
        //                            //item.SubItems[7].Text = memoryBank;
        //                            //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                            lock (m_TagTable.SyncRoot)
        //                            {
        //                                m_TagTable.Remove(tagID);
        //                                m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                    + tag.MemoryBankDataOffset.ToString(), item);
        //                            }
        //                        }
        //                        item.SubItems[1].Text = getTagEvent(tag);

        //                    }
        //                    else
        //                    {
        //                        ListViewItem item = new ListViewItem(tag.TagID);
        //                        ListViewItem.ListViewSubItem subItem;


        //                        subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                        item.SubItems.Add(subItem);

        //                        subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                        item.SubItems.Add(subItem);

        //                        antena1 = Convert.ToInt32(tag.AntennaID.ToString());

        //                        subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                        m_TagTotalCount += tag.TagSeenCount;
        //                        item.SubItems.Add(subItem);

        //                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                        //item.SubItems.Add(subItem);

        //                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                        //item.SubItems.Add(subItem);

        //                        if (memBank_CB.SelectedIndex >= 1)
        //                        {
        //                            //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                            //item.SubItems.Add(subItem);

        //                            string memoryBank = tag.MemoryBank.ToString();
        //                            int index = memoryBank.LastIndexOf('_');
        //                            if (index != -1)
        //                            {
        //                                memoryBank = memoryBank.Substring(index + 1);
        //                            }

        //                            //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                            //item.SubItems.Add(subItem);
        //                            //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                            //item.SubItems.Add(subItem);
        //                        }
        //                        else
        //                        {
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                        }
        //                        inventoryList.BeginUpdate();
        //                        inventoryList.Items.Add(item);
        //                        inventoryList.EndUpdate();

        //                        lock (m_TagTable.SyncRoot)
        //                        {
        //                            m_TagTable.Add(tagID, item);
        //                        }

        //                        inventoryList.Columns[0].Width = 250;
        //                        inventoryList.Columns[1].Width = 150;
        //                        inventoryList.Columns[2].Width = 150;
        //                        inventoryList.Columns[3].Width = 450;
        //                    }
        //                }
        //            }
        //            int dats = Convert.ToInt32(m_TagTable.Count);
        //            string final = Convert.ToString(dats);
        //            lblcount.Text = final;
        //            // lblcount.Text = m_TagTable.Count + "(" + m_TagTotalCount + ")";


        //            DataTable tvp = new DataTable();
        //            DataTable tbCategories = new DataTable("FilterCategory");
        //            tbCategories.Columns.Add("RfidId", typeof(string));
        //            tbCategories.Columns.Add("Reader", typeof(string));
        //            tbCategories.Columns.Add("Antenna", typeof(string));
        //            tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //            DataTable table = new DataTable();
        //            DataRow row = tbCategories.NewRow();
        //            row["RfidId"] = tagID;
        //            row["Reader"] = m_ConnectionForm.IpText;
        //            row["Antenna"] = antena1;

        //            //rfids = tag.TagID;
        //            row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //            tbCategories.Rows.Add(row);

        //            if (antena1 == 1)
        //            {
        //                try
        //                {
        //                    btna1.BackColor = System.Drawing.Color.Green;
        //                    btna2.BackColor = System.Drawing.Color.Red;
        //                    btna3.BackColor = System.Drawing.Color.Red;
        //                    btna4.BackColor = System.Drawing.Color.Red;
        //                    btna5.BackColor = System.Drawing.Color.Red;
        //                    btna6.BackColor = System.Drawing.Color.Red;
        //                    btna7.BackColor = System.Drawing.Color.Red;
        //                    btna8.BackColor = System.Drawing.Color.Red;

        //                    SqlConnection connection = new SqlConnection();
        //                    connection.ConnectionString = connectionString1;
        //                    connection.Open();
        //                    SqlCommand cmd = new SqlCommand();
        //                    cmd.Connection = connection;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 10000;
        //                    cmd.CommandText = "InsertIntoMyTable1";
        //                    cmd.Parameters.AddWithValue("@mytable", tbCategories);
        //                    int i = cmd.ExecuteNonQuery();
        //                    connection.Close();
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            else
        //            {

        //            }
        //            if (antena1 == 2)
        //            {
        //                try
        //                {
        //                    btna1.BackColor = System.Drawing.Color.Red;
        //                    btna2.BackColor = System.Drawing.Color.Green;
        //                    btna3.BackColor = System.Drawing.Color.Red;
        //                    btna4.BackColor = System.Drawing.Color.Red;
        //                    btna5.BackColor = System.Drawing.Color.Red;
        //                    btna6.BackColor = System.Drawing.Color.Red;
        //                    btna7.BackColor = System.Drawing.Color.Red;
        //                    btna8.BackColor = System.Drawing.Color.Red;
        //                    SqlConnection connection = new SqlConnection();
        //                    connection.ConnectionString = connectionString1;
        //                    connection.Open();
        //                    SqlCommand cmd = new SqlCommand();
        //                    cmd.Connection = connection;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 10000;
        //                    cmd.CommandText = "InsertIntoMyTable1";
        //                    cmd.Parameters.AddWithValue("@mytable", tbCategories);
        //                    int i = cmd.ExecuteNonQuery();
        //                    connection.Close();
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            else
        //            {

        //            }
        //            if (antena1 == 3)
        //            {
        //                try
        //                {
        //                    btna1.BackColor = System.Drawing.Color.Red;
        //                    btna2.BackColor = System.Drawing.Color.Red;
        //                    btna3.BackColor = System.Drawing.Color.Green;
        //                    btna4.BackColor = System.Drawing.Color.Red;
        //                    btna5.BackColor = System.Drawing.Color.Red;
        //                    btna6.BackColor = System.Drawing.Color.Red;
        //                    btna7.BackColor = System.Drawing.Color.Red;
        //                    btna8.BackColor = System.Drawing.Color.Red;
        //                    SqlConnection connection = new SqlConnection();
        //                    connection.ConnectionString = connectionString1;
        //                    connection.Open();
        //                    SqlCommand cmd = new SqlCommand();
        //                    cmd.Connection = connection;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 10000;
        //                    cmd.CommandText = "InsertIntoMyTable1";
        //                    cmd.Parameters.AddWithValue("@mytable", tbCategories);
        //                    int i = cmd.ExecuteNonQuery();
        //                    connection.Close();
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            else
        //            {

        //            }
        //            if (antena1 == 4)
        //            {
        //                try
        //                {
        //                    btna1.BackColor = System.Drawing.Color.Red;
        //                    btna2.BackColor = System.Drawing.Color.Red;
        //                    btna3.BackColor = System.Drawing.Color.Red;
        //                    btna4.BackColor = System.Drawing.Color.Green;
        //                    btna5.BackColor = System.Drawing.Color.Red;
        //                    btna6.BackColor = System.Drawing.Color.Red;
        //                    btna7.BackColor = System.Drawing.Color.Red;
        //                    btna8.BackColor = System.Drawing.Color.Red;
        //                    SqlConnection connection = new SqlConnection();
        //                    connection.ConnectionString = connectionString1;
        //                    connection.Open();
        //                    SqlCommand cmd = new SqlCommand();
        //                    cmd.Connection = connection;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 10000;
        //                    cmd.CommandText = "InsertIntoMyTable1";
        //                    cmd.Parameters.AddWithValue("@mytable", tbCategories);
        //                    int i = cmd.ExecuteNonQuery();
        //                    connection.Close();
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //    else if (chkout.Checked == true)
        //    {
        //        Symbol.RFID3.TagData[] tagData = m_ReaderAPI.Actions.GetReadTags(1000);
        //        if (tagData != null)
        //        {
        //            for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
        //            {
        //                if (tagData[nIndex].ContainsLocationInfo)
        //                {
        //                    m_LocateForm.Locate_PB.Value = tagData[nIndex].LocationInfo.RelativeDistance;
        //                }

        //                if (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
        //                    (tagData[nIndex].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
        //                    tagData[nIndex].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
        //                {
        //                    Symbol.RFID3.TagData tag = tagData[nIndex];
        //                    tagID = tag.TagID;
        //                    bool isFound = false;

        //                    lock (m_TagTable.SyncRoot)
        //                    {
        //                        isFound = m_TagTable.ContainsKey(tagID);
        //                        if (!isFound && this.memBank_CB.SelectedIndex >= 1)
        //                        {
        //                            tagID = tag.TagID + tag.MemoryBank.ToString()
        //                                + tag.MemoryBankDataOffset.ToString();
        //                            isFound = m_TagTable.ContainsKey(tagID);
        //                        }
        //                    }

        //                    if (isFound)
        //                    {
        //                        uint count = 0;
        //                        ListViewItem item = (ListViewItem)m_TagTable[tagID];
        //                        try
        //                        {
        //                            count = uint.Parse(item.SubItems[3].Text) + tagData[nIndex].TagSeenCount;
        //                            m_TagTotalCount += tagData[nIndex].TagSeenCount;
        //                        }
        //                        catch (FormatException fe)
        //                        {
        //                            functionCallStatusLabel.Text = fe.Message;
        //                            break;
        //                        }
        //                        item.SubItems[2].Text = tag.AntennaID.ToString();
        //                        item.SubItems[3].Text = count.ToString();
        //                        // item.SubItems[4].Text = tag.PeakRSSI.ToString();

        //                        string memoryBank = tag.MemoryBank.ToString();
        //                        int index = memoryBank.LastIndexOf('_');
        //                        if (index != -1)
        //                        {
        //                            memoryBank = memoryBank.Substring(index + 1);
        //                        }
        //                        if (tag.MemoryBankData.Length > 0 && !memoryBank.Equals(item.SubItems[5].Text))
        //                        {
        //                            //item.SubItems[6].Text = tag.MemoryBankData;
        //                            //item.SubItems[7].Text = memoryBank;
        //                            //item.SubItems[8].Text = tag.MemoryBankDataOffset.ToString();

        //                            lock (m_TagTable.SyncRoot)
        //                            {
        //                                m_TagTable.Remove(tagID);
        //                                m_TagTable.Add(tag.TagID + tag.MemoryBank.ToString()
        //                                    + tag.MemoryBankDataOffset.ToString(), item);
        //                            }
        //                        }
        //                        item.SubItems[1].Text = getTagEvent(tag);

        //                    }
        //                    else
        //                    {
        //                        ListViewItem item = new ListViewItem(tag.TagID);
        //                        ListViewItem.ListViewSubItem subItem;


        //                        subItem = new ListViewItem.ListViewSubItem(item, getTagEvent(tag));
        //                        item.SubItems.Add(subItem);

        //                        subItem = new ListViewItem.ListViewSubItem(item, tag.AntennaID.ToString());
        //                        item.SubItems.Add(subItem);

        //                        antena1 = Convert.ToInt32(tag.AntennaID.ToString());

        //                        subItem = new ListViewItem.ListViewSubItem(item, tag.TagSeenCount.ToString());
        //                        m_TagTotalCount += tag.TagSeenCount;
        //                        item.SubItems.Add(subItem);

        //                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PeakRSSI.ToString());
        //                        //item.SubItems.Add(subItem);

        //                        //subItem = new ListViewItem.ListViewSubItem(item, tag.PC.ToString("X"));
        //                        //item.SubItems.Add(subItem);

        //                        if (memBank_CB.SelectedIndex >= 1)
        //                        {
        //                            //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankData);
        //                            //item.SubItems.Add(subItem);

        //                            string memoryBank = tag.MemoryBank.ToString();
        //                            int index = memoryBank.LastIndexOf('_');
        //                            if (index != -1)
        //                            {
        //                                memoryBank = memoryBank.Substring(index + 1);
        //                            }

        //                            //subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
        //                            //item.SubItems.Add(subItem);
        //                            //subItem = new ListViewItem.ListViewSubItem(item, tag.MemoryBankDataOffset.ToString());
        //                            //item.SubItems.Add(subItem);
        //                        }
        //                        else
        //                        {
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                            subItem = new ListViewItem.ListViewSubItem(item, "");
        //                            item.SubItems.Add(subItem);
        //                        }
        //                        inventoryList.BeginUpdate();
        //                        inventoryList.Items.Add(item);
        //                        inventoryList.EndUpdate();

        //                        lock (m_TagTable.SyncRoot)
        //                        {
        //                            m_TagTable.Add(tagID, item);
        //                        }

        //                        inventoryList.Columns[0].Width = 250;
        //                        inventoryList.Columns[1].Width = 150;
        //                        inventoryList.Columns[2].Width = 150;
        //                        inventoryList.Columns[3].Width = 250;
        //                    }
        //                }
        //            }
        //            int dats = Convert.ToInt32(m_TagTable.Count);
        //            string final = Convert.ToString(dats);
        //            lblcount.Text = final;
        //            // lblcount.Text = m_TagTable.Count + "(" + m_TagTotalCount + ")";


        //            DataTable tvp = new DataTable();
        //            DataTable tbCategories = new DataTable("FilterCategory");
        //            tbCategories.Columns.Add("RfidId", typeof(string));
        //            tbCategories.Columns.Add("Reader", typeof(string));
        //            tbCategories.Columns.Add("Antenna", typeof(string));
        //            tbCategories.Columns.Add("Rd_Time", typeof(DateTime));
        //            DataTable table = new DataTable();
        //            DataRow row = tbCategories.NewRow();
        //            row["RfidId"] = tagID;
        //            row["Reader"] = m_ConnectionForm.IpText;
        //            row["Antenna"] = antena1;

        //            //rfids = tag.TagID;
        //            row["Rd_time"] = DateTime.Now.ToLongTimeString();
        //            tbCategories.Rows.Add(row);

        //            if (antena1 == 1)
        //            {
        //                try
        //                {
        //                    DataSet dsss = new DataSet();
        //                    dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + tagID + "'", "spp");
        //                    if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                    {
        //                        Hashtable hats=new Hashtable();
        //                        int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + tagID + "'", hats, "spp");
        //                        if (up > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {
        //                        Hashtable hats1 = new Hashtable();
        //                        int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate) values('" + tagID + "'',getdate())", hats1, "spp");
        //                        if (ups > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }

        //                    }
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            if (antena1 == 2)
        //            {
        //                try
        //                {
        //                    DataSet dsss = new DataSet();
        //                    dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + tagID + "'", "spp");
        //                    if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                    {
        //                        Hashtable hats = new Hashtable();
        //                        int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + tagID + "'", hats, "spp");
        //                        if (up > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {
        //                        Hashtable hats1 = new Hashtable();
        //                        int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate) values('" + tagID + "'',getdate())", hats1, "spp");
        //                        if (ups > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }

        //                    }
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            if (antena1 == 3)
        //            {
        //                try
        //                {
        //                    DataSet dsss = new DataSet();
        //                    dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + tagID + "'", "spp");
        //                    if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                    {
        //                        Hashtable hats = new Hashtable();
        //                        int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + tagID + "'", hats, "spp");
        //                        if (up > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {
        //                        Hashtable hats1 = new Hashtable();
        //                        int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate) values('" + tagID + "'',getdate())", hats1, "spp");
        //                        if (ups > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }

        //                    }
        //                }
        //                catch
        //                {

        //                }

        //            }
        //            if (antena1 == 4)
        //            {
        //                try
        //                {
        //                    DataSet dsss = new DataSet();
        //                    dsss = data2.select_method_wo_parameter("select * from Dispatchrfid where printerRfidID='" + tagID + "'", "spp");
        //                    if (dsss != null && dsss.Tables[0].Rows.Count > 0)
        //                    {
        //                        Hashtable hats = new Hashtable();
        //                        int up = data2.insert_method("update Dispatchrfid set Updatedate=getdate() where printerRfidID='" + tagID + "'", hats, "spp");
        //                        if (up > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {
        //                        Hashtable hats1 = new Hashtable();
        //                        int ups = data2.insert_method("insert into Dispatchrfid(printerRfidID,Updatedate) values('" + tagID + "',getdate())", hats1, "spp");
        //                        if (ups > 0)
        //                        {

        //                        }
        //                        else
        //                        {

        //                        }

        //                    }
        //                }
        //                catch
        //                {

        //                }

        //            }
                    
        //        }
        //    }
        //    else
        //    {

        //    }

            
                                    
        //}
       

        private void Events_ReadNotify(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }

        private void Events_ReadNotify1(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler1, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify2(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler2, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify3(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler3, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify4(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler4, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify5(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler5, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify6(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler6, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        private void Events_ReadNotify7(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateReadHandler7, new object[] { readEventArgs.ReadEventData.TagData });
            }
            catch (Exception)
            {
            }
        }
        public void Events_StatusNotify(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify1(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler1, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }
        public void Events_StatusNotify2(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler2, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify3(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler3, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify4(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler4, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        public void Events_StatusNotify5(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler5, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }
        public void Events_StatusNotify6(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler6, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }
        public void Events_StatusNotify7(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                this.Invoke(m_UpdateStatusHandler7, new object[] { statusEventArgs.StatusEventData });
            }
            catch (Exception)
            {
            }
        }

        private void accessBackgroundWorker_DoWork(object sender, DoWorkEventArgs accessEvent)
        {
            try
            {
                m_AccessOpResult.m_OpCode = (ACCESS_OPERATION_CODE)accessEvent.Argument;
                m_AccessOpResult.m_Result = RFIDResults.RFID_API_SUCCESS;

                if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReadTag = m_ReaderAPI.Actions.TagAccess.ReadWait(
                        m_SelectedTagID, m_ReadForm.m_ReadParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.ReadEvent(m_ReadForm.m_ReadParams,
                            m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.WriteWait(
                            m_SelectedTagID, m_WriteForm.m_WriteParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.WriteEvent(
                            m_WriteForm.m_WriteParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.LockWait(
                            m_SelectedTagID, m_LockForm.m_LockParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.LockEvent(
                            m_LockForm.m_LockParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.KillWait(
                            m_SelectedTagID, m_KillForm.m_KillParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.KillEvent(
                            m_KillForm.m_KillParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockWriteWait(
                            m_SelectedTagID, m_BlockWriteForm.m_WriteParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockWriteEvent(
                            m_BlockWriteForm.m_WriteParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
                else if ((ACCESS_OPERATION_CODE)accessEvent.Argument == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                {
                    if (m_SelectedTagID != String.Empty)
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockEraseWait(
                            m_SelectedTagID, m_BlockEraseForm.m_BlockEraseParams, m_AntennaInfoForm.getInfo());
                    }
                    else
                    {
                        m_ReaderAPI.Actions.TagAccess.BlockEraseEvent(
                            m_BlockEraseForm.m_BlockEraseParams, m_AccessFilterForm.getFilter(), m_AntennaInfoForm.getInfo());
                    }
                }
            }
            catch (OperationFailureException ofe)
            {
                m_AccessOpResult.m_Result = ofe.Result;
            }
            accessEvent.Result = m_AccessOpResult;
        }

        private void accessBackgroundWorker_ProgressChanged(object sender,
        ProgressChangedEventArgs pce)
        {

        }

        private void accessBackgroundWorker_RunWorkerCompleted(object sender,
        RunWorkerCompletedEventArgs accessEvents)
        {
            if (accessEvents.Error != null)
            {
                functionCallStatusLabel.Text = accessEvents.Error.Message;
            }
            else
            {
                // Handle AccessWait Operations              
                AccessOperationResult accessOpResult = (AccessOperationResult)accessEvents.Result;
                if (accessOpResult.m_Result == RFIDResults.RFID_API_SUCCESS)
                {
                    if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ)
                    {
                        if (m_SelectedTagID != String.Empty)
                        {
                            if (m_ReadTag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                                m_ReadTag.OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS)
                            {
                               // ListViewItem item = inventoryList.SelectedItems[0];
                                string tagID = m_ReadTag.TagID + m_ReadTag.MemoryBank.ToString()
                                    + m_ReadTag.MemoryBankDataOffset.ToString();

                        //        if (item.SubItems[6].Text.Length > 0)
                        //        {
                        //            bool isFound = false;

                        //            // Search or add new one
                        //            lock (m_TagTable.SyncRoot)
                        //            {
                        //                isFound = m_TagTable.ContainsKey(tagID);
                        //            }

                        //            if (!isFound)
                        //            {
                        //                ListViewItem newItem = new ListViewItem(m_ReadTag.TagID);
                        //                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(newItem, getTagEvent(m_ReadTag));
                        //                m_TagTotalCount += m_ReadTag.TagSeenCount;
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.TagSeenCount.ToString());
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.AntennaID.ToString());
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PeakRSSI.ToString());
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.PC.ToString("X"));
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankData);
                        //                newItem.SubItems.Add(subItem);

                        //                string memoryBank = m_ReadTag.MemoryBank.ToString();
                        //                int index = memoryBank.LastIndexOf('_');
                        //                if (index != -1)
                        //                {
                        //                    memoryBank = memoryBank.Substring(index + 1);
                        //                }

                        //                subItem = new ListViewItem.ListViewSubItem(item, memoryBank);
                        //                newItem.SubItems.Add(subItem);
                        //                subItem = new ListViewItem.ListViewSubItem(item, m_ReadTag.MemoryBankDataOffset.ToString());
                        //                newItem.SubItems.Add(subItem);

                        //                inventoryList.BeginUpdate();
                        //                inventoryList.Items.Add(newItem);
                        //                inventoryList.EndUpdate();

                        //                lock (m_TagTable.SyncRoot)
                        //                {
                        //                    m_TagTable.Add(tagID, newItem);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                item.SubItems[6].Text = m_ReadTag.MemoryBankData;
                        //                item.SubItems[8].Text = m_ReadTag.MemoryBankDataOffset.ToString();
                        //            }
                        //        }
                        //        else
                        //        {
                        //            // Empty Memory Bank Slot
                        //            item.SubItems[6].Text = m_ReadTag.MemoryBankData;

                        //            string memoryBank = m_ReadForm.m_ReadParams.MemoryBank.ToString();
                        //            int index = memoryBank.LastIndexOf('_');
                        //            if (index != -1)
                        //            {
                        //                memoryBank = memoryBank.Substring(index + 1);
                        //            }
                        //            item.SubItems[7].Text = memoryBank;
                        //            item.SubItems[8].Text = m_ReadTag.MemoryBankDataOffset.ToString();

                        //            lock (m_TagTable.SyncRoot)
                        //            {
                        //                m_TagTable.Remove(m_ReadTag.TagID);
                        //                m_TagTable.Add(tagID, item);
                        //            }
                        //        }
                        //        this.m_ReadForm.ReadData_TB.Text = m_ReadTag.MemoryBankData;
                        //        functionCallStatusLabel.Text = "Read Succeed";
                            }
                        }
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_WRITE)
                    {
                        functionCallStatusLabel.Text = "Write Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_LOCK)
                    {
                        functionCallStatusLabel.Text = "Lock Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_KILL)
                    {
                        functionCallStatusLabel.Text = "Kill Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_WRITE)
                    {
                        functionCallStatusLabel.Text = "BlockWrite Succeed";
                    }
                    else if (accessOpResult.m_OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_BLOCK_ERASE)
                    {
                        functionCallStatusLabel.Text = "BlockErase Succeed";
                    }
                }
                else
                {
                    functionCallStatusLabel.Text = accessOpResult.m_Result.ToString();
                }
                resetButtonState();
                memBank_CB.Enabled = true;
            }
        }

        private void resetButtonState()
        {
            try
            {
                if (m_ReadForm != null)
                    m_ReadForm.readButton.Enabled = true;
                if (m_WriteForm != null)
                    m_WriteForm.writeButton.Enabled = true;
                if (m_LockForm != null)
                    m_LockForm.lockButton.Enabled = true;
                if (m_KillForm != null)
                    m_KillForm.killButton.Enabled = true;
                if (m_BlockWriteForm != null)
                    m_BlockWriteForm.writeButton.Enabled = true;
                if (m_BlockEraseForm != null)
                    m_BlockEraseForm.eraseButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void configureMenuItemsUponConnectDisconnect()
        {
            try
            {
               // this.autonomous_CB.Enabled = this.m_IsConnected;
                this.memBank_CB.Enabled = this.m_IsConnected;
                this.capabilitiesToolStripMenuItem.Enabled = this.m_IsConnected;
                this.antennaInfoToolStripMenuItem.Enabled = this.m_IsConnected;
                this.antennaToolStripMenuItem.Enabled = this.m_IsConnected;
                this.rFModesToolStripMenuItem.Enabled = this.m_IsConnected;
                this.singulationToolStripMenuItem.Enabled = this.m_IsConnected;
                this.gpioToolStripMenuItem.Enabled = this.m_IsConnected;
                this.resetToFactoryDefaultsToolStripMenuItem.Enabled = this.m_IsConnected;
                this.storageSettingsToolStripMenuItem.Enabled = this.m_IsConnected;
                this.filtersToolStripMenuItem.Enabled = this.m_IsConnected;
                this.accessToolStripMenuItem.Enabled = this.m_IsConnected;
                this.triggersToolStripMenuItem.Enabled = this.m_IsConnected;
                if (this.m_ReaderAPI != null && this.m_IsConnected && this.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported == true)
                {
                    this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                    "Power On Radio" : "Power Off Radio";
                }
                else
                {
                    this.radioPowerGetSetToolStripMenuItem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        internal void configureMenuItemsUponLoginLogout()
        {
            this.softwareFirmwareUpdateToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;

            if (this.m_ReaderType != READER_TYPE.MC)
            {
                this.antennaModeToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.readPointToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.rebootToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.softwareFirmwareUpdateToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
                this.systemInfoToolStripMenuItem.Enabled = this.m_ReaderMgmt.IsLoggedIn;
            }
            else
            {
                this.antennaModeToolStripMenuItem.Enabled = false;
                this.readPointToolStripMenuItem.Enabled = false;
                this.rebootToolStripMenuItem.Enabled = false;
                this.systemInfoToolStripMenuItem.Enabled = false;
            }
            //this.systemInfoToolStripMenuItem.Visible = false; // Dlg Not implemented now
        }
        internal void configureMenuItemsBasedOnCapabilities()
        {
            try
            {
                // this.autonomousMode_CB.Visible = this.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
                m_TriggerForm.Reset();
                this.radioPowerGetSetToolStripMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsRadioPowerControlSupported;
                this.gpioToolStripMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.NumGPIPorts > 0 ? true : false |
                this.m_ReaderAPI.ReaderCapabilities.NumGPOPorts > 0 ? true : false;
                this.blockEraseDataContextMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                this.blockWriteDataContextMenuItem.Visible = this.m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;


                this.m_TriggerForm.newTag_CB.Enabled =
                this.m_TriggerForm.newTag_TB.Enabled =
                this.m_TriggerForm.backTag_CB.Enabled =
                this.m_TriggerForm.backTag_TB.Enabled =
                this.m_TriggerForm.invisibleTag_CB.Enabled =
                this.m_TriggerForm.invisibleTag_TB.Enabled = this.m_ReaderAPI.ReaderCapabilities.IsTagEventReportingSupported;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void connectBackgroundWorker_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI = new RFIDReader(IPaddress, uint.Parse("5084"), 0);
                    try
                    {
                        
                        m_ReaderAPI.Connect();
                        m_IsConnected = true;
                        workEventArgs.Result = "Connect Succeed";
                        
                       
                        try
                        {
                            if (m_IsConnected)
                            {
                               // reader_connect();
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                        
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                   
                    try
                    {
                        try
                        {

                            m_ReaderAPI.Actions.Inventory.Stop();
                            m_ReaderAPI.Disconnect();
                            m_IsConnected = false;
                            //workEventArgs.Result = "Disconnect Succeed";
                            //if (m_IsConnected)
                            //{
                            //    if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                            //    {
                            //        m_ReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                            //    }
                            //    else
                            //    {
                            //        m_ReaderAPI.Actions.Inventory.Stop();
                            //    }
                            //}
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                       
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker_ProgressChanged(object sender,
        ProgressChangedEventArgs progressEventArgs)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker_RunWorkerCompleted(object sender,
        RunWorkerCompletedEventArgs connectEventArgs)
        {
            //if (m_ConnectionForm.connectionButton.Text == "Connect")
            //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                //m_ConnectionForm.connectionButton.Text = "Disconnect";
            if (m_IsConnected)
            {

                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                m_ReaderAPI.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                m_ReaderAPI.Events.NotifyGPIEvent = true;
                m_ReaderAPI.Events.NotifyAntennaEvent = true;
                m_ReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                // configureMenuItemsBasedOnCapabilities();
                // }
                // }
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs.Result.ToString();
            }
           // m_ConnectionForm.connectionButton.Enabled = true;

            //updateGPIState();
        }
       

        private void AppForm_Load(object sender, EventArgs e)
        {
            m_GPIStateList = new ArrayList();
            m_UpdateStatusHandler = new UpdateStatus(myUpdateStatus);

            m_UpdateReadHandler = new UpdateRead(myUpdateRead);

            m_UpdateStatusHandler1 = new UpdateStatus(myUpdateStatus1);

            m_UpdateReadHandler1 = new UpdateRead(myUpdateRead1);

            m_UpdateStatusHandler2 = new UpdateStatus(myUpdateStatus2);

            m_UpdateReadHandler2 = new UpdateRead(myUpdateRead2);

            m_UpdateStatusHandler3 = new UpdateStatus(myUpdateStatus3);

            m_UpdateReadHandler3 = new UpdateRead(myUpdateRead3);

            m_UpdateStatusHandler4 = new UpdateStatus(myUpdateStatus4);

            m_UpdateReadHandler4 = new UpdateRead(myUpdateRead4);

            m_UpdateStatusHandler5 = new UpdateStatus(myUpdateStatus5);

            m_UpdateReadHandler5 = new UpdateRead(myUpdateRead5);

            m_UpdateStatusHandler6 = new UpdateStatus(myUpdateStatus6);

            m_UpdateReadHandler6 = new UpdateRead(myUpdateRead6);

            m_UpdateStatusHandler7 = new UpdateStatus(myUpdateStatus7);

            m_UpdateReadHandler7 = new UpdateRead(myUpdateRead7);
            m_ReadTag = new Symbol.RFID3.TagData();
            m_ReadTag1 = new Symbol.RFID3.TagData();

            m_ConnectionForm = new ConnectionForm(this);
            m_ReadForm = new ReadForm(this);
            m_AntennaInfoForm = new AntennaInfoForm(this);
            m_PostFilterForm = new PostFilterForm(this);
            m_AccessFilterForm = new AccessFilterForm(this);
            m_TriggerForm = new TriggersForm(this);
            m_ReaderMgmt = new ReaderManagement();
            m_TagTable = new Hashtable();
            m_TagTable1 = new Hashtable();
            m_TagTable2 = new Hashtable();
            m_TagTable3 = new Hashtable();
            m_TagTable4 = new Hashtable();
            m_TagTable5 = new Hashtable();
            m_TagTable6 = new Hashtable();
            m_TagTable7 = new Hashtable();
            m_AccessOpResult = new AccessOperationResult();
            m_IsConnected = false;
            m_TagTotalCount = 0;
            configureMenuItemsUponConnectDisconnect();
            chkin.Visible = false;
            chkout.Visible = false;
            chkin1.Visible = false;
            chkout1.Visible = false;
            chkin2.Visible = false;
            chkout2.Visible = false;
            chkin3.Visible = false;
            chkout3.Visible = false;
            chkin4.Visible = false;
            chkout4.Visible = false;
            chkin5.Visible = false;
            chkout5.Visible = false;
            chkin6.Visible = false;
            chkout6.Visible = false;
            chkin7.Visible = false;
            chkout7.Visible = false;
            //Constatus = "Connect";
            //Constatus1 = "Connect";
            //Constatus2 = "Connect";
            //Constatus3 = "Connect";
            //DataSet dss = new DataSet();
            //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster where IPaddress='192.168.0.202' ", "spp");
            ////dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

            //IPaddress = dss.Tables[0].Rows[0]["IPaddress"].ToString();
            ////IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
            ////IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
            ////IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
            ////IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
            //if (PingHost(IPaddress))
            //{
            //    button9.BackColor = System.Drawing.Color.Green;
            //    button10.BackColor = System.Drawing.Color.Red;
            //    button11.BackColor = System.Drawing.Color.Red;
            //    button12.BackColor = System.Drawing.Color.Red;
            //    button18.BackColor = System.Drawing.Color.Red;
            //    button20.BackColor = System.Drawing.Color.Red;
            //    button22.BackColor = System.Drawing.Color.Red;
            //    button24.BackColor = System.Drawing.Color.Red;
            //    this.connectBackgroundWorker.RunWorkerAsync("Connect");
            //    chkin.Visible = true;
            //    chkout.Visible = true;
            //    chkin1.Visible = false;
            //    chkout1.Visible = false;
            //    chkin2.Visible = false;
            //    chkout2.Visible = false;
            //    chkin3.Visible = false;
            //    chkout3.Visible = false;
            //    chkin4.Visible = false;
            //    chkout4.Visible = false;
            //    chkin5.Visible = false;
            //    chkout5.Visible = false;
            //    chkin6.Visible = false;
            //    chkout6.Visible = false;
            //    chkin7.Visible = false;
            //    chkout7.Visible = false;

            //}
                //if (PingHost(IPaddress1))
                //{
                //    button9.BackColor = System.Drawing.Color.Green;
                //    button10.BackColor = System.Drawing.Color.Green;
                //    button11.BackColor = System.Drawing.Color.Red;
                //    button12.BackColor = System.Drawing.Color.Red;
                //    this.connectBackgroundWorker1.RunWorkerAsync("Connect");
                //    chkin.Visible = true;
                //    chkout.Visible = true;
                //    chkin1.Visible = true;
                //    chkout1.Visible = true;
                //    chkin2.Visible = false;
                //    chkout2.Visible = false;
                //    chkin3.Visible = false;
                //    chkout3.Visible = false;
                //    chkin4.Visible = false;
                //    chkout4.Visible = false;
                //    chkin5.Visible = false;
                //    chkout5.Visible = false;
                //    chkin6.Visible = false;
                //    chkout6.Visible = false;
                //    chkin7.Visible = false;
                //    chkout7.Visible = false;
                   
                //}
                //if (PingHost(IPaddress2))
                //{
                //    button9.BackColor = System.Drawing.Color.Green;
                //    button10.BackColor = System.Drawing.Color.Green;
                //    button11.BackColor = System.Drawing.Color.Green;
                //    button12.BackColor = System.Drawing.Color.Red;
                //    this.connectBackgroundWorker2.RunWorkerAsync("Connect");
                //    chkin.Visible = true;
                //    chkout.Visible = true;
                //    chkin1.Visible = true;
                //    chkout1.Visible = true;
                //    chkin2.Visible = true;
                //    chkout2.Visible = true;
                //    chkin3.Visible = false;
                //    chkout3.Visible = false;
            //    chkin4.Visible = false;
            //    chkout4.Visible = false;
            //    chkin5.Visible = false;
            //    chkout5.Visible = false;
            //    chkin6.Visible = false;
            //    chkout6.Visible = false;
            //    chkin7.Visible = false;
            //    chkout7.Visible = false;
                //}
                //if (PingHost(IPaddress3))
                //{
                //    button9.BackColor = System.Drawing.Color.Green;
                //    button10.BackColor = System.Drawing.Color.Green;
                //    button11.BackColor = System.Drawing.Color.Green;
                //    button12.BackColor = System.Drawing.Color.Green;
                //    this.connectBackgroundWorker3.RunWorkerAsync("Connect");
                //    chkin.Visible = true;
                //    chkout.Visible = true;
                //    chkin1.Visible = true;
                //    chkout1.Visible = true;
                //    chkin2.Visible = true;
                //    chkout2.Visible = true;
                //    chkin3.Visible = true;
                //    chkout3.Visible = true;
            //    chkin4.Visible = false;
            //    chkout4.Visible = false;
            //    chkin5.Visible = false;
            //    chkout5.Visible = false;
            //    chkin6.Visible = false;
            //    chkout6.Visible = false;
            //    chkin7.Visible = false;
            //    chkout7.Visible = false;
                //}
            //if (PingHost(IPaddress4))
            //{
            //    button9.BackColor = System.Drawing.Color.Green;
            //    button10.BackColor = System.Drawing.Color.Green;
            //    button11.BackColor = System.Drawing.Color.Green;
            //    button12.BackColor = System.Drawing.Color.Green;
            //    this.connectBackgroundWorker4.RunWorkerAsync("Connect");
            //    chkin.Visible = true;
            //    chkout.Visible = true;
            //    chkin1.Visible = true;
            //    chkout1.Visible = true;
            //    chkin2.Visible = true;
            //    chkout2.Visible = true;
            //    chkin3.Visible = true;
            //    chkout3.Visible = true;
            //    chkin4.Visible = true;
            //    chkout4.Visible = true;
            //    chkin4.Visible = false;
            //    chkout4.Visible = false;
            //    chkin5.Visible = false;
            //    chkout5.Visible = false;
            //    chkin6.Visible = false;
            //    chkout6.Visible = false;
            //    chkin7.Visible = false;
            //    chkout7.Visible = false;
            //}

            //if (PingHost(IPaddress5))
            //{
            //    button9.BackColor = System.Drawing.Color.Green;
            //    button10.BackColor = System.Drawing.Color.Green;
            //    button11.BackColor = System.Drawing.Color.Green;
            //    button12.BackColor = System.Drawing.Color.Green;
            //    this.connectBackgroundWorker5.RunWorkerAsync("Connect");
            //    chkin.Visible = true;
            //    chkout.Visible = true;
            //    chkin1.Visible = true;
            //    chkout1.Visible = true;
            //    chkin2.Visible = true;
            //    chkout2.Visible = true;
            //    chkin3.Visible = true;
            //    chkout3.Visible = true;
            //    chkin4.Visible = true;
            //    chkout4.Visible = true;
            //    chkin5.Visible = true;
            //    chkout5.Visible = true;
            //    chkin6.Visible = false;
            //    chkout6.Visible = false;
            //    chkin7.Visible = false;
            //    chkout7.Visible = false;

            //}

            //if (PingHost(IPaddress6))
            //{
            //    button9.BackColor = System.Drawing.Color.Green;
            //    button10.BackColor = System.Drawing.Color.Green;
            //    button11.BackColor = System.Drawing.Color.Green;
            //    button12.BackColor = System.Drawing.Color.Green;
            //    this.connectBackgroundWorker6.RunWorkerAsync("Connect");
            //    chkin.Visible = true;
            //    chkout.Visible = true;
            //    chkin1.Visible = true;
            //    chkout1.Visible = true;
            //    chkin2.Visible = true;
            //    chkout2.Visible = true;
            //    chkin3.Visible = true;
            //    chkout3.Visible = true;
            //    chkin4.Visible = true;
            //    chkout4.Visible = true;
            //    chkin5.Visible = true;
            //    chkout5.Visible = true;
            //    chkin6.Visible = true;
            //    chkout6.Visible = true;
            //    chkin7.Visible = true;
            //    chkout7.Visible = true;


            //}

            //if (PingHost(IPaddress7))
            //{
            //    button9.BackColor = System.Drawing.Color.Green;
            //    button10.BackColor = System.Drawing.Color.Green;
            //    button11.BackColor = System.Drawing.Color.Green;
            //    button12.BackColor = System.Drawing.Color.Green;
            //    this.connectBackgroundWorker7.RunWorkerAsync("Connect");
            //    chkin.Visible = true;
            //    chkout.Visible = true;
            //    chkin1.Visible = true;
            //    chkout1.Visible = true;
            //    chkin2.Visible = true;
            //    chkout2.Visible = true;
            //    chkin3.Visible = true;
            //    chkout3.Visible = true;
            //    chkin4.Visible = true;
            //    chkout4.Visible = true;
            //    chkin5.Visible = true;
            //    chkout5.Visible = true;
            //    chkin6.Visible = true;
            //    chkout6.Visible = true;
            //    chkin7.Visible = true;
            //    chkout7.Visible = true;


            //}
                
               
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_IsConnected)
                {
                    m_ReaderAPI.Disconnect();
                }
                m_ReaderMgmt.Dispose();
                this.Dispose();
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ConnectionForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void capabilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CapabilitiesForm capabilitiesForm = new CapabilitiesForm(this);
                capabilitiesForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void antennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AntennaConfigForm antennaConfigForm = new AntennaConfigForm(this);
                antennaConfigForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void rFModesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RFModeForm RFModeForm = new RFModeForm(this);
                RFModeForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void singulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SingulationForm singulationForm = new SingulationForm(this);
                singulationForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ReaderAPI != null && m_IsConnected)
                {
                    m_ReaderAPI.Disconnect();
                }
                if (this.m_ReaderMgmt.IsLoggedIn)
                {
                    m_ReaderMgmt.Logout();
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void storageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_TagStorageSettingsForm)
                {
                    m_TagStorageSettingsForm = new TagStorageSettingsForm(this);
                }
                m_TagStorageSettingsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gpioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GPIOForm gpio = new GPIOForm(this);
                gpio.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void preFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_PreFilterForm)
                {
                    m_PreFilterForm = new PreFilterForm(this);
                }
                m_PreFilterForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void postfilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_PostFilterForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void accessfilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_AccessFilterForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void triggersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_TriggerForm)
                {
                    m_TriggerForm = new TriggersForm(this);
                }
                m_TriggerForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReadForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = "Read Form:" + ex.Message;
            }
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_WriteForm)
                {
                    m_WriteForm = new WriteForm(this, false);
                }
                m_WriteForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_LockForm)
                {
                    m_LockForm = new LockForm(this);
                }
                m_LockForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_KillForm)
                {
                    m_KillForm = new KillForm(this);
                }
                m_KillForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void blockWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_BlockWriteForm)
                {
                    m_BlockWriteForm = new WriteForm(this, true);
                }
                m_BlockWriteForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void blockEraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_BlockEraseForm)
                {
                    m_BlockEraseForm = new BlockEraseForm(this);
                }
                m_BlockEraseForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void softwareFirmwareUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_FirmwareUpdateForm)
                {
                    m_FirmwareUpdateForm = new FirmwareUpdateForm(this);
                }
                m_FirmwareUpdateForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void antennaModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_AntennaModeForm)
                {
                    m_AntennaModeForm = new AntennaModeForm(this);
                }
                m_AntennaModeForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == m_ReadPointForm)
            {
                m_ReadPointForm = new ReadPointForm(this);
            }
            m_ReadPointForm.ShowDialog(this);
        }

        private void radioPowerGetSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioPowerGetSetToolStripMenuItem.Text == "Power On Radio")
                {
                    m_ReaderAPI.Config.RadioPowerState = RADIO_POWER_STATE.OFF;
                }
                else
                {
                    m_ReaderAPI.Config.RadioPowerState = RADIO_POWER_STATE.ON;
                }
                this.radioPowerGetSetToolStripMenuItem.Text = this.m_ReaderAPI.Config.RadioPowerState == RADIO_POWER_STATE.OFF ?
                "Power On Radio" : "Power Off Radio";
            }
            catch (OperationFailureException ex)
            {
                functionCallStatusLabel.Text = ex.Result.ToString();
            }
        }

        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReaderMgmt.Restart();

                this.antennaModeToolStripMenuItem.Enabled = false;
                this.rebootToolStripMenuItem.Enabled = false;
                this.radioPowerGetSetToolStripMenuItem.Enabled = false;
                this.readPointToolStripMenuItem.Enabled = false;
                this.softwareFirmwareUpdateToolStripMenuItem.Enabled = false;
                this.m_IsConnected = false;

                m_LoginForm.loginButton.Text = "Login";
                functionCallStatusLabel.Text = "Reboot Successfully";
            }
            catch (OperationFailureException failureException)
            {
                functionCallStatusLabel.Text = failureException.Result.ToString();
            }
        }

        private void loginLogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_LoginForm == null)
                {
                    m_LoginForm = new LoginForm(this);
                }
                m_LoginForm.clearPassword();
                m_LoginForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HelpForm helpDialog = new HelpForm(this);
                if (helpDialog.ShowDialog(this) == DialogResult.Yes)
                {

                }
                helpDialog.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_IsConnected=true;
                m_IsConnected1=true;
                 if (m_IsConnected)
                {
                    if (readButton.Text == "Start Reading")
                    {
                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;

                    }
                    else if (readButton.Text == "Stop Reading")
                    {

                        if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_ReaderAPI.Actions.Inventory.Stop();
                            //m_ReaderAPI1.Actions.Inventory.Stop();
                            m_IsConnected=false;
                            //m_IsConnected1=false;

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;
                        //if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        //{
                        //    m_ReaderAPI1.Actions.TagAccess.OperationSequence.StopSequence();
                        //}
                        //else
                        //{
                        //    m_ReaderAPI1.Actions.Inventory.Stop();
                        //}

                        ////cbin.Visible = true;
                        ////cbout.Visible = true;
                        //readButton.Text = "Start Reading";
                        //memBank_CB.Enabled = true;
                    }
                }

                if (m_IsConnected1)
                {
                    if (readButton.Text == "Start Reading")
                    {
                        if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI1.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable1.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI1.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;

                    }
                    else if (readButton.Text == "Stop Reading")
                    {

                        if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI1.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable1.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI1.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;
                        //if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        //{
                        //    m_ReaderAPI1.Actions.TagAccess.OperationSequence.StopSequence();
                        //}
                        //else
                        //{
                        //    m_ReaderAPI1.Actions.Inventory.Stop();
                        //}

                        ////cbin.Visible = true;
                        ////cbout.Visible = true;
                        //readButton.Text = "Start Reading";
                        //memBank_CB.Enabled = true;
                    }
                }
                if (m_IsConnected2)
                {
                    if (readButton.Text == "Start Reading")
                    {
                        if (m_ReaderAPI2.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI2.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable2.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI2.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;

                    }
                    else if (readButton.Text == "Stop Reading")
                    {

                        if (m_ReaderAPI2.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI2.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable2.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI2.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;
                        //if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        //{
                        //    m_ReaderAPI1.Actions.TagAccess.OperationSequence.StopSequence();
                        //}
                        //else
                        //{
                        //    m_ReaderAPI1.Actions.Inventory.Stop();
                        //}

                        ////cbin.Visible = true;
                        ////cbout.Visible = true;
                        //readButton.Text = "Start Reading";
                        //memBank_CB.Enabled = true;
                    }
                }

                if (m_IsConnected3)
                {
                    if (readButton.Text == "Start Reading")
                    {
                        if (m_ReaderAPI3.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI3.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable3.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI3.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;

                    }
                    else if (readButton.Text == "Stop Reading")
                    {

                        if (m_ReaderAPI3.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            m_ReaderAPI3.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                                m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                        }
                        else
                        {
                            //inventoryList.Items.Clear();
                            m_TagTable3.Clear();
                            m_TagTotalCount = 0;
                            m_ReaderAPI3.Actions.Inventory.Perform(null, null, null);

                            //m_ReaderAPI1.Actions.Inventory.Perform(
                            //    m_PostFilterForm.getFilter(),
                            //    m_TriggerForm.getTriggerInfo(),
                            //    m_AntennaInfoForm.getInfo());
                        }



                        readButton.Text = "Stop Reading";
                        memBank_CB.Enabled = false;
                        //if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                        //{
                        //    m_ReaderAPI1.Actions.TagAccess.OperationSequence.StopSequence();
                        //}
                        //else
                        //{
                        //    m_ReaderAPI1.Actions.Inventory.Stop();
                        //}

                        ////cbin.Visible = true;
                        ////cbout.Visible = true;
                        //readButton.Text = "Start Reading";
                        //memBank_CB.Enabled = true;
                    }
                }


                //else
                //{
                //    functionCallStatusLabel.Text = "Please connect to a reader first";
                //}
            }
            catch (InvalidOperationException ioe)
            {
                functionCallStatusLabel.Text = ioe.Message;
            }
            catch (InvalidUsageException iue)
            {
                functionCallStatusLabel.Text = iue.Info;
            }
            catch (OperationFailureException ofe)
            {
                functionCallStatusLabel.Text = ofe.Result + ":" + ofe.StatusDescription;
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        void inventoryList_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //dataContextMenuStrip.Show(inventoryList, new Point(e.X, e.Y));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void inventoryList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //if (e.Column != this.m_SortColumn)
            //{
            //    m_SortColumn = e.Column;
            //    inventoryList.Sorting = SortOrder.Ascending;
            //}
            //else
            //{
            //    if (inventoryList.Sorting == SortOrder.Ascending)
            //        inventoryList.Sorting = SortOrder.Descending;
            //    else
            //        inventoryList.Sorting = SortOrder.Ascending;
            //}
            //this.inventoryList.Sort();
            //this.inventoryList.ListViewItemSorter = new ListViewItemComparer(e.Column, inventoryList.Sorting);
        }

        private void tagDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TagDataForm tagDataForm = new TagDataForm(this);
                tagDataForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_ReadForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void writeDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_WriteForm)
                {
                    m_WriteForm = new WriteForm(this, false);
                }
                m_WriteForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lockDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_LockForm)
                {
                    m_LockForm = new LockForm(this);
                }
                m_LockForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void killDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_KillForm)
                {
                    m_KillForm = new KillForm(this);
                }
                m_KillForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void blockWriteDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_BlockWriteForm)
                {
                    m_BlockWriteForm = new WriteForm(this, true);
                }
                m_BlockWriteForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void blockEraseDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_BlockEraseForm)
                {
                    m_BlockEraseForm = new BlockEraseForm(this);
                }
                m_BlockEraseForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateGPIState()
        {
            try
            {
                if (m_IsConnected)
                {
                    for (int index = 0; index < 8; index++)
                    {
                        if (index < m_ReaderAPI.ReaderCapabilities.NumGPIPorts)
                        {
                            Label gpiLabel = (Label)m_GPIStateList[index];
                            GPIs.GPI_PORT_STATE portState = m_ReaderAPI.Config.GPI[index + 1].PortState;

                            if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_HIGH)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.GreenYellow;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_LOW)
                            {
                                gpiLabel.BackColor = System.Drawing.Color.Red;
                            }
                            else if (portState == GPIs.GPI_PORT_STATE.GPI_PORT_STATE_UNKNOWN)
                            {

                            }
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < 8; index++)
                    {
                        ((Label)m_GPIStateList[index]).BackColor = System.Drawing.Color.Transparent;
                    }
                }
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void resetToFactoryDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_ReaderAPI.IsConnected)
                {
                    m_ReaderAPI.Config.ResetFactoryDefaults();
                    if (m_TagStorageSettingsForm != null)
                        m_TagStorageSettingsForm.Reset();
                    functionCallStatusLabel.Text = "Reset Factory Defaults Successfully";
                }
            }
            catch (Exception ex)
            {
                functionCallStatusLabel.Text = ex.Message;
            }
        }

        private void clearReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.inventoryList.Items.Clear();
                this.m_TagTable.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void antennaInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                m_AntennaInfoForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         
        private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_ReaderInfoForm)
                {
                    m_ReaderInfoForm = new ReaderInfoForm(this);
                }
                m_ReaderInfoForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppForm_ClientSizeChanged(object sender, EventArgs e)
        {
            try
            {
                functionCallStatusLabel.Width = this.Width - 77;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string getTagEvent(TagData tag)
        {
            string eventString = "Reading";
            if (tag.TagEvent != TAG_EVENT.NONE)
            {
                switch (tag.TagEvent)
                {
                    case TAG_EVENT.NEW_TAG_VISIBLE:
                        eventString = "New";
                        break;
                    case TAG_EVENT.TAG_BACK_TO_VISIBILITY:
                        eventString = "Back";
                        break;
                    case TAG_EVENT.TAG_NOT_VISIBLE:
                        eventString = "Gone";
                        break;
                    default:
                        eventString = "None";
                        break;

                }

            }
            return eventString;
        }

        private string getTagEvent1(TagData tag)
        {
            string eventString = "192.168.1.100";
            if (tag.TagEvent != TAG_EVENT.NONE)
            {
                switch (tag.TagEvent)
                {
                    case TAG_EVENT.NEW_TAG_VISIBLE:
                        eventString = "New";
                        break;
                    case TAG_EVENT.TAG_BACK_TO_VISIBILITY:
                        eventString = "Back";
                        break;
                    case TAG_EVENT.TAG_NOT_VISIBLE:
                        eventString = "Gone";
                        break;
                    default:
                        eventString = "None";
                        break;

                }

            }
            return eventString;
        }

        private void locateTagDataContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == m_LocateForm)
                {
                    m_LocateForm = new LocateForm(this);
                }
                m_LocateForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnnor_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         
        private void insert_tag_Details_from_csvfile()
        {
            try
            {
                string[] split = null;

               string connectionstring = ConfigurationSettings.AppSettings["Test"].ToString();

               System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionstring);

                con.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";

                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName))
                    {
                        string line;
                        long count = 0;

                        while ((line = reader.ReadLine()) != null)
                        {
                            count++;
                        }
                        System.IO.StreamReader READ = new System.IO.StreamReader(openFileDialog1.FileName);

                        int i = 0;

                        while ((line = READ.ReadLine()) != null)
                        {
                            if (i != 0)
                            {
                                try
                                {
                                    string CommandText = string.Empty;
                                    split = line.Split(new char[] { ',' });

                                    if (split[0].ToString() != null && split[0].ToString() != string.Empty)
                                    {
                                        try
                                        {
                                            int m = 0;
                                            string cs = "0" + split[0].ToString();
                                            string palletid = split[0].ToString();
                                            string itemcode = split[1].ToString();
                                            string noofcartons = split[2].ToString();
                                            string cartonqty = split[3].ToString();
                                            string uom = split[4].ToString();
                                            string rfidtag = split[5].ToString();
                                            //string Model = cs.ToString();
                                            // string Event = split[1].ToString();
                                            //string Antenna = split[2].ToString();
                                            //string TagCount = split[3].ToString();
                                            //string RSSI = split[4].ToString();
                                            //string PCBits = split[5].ToString();
                                            // string MemoryBan Data = split[6].ToString();
                                            //string MB = split[5].ToString();
                                            // string Offset = split[6].ToString();
                                            string cur_date = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;

                                            System.Data.SqlClient.SqlDataAdapter sqlceadpsl = new System.Data.SqlClient.SqlDataAdapter("Select * from AdvancedShippingnotificationMaster where [RFID Tag] ='" + rfidtag + "'", con);

                                            DataSet dssl = new DataSet();

                                            sqlceadpsl.Fill(dssl, "RFID Tag");

                                            if (dssl.Tables[0].Rows.Count == 0)
                                            {
                                                CommandText = "insert into AdvancedShippingnotificationMaster(PalletID,ItemCode,[No.of Cartons],[Carton Qty],UoM,[RFID Tag]) values('" + palletid + "','" + itemcode + "','" + noofcartons + "','" + cartonqty + "','" + uom + "','" + rfidtag + "')";
                                               // CommandText = "insert into epcidr1(EPCID) values('" + EPCID + "')";
                                                //,'" + Event + "','" + Antenna + "','" + TagCount + "','" + RSSI + "','" + PCBits + "','" + MB + "','" + Offset + "')";
                                                cmd = new System.Data.SqlClient.SqlCommand(CommandText, con);

                                                cmd.ExecuteNonQuery();

                                            }

                                            else
                                            {

                                                CommandText = "update AdvancedShippingnotificationMaster set PalletID='" + palletid + "',ItemCode='"+itemcode+"',[No.of Cartons]='" + noofcartons + "',[Carton Qty]='" + cartonqty + "',UoM='" + uom + "'  where [RFID Tag] ='" + rfidtag + "'";
                                                //, Event='" + Event + "'+, Antenna='" + Antenna + "'+, TagCount='" + TagCount + "'+, RSSI='" + RSSI + "'+, PCBits='" + PCBits + "'+, MB='" + MB + "'+, Offset='" + Offset + "'+

                                                cmd = new System.Data.SqlClient.SqlCommand(CommandText, con);

                                                cmd.ExecuteNonQuery();

                                            }

                                        }
                                        catch (Exception EX)
                                        {
                                        }
                                    }
                                }
                                catch (Exception ex) { }
                            }
                            i++;

                        }

                    }
                    MessageBox.Show("TagDetails inserted successfully");

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Please select proper .csv file");

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                insert_tag_Details_from_csvfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                // this.inventoryList.Items.Clear();
                this.m_TagTable.Clear();
                this.m_TagTable1.Clear();
                this.m_TagTable2.Clear();
                this.m_TagTable3.Clear();
                this.m_TagTable4.Clear();
                this.m_TagTable5.Clear();
                this.m_TagTable6.Clear();
                this.m_TagTable7.Clear();
                lblcount.Text = string.Empty;
                label16.Text = string.Empty;
                label15.Text = string.Empty;
                label19.Text = string.Empty;
                label23.Text = string.Empty;
                label21.Text = string.Empty;
                label25.Text = string.Empty;
                label27.Text = string.Empty;
                lblcount.Text = "0";
                label16.Text = "0";
                label15.Text = "0";
                label19.Text = "0";
                label23.Text = "0";
                label21.Text = "0";
                label25.Text = "0";
                label27.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbin_CheckedChanged(object sender, EventArgs e)
        {
            //cbout.Visible = false;
            //res = "IN";
            //if (cbin.Checked == true && cbout.Checked == true)
            //{
            //    res = "NULL";
            //}

            //else if (cbin.Checked == false && cbout.Checked==true)
            //{
            //    res = "OUT";

            //}
            //else if (cbin.Checked == true && cbout.Checked == false)
            //{
            //    res = "IN";
            //}
            //else
            //{
            //    res = " ";
            //}

        }

        private void cbout_CheckedChanged(object sender, EventArgs e)
        {
            //cbin.Visible = false;
            //res = "OUT";
            //if (cbin.Checked == true && cbout.Checked == true)
            //{
            //    res = "NULL";
            //}
            //else if (cbin.Checked == true && cbout.Checked == false)
            //{
            //    res = "OUT";

            //}
            
            //else if (cbout.Checked == true && cbout.Checked == false)
            //{
            //    res = "OUT";

            //}
            //else
            //{
            //    res = " ";
            //}

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void itemRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Item_Registration ItemRegistration = new Item_Registration(this);
                ItemRegistration.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void chkin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkout_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void connectBackgroundWorker1_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker1.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI1 = new RFIDReader(IPaddress1, uint.Parse("5084"), 0);
                    try
                    {

                        m_ReaderAPI1.Connect();
                        m_IsConnected1 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected1)
                            {
                               
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected1)
                            {
                                if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI1.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI1.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI1.Disconnect();
                        m_IsConnected1 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI1.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs1)
        {
            //if (m_ConnectionForm.connectionButton.Text == "Connect")
            //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                    /*
                        *  UI Updates
                        */
                   // m_ConnectionForm.connectionButton.Text = "Disconnect";
            if (m_IsConnected1)
            {
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI1.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify1);
                m_ReaderAPI1.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI1.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify1);
                m_ReaderAPI1.Events.NotifyGPIEvent = true;
                m_ReaderAPI1.Events.NotifyAntennaEvent = true;
                m_ReaderAPI1.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI1.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI1.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI1.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI1.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI1.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI1.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI1.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
            }
                   // configureMenuItemsBasedOnCapabilities();
               // }
            //}
            //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
            //{
            //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
            //    //{
            //    //}
            //    this.Text = "CS_RFID3_Host_Sample2";
            //    this.connectionStatus.BackgroundImage =
            //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

            //    m_ConnectionForm.connectionButton.Text = "Connect";
            //    m_ConnectionForm.hostname_TB.Enabled = true;
            //    m_ConnectionForm.port_TB.Enabled = true;
            //    this.readButton.Enabled = false;
            //    this.readButton.Text = "Start Reading";
            //    configureMenuItemsUponConnectDisconnect();
            //    m_IsConnected1 = false;

            //}
            functionCallStatusLabel.Text = connectEventArgs1.Result.ToString();
            m_ConnectionForm.connectionButton.Enabled = true;

            //updateGPIState();
        }

        private void connectBackgroundWorker2_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker2.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI2 = new RFIDReader(IPaddress2, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI2.Connect();
                        m_IsConnected2 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected2)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected2)
                            {
                                if (m_ReaderAPI2.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI2.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI2.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI2.Disconnect();
                        m_IsConnected2 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI2.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs2)
        {
            //if (m_ConnectionForm.connectionButton.Text == "Connect")
            //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
            if (m_IsConnected2)
            {
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI2.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify2);
                m_ReaderAPI2.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI2.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify2);
                m_ReaderAPI2.Events.NotifyGPIEvent = true;
                m_ReaderAPI2.Events.NotifyAntennaEvent = true;
                m_ReaderAPI2.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI2.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI2.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI2.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI2.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI2.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI2.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI2.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected2 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs2.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }

            //updateGPIState();
        }

        private void connectBackgroundWorker3_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker3.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI3 = new RFIDReader(IPaddress3, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI3.Connect();
                        m_IsConnected3 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected3)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected3)
                            {
                                if (m_ReaderAPI3.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI3.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI3.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI3.Disconnect();
                        m_IsConnected3 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI3.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs3)
        {
            if (m_IsConnected3)
            {
                //if (m_ConnectionForm.connectionButton.Text == "Connect")
                //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI3.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify3);
                m_ReaderAPI3.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI3.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify3);
                m_ReaderAPI3.Events.NotifyGPIEvent = true;
                m_ReaderAPI3.Events.NotifyAntennaEvent = true;
                m_ReaderAPI3.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI3.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI3.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI3.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI3.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI3.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI3.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI3.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected3 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs3.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }

            //updateGPIState();
        }

        private void chkin_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkin.Checked == true)
            {
                this.m_TagTable.Clear();
                reader_connect();
                lblcount.Text = "Start Reading";
                chkout.Enabled = false;
            }
            if (chkin.Checked == false)
            {
                this.m_TagTable.Clear();
                lblcount.Text = "Stop Reading";
                m_ReaderAPI.Actions.Inventory.Stop();
                chkout.Enabled = true;
            }
            
        }

        private void chkout_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkout.Checked == true)
            {
                this.m_TagTable.Clear();
                reader_connect();
                lblcount.Text = "Start Reading";
                chkin.Enabled = false;
            }
            if (chkout.Checked == false)
            {
                this.m_TagTable.Clear();
                lblcount.Text = "Stop Reading";
                m_ReaderAPI.Actions.Inventory.Stop();
                chkin.Enabled = true;
            }
        }

        private void chkin1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkin1.Checked == true)
            {
                this.m_TagTable1.Clear();
                reader_connect1();
                label16.Text = "Start Reading";
                chkout1.Enabled = false;
            }
            if (chkin1.Checked == false)
            {
                this.m_TagTable1.Clear();
                label16.Text = "Stop Reading";
                m_ReaderAPI1.Actions.Inventory.Stop();
                chkout1.Enabled = true;
            }
        }

        private void chkout1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout1.Checked == true)
            {
                this.m_TagTable1.Clear();
                reader_connect1();
                label16.Text = "Start Reading";
                chkin1.Enabled = false;
            }
            if (chkout1.Checked == false)
            {
                this.m_TagTable1.Clear();
                label16.Text = "Stop Reading";
                m_ReaderAPI1.Actions.Inventory.Stop();
                chkin1.Enabled = true;
            }
        }

        private void chkin2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin2.Checked == true)
            {
                reader_connect2();
                label15.Text = "Start Reading";
                chkout2.Enabled = false;
            }
            if (chkin2.Checked == false)
            {
                label15.Text = "Stop Reading";
                m_ReaderAPI2.Actions.Inventory.Stop();
                chkout2.Enabled = true;
            }
        }

        private void chkout2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout2.Checked == true)
            {
                reader_connect2();
                label15.Text = "Start Reading";
                chkin2.Enabled = false;
            }
            if (chkout2.Checked == false)
            {
                m_ReaderAPI2.Actions.Inventory.Stop();
                label15.Text = "Stop Reading";
                chkin2.Enabled = true;
            }
        }

        private void chkin3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin3.Checked == true)
            {
                reader_connect3();
                label19.Text = "Start Reading";
                chkout3.Enabled = false;
            }
            if (chkin3.Checked == false)
            {
                label19.Text = "Stop Reading";
                m_ReaderAPI3.Actions.Inventory.Stop();
               chkout3.Enabled = true;
            }
       }

        

        private void chkout3_CheckedChanged(object sender,EventArgs e)
        {
            if (chkout3.Checked == true)
            {
                reader_connect3();
                label19.Text = "Start Reading";
                chkin3.Enabled = false;
            }
            if (chkout3.Checked == false)
            {
                label19.Text = "Stop Reading";
                m_ReaderAPI3.Actions.Inventory.Stop();
                chkin3.Enabled = true;
            }
        }

        private void connectBackgroundWorker4_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker4.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI4 = new RFIDReader(IPaddress4, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI4.Connect();
                        m_IsConnected4 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected4)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected4)
                            {
                                if (m_ReaderAPI4.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI4.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI4.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI4.Disconnect();
                        m_IsConnected4 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI4.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs4)
        {
            if (m_IsConnected4)
            {
                //if (m_ConnectionForm.connectionButton.Text == "Connect")
                //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI4.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify4);
                m_ReaderAPI4.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI4.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify4);
                m_ReaderAPI4.Events.NotifyGPIEvent = true;
                m_ReaderAPI4.Events.NotifyAntennaEvent = true;
                m_ReaderAPI4.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI4.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI4.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI4.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI4.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI4.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI4.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI4.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected4 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs4.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }
        }

        private void chkin4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin4.Checked == true)
            {
                reader_connect4();
                label23.Text = "Start Reading";
                chkout4.Enabled = false;
            }
            if (chkin4.Checked == false)
            {
                label23.Text = "Stop Reading";
                m_ReaderAPI4.Actions.Inventory.Stop();
                chkout4.Enabled = true;
            }
        }

        private void chkout4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout4.Checked == true)
            {
                reader_connect4();
                label23.Text = "Start Reading";
                chkin4.Enabled = false;
            }
            if (chkout4.Checked == false)
            {
                label23.Text = "Stop Reading";
                m_ReaderAPI4.Actions.Inventory.Stop();
                chkin4.Enabled = true;
            }
        }

        private void connectBackgroundWorker5_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker5.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI5 = new RFIDReader(IPaddress5, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI5.Connect();
                        m_IsConnected5 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected5)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected5)
                            {
                                if (m_ReaderAPI5.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI5.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI5.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI5.Disconnect();
                        m_IsConnected5 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI5.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs5)
        {
            if (m_IsConnected5)
            {
                //if (m_ConnectionForm.connectionButton.Text == "Connect")
                //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI5.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify5);
                m_ReaderAPI5.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI5.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify5);
                m_ReaderAPI5.Events.NotifyGPIEvent = true;
                m_ReaderAPI5.Events.NotifyAntennaEvent = true;
                m_ReaderAPI5.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI5.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI5.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI5.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI5.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI5.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI5.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI5.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected5 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs5.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }
        }

        private void chkin5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin5.Checked == true)
            {
                reader_connect5();
                label21.Text = "Start Reading";
                chkout5.Enabled = false;
            }
            if (chkin5.Checked == false)
            {
                label21.Text = "Stop Reading";
                m_ReaderAPI5.Actions.Inventory.Stop();
                chkout5.Enabled = true;
            }
        }

        private void chkout5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout5.Checked == true)
            {
                reader_connect5();
                label21.Text = "Start Reading";
                chkin5.Enabled = false;
            }
            if (chkout5.Checked == false)
            {
                label21.Text = "Stop Reading";
                m_ReaderAPI5.Actions.Inventory.Stop();
                chkin5.Enabled = true;
            }
        }

        private void chkin6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin6.Checked == true)
            {
                reader_connect6();
                label25.Text = "Start Reading";
                chkout6.Enabled = false;
            }
            if (chkin6.Checked == false)
            {
                label25.Text = "Stop Reading";
                m_ReaderAPI6.Actions.Inventory.Stop();
                chkout6.Enabled = true;
            }
        }

        private void chkin7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkin7.Checked == true)
            {
                reader_connect7();
                label27.Text = "Start Reading";
                chkout7.Enabled = false;
            }
            if (chkin7.Checked == false)
            {
                label27.Text = "Stop Reading";
                m_ReaderAPI7.Actions.Inventory.Stop();
                chkout7.Enabled = true;
            }
        }

        private void chkout6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout6.Checked == true)
            {
                reader_connect6();
                label25.Text = "Start Reading";
                chkin6.Enabled = false;
            }
            if (chkout6.Checked == false)
            {
                label25.Text = "Stop Reading";
                m_ReaderAPI6.Actions.Inventory.Stop();
                chkin6.Enabled = true;
            }
        }

        private void chkout7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkout7.Checked == true)
            {
                reader_connect7();
                label27.Text = "Start Reading";
                chkin7.Enabled = false;
            }
            if (chkout7.Checked == false)
            {
                label27.Text = "Stop Reading";
                m_ReaderAPI7.Actions.Inventory.Stop();
                chkin7.Enabled = true;
            }
        }

        private void connectBackgroundWorker6_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker6.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI6 = new RFIDReader(IPaddress6, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI6.Connect();
                        m_IsConnected6 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected6)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected6)
                            {
                                if (m_ReaderAPI6.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI6.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI6.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI6.Disconnect();
                        m_IsConnected6 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI6.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs6)
        {
            if (m_IsConnected6)
            {
                //if (m_ConnectionForm.connectionButton.Text == "Connect")
                //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI6.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify6);
                m_ReaderAPI6.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI6.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify6);
                m_ReaderAPI6.Events.NotifyGPIEvent = true;
                m_ReaderAPI6.Events.NotifyAntennaEvent = true;
                m_ReaderAPI6.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI6.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI6.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI6.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI6.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI6.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI6.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI6.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected6 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs6.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }
        }

        private void connectBackgroundWorker7_DoWork(object sender, DoWorkEventArgs workEventArgs)
        {
            try
            {
                connectBackgroundWorker7.ReportProgress(0, workEventArgs.Argument);

                if ((string)workEventArgs.Argument == "Connect")
                {
                    //m_ReaderAPI = new RFIDReader(m_ConnectionForm.IpText, uint.Parse(m_ConnectionForm.PortText), 0);
                    m_ReaderAPI7 = new RFIDReader(IPaddress7, uint.Parse("5084"), 0);
                    try
                    {
                        m_ReaderAPI7.Connect();
                        m_IsConnected7 = true;
                        workEventArgs.Result = "Connect Succeed";

                        try
                        {
                            if (m_IsConnected7)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                    }
                    catch (OperationFailureException operationException)
                    {
                        workEventArgs.Result = operationException.Result;
                    }
                    catch (Exception ex)
                    {
                        workEventArgs.Result = ex.Message;
                    }
                }
                else if ((string)workEventArgs.Argument == "Disconnect")
                {
                    try
                    {
                        try
                        {
                            if (m_IsConnected7)
                            {
                                if (m_ReaderAPI7.Actions.TagAccess.OperationSequence.Length > 0)
                                {
                                    m_ReaderAPI7.Actions.TagAccess.OperationSequence.StopSequence();
                                }
                                else
                                {
                                    m_ReaderAPI7.Actions.Inventory.Stop();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            functionCallStatusLabel.Text = ex.Message;
                        }
                        m_ReaderAPI7.Disconnect();
                        m_IsConnected7 = false;
                        workEventArgs.Result = "Disconnect Succeed";
                    }
                    catch (OperationFailureException ofe)
                    {
                        workEventArgs.Result = ofe.Result;
                    }
                }
                else if ((string)workEventArgs.Argument == "Reconnect")
                {
                    for (int nIndex = 0; nIndex < 5; nIndex++)
                    {
                        try
                        {
                            m_ReaderAPI7.Reconnect();
                            functionCallStatusLabel.Text = "Disconnect & Reconnect Success in Attempt "
                                + nIndex;
                            workEventArgs.Result = "Reconnect Succeed";
                            break;
                        }
                        catch (OperationFailureException exception)
                        {
                            workEventArgs.Result = exception.VendorMessage;
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void connectBackgroundWorker7_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ConnectionForm.connectionButton.Enabled = false;
        }

        private void connectBackgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs connectEventArgs7)
        {
            if (m_IsConnected7)
            {
                //if (m_ConnectionForm.connectionButton.Text == "Connect")
                //{
                //if (connectEventArgs1.Result.ToString() == "Connect Succeed")
                //{
                /*
                    *  UI Updates
                    */
                m_ConnectionForm.connectionButton.Text = "Disconnect";
                m_ConnectionForm.hostname_TB.Enabled = false;
                m_ConnectionForm.port_TB.Enabled = false;
                m_ConnectionForm.Close();
                this.readButton.Enabled = true;
                this.readButton.Text = "Start Reading";
                //blockEraseToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockEraseSupported;
                //blockWriteToolStripMenuItem.Enabled = m_ReaderAPI.ReaderCapabilities.IsBlockWriteSupported;

                /*
                    *  Events Registration
                    */
                //  m_ReaderAPI1.Actions.PreFilters.DeleteAll();

                m_ReaderAPI7.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify7);
                m_ReaderAPI7.Events.AttachTagDataWithReadEvent = false;
                m_ReaderAPI7.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify7);
                m_ReaderAPI7.Events.NotifyGPIEvent = true;
                m_ReaderAPI7.Events.NotifyAntennaEvent = true;
                m_ReaderAPI7.Events.NotifyReaderDisconnectEvent = true;
                m_ReaderAPI7.Events.NotifyBufferFullEvent = true;
                m_ReaderAPI7.Events.NotifyBufferFullWarningEvent = true;
                m_ReaderAPI7.Events.NotifyAccessStartEvent = true;
                m_ReaderAPI7.Events.NotifyAccessStopEvent = true;
                m_ReaderAPI7.Events.NotifyInventoryStartEvent = true;
                m_ReaderAPI7.Events.NotifyInventoryStopEvent = true;
                m_ReaderAPI7.Events.NotifyReaderExceptionEvent = true;

                this.Text = "Connected to " + "192.168.1.100";
                this.connectionStatus.BackgroundImage =
                    global::CS_RFID3_Host_Sample2.Properties.Resources.connected;
                configureMenuItemsUponConnectDisconnect();
                //configureMenuItemsBasedOnCapabilities();
                // }
                //}
                //else if (m_ConnectionForm.connectionButton.Text == "Disconnect")
                //{
                //    //if (connectEventArgs1.Result.ToString() == "Disconnect Succeed")
                //    //{
                //    //}
                //    this.Text = "CS_RFID3_Host_Sample2";
                //    this.connectionStatus.BackgroundImage =
                //    global::CS_RFID3_Host_Sample2.Properties.Resources.disconnected;

                //    m_ConnectionForm.connectionButton.Text = "Connect";
                //    m_ConnectionForm.hostname_TB.Enabled = true;
                //    m_ConnectionForm.port_TB.Enabled = true;
                //    this.readButton.Enabled = false;
                //    this.readButton.Text = "Start Reading";
                //    configureMenuItemsUponConnectDisconnect();
                //    m_IsConnected7 = false;

                //}
                functionCallStatusLabel.Text = connectEventArgs7.Result.ToString();
                m_ConnectionForm.connectionButton.Enabled = true;
            }
        }
        private void reader_connect()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected = true;
            if (m_IsConnected)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable.Clear();
                    m_TagTotalCount = 0;
                    m_ReaderAPI.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect1()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected1 = true;
            if (m_IsConnected1)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI1.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI1.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable1.Clear();
                   // m_TagTotalCount1 = 0;
                    m_ReaderAPI1.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect2()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected2 = true;
            if (m_IsConnected2)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI2.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI2.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable2.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI2.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect3()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected3 = true;
            if (m_IsConnected3)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI3.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI3.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable3.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI3.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect4()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected4 = true;
            if (m_IsConnected4)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI4.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI4.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable4.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI4.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }


        private void reader_connect5()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected5 = true;
            if (m_IsConnected5)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI5.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI5.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable5.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI5.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect6()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected6 = true;
            if (m_IsConnected6)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI6.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI6.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable6.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI6.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }

        private void reader_connect7()
        {
            //m_ReaderAPI = new RFIDReader();
            m_IsConnected7 = true;
            if (m_IsConnected7)
            {
                //if (readButton.Text == "Start Reading")
                //{


                if (m_ReaderAPI7.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    m_ReaderAPI7.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                }
                else
                {
                    //inventoryList.Items.Clear();
                    m_TagTable7.Clear();
                    // m_TagTotalCount1 = 0;
                    m_ReaderAPI7.Actions.Inventory.Perform(null, null, null);

                    //m_ReaderAPI1.Actions.Inventory.Perform(
                    //    m_PostFilterForm.getFilter(),
                    //    m_TriggerForm.getTriggerInfo(),
                    //    m_AntennaInfoForm.getInfo());
                }



                // readButton.Text = "Stop Reading";
                //memBank_CB.Enabled = false;

            }
        }
        private void reader_disconnect(object sender, DoWorkEventArgs workEventArgs)
        {
            m_ReaderAPI.Disconnect();
            m_IsConnected = false;
        }

        private void chkon1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkon1.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected = true;    
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress = dss.Tables[0].Rows[0]["IPaddress"].ToString();
                
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress))
                {
                    label13.Text = IPaddress;
                    button9.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker.RunWorkerAsync("Connect");
                    chkin.Visible = true;
                    chkout.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader1 Not connected!!!");
                    chkon1.Checked = false;

                }
                //reader_connect();

                
            }
            if (chkon1.Checked == false)
            {
                
                m_ReaderAPI.Actions.Inventory.Stop();
                this.connectBackgroundWorker.RunWorkerAsync("Disconnect");
                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button9.BackColor = System.Drawing.Color.Red;
                chkin.Visible = false;
                chkout.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();
                    
                //    //m_ReaderAPI1.Actions.Inventory.Stop();
                   
                   
                    this.m_TagTable.Clear();
                    lblcount.Text = string.Empty;
                    lblcount.Text = "0";

                    
                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;
                    
                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }


        }

        private void chkon3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon3.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected2 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
               
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress2))
                {
                    label30.Text = IPaddress2;
                    button11.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker2.RunWorkerAsync("Connect");

                    chkin2.Visible = true;
                    chkout2.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader3 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon3.Checked == false)
            {

                m_ReaderAPI2.Actions.Inventory.Stop();
                this.connectBackgroundWorker2.RunWorkerAsync("Disconnect");
                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button11.BackColor = System.Drawing.Color.Red;
                chkin2.Visible = false;
                chkout2.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable2.Clear();
                label15.Text = string.Empty;
                label15.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon2_CheckedChanged_1(object sender, EventArgs e)
        {

            if (chkon2.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected1 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
               
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress1))
                {
                    label29.Text = IPaddress1;
                    button10.BackColor = System.Drawing.Color.Green;
                    this.connectBackgroundWorker1.RunWorkerAsync("Connect");
                    chkin1.Visible = true;
                    chkout1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Reader2 Not connected!!!");
                    chkon2.Checked = false;
                }
                //reader_connect();


            }
            if (chkon2.Checked == false)
            {

                m_ReaderAPI1.Actions.Inventory.Stop();
                this.connectBackgroundWorker1.RunWorkerAsync("Disconnect");
                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button10.BackColor = System.Drawing.Color.Red;
                chkin1.Visible = false;
                chkout1.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable1.Clear();
                label16.Text = string.Empty;
                label16.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon4.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected3 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress3))
                {
                    label31.Text = IPaddress3;
                    button12.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker3.RunWorkerAsync("Connect");

                    chkin3.Visible = true;
                    chkout3.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader4 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon4.Checked == false)
            {

                m_ReaderAPI3.Actions.Inventory.Stop();
                this.connectBackgroundWorker3.RunWorkerAsync("Disconnect");
                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button12.BackColor = System.Drawing.Color.Red;
                chkin3.Visible = false;
                chkout3.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable3.Clear();
                label19.Text = string.Empty;
                label19.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon5.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected4 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress4))
                {
                    label32.Text = IPaddress4;
                    button18.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker4.RunWorkerAsync("Connect");

                    chkin4.Visible = true;
                    chkout4.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader5 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon5.Checked == false)
            {


                m_ReaderAPI4.Actions.Inventory.Stop();
                this.connectBackgroundWorker4.RunWorkerAsync("Disconnect");
                
                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button18.BackColor = System.Drawing.Color.Red;
                chkin4.Visible = false;
                chkout4.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable4.Clear();
                label23.Text = string.Empty;
                label23.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon6.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected5 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster  ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress5 = dss.Tables[0].Rows[5]["IPaddress"].ToString();
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress5))
                {
                    label33.Text = IPaddress5;
                    button20.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker5.RunWorkerAsync("Connect");

                    chkin5.Visible = true;
                    chkout5.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader6 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon6.Checked == false)
            {


                m_ReaderAPI5.Actions.Inventory.Stop();
                this.connectBackgroundWorker5.RunWorkerAsync("Disconnect");

                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button20.BackColor = System.Drawing.Color.Red;
                chkin5.Visible = false;
                chkout5.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable5.Clear();
                label21.Text = string.Empty;
                label21.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon7.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected6 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress6 = dss.Tables[0].Rows[6]["IPaddress"].ToString();
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress6))
                {
                    label34.Text = IPaddress6;
                    button22.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker6.RunWorkerAsync("Connect");

                    chkin6.Visible = true;
                    chkout6.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader7 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon7.Checked == false)
            {


                m_ReaderAPI6.Actions.Inventory.Stop();
                this.connectBackgroundWorker6.RunWorkerAsync("Disconnect");

                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button22.BackColor = System.Drawing.Color.Red;
                chkin6.Visible = false;
                chkout6.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable6.Clear();
                label25.Text = string.Empty;
                label25.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        private void chkon8_CheckedChanged(object sender, EventArgs e)
        {
            if (chkon8.Checked == true)
            {
                //m_IsConnected1 = false;
                m_IsConnected7 = true;
                //chkoff1.Enabled = false;
                DataSet dss = new DataSet();
                dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");
                //dss = d2.select_method_wo_parameter("select distinct IPaddress from dc_devicemaster ", "spp");

                IPaddress7 = dss.Tables[0].Rows[7]["IPaddress"].ToString();
                //IPaddress1 = dss.Tables[0].Rows[1]["IPaddress"].ToString();
                //IPaddress2 = dss.Tables[0].Rows[2]["IPaddress"].ToString();
                //IPaddress3 = dss.Tables[0].Rows[3]["IPaddress"].ToString();
                //IPaddress4 = dss.Tables[0].Rows[4]["IPaddress"].ToString();
                if (PingHost(IPaddress7))
                {
                    label35.Text = IPaddress7;
                    button24.BackColor = System.Drawing.Color.Green;

                    this.connectBackgroundWorker7.RunWorkerAsync("Connect");

                    chkin7.Visible = true;
                    chkout7.Visible = true;



                    //reader_connect();


                }
                else
                {
                    MessageBox.Show("Reader8 Not connected!!!");
                }
                //reader_connect();


            }
            if (chkon8.Checked == false)
            {


                m_ReaderAPI7.Actions.Inventory.Stop();
                this.connectBackgroundWorker7.RunWorkerAsync("Disconnect");

                //connectBackgroundWorker.RunWorkerAsync("Disconnect");
                button24.BackColor = System.Drawing.Color.Red;
                chkin7.Visible = false;
                chkout7.Visible = false;
                //chkoff1.Enabled = true;

                //if (m_ReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                //{
                //    m_ReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(m_AccessFilterForm.getFilter(),
                //        m_TriggerForm.getTriggerInfo(), m_AntennaInfoForm.getInfo());
                //}
                //else
                //{
                //    //inventoryList.Items.Clear();

                //    //m_ReaderAPI1.Actions.Inventory.Stop();


                this.m_TagTable7.Clear();
                label27.Text = string.Empty;
                label27.Text = "0";


                //    //m_ReaderAPI.Disconnect();
                //     //m_IsConnected = false;

                //     //configureMenuItemsUponConnectDisconnect();
                //     //m_disconnected = false;

                //    //m_IsConnected1=false;

                //    //m_ReaderAPI1.Actions.Inventory.Perform(
                //    //    m_PostFilterForm.getFilter(),
                //    //    m_TriggerForm.getTriggerInfo(),
                //    //    m_AntennaInfoForm.getInfo());
                //}
            }
        }

        

        
      }
}

        
         




         
         
     
      
    

       

        

        


       

      
    
    

































