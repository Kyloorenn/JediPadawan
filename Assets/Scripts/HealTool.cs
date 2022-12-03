using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTool : BaseWeapon
{
    Player player;
    private float cooldown = 8f;
    private bool ready = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& ready == true)
        {
            player.PlayerHealth += (int)(0.1*(3+level) * player.maxHP);
            ready = false;
        }
        if(ready == false)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0f)
        {
            ready = true;
            cooldown = 8f - (int)(0.5 * level);
        }
    }
}
