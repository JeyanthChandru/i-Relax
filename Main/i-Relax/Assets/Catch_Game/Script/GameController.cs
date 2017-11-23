using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] balls;
    public float timeLeft;
    private float maxWidth;
    private bool counting;
    public Text timerText;
    public Dropdown dropdown;
    public GameObject gameOverText;
    public GameObject restartButton;
    //public GameObject splashScreen;
    public GameObject startButton;
    public Bin_controller bincontroller;

    void Start()
    {
        
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt(timeLeft);
        //dropdown.Show();
    }

    public void StartGame()
    {
        print(dropdown.value);
        if (dropdown.value == 1)
        {
            timeLeft = 60;
        }
        else
        {
            timeLeft = 30;
        }
        print(timeLeft);
        timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt(timeLeft);
        print("Game Started");
        //dropdown.Hide();
        //dropdown.SetActive(false);
        //splashScreen.SetActive(false);
        startButton.SetActive(false);
        bincontroller.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    void FixedUpdate()
    {
        if (counting)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt(timeLeft);
        }
        if (Input.GetKeyDown("escape"))
        {
            print("ESC pressed");
            Application.Quit();
        }

    }
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        counting = true;
        while (timeLeft > 0)
        {
            GameObject ball = balls[Random.Range(0, balls.Length)];
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        restartButton.SetActive(true);
    }
}
