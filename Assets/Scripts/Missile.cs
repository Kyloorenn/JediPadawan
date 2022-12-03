using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : BaseWeapon
{
    [SerializeField] GameObject rocketMissile;
    [SerializeField] GameObject Player;
    private float angle;
    public float CD = 7;
    bool isOpen = false;
    public AudioSource blasterattack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isOpen == false)
        {
            angle = UnityEngine.Random.Range(80, 100);
            if (Player.transform.localRotation.y != 0)
            {
                angle *= -1;
            }
            Instantiate(rocketMissile, transform.position, Quaternion.Euler(0, 0, angle));
            isOpen = true;
        }

        if (isOpen == true)
        {
            CD -= Time.deltaTime;
        }

        if (CD <= 0)
        {           
            CD = 7 - level;
            isOpen = false;
        }
    }
}
