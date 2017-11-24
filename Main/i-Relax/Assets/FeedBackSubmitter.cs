using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;


public class FeedBackSubmitter : MonoBehaviour {
	public Dropdown rate_exp;
	public Dropdown  help_relax;
	public Dropdown prefer_future;
	public void SubmitFeedback(){
		string rating = rate_exp.captionText.text;
		string help = help_relax.captionText.text;
		string preference = prefer_future.captionText.text;

        string json = File.ReadAllText(@"C:\Users\Nirmal Kumar\Desktop\app_config.json");
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        string curr_game = Convert.ToString(jsonObj["current_game"]);
        jsonObj["current_game"]="";
        if (rating.Equals("Good"))
        {
            jsonObj[curr_game]["good_experience"] = Convert.ToInt32(jsonObj[curr_game]["good_experience"]) + 1;
        }
        else if (rating.Equals("Average"))
        {
            jsonObj[curr_game]["average_experience"] = Convert.ToInt32(jsonObj[curr_game]["average_experience"]) + 1;
        }
        else if (rating.Equals("Bad"))
        {
            jsonObj[curr_game]["bad_experience"] = Convert.ToInt32(jsonObj[curr_game]["bad_experience"]) + 1;
        }
        if (help.Equals("Yes"))
        {
            jsonObj["general"]["yes_help"] = Convert.ToInt32(jsonObj["general"]["yes_help"]) + 1;
        }
        else if (help.Equals("No"))
        {
            jsonObj["general"]["no_help"] = Convert.ToInt32(jsonObj["general"]["no_help"]) + 1;
        }
        else 
        {
            jsonObj["general"]["notsure_help"] = Convert.ToInt32(jsonObj["general"]["notsure_help"]) + 1;

        }
        if (preference.Equals("Neutral"))
        {
            jsonObj[curr_game]["neutral_preference"] = Convert.ToInt32(jsonObj[curr_game]["neutral_preference"]) + 1;
        }
        else if (preference.Equals("Most Likely"))
        {
            jsonObj[curr_game]["likely_preference"] = Convert.ToInt32(jsonObj[curr_game]["likely_preference"]) + 1;
        }
        else
        {
            jsonObj[curr_game]["no_preference"] = Convert.ToInt32(jsonObj[curr_game]["no_preference"]) + 1;
        }
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(@"C:\Users\Nirmal Kumar\Desktop\app_config.json", output);
        Application.Quit();



    }
}
