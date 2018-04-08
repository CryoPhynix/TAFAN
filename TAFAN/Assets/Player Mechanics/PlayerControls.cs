using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    ShootScript ss;

    private void Awake()
    {
        ss = GetComponent<ShootScript>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ss.Shoot();
        }
	}
}
