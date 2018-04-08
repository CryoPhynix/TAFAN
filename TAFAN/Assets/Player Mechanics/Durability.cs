using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour {

    int durability;

    void Start()
    {
        durability = 5;
    }

    void takeDamage(int dmg)
    {
        durability -= dmg;
        if (durability <= 0)
        {
            //call game over
        }
    }
}
