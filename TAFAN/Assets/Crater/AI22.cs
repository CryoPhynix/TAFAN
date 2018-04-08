using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class AI22 : MonoBehaviour
{

    Rigidbody thisRigidbody;
    public Transform player;
    static Animator anim;
    public NavMeshAgent nav;
    // Use this for initialization
    public BoxCollider HitBox;
    public int gun_damage = 100; //gun damage
    public int explosion_damage = 50; //explosion damage
    //public float Robot_health = 100;//  health
    public int sniperrifle_damage = 25;
    public float walkRadius;
    private Transform PlayerT;
    private GameObject Player;
    private float Timer = 1.5f;
    public bool DoWaypoints;
    public int Range;
    public float MaxTimer = 1.5f;
    public GameObject Enemy;
    public AudioClip HitNoise;
    Animator animator;

    
    
    
    
    public SphereCollider col;
    public Vector3 distance;
    private Vector3 previousPosition;
    public bool agro = false;
    public float curSpeed;
    public bool canTakeDamage;
    public bool ow = false;
    public float myHealth = 100;
    public int Damagetimer = 2;
    public int Attacktimer = 2;
    public float timer=0;
    public bool CanAttack;
    public bool RunTimer=false;
    public GameObject RandomPath;
    public double DeathTime = 3.3;

    public void RandomRun()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", true);
        nav.SetDestination(RandomPath.transform.position);
        nav.speed = 10;
    }



    private void Update()
    {
       // Debug.Log(timer);
      //  Debug.Log(myHealth);
        DistanceChecker();

        if (Damagetimer == 1)
        {
            Undamage();
        }
       
        if (Attacktimer == 1)
        {
            CanAttack = false;
            Attacktimer = 2;
        }

        // Debug.Log(nav.destination);
        if (agro)
        {

            nav.SetDestination(player.position);
            nav.speed = 10;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }
        else
        {
            Wonder();
        }
        //Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));

       
        if (myHealth == 0)
        {
            Death();

        }


       
    }

  
        
        
         public void TakeDamage() //Damage Function
    {
        anim.SetBool("isDamage", true);
   
        myHealth -= 10;
        while (Damagetimer == 2)
        {
            Damagetimer = Damagetimer - 1;
        }

    }
      

    public void Undamage() //reverts damage animation to false
    {
        
      
        anim.SetBool("isDamage", false);
        Damagetimer = 2;
    }


      
    void Deathclock()
    {
        timer = timer + Time.deltaTime;
    }

    void Start() //mainly pulls components
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        thisRigidbody = GetComponent<Rigidbody>();
        myHealth = 100;
        PlayerT = player.transform;
        col = GetComponent<SphereCollider>();
        
        Enemy = this.gameObject;
        HitBox = GetComponent<BoxCollider>();
        RandomRun();
        
    }

    

    void Wonder() //sets skeleton to the idle state
    {
        anim.SetBool("Run", false);
        anim.SetBool("Idle", true);
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 5);
            Vector3 finalPosition = hit.position;
            nav.destination = finalPosition;
        anim.SetBool("Walk", true);
            transform.LookAt(nav.destination); //to do (fix this to face where walking }  
            if (Enemy.transform.position==finalPosition && agro ==false)
         {
            anim.SetBool("Idle", true);

                                                                                            }

       
    } 
    void DistanceChecker() //checks the distance between the player and the enemy
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 2)  //this checks the distance between the player and the Enemy 
        {
            Attack(); //runs the attack function
        }
        if (Vector3.Distance(player.transform.position, this.transform.position) < 10)
        {
            agro = true;
        }
        else
        {
            agro = false;
            RandomRun();
            anim.SetBool("Attack_player", false);
        }
     
    }

    void Attack() //this is the AI attack method, after run 
    {
        if (agro) {
            
            anim.SetBool("Attack_player", true); //runs the attack animation
           
            
            transform.LookAt(player.position);
            Debug.Log("I AM ATTACKING");
            CanAttack = true;


        }
        else
        {
            anim.SetBool("Attack_player", false);
        }

    }
    void Death()
    {
        
        anim.SetBool("isDead", true);
        RunTimer = true;
        
        
           
        
    }

    private void FixedUpdate()
    {
        if (agro == false)
        {
            anim.SetBool("Attack_Player", false);
        }

        if (timer >= DeathTime)
        {
           // Debug.Log("DEATH SHOULD HAVE RENDERED!");
            Destroy(this.gameObject);
            RunTimer = false;
            timer = 0;

        }

        if (RunTimer)
        {
            Deathclock();
        }
    }
}





