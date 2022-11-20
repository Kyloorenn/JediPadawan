using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Specialized;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class Enemy : MonoBehaviour
{   

    [SerializeField] float speed = 1f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Projectile;
    [SerializeField] SpriteRenderer EnemyspriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] GameObject chest;
    
    // Make a material field
    Material material;
    GameRecord gameRecord;
    public GameObject[] Drops;
    public AudioSource enemydeath;
    public AudioSource enemyMelee;
    public GameObject floatpoint;
    public GameObject meleeLight;
    public GameObject crystal;
    public GameObject goldcoin;
    GameObject player;
    public int EnemyHealth;
    private int EnemyHealthMax;
    bool EnemyInvincible = false;
    private float deathcountdown = 1.5f;
    private float Bossdeathcountdown = 5f;
    private bool gunOnCd = true;
    public float gunCD = 5;
    public bool isdead = false;
    public bool CanFire = false; 
    public bool CanEnrage = false; //Only Boss enemy uses this bool;
    public bool IsEnrage = false;
    public bool IsGaint = false;
    private float healthratio;
    //Giant Info
    //float waitTimer = 2f;
    //float chaseTimer = 5f;

    //Enemy class
    public bool isTroop;
    public bool isAssault;
    public bool isSupport;
    
   
    void Start()
    {
        gunOnCd = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        EnemyHealthMax = EnemyHealth;
        if(CanEnrage == true)
        {
            deathcountdown = 10f;
            StartCoroutine(BossCameraCoroutine());
        }
        //Assign the material from the sprite renderer to your field
        material = EnemyspriteRenderer.material;
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
    }
   public void Damage(int damage)
    {
        if (EnemyInvincible == false && isdead == false)
        {
            GameObject damagenumber = Instantiate(floatpoint, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity) as GameObject;
            damagenumber.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
           
            EnemyHealth -= damage;
            StartCoroutine(Invincible());
            Instantiate(floatpoint, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
        
            if (EnemyHealth <= 0 )
            {   
                isdead = true;
                enemydeath.Play();
                if (isTroop == true)
                {
                    gameRecord.troops_kill++;
                    UnityEngine.Debug.Log("You kill a stormtrooper.");
                }else
                if (isAssault == true)
                {
                    gameRecord.assault_kill++;
                    UnityEngine.Debug.Log("You kill a Assault.");
                }else
                if (isSupport == true)
                {
                    gameRecord.support_kill++;
                    UnityEngine.Debug.Log("You kill a Support.");
                }
                else
                if (CanEnrage == true)
                {
                    gameRecord.boss_kill = true;
                    UnityEngine.Debug.Log("You kill a Boss.");
                }

                boxCollider2D.enabled = false;
                animator.SetTrigger("Dead");               
            }
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0.00001f;
        Camera.main.GetComponent<PlayerCamera>().target = transform;
        Camera.main.orthographicSize = 3;
        yield return new WaitForSecondsRealtime(5f);
        Camera.main.GetComponent<PlayerCamera>().target = player.transform;
        yield return new WaitForSecondsRealtime(2.3f);
        Camera.main.orthographicSize = 5;
        yield return new WaitForSecondsRealtime(0.7f);
        Time.timeScale = 1;
    }


    IEnumerator Invincible()
    {    
        EnemyInvincible = true;               
        EnemyspriteRenderer.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(0.3f);
        EnemyspriteRenderer.color = UnityEngine.Color.white;      
        EnemyInvincible = false;
    }
    //Boss Melee function
    public void BossMelee()
    {
        enemyMelee.Play();
        if(transform.localScale.x == -1f)
        {
            Instantiate(meleeLight, enemy.transform.position + new Vector3(2.1f, 1f, 0), Quaternion.Euler(0, -180, 0));
        }
        else
        {
            Instantiate(meleeLight, enemy.transform.position + new Vector3(-2.1f, 1f, 0), Quaternion.Euler(0, 0, 0));
            
        }
       
    }
    void Update()
    {
        
        if(EnemyHealth <= 0 && CanEnrage == false)
        {
            deathcountdown -= Time.deltaTime;
            if (deathcountdown <= 0)
            {               
                Instantiate(Drops[UnityEngine.Random.Range(0, Drops.Length)], transform.position, Quaternion.identity);
                Instantiate(crystal, transform.position, Quaternion.identity);
               
                Destroy(enemy);
            }
        }
        if (EnemyHealth <= 0 && CanEnrage == true)
        {
            
            Bossdeathcountdown -= Time.deltaTime;
            if (Bossdeathcountdown <= 0)
            {
                
                Instantiate(Drops[UnityEngine.Random.Range(0, Drops.Length)], transform.position , Quaternion.identity);
                Instantiate(chest, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                Destroy(enemy);
            }
        }
        if(CanEnrage == true)
        {
            float a = EnemyHealth;
            float b = EnemyHealthMax;
            healthratio = a / b;
            material.SetFloat("_HealthRatio",(healthratio -1f)/2);
            material.SetFloat("_HealthRatio2", (1f - healthratio));
        }
    //Enemy Move
       
        if (IsGaint == false)
        {
            if (player == null)
            {
                return;
            }
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            if (isdead == false)
            {
                transform.position += direction * Time.deltaTime * speed;
                transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
            }
        }
        //Enemy fire
        if (Vector3.Distance(enemy.transform.position, player.transform.position) < 20 && Vector3.Distance(enemy.transform.position, player.transform.position) > 4 
            && gunOnCd == false && CanFire == true && isdead == false && IsGaint == false && CanEnrage == false)
        {
            Vector3 v = player.transform.position - transform.position;
            v.z = 0;
            float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);

            gunOnCd = true;
            Instantiate(Projectile, transform.position, Quaternion.Euler(0,0,angle));
        }
        //Boss Melee
        if(Vector3.Distance(enemy.transform.position, player.transform.position) < 5 && CanEnrage == true)
        {   
            animator.SetBool("MeleeAttack",true);
        }else if(Vector3.Distance(enemy.transform.position, player.transform.position) > 6 && CanEnrage == true)
        {
            animator.SetBool("MeleeAttack", false);
        }
         
        //Gunfire CD
        if (gunOnCd == true)
        {
            gunCD -= Time.deltaTime;
        }
        if (gunCD <= 0)
        {
            gunCD = UnityEngine.Random.Range(4.25f, 6.5f);
            gunOnCd = false;
        }
        if(CanEnrage == true && EnemyHealth <= EnemyHealthMax / 2)
        {   
            IsEnrage = true;
            speed = 3.5f;
            gunOnCd = true;
        }
    }
}
