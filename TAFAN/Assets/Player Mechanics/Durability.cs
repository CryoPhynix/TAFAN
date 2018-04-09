using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Durability : MonoBehaviour {

    public Image DurabilityLevel;
    public GameOver gameover;
    public int durability;

    void Start()
    {
        durability = 5;
    }

    void takeDamage(int dmg)
    {
        durability -= dmg;
        if (durability <= 0)
        {
            gameover.CallGameOver();
        }
    }
}
