using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameRecord : MonoBehaviour
{
    public GameObject troops;
    public GameObject assault; 
    public GameObject support; 
    public GameObject boss; 
    public GameObject coin;
    public int assault_kill;
    public int troops_kill;
    public int support_kill;
    public int coin_collect;
    public int exp_gained;
    public bool boss_kill;    
    private int initial_gold;
    private int final_gold;
    Enemy enemy;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        assault_kill = 0;
        support_kill = 0;
        coin_collect = 0;
        troops_kill = 0;
        exp_gained = 0;
        boss_kill = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        initial_gold = player.coins;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(player.PlayerHealth >= 0)
        {
            final_gold = player.coins;
            coin_collect = final_gold - initial_gold;
        }
        
    }
}
