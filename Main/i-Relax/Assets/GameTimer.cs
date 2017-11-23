using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameTimer : MonoBehaviour {
	public Text Timer;
float timeLeft = 20.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		Timer.text = "Time Left:"+(int)timeLeft;
		if(timeLeft < 0)
		{
			
			SceneManager.LoadScene ("FeedbackScene");
		}
		
	}
}
