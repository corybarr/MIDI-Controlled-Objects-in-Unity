using UnityEngine;
using System.Collections;

public class MIDITrigger : MonoBehaviour {
	
	private OSCTestSender oscTestSender;
	public int midiNote = 88;

	// Use this for initialization
	void Start () {
		GameObject oscTestSenderObject = GameObject.FindWithTag("osc");
		oscTestSender = oscTestSenderObject.GetComponent(typeof(OSCTestSender)) as OSCTestSender;
	}
	
	// Update is called once per frame
	void Update () {
		//print("Updating");
	}
	
	void OnTriggerEnter() {
		print("Trigger Entered");
		
		oscTestSender.SendNoteOn(midiNote);
	}
	
	void OnTriggerExit() {
		oscTestSender.SendNoteOff(midiNote);
	}
	
	void OnMouseDown() {
		print("Mouse button pressed");
		
		oscTestSender.SendNoteOn(midiNote);
	}
	
	void OnMouseUp() {
		oscTestSender.SendNoteOff(midiNote);
	}
}
