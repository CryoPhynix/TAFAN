using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeed : MonoBehaviour {

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    public Scoulville_Manager scouls;
    const int MAX_UPGRADES = 3;
    int current_upgrade = 0;
    Button speedButton;



    public void ActivateUpgradeSpeed()
    {
        if (scouls.Scoulville > 100 * (current_upgrade + 1) && current_upgrade < MAX_UPGRADES)
        {
            scouls.UseScoulville(100 * (current_upgrade + 1));
            fps.speedMultiplier += 0.5f;
            current_upgrade += 1;
        }
    }
}
