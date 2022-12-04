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
    Player playerData;
    // Make a material field
    Material material;
    GameRecord gameRecord;
    ProjectilePool projectilePool;
    CrystalPool crystalPool;
    public GameObject[] Drops;
    public AudioSource enemydeath;
    public AudioSource enemyMelee;
    public AudioSource enemyFire;  //Only add Boss enemy's firing audio source.  
    public GameObject floatpoint;
    public GameObject meleeLight;
    public GameObject crystal;
    public GameObject goldcoin;
    public GameObject bossProjectile;
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
    //Boss fire limit
    public int bossFireLimit = 3;
    private float bossFireTimer = 4f;
    //Normal Enemy shader parameter
    private float fading = 1f;
    private float enemyRatio;
    void Start()
    {
        gunOnCd = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        EnemyHealthMax = EnemyHealth;
        if (CanEnrage == true)
        {
            deathcountdown = 10f;
            StartCoroutine(BossCameraCoroutine());
        }
        //Assign the material from the sprite renderer to your field
        material = EnemyspriteRenderer.material;
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        projectilePool = GameObject.Find("ProjectilePool").GetComponent<ProjectilePool>();
        crystalPool = GameObject.Find("CrystalPool").GetComponent<CrystalPool>();
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
                //increase the parameter of shader after player kills one enemy.
                playerData.killingStreak++;
               

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
    public void BossFire()
    {
        Vector3 v = player.transform.position - transform.position;
        v.z = 0;
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);
       
            if (transform.localScale.x == -1f)
            {
                Instantiate(bossProjectile, enemy.transform.position + new Vector3(1.7f, 1f, 0), Quaternion.Euler(0, -180, 270 - angle));
                enemyFire.Play();

            }
            else
            {
                Instantiate(bossProjectile, enemy.transform.position + new Vector3(-1.7f, 1f, 0), Quaternion.Euler(0, 0, angle - 90));
                enemyFire.Play();
            }
            bossFireLimit--;
        
       
    }
    void Update()
    {
        //Update normal enemy health ratio
        enemyRatio = EnemyHealth / EnemyHealthMax;
        if(enemyRatio <= 0.8f && CanEnrage == false)
        {
            material.SetFloat("_Weak", 0.3f);
        }else if(enemyRatio <= 0.3f && CanEnrage == false)
        {
            material.SetFloat("_Weak", 0.8f);
        }
        if(EnemyHealth <= 0 && CanEnrage == false)
        {
            deathcountdown -= Time.deltaTime;
            fading -= (Time.deltaTime * 0.67f);
            material.SetFloat("_Fading", fading);
          
            if (deathcountdown <= 0)
            {               
                Instantiate(Drops[UnityEngine.Random.Range(0, Drops.Length)], transform.position, Quaternion.identity);
                //Instantiate(crystal, transform.position, Quaternion.identity);
                var crystal = crystalPool.Get();
                crystal.transform.position = transform.position;
                crystal.transform.rotation = Quaternion.identity;
                crystal.SetActive(true);
                enemy.SetActive(false);
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
            //Instantiate(Projectile, transform.position, Quaternion.Euler(0,0,angle));
            var bullet = projectilePool.GetP();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            bullet.SetActive(true);
        }
        //Boss Melee
        if(Vector3.Distance(enemy.transform.position, player.transform.position) < 5 && CanEnrage == true )
        {   
            animator.SetBool("MeleeAttack",true);
        }else if(Vector3.Distance(enemy.transform.position, player.transform.position) > 6 && CanEnrage == true)
        {
            animator.SetBool("MeleeAttack", false);
        }
        //Boss Fire
       
        if (Vector3.Distance(enemy.transform.position, player.transform.position) > 7  && CanEnrage == true )
        {   
            if(bossFireLimit >= 1)
            {
                animator.SetBool("RangeAttack", true);
                
            }    
            if (bossFireLimit <= 0)
            {
                animator.SetBool("RangeAttack", false);
            }
        }
        
         if (Vector3.Distance(enemy.transform.position, player.transform.position) > 20 && CanEnrage == true)
        {
            animator.SetBool("RangeAttack", false);
        }
        else if (Vector3.Distance(enemy.transform.position, player.transform.position) < 6 && CanEnrage == true)
        {
            animator.SetBool("RangeAttack", false);
        }
        //Boss reload
        if(bossFireLimit < 3)
        {
            bossFireTimer -= Time.deltaTime;
            if(bossFireTimer <= 0)
            {
                bossFireLimit = 3;
                bossFireTimer = 5f;
            }
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
