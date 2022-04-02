using UnityEngine;
using System;
using System.Collections;

public class Main : MonoBehaviour {

	int index = 0;
	// Use this for initialization
	void Start () {

		//event
		EventManager.Instance.addEventListener<ClickEvent>(ClickEvent.Mouse_Down, Down);

		//event
		EventManager.Instance.addEventListener<ClickEvent>(ClickEvent.Mouse_Up, Up);
		EventManager.Instance.dispatchEvent(new ClickEvent(ClickEvent.Mouse_Up));
	}

	void Down(ClickEvent evt){Debug.LogFormat("name:{0}, body:{1}", evt.name, evt.body);}

	void Up(ClickEvent evt){print("Up");}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(++index != 5)EventManager.Instance.dispatchEvent(new ClickEvent(ClickEvent.Mouse_Down, index));
			else {EventManager.Instance.removeEventListener<ClickEvent>(ClickEvent.Mouse_Down, Down); ++index;}
		}
	}
}
