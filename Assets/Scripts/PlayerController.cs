﻿		using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject Player;
	public GameObject Shot;
	void Start()
	{
		//Shot.SetActive (false);
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			Player.GetComponent<Animator>().SetTrigger ("Shot");
			//Shot.SetActive (true);
		}
		if(Input.GetMouseButtonUp(0)){
			Player.GetComponent<Animator>().SetTrigger ("Idle");
		}
	}

	public void Hit()
    {
		print("player attack");
    }				
}
	