using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class GameCoinsDisplay : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text coinsNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float coins = (float)player.coins;
        coinsNumber.text = "" + coins;
    }
}
