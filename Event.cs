using UnityEngine;
using System.Collections;

public class Event {
	
	public object body;
	public string name;

	public Event(string name = "Event", object body = null){
		this.name = name;
		this.body = body;
	}
}
