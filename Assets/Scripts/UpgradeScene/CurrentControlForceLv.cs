using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
public class CurrentControlForceLv : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text currentControlForceLv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float controlForceLv = (float)upgradeManager.controlForceLv;
        currentControlForceLv.text = "" + controlForceLv;
    }
}
