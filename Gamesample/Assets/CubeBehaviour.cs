using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {
    public static int score=0;
    TextMesh text123;

    void OnMouseDown()
    {
        Destroy(gameObject);
        score += 50;
    }
    void Update()
    {
        text123.text = ""+score.ToString();
    }
    void Start()
    {
        text123 = GameObject.Find("Score").GetComponent<TextMesh>();
        text123.text=""+score.ToString();
    
    }
}
