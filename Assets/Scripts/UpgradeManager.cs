using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;


public class UpgradeManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject UpgradeError;
    public int coins = 0;
    public int controlForceLv = 0; // permanent passive upgrade to decrease the cost of forceValue and the damage of force skill.
    public int EnhancedHealth = 0; //plus 30 health each level
    public int ForceTalent = 0; // get a random skill upgrade at the beginning of game.
    public bool buyFighter = false;
    // Method is a function that belongs to class;

    // Start is called before the first frame update
    void Start()
    {
          coins = Titlemanage.saveData.goldCoins;
          controlForceLv = Titlemanage.saveData.controlForceLv;
          EnhancedHealth = Titlemanage.saveData.EnhancedHealth;
          ForceTalent = Titlemanage.saveData.ForceTalent;
          buyFighter = Titlemanage.saveData.buyFighter;
    }

    public void OnUpgrade1Click()
    {
        
        if (coins < 50 + controlForceLv * 25)
        {
            UpgradeError.SetActive(true);
        }
        else
        {
            controlForceLv++;
            coins -= (25 + controlForceLv * 25);
        }
       

    }
    public void OnUpgrade2Click()
    {
        if (coins < 40 + EnhancedHealth * 30)
        {
            UpgradeError.SetActive(true);
        }
        else
        {
            EnhancedHealth++;
            coins -= (10 + EnhancedHealth * 30);
        }
    }
    public void OnUpgrade3Click()
    {
        if (coins < 80 + ForceTalent * 40)
        {
            UpgradeError.SetActive(true);
        }
        else
        {
            ForceTalent++;
           coins -= 40 + ForceTalent * 40;
        }
    }
    public void BuyFighterClick()
    {
        if (coins < 200  )
        {
            UpgradeError.SetActive(true);
        }
        else if( buyFighter == false)
        {
            buyFighter = true;
            coins -= 200;
        }
    }

    public void OnReturnClick()
    {
        // Titlemanage.saveData.goldCoins = coins;
        Titlemanage.saveData.goldCoins = coins;
        Titlemanage.saveData.controlForceLv = controlForceLv;
        Titlemanage.saveData.EnhancedHealth = EnhancedHealth;
        Titlemanage.saveData.ForceTalent = ForceTalent;
        Titlemanage.saveData.buyFighter = buyFighter;
        SceneManager.LoadScene("Title");        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
