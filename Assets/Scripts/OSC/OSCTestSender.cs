using UnityEngine;
using System.Collections;

public class OSCTestSender : MonoBehaviour {

	private Osc oscHandler;
	
	public string remoteIp;
	public int senderPort;
	public int listenerPort;
	
 	~OSCTestSender() {
		print("Destructor called");
		if (oscHandler != null) {
			oscHandler.Cancel();
		}
		
		oscHandler = null;
		System.GC.Collect();
	} 
	
	// Use this for initialization
	void Start () {
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(remoteIp, senderPort, listenerPort);
		
		oscHandler = GetComponent<Osc>();
		oscHandler.init(udp);
		oscHandler.SetAddressHandler("/hand1", Example);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onDisable() {
		oscHandler.Cancel();
		oscHandler = null;
	}
	
	public void SendNoteOn(int noteNum) {
		
		OscMessage oscM = Osc.StringToOscMessage("/noteon " +  noteNum + " 120");
		oscHandler.Send(oscM);
	}
	
	public void SendNoteOff(int noteNum) {
		OscMessage oscM = Osc.StringToOscMessage("/noteoff " + noteNum);
		oscHandler.Send(oscM);
	}
	
	public static void Example(OscMessage m) {
		print("----------> OSC example message received: (" + m + ")");
	}
}
