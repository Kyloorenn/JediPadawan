using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    private void Start()
    {
        if (!player && Titlemanage.saveData.isone == true)
        {
            player = GameObject.Find("Padawan").GetComponent<Player>();

        }
        else if(!player && Titlemanage.saveData.istwo == true)
        {
            player = GameObject.Find("Fighter").GetComponent<Player>();
        }
    }
    private void Update()
    {
        float expRatio =  (float)player.currentEXP/player.expToLevel;

        foreground.transform.localScale = new Vector3(expRatio, 1, 1);
    }
}
