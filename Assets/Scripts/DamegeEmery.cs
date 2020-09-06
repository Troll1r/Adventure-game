using UnityEngine;
using System.Collections;

public class DamegeEmery : MonoBehaviour {
	public GameObject Emery;
	public GameObject Ragdoll;
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="PolicShot"){
			Emery.SetActive (false);
			Ragdoll.SetActive (true);
		Instantiate(Ragdoll, transform.position, transform.rotation);
		}
	}
	

}
