using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
public class CurrentEnhanceHealth : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text currentEnhanceHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float EnhancedHealth = (float)upgradeManager.EnhancedHealth;
        currentEnhanceHealth.text = "" + EnhancedHealth;
    }
}
