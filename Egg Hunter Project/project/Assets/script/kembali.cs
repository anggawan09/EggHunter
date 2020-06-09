using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class kembali : MonoBehaviour {

	public GameObject m_pause, tmbl_play_pause, tmbl_level_pause, tmbl_ulang_pause;
	
	
		// Update is called once per frame
	void Update () {
			
	}
	
	public void resume (){
		m_pause.SetActive(false);
		tmbl_ulang_pause.SetActive(false);
		tmbl_play_pause.SetActive(false);
		tmbl_level_pause.SetActive(false);
		Time.timeScale = 1f;
		GameObject.Find("pause").GetComponent<AudioSource>().Play();		
			
	}public	void pause(){
		m_pause.SetActive(true);
		tmbl_ulang_pause.SetActive(true);
		tmbl_play_pause.SetActive(true);
		tmbl_level_pause.SetActive(true);
		Time.timeScale= -1f;
		GameObject.Find("pause").GetComponent<AudioSource>().Play();
	}
	public void quit(){
		Application.Quit();
	}
}
