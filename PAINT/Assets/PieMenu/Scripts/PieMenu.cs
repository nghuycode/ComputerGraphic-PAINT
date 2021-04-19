using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieMenu : MonoBehaviour
{

	public bool IsShowing;
	public List<string> commands;
	public List<Texture> icons;
	
	public float iconSize = 64f;
	public float spacing = 12f;
	public float speed = 8f;
	public GUISkin skin;
	
	[HideInInspector]
	public float scale;
	[HideInInspector]
	public float angle;
	
	PieMenuManager manager;
	
	void Awake () {
		manager = PieMenuManager.Instance;
	}
	
	void OnMouseUp() {
		manager.Show(this);
	}
	private void Update() {
		if (Input.GetMouseButtonDown(0)) 
		{
			manager.Hide(this);
		}
		if (Input.GetMouseButtonDown(1)) 
		{
			this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			manager.Show(this);
			IsShowing = true;
		}
	}
	
}
