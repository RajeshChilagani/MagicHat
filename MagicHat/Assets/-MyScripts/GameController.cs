﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Camera cam;
    private float maxWidth;
    public GameObject ball;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOver;
    public GameObject restart;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
            Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
            Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
            float ballWidth =ball.GetComponent<Renderer>().bounds.extents.x;
            maxWidth = targetWidth.x - ballWidth;
            StartCoroutine(Spawn());
        }
    }
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<0)
        {
            timerText.text = "End";
           
        }
        else
        timerText.text = "Time Left\n" + Mathf.RoundToInt(timeLeft);
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeLeft>=0)
        {
            Vector3 spwanPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spwanPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }
        yield return new WaitForSeconds(1.0f);
        gameOver.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        restart.SetActive(true);
    }
}
