using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class BuyFighterButton : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text locked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(upgradeManager.buyFighter == true)
        {
            locked.text = "UNLOCKED";
        }
    }
}
