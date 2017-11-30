using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;

public class Changecolor : MonoBehaviour, IGazeListener {
    private Camera cam;

    public int fixedtime = 30;
    public int timeLeft = 30;
    public Text countdownText;
    public Text ResultText;

    public Text TitleText;
    public Text HelpText;

    public Color startColor;
    public Color mouseOverColor;
    public Renderer rend;
    //public GameObject StatusText;
    public GameObject StartButton;
    //public GameObject ResultTextGO;
    private GazeDataValidator gazeUtils;
    private Component gazeIndicator;
    private Collider currentHit;



    bool mouseOver = false;
    bool playing = false;
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        rend = GetComponent<Renderer>();
        StartButton.SetActive(true);
        gazeUtils = new GazeDataValidator(30);
        gazeIndicator = cam.transform.GetChild(0);

        GazeManager.Instance.AddGazeListener(this);
    }

    void OnApplicationQuit()
    {
        GazeManager.Instance.CalibrationAbort();
        GazeManager.Instance.RemoveGazeListener(this);
        GazeManager.Instance.Deactivate();
    }

    private void checkGazeCollision(Vector3 screenPoint)
    {
        Ray collisionRay = cam.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if (Physics.Raycast(collisionRay, out hit))
        {
            if (hit.collider.name == "Cube")
                mouseEnter();    
        }
        else
        {
            mouseExit();
        }
    }

    public void OnGazeUpdate(GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        gazeUtils.Update(gazeData);
    }

    void Update()
    {
        Point2D gazeCoords = gazeUtils.GetLastValidSmoothedGazeCoordinates();
        if (mouseOver == false)
        {
            if (timeLeft <= 0)
            {
                StopCoroutine("LoseTime");
                countdownText.text = "Times Up!";
                //TitleText.enabled = true;
                //HelpText.enabled = true; 
                ResultText.enabled = true;
                ResultText.text = "You Won !";
                playing = false;
                //MyFunction(3.0f);
                StartCoroutine("FinishIt");
            }
        }
        if (null != gazeCoords)
        {
            //map gaze indicator
            Point2D gp = UnityGazeUtils.getGazeCoordsToUnityWindowCoords(gazeCoords);

            Vector3 screenPoint = new Vector3((float)gp.X, (float)gp.Y, cam.nearClipPlane + .1f);

            Vector3 planeCoord = cam.ScreenToWorldPoint(screenPoint);
            gazeIndicator.transform.position = planeCoord;

            //handle collision detection
            checkGazeCollision(screenPoint);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public IEnumerator FinishIt()
    {
        yield return new WaitForSeconds(3.0f);
        GazeManager.Instance.CalibrationAbort();
        GazeManager.Instance.RemoveGazeListener(this);
        GazeManager.Instance.Deactivate();
        SceneManager.LoadScene("FeedbackScene");
    }
    public void startGame()
    {
        StartButton.SetActive(false);
        TitleText.enabled = false;
        HelpText.enabled = false;
        ResultText.enabled = false;
        playing = true;
    }
    void mouseEnter()
    {
        if (playing)
        {
            mouseOver = true;
            rend.material.SetColor("_Color", mouseOverColor);
            StopCoroutine("LoseTime");
            //countdownText.text = ("TIME LEFT: " + timeLeft);
            HelpText.text = "Try looking looking at distant object rather than screen. Look outside to begin";
            TitleText.enabled = true;
            HelpText.enabled = true;
            ResultText.enabled = true;
            ResultText.text = "You Lost !  Try Again !";
        }
    }

    void mouseExit()
    {
        if (playing)
        {
            TitleText.enabled = false;
            HelpText.enabled = false;
            ResultText.enabled = false;
            countdownText.text = "You are doing Great, Keep it up....";
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
            yield return new WaitForSeconds(3);
            timeLeft = timeLeft - 1;
            print(timeLeft);
        }
    }
}
