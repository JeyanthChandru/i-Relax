using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

public class GamePicker : MonoBehaviour {

	// Logic for what happens when Callibrate button is clicked.
	public static void PickScene(){
		string[] name = new string[] {
		"CatchScene",
			"BreakGameStart","SightScene"};
		System.Random rand = new System.Random ();
		int randomNumber =rand.Next (1, 4);
		string pickedScene = name [randomNumber-1];
        string path = "AppConfig\\app_config.json";
        //StreamReader streamReader = new StreamReader(path);
        string json = File.ReadAllText(path);
        //string json = streamReader.ReadToEnd();
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
       
        if (randomNumber == 1) {
            jsonObj["current_game"] = "catch_game";
           
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(path, output);
        }
        else if (randomNumber == 2)
        {
            jsonObj["current_game"] = "break_game";
            
            string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);

        }
        else
        {
            jsonObj["current_game"] = "sight_game";

            string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
        }
		SceneManager.LoadScene (pickedScene);
        
	
	
	
	
	
	}
	//// Logic for what happens when Play button is clicked.
	public void Callibrate(){
		SceneManager.LoadScene ("CallibrationScene");
	}

	//Logic for what happens when you click Submit Feedback button.
	public void SubmitFeedBack(string rated_exp){
	
	
	
	}
	// Logic for what happens when Skip button is clicked.
	public void SkipGame(){
        Application.Quit();
	}

	//Logic for what happens when Settings button is clicked.
	public void ShowSettings(){
	
	
	
	}

}
