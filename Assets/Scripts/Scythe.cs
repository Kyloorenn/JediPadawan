using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Scythe : BaseWeapon
{
    [SerializeField] Player player;
    public int damage ;
    private float startdistance;
    private Vector3 dir;
    public Transform center;
    
    // Start is called before the first frame update
    private void Start()
    {
        startdistance=Vector3.Distance(transform.position, center.position);
        dir = transform.position - center.position;
        
    }
    void Update()
    {
        player.maxForce = 100 + 20 * level;
        damage = 2 + (int)level / 2;
        transform.position = center.position + dir.normalized * startdistance;
        transform.RotateAround(center.position, Vector3.forward, 80 * Time.deltaTime + 20 * level* Time.deltaTime);
        dir = transform.position - center.position;
        

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
