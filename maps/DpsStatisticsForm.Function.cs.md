StarResonanceDpsAnalysis.Forms
└── Class: DpsStatisticsForm
    │
    ├── [Startup & Initialization]
    │   ├── InitTableColumnsConfigAtFirstRun()
    │   ├── LoadNetworkDevices()
    │   └── SetStyle()
    │
    ├── [Packet Capture]
    │   ├── StartCapture()
    │   ├── StopCapture()
    │   ├── Device_OnPacketArrival(sender, PacketCapture e)
    │   └── Properties
    │       ├── static ICaptureDevice? SelectedDevice
    │       └── static bool IsCaptureStarted
    │
    ├── [Cleanup & Reset]
    │   ├── HandleClearData(bool ClearPicture = false)
    │   ├── ListClear()
    │   └── Fields
    │       ├── object _dataLock
    │       └── int _isClearing
    │
    ├── [UI & State]
    │   ├── SetStyle()   // configure progress bar visuals
    │   ├── Fields
    │   │   ├── volatile bool _npcDetailMode
    │   │   ├── ulong _npcFocusId
    │   │   ├── static SortedProgressBarList SortedProgressBarStatic
    │   │   ├── static Dictionary<long, List<RenderContent>> DictList
    │   │   ├── static List<ProgressBarData> list
    │   │   ├── static List<RenderContent> userRenderContent
    │   │   ├── Dictionary<string, Color> colorDict
    │   │   ├── Dictionary<string, Color> blackColorDict
    │   │   └── static Dictionary<string, Bitmap> imgDict
    │   └── Helper
    │       └── static Bitmap EmptyBitmap(int w = 1, int h = 1)
    │
    └── [External Components]
        ├── PacketAnalyzer PacketAnalyzer
        ├── ChartVisualizationService (used in StartCapture/StopCapture/HandleClearData)
        ├── FullRecord (used in StartCapture/HandleClearData)
        ├── FormManager (settingsForm, showTotal)
        └── AppConfig (user settings, network card, etc.)
