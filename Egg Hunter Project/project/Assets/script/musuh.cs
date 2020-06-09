using UnityEngine;
using System.Collections;

public class musuh : MonoBehaviour {

	gerak KomponenGerak;

	// Use this for initialization
	void Start () {
		KomponenGerak = GameObject.Find("player").GetComponent<gerak>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			GameObject.Find("kaktus").GetComponent<AudioSource>().Play();
			KomponenGerak.nyawa--;
			KomponenGerak.ulang = true;
		}
	}
}
