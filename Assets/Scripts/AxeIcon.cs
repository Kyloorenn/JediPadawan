using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class AxeIcon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image axeicon;
    [SerializeField] Blaster blaster;
    // Update is called once per frame
    void Start()
    {
        if (!blaster)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        

        if(blaster.AttackNumber <= 0)
        {
            axeicon.enabled = false;
        }
        else
        {
            axeicon.enabled = true;
        }
    }
}
