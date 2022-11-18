using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image HPBar;
    // Start is called before the first frame update
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-1f,0.9f,0);       
        float hpRatio = (float)player.PlayerHealth/player.maxHP;
        HPBar.transform.localScale = new Vector3(hpRatio, 1, 1);
    }
}
