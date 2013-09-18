
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
	// public
	// public string IP = "127.0.0.1"; default local
	public int port; // define > init
	// infos
	public string lastReceivedUDPPacket = "";
	public string allReceivedUDPPackets = ""; // clean up this from time to time!
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
		//00-00-00-80-59-9E-2F-C0-00-00-00-40-44-04-32-C0-00-00-00-C0-E4-37-4C-40-00-00-00-80-25-FE-32-C0-00-00-00-00-52-3F-51-C0-00-00-00-E0-A3-70-14-40
		print(Decode(1440));
		init();
	}
	// OnGUI
	void OnGUI() {
		Rect rectObj = new Rect(40, 10, 200, 400);
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.UpperLeft;
		GUI.Box(rectObj, "# UDPReceive\n127.0.0.1 " + port + " #\n" + "shell> nc -u 127.0.0.1 : " + port + " \n" + "\nLast Packet: \n" + lastReceivedUDPPacket + "\n\nAll Messages: \n" + allReceivedUDPPackets, style);
	}
	// init
	private void init() {
		// Endpunkt definieren, von dem die Nachrichten gesendet werden.
		print("UDPSend.init()");
		// define port
		port = 5550;
		// status
		print("Sending to 127.0.0.1 : " + port);
		print("Test-Sending to this Port: nc -u 127.0.0.1  " + port + "");
		// ----------------------------
		// Abhören
		// ----------------------------
		// Lokalen Endpunkt definieren (wo Nachrichten empfangen werden).
		// Einen neuen Thread für den Empfang eingehender Nachrichten erstellen.
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
				// Bytes empfangen.
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = client.Receive(ref anyIP);
				// Bytes mit der UTF8-Kodierung in das Textformat kodieren.
				string text = System.BitConverter.ToString(data);
				//00-00-00-80-59-9E-2F-C0-00-00-00-40-44-04-32-C0-00-00-00-C0-E4-37-4C-40-00-00-00-80-25-FE-32-C0-00-00-00-00-52-3F-51-C0-00-00-00-E0-A3-70-14-40
				// Den abgerufenen Text anzeigen.
				// print(">> " + text);
				// latest UDPpacket
				lastReceivedUDPPacket = text;
				print(Decode(4044));
				// ....
				// allReceivedUDPPackets=allReceivedUDPPackets+text;
			} catch (Exception err) {
				print(err.ToString());
			}
		}
	}
	public static short Encode(double value) {
		int cnt = 0;
		while (value != Math.Floor(value)) {
			value *= 10.0;
			cnt++;
		}
		return (short)((cnt << 12) + (int) value);
	}
	public static double Decode(short value) {
		int cnt = value >> 12;
		double result = value & 0xfff;
		while (cnt > 0) {
			result /= 10.0;
			cnt--;
		}
		return result;
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