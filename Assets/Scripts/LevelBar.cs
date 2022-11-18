using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class LevelBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text levelBar;

    private void Update()
    {
        float level = (float)player.currentLevel;

        levelBar.text = "Lv: " + level;
    }
}
