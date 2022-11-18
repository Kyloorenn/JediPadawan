using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 2;
    public int attacknumber = 5;
    private float timer = 3f;
 
    // Update is called once per frame

    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += transform.up * 20 * Time.deltaTime;
        if(attacknumber == 0)
        {
            timer = 3f;
            gameObject.SetActive(false);
        }
        if(timer <= 0f)
        {   
            timer = 3f;
            gameObject.SetActive(false);
        }
        
    }   
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
        
        if (enemy != null)
            {
                enemy.Damage(damage);
            attacknumber--;
            }
        

          
        }
    }
    

