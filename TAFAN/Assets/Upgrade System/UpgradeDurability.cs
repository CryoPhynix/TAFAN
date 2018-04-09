using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDurability : MonoBehaviour {

    public Durability durab;
    public Scoulville_Manager scouls;
    const int MAX_UPGRADES = 3;
    int current_upgrade = 0;
    Button durabiltyButton;

    public void ActivateUpgradeDurability()
    {
        if (scouls.Scoulville > 100 * (current_upgrade + 1) && current_upgrade < MAX_UPGRADES)
        {
            scouls.UseScoulville(100 * (current_upgrade + 1));
            durab.durability += 1;
            current_upgrade += 1;
        }
    }
}
