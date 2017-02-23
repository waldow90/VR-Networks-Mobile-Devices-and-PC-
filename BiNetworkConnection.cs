using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiNetworkConnection : MonoBehaviour {
    public string ComputerIp = "192.168.1.156";
    public string MobileDeviceIP = "192.168.1.168";
    public int portNUmber1 = 25001;
    public int dNotation1 = 0;
    public int dNotation2 = 0;
    public int dNotation3 = 0;
    public int dNotation4 = 0;

    public bool commutingStarted = false;
    public bool MobileTransmittion = false;
    public bool ComputerTransmittion = false;


    private void Update()
    {
        //dNotation1 = int.Parse(ComputerIp.Substring(0, 3)); 
        if(commutingStarted && !MobileTransmittion) 
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                Network.InitializeServer(4, portNUmber1, true);
                ComputerTransmittion = false;
                commutingStarted = false;
                MobileTransmittion = true;
            }
        }
        else if (commutingStarted && !ComputerTransmittion)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Network.InitializeServer(4, portNUmber1, true);
                MobileTransmittion = false;
                commutingStarted = false;
                ComputerTransmittion = true;
            }
        }
    }
    private void FixedUpdate()
    {
        //dNotation1 = int.Parse(ComputerIp.Substring(0, 3)); 
        if (commutingStarted && !MobileTransmittion)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Network.InitializeServer(4, portNUmber1, true);
                ComputerTransmittion = false;
                commutingStarted = false;
                MobileTransmittion = true;
            }
        }
        else if (commutingStarted && !ComputerTransmittion)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Network.InitializeServer(4, portNUmber1, true);
                MobileTransmittion = false;
                commutingStarted = false;
                ComputerTransmittion = true;
            }
        }
    }
    private void LateUpdate()
    {
        //dNotation1 = int.Parse(ComputerIp.Substring(0, 3)); 
        if (commutingStarted && !MobileTransmittion)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Network.InitializeServer(4, portNUmber1, true);
                ComputerTransmittion = false;
                commutingStarted = false;
                MobileTransmittion = true;
            }
        }
        else if (commutingStarted && !ComputerTransmittion)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Network.InitializeServer(4, portNUmber1, true);
                MobileTransmittion = false;
                commutingStarted = false;
                ComputerTransmittion = true;
            }
        }
    }

    private void Test()
    {//1.
        if((ComputerIp.Substring(1, 1)) == ".")
        {
            dNotation1 = System.Int32.Parse(ComputerIp.Substring(0, 0));
            //1.1.
            if((ComputerIp.Substring(3, 3)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(2, 2));
                //1.1.1.
                if ((ComputerIp.Substring(5, 5)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(4, 4));
                    //1.1.1.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(6, 8));
                }
                //1.1.11.
                else if ((ComputerIp.Substring(6, 6)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(4, 5));
                    //1.1.11.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(7, 9));
                }
                //1.1.111.
                else if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(4, 6));
                    //1.1.111.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(8, 10));
                }
            }//1.11.
            else if ((ComputerIp.Substring(4, 4)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(2, 3));
                //1.11.1.
                if ((ComputerIp.Substring(6, 6)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 5));
                    //1.11.1.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(7, 9));
                }
                //1.11.11.
                else if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 6));
                    //1.11.11.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(8, 10));
                }
                //1.11.111.
                else if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 7));
                    //1.11.111.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(9, 11));
                }
            }//1.111.
            else if ((ComputerIp.Substring(5, 5)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(2, 4));
                //1.111.1.
                if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 6));
                    //1.111.1.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(8, 10));
                }
                //1.111.11.
                else if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 7));
                    //1.111.11.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(9, 11));
                }
                //1.111.111.
                else if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 8));
                    //1.111.111.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(10, 12));
                }
            }
        }//11.
        else if ((ComputerIp.Substring(2, 2)) == ".")
        {
            dNotation1 = System.Int32.Parse(ComputerIp.Substring(0, 1));
            //11.1.
            if ((ComputerIp.Substring(4, 4)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(3, 3));
                //11.1.1.
                if((ComputerIp.Substring(6, 6)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 5));
                    //11.1.1.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(7, 9));
                }
                //11.1.11.
                else if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 6));
                    //11.1.11.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(8, 10));
                }
                //11.1.111.
                else if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(5, 7));
                    //11.1.111.111
                    dNotation4 = System.Int32.Parse(ComputerIp.Substring(9, 11));
                }
            }//11.11.
            else if ((ComputerIp.Substring(5, 5)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(3, 4));
                //11.11.1.
                if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 6));
                }
                //11.11.11.
                else if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 7));
                }
                //11.11.111.
                else if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 8));
                }
            }
            //11.111.
            else if ((ComputerIp.Substring(6, 6)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(3, 5));
                //11.111.1.
                if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 7));
                }
                //11.111.11.
                else if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 8));
                }
                //11.111.111.
                else if ((ComputerIp.Substring(10, 10)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 9));
                }
            }
        }//111.
        else if ((ComputerIp.Substring(3, 3)) == ".")
        {
            dNotation1 = System.Int32.Parse(ComputerIp.Substring(0, 2));
            //111.1.
            if ((ComputerIp.Substring(5, 5)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(4, 4)); 
                //111.1.1.
                if ((ComputerIp.Substring(7, 7)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 6));
                }
                //111.1.11.
                else if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 7));
                }
                //111.1.111.
                else if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(6, 8));
                }
            }
            //111.11.
            else if ((ComputerIp.Substring(6, 6)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(4, 5));
                //111.11.1.
                if ((ComputerIp.Substring(8, 8)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 7));
                }
                //111.11.11.
                else if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 8));
                }
                //111.11.111.
                else if ((ComputerIp.Substring(10, 10)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(7, 9));
                }
            }
            //111.111.
            else if ((ComputerIp.Substring(7, 7)) == ".")
            {
                dNotation2 = System.Int32.Parse(ComputerIp.Substring(4, 6));
                //111.111.1.
                if ((ComputerIp.Substring(9, 9)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(8, 8));
                }
                //111.111.11.
                else if ((ComputerIp.Substring(10, 10)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(8, 9));
                }
                //111.111.111.
                else if ((ComputerIp.Substring(11, 11)) == ".")
                {
                    dNotation3 = System.Int32.Parse(ComputerIp.Substring(8, 10));
                }
            }
        }
    }

    private void OnPlayerDisconnected(NetworkPlayer player)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (player.ipAddress == ComputerIp)
            {
                Debug.Log("Mobile device" + ComputerIp + "has recived transmittion and is now transmitting");
                Network.Connect(ComputerIp, portNUmber1);
                Debug.Log("Computer have recived transmittion");
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (player.ipAddress == MobileDeviceIP)
            {
                Debug.Log("Mobile device" + MobileDeviceIP + "has recived transmittion and is now transmitting");
                Network.Connect(MobileDeviceIP, portNUmber1);
                Debug.Log("Computer have recived transmittion");
            }
        }
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        bool StartSquence = false;
        bool MTransmittion = false;
        bool CTransmittion = false;

        if (stream.isWriting)
        {
            CTransmittion = ComputerTransmittion;
            stream.Serialize(ref CTransmittion);
            MTransmittion = MobileTransmittion;
            stream.Serialize(ref MTransmittion);
            StartSquence = commutingStarted;
            stream.Serialize(ref StartSquence);
        }
        else
        {
            stream.Serialize(ref CTransmittion);
            ComputerTransmittion = CTransmittion;
            stream.Serialize(ref MTransmittion);
            MobileTransmittion = MTransmittion;
            stream.Serialize(ref StartSquence);
            commutingStarted = StartSquence;
        }
    }

    private void OnConnectedToServer()
    {
        Debug.Log("Recived");
    }

    private void OnServerInitialized()
    {
        Debug.Log("Transmitted");
    }
}
