using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public class CurrentForceTalent : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text currentForceTalent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ForceTalent = (float)upgradeManager.ForceTalent;
        currentForceTalent.text = "" + ForceTalent;
    }
}
