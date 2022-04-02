using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	private static	EventManager _instance = null;

	public delegate void DelegateHandler<T>(T e) where T : Event; 

	private Dictionary<string, Delegate> delegates = new Dictionary<string, Delegate>();  

	#region addEventListener
	public void addEventListener<T>(string eventName, DelegateHandler<T> callBack) where T : Event{
		if(delegates.ContainsKey(eventName)){
			Delegate _callBack = delegates[eventName];
			delegates[eventName] = Delegate.Combine(_callBack, callBack);
		}else{
			delegates[eventName] = callBack;
		}
	}
	#endregion

	#region dispatchEvent
	public void dispatchEvent<T>(T evt) where T : Event{
		if(delegates[evt.name] == null){
			return;
		}
		
		delegates[evt.name].DynamicInvoke(evt);
	}
	#endregion

	#region remove listener
	public void removeEventListener<T>(string eventName, DelegateHandler<T> callBack) where T : Event{
		if(delegates.ContainsKey(eventName)){
			Delegate _callBack = delegates[eventName];
			delegates[eventName] = Delegate.Remove( _callBack, callBack);
		}
	}
	#endregion

	#region Initialize
	public static EventManager Instance{
		get{
			if(_instance == null){
				_instance = GameObject.FindObjectOfType(typeof(EventManager)) as EventManager;
				if(_instance == null){
					GameObject obj = new GameObject("EventManager");
					obj.hideFlags = HideFlags.HideAndDontSave;
					_instance = obj.AddComponent<EventManager>();
				}
			}
			return _instance;
		}
	}

	void Awake(){
		if(_instance == null){
			_instance = this;
		}else{
			if(_instance != this){
				Destroy(gameObject);
			}
		}
	}
	#endregion
}
