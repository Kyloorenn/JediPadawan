using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{   
    private void Start()
    {
        Titlemanage.saveData.isone = false;
        Titlemanage.saveData.istwo = false;
    }
    public void OnReturnButtonClick()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnChoose1ButtonClick()
    {
        Titlemanage.saveData.isone = true;
        SceneManager.LoadScene("Game");
    }
    public void OnChoose2ButtonClick()
    {   
        if(Titlemanage.saveData.buyFighter == true)
        {
            Titlemanage.saveData.istwo = true;
            SceneManager.LoadScene("Game");
        }
        
    }
}
