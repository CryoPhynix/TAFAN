using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firelaser : MonoBehaviour
{
    public Transform camera;
    // Use this for initialization
    public Transform camera1;// fpc camera
    public Transform metalHit;// texture of holes from bullets
    public Transform MetalSparks;// sparks from bullet
    public Transform MuzzleFlash;// fire shoot
    public Light Light;// light when shoot
    private RaycastHit Hit;// raycast ray
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    private float timeout = 0.2f;// timer
    public float Accuracy = 0.01f;
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack"))// if shoot
        {

            timeout = 0;



            Vector3 Direction = camera1.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet
            curAmmo -= 1;//ammo consumption
            _rateofSpeed = 0;


            if (Physics.Raycast(camera1.position, Direction, out Hit, 10000f))// create raycast ray
            {




                if (Hit.collider.gameObject.name == "Enemy")
                {






                }


            }
        }                // Update is called once per frame



    }

}
