using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;

public class ExplodeScript : MonoBehaviour, IGazeListener {
	public GameObject explode;
	// Use this for initialization
	public Text text123;
    private Camera cam;
    private GazeDataValidator gazeUtils;
    private Component gazeIndicator;
    private Collider currentHit;

    public static int score = 0;

	void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        gazeUtils = new GazeDataValidator(30);
        gazeIndicator = cam.transform.GetChild(0);

        GazeManager.Instance.AddGazeListener(this);
    }

    void OnDestroy()
    {
        score = score + 100;
    }

    void OnApplicationQuit()
    {
        GazeManager.Instance.CalibrationAbort();
        GazeManager.Instance.RemoveGazeListener(this);
        GazeManager.Instance.Deactivate();
    }

    public void OnGazeUpdate(GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        gazeUtils.Update(gazeData);
    }

    // Update is called once per frame
    void Update () {
        Point2D gazeCoords = gazeUtils.GetLastValidSmoothedGazeCoordinates();
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
        text123.text = "Score:" + score;
        if (score == 900)
        {
            GazeManager.Instance.CalibrationAbort();
            GazeManager.Instance.RemoveGazeListener(this);
            GazeManager.Instance.Deactivate();
            SceneManager.LoadScene("FeedbackScene");
        }
    }

    private void checkGazeCollision(Vector3 screenPoint)
    {
        Ray collisionRay = cam.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if (Physics.Raycast(collisionRay, out hit))
        {
            if (hit.collider.name != "Quad")
            {
                if (null != hit.collider && currentHit != hit.collider)
                {
                    currentHit = hit.collider;
                   
                    Instantiate(explode, transform.position, Quaternion.identity);
                    Destroy(GameObject.Find(currentHit.name));
                    //currentHit.GetComponent<Renderer>().material.color = Color.red;
                    //mouseDown();
                }
            }
        }
    }
}
