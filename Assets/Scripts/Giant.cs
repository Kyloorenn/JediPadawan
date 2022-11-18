using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Specialized;
using UnityEngine.UI;

public class Giant : MonoBehaviour
{
    enum GiantState
    {
        Idle = 0,
        Chasing = 1,
        Attacking = 2
    }
    GiantState giantState = GiantState.Idle;
    [SerializeField] float speed = 2f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject Projectile;
    [SerializeField] SpriteRenderer EnemyspriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] GameObject chest;
    public GameObject[] Drops;
    public AudioSource enemydeath;
    public GameObject floatpoint;
    public GameObject crystal;
    public GameObject goldcoin;
    GameObject player;
    public int EnemyHealth;
    private int EnemyHealthMax;
    bool EnemyInvincible = false;
    //private bool gunOnCd = true;
    //public float gunCD = 5;
    public bool isdead = false;
    //public bool CanFire = false;
    //public bool CanEnrage = false;    
    //public bool IsGaint = false;
    public bool IsEnrage = false;
    private float healthratio;
    //Giant Info
    float waitTimer = 2f;
    float chaseTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //gunOnCd = true;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        EnemyHealthMax = EnemyHealth;
        EnemyspriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    //Take Damage
    public void Damage(int damage)
    {
        if (!EnemyInvincible && !isdead)
        {
            GameObject damagenumber = Instantiate(floatpoint, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity) as GameObject;
            damagenumber.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage.ToString();
            if(!IsEnrage)
            {
                giantState = GiantState.Idle;
                waitTimer = 2f;
            }       
            EnemyHealth -= damage;
            StartCoroutine(Invincible());
            Instantiate(floatpoint, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

            if (EnemyHealth <= 0)
            {
                isdead = true;
                enemydeath.Play();
                boxCollider2D.enabled = false;

            }
        }
    }
    IEnumerator Invincible()
    {

        EnemyInvincible = true;
        EnemyspriteRenderer.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(0.3f);
        EnemyspriteRenderer.color = UnityEngine.Color.white;
        EnemyInvincible = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {

                Damage(2);
           
        }
    }
    
    
        public void ThrowDagger()
    {
        Vector3 v = player.transform.position - transform.position;
        v.z = 0;
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);
        //gunOnCd = true;
        Instantiate(Projectile, transform.position, Quaternion.Euler(0, 0, angle));
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Instantiate(Drops[UnityEngine.Random.Range(0, Drops.Length)], transform.position, Quaternion.identity);
            Instantiate(crystal, transform.position, Quaternion.identity);
            Destroy(enemy);
        }
        switch (giantState)
        {
            case GiantState.Idle:
                speed = 0.5f;
                animator.SetBool("IsWalking", false);
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    giantState = GiantState.Chasing;
                }
                break;
            case GiantState.Chasing:
                float distance = Vector3.Distance(transform.position, player.transform.position);
                animator.SetBool("IsWalking", true);
                speed = 2f;
                chaseTimer -= Time.deltaTime;
                if(chaseTimer <= 0)
                {
                    giantState = GiantState.Idle;
                    waitTimer = 2f;
                    chaseTimer = 5f;
                }
                if (distance < 5f)
                {
                    giantState = GiantState.Attacking;
                }
                break;
            case GiantState.Attacking:
                animator.SetBool("IsWalking", false);            
                animator.SetTrigger("Attack");
                speed = 0f;
                if (IsEnrage == false)
                {
                    giantState = GiantState.Idle;
                }
                else
                {
                    giantState = GiantState.Attacking;
                }
                waitTimer = 2f;
                break;

        }
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
        if ( EnemyHealth <= EnemyHealthMax / 2)
        {
            IsEnrage = true;
            EnemyspriteRenderer.color = Color.red;
        }
    }

}
