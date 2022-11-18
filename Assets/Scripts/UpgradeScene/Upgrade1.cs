using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
public class Upgrade1 : MonoBehaviour
{
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] TMP_Text upgrade1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float controlforceLv = (float)upgradeManager.controlForceLv;
        upgrade1.text = "Upgrade: "+ (50 + controlforceLv*25);
    }
}
