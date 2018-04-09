using UnityEngine;
using System.Collections;
using UnityEngine.AI;
//This script executes commands to change character animations
[RequireComponent(typeof(Animator))]
public class ACS_Actions : MonoBehaviour {
    public NavMeshAgent nav;
    public bool ThrusterTargeted;
    public bool PlayerTargeted;
    public GameObject Player;
    public GameObject Thruster;
    public float dist;

    private void Start()
    {
        ThrusterTargeted = true;
        nav = GetComponent<NavMeshAgent>();
    }


    public GameObject[] weapArray;

    private Animator animator, animatorWeap;
    public void Update()
    {

        Thruster = GameObject.FindGameObjectWithTag("Thruster");
        Player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector3.Distance(Player.transform.position, this.transform.position);

     
        if (ThrusterTargeted)
        {
            nav.SetDestination(Thruster.transform.position);
            WalkForward();
            if (nav.updateRotation == true)
            {
                TernRight();
            }

            if (dist < 10)
            {
                nav.SetDestination(Player.transform.position);
                WalkForward();
               
            }

            if (dist < 5)
            {
                Fire();
            }
            
          
        }
        
    }
    void Awake () {
		animator = GetComponent<Animator> ();
        nav = GetComponent<NavMeshAgent>();

        


    }
 
	public void Fire()
	{
		foreach (GameObject weap in weapArray) {
			animatorWeap = weap.GetComponent <Animator> ();
			animatorWeap.SetBool ("Fire", true);
		 
		}
	}
	public void stopFire()
	{
		foreach (GameObject weap in weapArray) {
			animatorWeap = weap.GetComponent <Animator> ();
			animatorWeap.SetBool ("stopFire", true);
		 
		}
	}
 
   
         

       
    
    
	public void Dead1()
	{
		animator.SetBool ("ACS_Dead1", true);
	}
	public void Dead2()
	{
		animator.SetBool ("ACS_Dead2", true);
	}
	public void Dead3()
	{
		animator.SetBool ("ACS_Dead3", true);
	}
	public void Dead4()
	{
		animator.SetBool ("ACS_Dead4", true);
	}
	public void StrafeLeft()
	{
		animator.SetBool ("ACS_StrafeLeft", true);
	}
	public void StrafeRight()
	{
		animator.SetBool ("ACS_StrafeRight", true);
	}
	public void Idle()
	{
		animator.SetBool ("ACS_Idle", true);
	}
	public void Attack()
	{
		animator.SetBool ("ACS_Attack", true);
 	}
	public void TernLeft()
	{
		animator.SetBool ("ACS_TernLeft", true);
	}
	public void TernRight()
	{
		animator.SetBool ("ACS_TernRight", true);
	}
	public void ChangeToWalk()
	{
		animator.SetBool ("ACS_ChangeToWalk", true);
	}
	public void ChangeToWeels()
	{
		animator.SetBool ("ACS_ChangeToWeels", true);
	}
	public void MoveWeelsForwad()
	{
		animator.SetBool ("ACS_MoveWeelsForwad", true);
	}
	public void MoveWeelsBack()
	{
		animator.SetBool ("ACS_MoveWeelsBack", true);
	}
	public void WalkForward()
	{
		animator.SetBool ("ACS_WalkForwad", true);
	}
	public void WalkBack()
	{
		animator.SetBool ("ACS_WalkBack", true);
	}


}
