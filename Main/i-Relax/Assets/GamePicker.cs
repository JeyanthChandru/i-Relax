using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePicker : MonoBehaviour {

	// Logic for what happens when Play button is clicked.
	public void PickScene(){
		string[] name = new string[] {
		"CatchScene",
			"BreakGameStart"};
		System.Random rand = new System.Random ();
		int randomNumber =rand.Next (1, 3);
		string pickedScene = name [1];
		SceneManager.LoadScene (pickedScene);
	
	
	
	
	
	}
	// Logic for what happens when Skip button is clicked.
	public void SkipGame(){
	}

	//Logic for what happens when Settings button is clicked.
	public void ShowSettings(){
	
	
	
	}

}
