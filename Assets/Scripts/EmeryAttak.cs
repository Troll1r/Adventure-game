using UnityEngine;
using System.Collections;

public class EmeryAttak : MonoBehaviour {
	public GameObject Emery;
	public GameObject DeadZone;
	
	void Start(){
		DeadZone.SetActive (false);
	}
	
	void OnTriggerEnter (Collider other){
		if(other.tag=="Player"){
			Emery.GetComponent<Animator>().SetTrigger ("Attak");
			DeadZone.SetActive (true);
			
		}
	}
	void OnTriggerExit (Collider other){
		if(other.tag=="Player"){
			DeadZone.SetActive (false);
		}
	}
}
