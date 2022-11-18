using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Blaster : BaseWeapon
{
    [SerializeField] GameObject BlasterBullet;
    [SerializeField] GameObject Player;
    private float angle;
    public int AttackNumber = 3;
    public float CD = 5;
    bool isOpen = false;
    public AudioSource blasterattack;

    [SerializeField] SimpleObjectPool pool;

    void Start()
    {
        //StartCoroutine(SpawnBulletCoroutine());
    }
    IEnumerator SpawnBulletCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < 20; i++)
            {
                angle = UnityEngine.Random.Range(20, 100);
                if (Player.transform.localRotation.y != 0)
                {
                    angle *= -1;
                }
                var bullet = pool.Get();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
                bullet.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && AttackNumber >= 1)
        {
            angle = UnityEngine.Random.Range(80, 100);
            if (Player.transform.localRotation.y != 0)
            {
                angle *= -1;
            }
            //Instantiate(BlasterBullet, transform.position, Quaternion.Euler(0, 0, angle));
            var bullet = pool.Get();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            bullet.SetActive(true);


            blasterattack.Play();
            AttackNumber--;
            isOpen = true;
        }

        if (isOpen == true)
        {
            CD -= Time.deltaTime;
        }

        if (CD <= 0)
        {
            AttackNumber = 2 + level;
            CD = 5;
            isOpen = false;
        }

    }
}
