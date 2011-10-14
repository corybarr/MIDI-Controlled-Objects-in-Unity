using UnityEngine;
using System.Collections;

public class MidiSender : MonoBehaviour {
	private OSCTestSender oscTestSender;
	public int midiNote = 88;
	
	// Use this for initialization
	void Start () {
		GameObject oscTestSenderObject = GameObject.FindWithTag("osc");
		oscTestSender = oscTestSenderObject.GetComponent(typeof(OSCTestSender)) as OSCTestSender;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPointCloudCollisionEnter() {
		Debug.Log("collision enter. playing note: " + midiNote);
		oscTestSender.SendNoteOn(midiNote);
	}
	
	void OnPointCloudCollisionExit() {
		Debug.Log("collision exit. stopping note: " + midiNote);
		oscTestSender.SendNoteOff(midiNote);
	}
	
}
