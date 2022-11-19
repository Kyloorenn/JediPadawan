using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Barrier : MonoBehaviour
{
  
    [SerializeField] Player player;
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject reflectProjectile;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SimpleObjectPool pool;
    // Start is called before the first frame update
    // Make a material field
    Material material;
    void Start()
    {
        //Assign the material from the sprite renderer to your field
        material = spriteRenderer.material;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Projectile")
        {
            float angle = UnityEngine.Random.Range(0, 360);
            Destroy(collision.gameObject);
            Vector3 spawnpositon = UnityEngine.Random.insideUnitCircle * 0.5f;
            spawnpositon += collision.transform.position;
            //Instantiate(reflectProjectile, spawnpositon, Quaternion.Euler(0,0,angle));
            var bullet = pool.Get();
            bullet.transform.position = spawnpositon;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            bullet.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(player.forceEnough);
            player.isParry = player.forceEnough;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            player.isParry = false;
            gameObject.SetActive(false);
           
        }    

        transform.position = player.transform.position;
        player.forceValue -= Time.deltaTime * (30 - player.controlForceLv * 2);

        material.SetFloat("_Energy", (player.forceValue / player.maxForce) - 0.8f);

    }
}
