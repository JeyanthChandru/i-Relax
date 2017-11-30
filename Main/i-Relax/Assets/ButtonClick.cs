using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour{
	public Button btn123;


    Button btn;
	public GameObject gobj;
	// Use this for initialization
	void Start () { 
        btn123.onClick.AddListener(TaskOnClick);
	}
	void TaskOnClick(){
		btn123.gameObject.SetActive (false);
		gobj.SetActive (true);
    
}


    // Update is called once per frame
    void Update () {
        
    }

    
}
