using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class gerak : MonoBehaviour {

	Text infonyawa,infokoin;
	

	// Use this for initialization

	public int kecepatan,kekuatanLompat;

	public bool balik;
	public int pindah;

	Rigidbody2D lompat;
	

	public bool tanah;
	public LayerMask targetlayer;
	public Transform deteksitanah;
	public float jangkuan;

	Animator anim;

	public int nyawa;
	public int koin;

	Vector2 mulai;

	public bool ulang;

	public bool tombolKiri,tombolKanan;

	public GameObject menang, kalah, tmbl_ulang, tmbl_menu, tmbl_level, tmbl_level_kalah;

	void Start () {

		infonyawa 		= GameObject.Find("UInyawa").GetComponent<Text>();
		infokoin 		= GameObject.Find("UIkoin").GetComponent<Text>();
		lompat 			= GetComponent<Rigidbody2D> ();
		anim 			= GetComponent<Animator>();
		mulai 			= transform.position;
		GameObject.Find("main").GetComponent<AudioSource>().Play();
		

	}
	
	// Update is called once per frame
	void Update () {
		infonyawa.text = nyawa.ToString ();
		infokoin.text =  koin.ToString ();

		if (ulang == true) {
			transform.position = mulai;
			ulang =false;
		}
		
		
		if (nyawa <= 0) {
			Destroy(gameObject);
			GameObject.Find("main").GetComponent<AudioSource>().Stop();
			GameObject.Find("gameover").GetComponent<AudioSource>().Play();
			kalah.SetActive (true);
			tmbl_level_kalah.SetActive(true);
			tmbl_menu.SetActive(true);
			tmbl_ulang.SetActive(true);
		}
		else{

			if (koin==20) 
				{	
					GameObject.Find("main").GetComponent<AudioSource>().Stop();
					GameObject.Find("menang").GetComponent<AudioSource>().Play();
					menang.SetActive (true);
					tmbl_level.SetActive(true);
					tmbl_menu.SetActive(true);
					tmbl_ulang.SetActive(true);
					Destroy(gameObject);
				}
		
		}


		if (tanah == true) {
			anim.SetBool ("lompat", false);
		} else {
			anim.SetBool("lompat",true);
		}	

		tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkuan, targetlayer);

		if (Input.GetKey (KeyCode.D)||(tombolKanan==true)) {
			anim.SetBool ("lari", true);
			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			pindah = 1;
		} else if (Input.GetKey (KeyCode.A) || (tombolKiri==true)) {
			anim.SetBool ("lari", true);
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			pindah = -1;
		} else {
			anim.SetBool("lari",false);
		}

//		if (tanah == true && (Input.GetKey (KeyCode.Mouse0))) {
//			lompat.AddForce(new Vector2(0,kekuatanLompat));
//		}

		if (pindah > 0 && !balik) {
			balikbadan();
		}else if(pindah<0 && balik){
			balikbadan();
		}

	}
	void balikbadan(){
		balik = !balik;
		Vector3 karakter = transform.localScale;
		karakter.x *= -1;
		transform.localScale = karakter;
	}

	public void tekankiri(){
		tombolKiri = true;
	}
	public void lepaskiri(){
		tombolKiri = false;
	}

	public void tekankanan(){
		tombolKanan = true;
	}
	public void lepaskanan(){
		tombolKanan = false;
	}
	public void loncat(){
		if (tanah == true) {
			lompat.AddForce (new Vector2 (0, kekuatanLompat));
			GameObject.Find("lompat").GetComponent<AudioSource>().Play();
		}
	}
}
