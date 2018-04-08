using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChillyPower : MonoBehaviour {

    float chillyMeterValue;
    const int MAX_CHILLY_VALUE = 200;

	// Use this for initialization
	void Start () {
        chillyMeterValue = 0.0f;

    }

    //always adds
    public void addChillyPower(float chillyValue)
    {
        chillyMeterValue += chillyValue;
        Mathf.Clamp(chillyMeterValue, 0.0f, MAX_CHILLY_VALUE);
    }
    
    //always subtracts
    public void UseChillyPower(float chillyValue)
    {
        chillyMeterValue -= chillyValue;
        Mathf.Clamp(chillyMeterValue, 0.0f, MAX_CHILLY_VALUE);
    }
}
