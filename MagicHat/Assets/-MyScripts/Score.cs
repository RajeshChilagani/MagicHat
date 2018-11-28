using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int ballValue;
    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
        Update();
	}
    void OnTriggerEnter2D()
    {
        score += ballValue;
        Update();
    }
	
	void Update()
    {
        scoreText.text = "Score\n" + score;
    }
}
