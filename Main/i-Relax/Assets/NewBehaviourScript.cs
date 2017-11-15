
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour {
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    bool sta = true,ca=false;
	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        Screen.fullScreen = !Screen.fullScreen;
        ShowWindow(GetActiveWindow(), 2);
        startAfterTime();
        
	}
    void startAfterTime()
    {

        Thread.Sleep(10000);
      //sta = false;
        SceneManager.LoadScene("OptionsScene");
      ca = true;


    }
	
	// Update is called once per frame
    void Update()
    {
        Application.runInBackground = true;
        if (ca)
        {
            sta = false;
            //Application.runInBackground = false;
            
            //ShowWindow(GetActiveWindow(), 2);
            

        }
    }
}
