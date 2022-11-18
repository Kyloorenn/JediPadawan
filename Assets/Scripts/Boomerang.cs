using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour

{

    [SerializeField] Player player;
    public float speed =10f;
    public int damage;
    public float rotateSpeed =2f;
    public float tuning = 0.2f;
    public AudioSource throwSaber;  
    public Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform boomerangTransform;
    private Vector2 startSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        
       
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = -transform.right * speed;
        startSpeed = rb2d.velocity;       
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boomerangTransform = GetComponent<Transform>();
        throwSaber.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Enemy enemy = collision.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.Damage(damage);            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       
        damage = 3 + Titlemanage.saveData.controlForceLv;
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector3(transform.position.x, y, 0.0f);
        rb2d.velocity = rb2d.velocity - startSpeed * Time.deltaTime*1.5f;
        if(Mathf.Abs(transform.position.x - playerTransform.position.x) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
