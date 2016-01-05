using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive: MonoBehaviour {
	
	// receiving Thread
	Thread receiveThread;
	
	// udpclient object
	UdpClient client;

	
	public int port; // define > init
	
	// infos
	public string lastReceivedUDPPacket = "";
	public string allReceivedUDPPackets = ""; // clean up this from time to time!
	
	   // FaceAPI
   public float xPos;
   public float yPos;
   public float zPos;
   public float pitch;
   public float yaw;
   public float roll;
	
	// start from shell
	private static void Main() {
		
		UDPReceive receiveObj = new UDPReceive();
		receiveObj.init();
		string text = "";
		
		do {
			text = Console.ReadLine();
		}
		while (!text.Equals("exit"));
	}
	
	// start from unity3d
	public void Start() {
		init();
	}
	
	public string getLastPacket() {
		return lastReceivedUDPPacket;
	}
	
	
	// init
	private void init() {
		
		xPos = 0;
       yPos = 0;
       zPos = 0;
       pitch = 0;
       yaw = 0;
       roll = 0;
		
		
		print("UDPSend.init()");
		// define port
		port = 5550;
		
		// status
		print("Sending to 127.0.0.1 : " + port);
		print("Test-Sending to this Port: nc -u 127.0.0.1  " + port + "");
		
		
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}
	
	// receive thread 
	private void ReceiveData() {
		
		client = new UdpClient(port);
		while (true) {
			try {

				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = client.Receive(ref anyIP);

				
				
				for (int i = 0; i < 6; i++)	{
   					double datum = System.BitConverter.ToDouble(data, i * 8);
					var j = i+1;
						switch (j)
						{
						     case 1: {
								xPos = (float)datum;
						        break;
						    } case 2: {
											pitch = (float)datum;	

						        break;
						    } case 3: {
								zPos = (float)datum;
								break;
						    }case 4: {
								yaw = (float)datum;

						        break;
						    } case 5: {
										yPos = (float)datum;		//		
						
						        break;
						    } case 6: {
							roll = (float)datum;
								break;
						    }
						}
				}
				
				// ....
				// allReceivedUDPPackets=allReceivedUDPPackets+text;
			} catch (Exception err) {
				print(err.ToString());
			}
		}
	}

	
	// getLatestUDPPacket
	// cleans up the rest
	public string getLatestUDPPacket() {
		allReceivedUDPPackets = "";
		return lastReceivedUDPPacket;
	}
	void OnDisable() {
		if (receiveThread != null)
			receiveThread.Abort();
		client.Close();
	}
	void OnApplicationQuit() {
		if (receiveThread != null)
			receiveThread.Abort();
		client.Close();
	}
}