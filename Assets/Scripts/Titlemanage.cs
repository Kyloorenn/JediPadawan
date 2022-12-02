using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using TMPro;
using UnityEngine.UI;


public class Titlemanage : MonoBehaviour
{
    TitleCamera titleCamera;
    [SerializeField] GameObject processingManager;
    private bool menuOpen;
    private bool cstart, cupgrade, cquit;
    private float loadtimer = 2.75f;
    // Method is a function that belongs to class;
    public static SaveData saveData;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
    private void Awake()
    {
        if (saveData == null)
        {
            Load();
        }
        else
        {
            Save();
        }
        
    }
    private void Load()
    {
        FileStream file = null; 
        try 
        { 
            file = File.Open(SavePath, FileMode.Open); 
            var bf = new BinaryFormatter(); 
            saveData = (SaveData)bf.Deserialize(file) ; 
        }
        catch (Exception e) 
        { 
            UnityEngine.Debug.Log(e.Message); 
            saveData = new SaveData(); 
        } 
        finally 
        { 
            if (file != null) 
                file.Close();
        }
    }
    
    private void Save()
    {
        FileStream file = null; 
        try 
        { 
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }               
            file = File.Create(SavePath); 
            var bf = new BinaryFormatter(); 
            bf.Serialize(file, saveData); 
        } 
        catch (Exception e) 
        { 
            Debug.Log(e); 
        } 
        finally 
        {
            if (file != null) file.Close(); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        titleCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TitleCamera>(); //use method from TitleCamera;
        titleCamera.isStart = false;
        cstart = false;
        cupgrade = false;
        cquit = false;
        
    }
    //Button Click
    public void OnStartButtonClick()
    {
        titleCamera.isStart = true;
        
        cstart = true;

           
    }
      public void OnUpgradeButtonClick()
    {
        titleCamera.isStart = true;
        cupgrade = true;
       
    }
    public void OnShopButtonClick()
    {   
        SceneManager.LoadScene("Shop");
    }

    public void OnQuitButtonClick()
    {
        titleCamera.isStart = true;
        cquit = true;
    }

    public void OnPostProcessingClick()
    {
        if(titleCamera.volume.enabled == true)
        {
            titleCamera.volume.enabled = false;
            
        }
        else
        {
            titleCamera.volume.enabled = true;
           
        }
        
    }

    public void OnGameProcessingClick()
    {
        if(Titlemanage.saveData.gameProcessing == true)
        {
            Titlemanage.saveData.gameProcessing = false;
        }
        else
        {
            Titlemanage.saveData.gameProcessing = true;
        }
    }
    //Coroutine
    //IEnumerator OnStart()
    //{
    //    yield return new WaitForSeconds(2.75f);
    //    SceneManager.LoadScene("Continue");
    //}
    //IEnumerator Upgrade()
    //{
    //    yield return new WaitForSeconds(2.75f);
    //    SceneManager.LoadScene("Upgrade");
    //}
    //IEnumerator Quit()
    //{
    //    yield return new WaitForSeconds(2.75f);
    //    Application.Quit();
    //}
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if(menuOpen == false)
            {
                processingManager.SetActive(true);
                menuOpen = true;
            }
            else 
            {
                processingManager.SetActive(false);
                menuOpen = false;
            }
           
        }
        if(cstart == true || cupgrade == true || cquit == true)
        {
            loadtimer -= Time.deltaTime;
            if(loadtimer <= 0f)
            {
                if(cstart == true)
                {   
                    loadtimer = 2.75f;
                    SceneManager.LoadScene("Continue");
                }else if(cupgrade == true)
                {
                    loadtimer = 2.75f;
                    SceneManager.LoadScene("Upgrade");
                }else if (cquit)
                {
                    loadtimer = 2.75f;
                    Application.Quit();
                }
            }
        }
    }
    

}
