using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MobilexPCServer : MonoBehaviour {

    public GameObject playerPrefab;
    public Transform spawnObject;

    public string gameName = "";
    private bool refreshing = false;
    private HostData[] hostData;
    internal bool Hosting = false;

    //Buttons
    public Button Search;
    public Button Server1;
    public Button Server2;
    public Button Server3;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            PairSearch.SetActive(true);
        }
        Button SearchButton = Search.GetComponent<Button>();
        SearchButton.onClick.AddListener(refreshHostList);
    }
    void ButtonUI()
    {
        if (!Network.isClient && !Network.isServer) {
            try
            {
                for (var i = 0; i < hostData.Length; i++)
                {
                    if(hostData.Length == 1)
                    {
                        Server1.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[0].gameName;
                        Button Device1 = Server1.GetComponent<Button>();
                        Device1.onClick.AddListener(ConnectDevice1);

                        Server2.gameObject.SetActive(false);
                        Server3.gameObject.SetActive(false);
                    }
                    else if (hostData.Length == 2)
                    {
                        Server1.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[0].gameName;
                        Button Device1 = Server1.GetComponent<Button>();
                        Device1.onClick.AddListener(ConnectDevice1);

                        Server2.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[1].gameName;
                        Button Device2 = Server2.GetComponent<Button>();
                        Device2.onClick.AddListener(ConnectDevice2);

                        Server3.gameObject.SetActive(false);
                    }
                    else if (hostData.Length == 1)
                    {
                        Server1.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[0].gameName;
                        Button Device1 = Server1.GetComponent<Button>();
                        Device1.onClick.AddListener(ConnectDevice1);

                        Server2.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[1].gameName;
                        Button Device2 = Server2.GetComponent<Button>();
                        Device2.onClick.AddListener(ConnectDevice2);

                        Server3.gameObject.SetActive(true);
                        Server1.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "Device: " + hostData[2].gameName;
                        Button Device3 = Server3.GetComponent<Button>();
                        Device3.onClick.AddListener(ConnectDevice3);
                    }
                    else if(hostData.Length == 0)
                    {
                        Server1.gameObject.SetActive(false);
                        Server2.gameObject.SetActive(false);
                        Server3.gameObject.SetActive(false);
                    }
                }
            }
            catch(System.NullReferenceException ex)
            {

            }
        }
        else
            Server1.gameObject.SetActive(false);
            Server2.gameObject.SetActive(false);
            Server3.gameObject.SetActive(false);
    }

    void ConnectDevice1()
    {
                Network.Connect(hostData[0]);
    }
    void ConnectDevice2()
    {
        Network.Connect(hostData[1]);
    }
    void ConnectDevice3()
    {
        Network.Connect(hostData[2]);
    }

    public GameObject DeviceSearch;
    public GameObject DevicePaired;
    public GameObject PairSearch;
    void Update()
    {
        gameName = "level1";
        if (refreshing)
        {
            if (MasterServer.PollHostList().Length > 0)
            {
                refreshing = false;
                Debug.Log(MasterServer.PollHostList().Length);
                hostData = MasterServer.PollHostList();
            }
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
            if (!Network.isClient && !Network.isServer)
            {
                startServer();
            }
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            ButtonUI();
        }
    }
    void startServer()
    {
        if (!Hosting)
        {
            bool useNat = !Network.HavePublicAddress();
            Network.InitializeServer(1, 25001, useNat);
            MasterServer.RegisterHost(gameName,SystemInfo.deviceName, "This server is only made by PC/Mac not mobile devices");
            GameObject.Find("Bi NET").GetComponent<BiNetworkConnection>().ComputerTransmittion = true;
            Hosting = true;
        }
    }
    void OnServerInitialized()
    {
        Debug.Log("server initialized");
    }

    private int playerCount = 0;
    private void OnPlayerConnected(NetworkPlayer player)
    {
        DeviceSearch.SetActive(false);
        Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
        GameObject.Find("Bi NET").GetComponent<BiNetworkConnection>().MobileDeviceIP = player.ipAddress;
        GameObject.Find("Bi NET").GetComponent<BiNetworkConnection>().commutingStarted = true;
        DevicePaired.SetActive(true);
    }

    void OnConnectedToServer()
    {
        PairSearch.SetActive(false);
        DeviceSearch.SetActive(false);
        DevicePaired.SetActive(true);

    }

    void spawnPlayer()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            Network.Instantiate(playerPrefab, spawnObject.position, Quaternion.identity, 0).name = SystemInfo.deviceName;
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            Network.Instantiate(playerPrefab, spawnObject.position, Quaternion.identity, 0).name = SystemInfo.deviceName;
        }
    }
    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.RegistrationSucceeded)
            Debug.Log("Server registered");
    }
    void refreshHostList()
    {
        MasterServer.RequestHostList(gameName);
        refreshing = true;
    }
}
