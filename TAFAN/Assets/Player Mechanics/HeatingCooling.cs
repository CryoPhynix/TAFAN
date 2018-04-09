using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeatingCooling : MonoBehaviour {

    public Image HeatLevel;
    public GameOver gameover;
    float gameOverTimer;
    float heatValue;
    int coolingValue;
    const int MAX_HEATVALUE = 100;
    bool isMoving;

	// Use this for initialization
	void Start () {
        gameOverTimer = 3.0f;
        heatValue = 0.0f;
        coolingValue = 1;
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMoving)
        {
            heatValue += Time.deltaTime * (50 / coolingValue);
            Mathf.Clamp(heatValue, 0.0f, MAX_HEATVALUE);
            if (heatValue >= 100.0f)
            {
                gameOverTimer -= Time.deltaTime;
                if (gameOverTimer <= 0.0f)
                {
                    gameover.CallGameOver();
                }
            }
        }
        else
        {
            if (gameOverTimer <= 3.0f)
            {
                gameOverTimer = 3.0f;
            }

            heatValue -= Time.deltaTime * (5 * coolingValue);
            Mathf.Clamp(heatValue, 0.0f, MAX_HEATVALUE);
        }
	}

    public void IncreaseCooling()
    {
        coolingValue++;
    }


}
