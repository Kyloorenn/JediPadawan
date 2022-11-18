using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Parry : BaseWeapon
{
    [SerializeField] GameObject barrier;
    PlayerCamera playerCamera;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            player.isParry = true;
            barrier.SetActive(true);
            playerCamera.Chromatic();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.isParry = false;
            barrier.SetActive(false);
            playerCamera.NormalChromatic();
        }
      
    }
}
