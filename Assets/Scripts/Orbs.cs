using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    
    private float speed = 0.35f;
    private bool up = true;
    private float time = 0.75f;
    [SerializeField] Animator animator;  
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider2D;
    public Rigidbody2D rb2d;
    public AudioSource pickorb;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        
    
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            pickorb.Play();
            Destroy(gameObject,2f);
        }
    }
    void Update()
    {
        if (up == true)
        {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                up = false;
                rb2d.velocity = -transform.up * speed;
                time = 0.75f;
            }
        }
        if (up == false)
        {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                up = true;
                rb2d.velocity = transform.up * speed;
                time = 0.75f;
            }

        }
    }
}
