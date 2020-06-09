using UnityEngine;
using System.Collections;

public class rotasi : MonoBehaviour {

	public int kecepatanX,kecepatanY,kecepatanZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (kecepatanX,kecepatanY,kecepatanZ);
	}
}
