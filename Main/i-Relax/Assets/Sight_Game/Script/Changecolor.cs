using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changecolor : MonoBehaviour {

    public int fixedtime = 30;
    public int timeLeft = 30;
    public Text countdownText;
    public Text ResultText;

    public Color startColor;
    public Color mouseOverColor;
    public Renderer rend;
    //public GameObject StatusText;
    public GameObject StartButton;
    //public GameObject ResultTextGO;
    bool mouseOver = false;
    bool playing = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartButton.SetActive(true);
    }
    void Update()
    {
        if (mouseOver == false)
        {
            countdownText.text = ("TIME LEFT: " + timeLeft);
            if (timeLeft <= 0)
            {
                StopCoroutine("LoseTime");
                countdownText.text = "Times Up!";
                ResultText.enabled = true;
                ResultText.text = "You Won !";
                playing = false;
            }
        }
    }
    public void startGame()
    {
        StartButton.SetActive(false);
        ResultText.enabled = false;
        playing = true;
    }
    void OnMouseEnter()
    {
        if (playing)
        {
            mouseOver = true;
            rend.material.SetColor("_Color", mouseOverColor);
            StopCoroutine("LoseTime");
            //countdownText.text = ("TIME LEFT: " + timeLeft);
            ResultText.enabled = true;
            ResultText.text = "You Lost !  Try Again !";
        }
    }
    void OnMouseOver()
    {
        //print("over");
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    void OnMouseExit()
    {
        ResultText.enabled = false;
        if (playing)
        {
            timeLeft = fixedtime;
            mouseOver = false;
            rend.material.SetColor("_Color", startColor);
            StartCoroutine("LoseTime");
        }
    }


    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
