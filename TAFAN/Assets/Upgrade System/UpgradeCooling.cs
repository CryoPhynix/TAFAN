using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCooling : MonoBehaviour {

    const int MAX_UPGRADES = 3;
    int current_upgrade = 0;
    Button coolingButton;
    
    public void ActivateUpgradeCooling()
    {
        //todo logic here
        Debug.Log("upgrade cooling");
    }
}
