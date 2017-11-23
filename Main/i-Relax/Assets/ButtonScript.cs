using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	public void playBreaker(string some){


		SceneManager.LoadScene ("BrickBreaker");
	
	}
}
