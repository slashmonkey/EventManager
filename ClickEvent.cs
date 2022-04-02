using UnityEngine;
using System.Collections;

public class ClickEvent : Event {
	public const string Mouse_Up 	= "Mouse_Up";
	public const string Mouse_Down 	= "Mouse_Down";

	public ClickEvent(string name, object body = null):base(name, body){}
}
