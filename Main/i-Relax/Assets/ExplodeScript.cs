using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExplodeScript : MonoBehaviour {
	public GameObject explode;
	// Use this for initialization
	public Text text123;

	public static int score = 0;

	void Start () {
		
	}
	void OnMouseDown(){
	
		Instantiate (explode,transform.position,Quaternion.identity);
		score = score + 100;
		text123.text = "Score:" + score;
		if (score == 900) {
			
			SceneManager.LoadScene ("FeedbackScene");
		}
	


		Destroy (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
