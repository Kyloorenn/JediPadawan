using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class Upgrade3 : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text upgrade3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forcetalent = (float)upgradeManager.ForceTalent;
        upgrade3.text = "Upgrade: " + (80 + forcetalent * 40); 
    }
}
