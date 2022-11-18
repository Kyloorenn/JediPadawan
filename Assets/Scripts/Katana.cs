using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Katana : BaseWeapon
{
    [SerializeField] GameObject weapon;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;
    
    bool IsAttacking = false;
    private int damage = 1;
    private float attackcd = 0.8f;
    public AudioSource saberattack;


    // Start is called before the first frame update
    void Start()
    {       
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
       
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Damage(damage);
        }
    }
    void Update()
    {
        damage = level;
        if (Input.GetKeyDown(KeyCode.J)&& IsAttacking == false)
        {
            IsAttacking = true;
            saberattack.Play();
            
        }
        
   if (IsAttacking == true)
   {      
         attackcd -= Time.deltaTime;
     }
       if(attackcd <= 0)
      {
           IsAttacking=false;         
           attackcd = 0.8f;
           UnityEngine.Debug.Log("SaberReady");
        
        }
        animator.SetBool("IsAttacking", IsAttacking);
    }
}
