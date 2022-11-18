using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Exp_Number : MonoBehaviour
{
    GameRecord gameRecord;
    [SerializeField] TMP_Text exp_Number;
    // Start is called before the first frame update
    void Start()
    {
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
    }

    // Update is called once per frame
    void Update()
    {
        float number = (float)gameRecord.exp_gained;
        exp_Number.text = "EXP: " + number;
    }
}
