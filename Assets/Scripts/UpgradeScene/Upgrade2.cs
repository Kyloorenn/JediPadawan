using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class Upgrade2 : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text upgrade2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float enhancehealthLv = (float)upgradeManager.EnhancedHealth;
        upgrade2.text = "Upgrade: " + (40 + enhancehealthLv * 30);
    }
}
