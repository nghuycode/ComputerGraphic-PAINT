using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PieMenu : MonoBehaviour
{

	public bool IsShowing, IsParent;
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
	
	private void Update() {
		if (Input.GetMouseButtonDown(1) && IsParent) 
			ShowMenu();
		if (Input.GetKeyDown(KeyCode.Space))
			manager.Hide(this);		

	}
	public void ShowMenu() 
	{
		this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		manager.Show(this);
	}

}
