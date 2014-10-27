﻿using UnityEngine;
using System.Collections;

public class LaserTarget : MonoBehaviour {

	public string title;
	public int destinationNumber;
	public Color HighlightColor = Color.blue;
	private WireframeBehaviour wireFrame_script;
	private bool active = false;
	private Color originalColor;
	private float lerpDuration = 1.0f;

	// Use this for initialization
	void Start () {
		originalColor = renderer.material.color;
		wireFrame_script = gameObject.AddComponent<WireframeBehaviour>();
		wireFrame_script.LineColor = HighlightColor;
		wireFrame_script.ShowLines = false;
		//wireFrame_script = (WireframeBehaviour) GetComponent(typeof(WireframeBehaviour));
	}
	
	// Update is called once per frame
	void Update () {
		if(active) {
			float lerp = Mathf.PingPong (Time.time, lerpDuration) / lerpDuration;
			renderer.material.color = Color.Lerp (originalColor, HighlightColor, lerp);
		}
	}

	public void highlight(bool active){
		this.active = active;
		wireFrame_script.ShowLines = active;
		if(!active) {
			renderer.material.color = originalColor;
		}
	}

	public void pickUp(GameObject pickerUpper){
		transform.parent = pickerUpper.transform;
	}


	public string getTitle()
	{
		return title;
	}


}