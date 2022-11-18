using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;


public class Boss_Defeated : MonoBehaviour
{
    GameRecord gameRecord;
    [SerializeField] TMP_Text boss_Defeated;
    // Start is called before the first frame update
    void Start()
    {
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
        boss_Defeated.text = " Alive ";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRecord.boss_kill == true)
        {
            boss_Defeated.text = " Defeated ";
        }
    }
}
