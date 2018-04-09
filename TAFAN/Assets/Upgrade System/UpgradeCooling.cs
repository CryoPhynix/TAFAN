using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCooling : MonoBehaviour {

    public HeatingCooling hc;
    public Scoulville_Manager scouls;
    const int MAX_UPGRADES = 3;
    int current_upgrade = 0;
    Button coolingButton;
    
    public void ActivateUpgradeCooling()
    {
        if (scouls.Scoulville > 100 * (current_upgrade + 1) && current_upgrade < MAX_UPGRADES)
        {
            scouls.UseScoulville(100 * (current_upgrade + 1));
            hc.IncreaseCooling();
            current_upgrade += 1;
        }
    }
}
