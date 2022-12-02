using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Player player;
    public int damage = 4;   
    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player.transform.localRotation.y != 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
            transform.position += -transform.right * 15 * Time.deltaTime;

        if (timer <= 0f)
        {
           
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.Damage(damage);
            
        }



    }
}
