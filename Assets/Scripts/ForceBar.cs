using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class ForceBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image Forcebar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float staRatio = (float)player.forceValue / player.maxForce;
        Forcebar.transform.localScale = new Vector3(staRatio, 1, 1);
    }
}
