using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class koin : MonoBehaviour {

	
	gerak KomponenGerak;



	// Use this for initialization
	void Start () {
		KomponenGerak 	= GameObject.Find("player").GetComponent<gerak>();
		
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			KomponenGerak.koin++;
			GameObject.Find("egg").GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
	}
	public void button(){

	} 
}