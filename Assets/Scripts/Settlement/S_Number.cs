using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class S_Number : MonoBehaviour
{
    GameRecord gameRecord;
    [SerializeField] TMP_Text s_Number;
    // Start is called before the first frame update
    void Start()
    {
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
    }

    // Update is called once per frame
    void Update()
    {
        float number = (float)gameRecord.support_kill;
        s_Number.text = " " + number;
    }
}
