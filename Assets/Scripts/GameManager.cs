using System;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] TMP_Text TimerText;
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject stormtrooper;
    [SerializeField] GameObject assaultrobot;
    [SerializeField] GameObject player;
    [SerializeField] GameObject supportrobot;
    [SerializeField] GameObject giant;
    [SerializeField] GameObject orb;
    [SerializeField] GameObject boss;
    [SerializeField] SEnemyPool Spool;
    [SerializeField] AEnemyPool Apool;
    [SerializeField] EnemyPool Tpool;
    private int minutecounter = 0;
    private bool BossFight = false;
    int spawnCounter = 0;
    private IEnumerator coroutine;
    public int minute, second;
    PlayerCamera playerCamera;

    private void Start()
    {
        //Player player = GetComponent<Player>();
        coroutine = SpawnEnemyCoroutine();
        StartCoroutine(coroutine);
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
        playerCamera.volume.enabled = Titlemanage.saveData.gameProcessing;

        if (Titlemanage.saveData.isone == true)
        {
            characters[1].SetActive(false);
        }

        if (Titlemanage.saveData.istwo == true)
        {
            characters[0].SetActive(false);
        }
        if (Titlemanage.saveData.isone == true)
        {
            UnityEngine.Debug.Log("the one. ");
        }
        if (Titlemanage.saveData.istwo == true)
        {
            UnityEngine.Debug.Log("the two. ");
        }
    }

   
    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            //SpawnEnemies(giant, 2);
            //yield return new WaitForSeconds(30f);
            //1st minute monster patterns;
            SpawnTEnemies(3 + spawnCounter + minutecounter);
            SpawnSEnemies(1 + minutecounter);
            SpawnAEnemies(1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(10f);

            SpawnTEnemies(3 + minutecounter);
            SpawnSEnemies(1 + spawnCounter + minutecounter);
            SpawnAEnemies(2 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);

            SpawnTEnemies(3 + spawnCounter + minutecounter);
            SpawnSEnemies(1 + spawnCounter + minutecounter);
            SpawnAEnemies(1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(10f);

            SpawnTEnemies(3 + minutecounter);
            SpawnSEnemies(2 + minutecounter);
            SpawnAEnemies(2 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);

            SpawnTEnemies( 3 + spawnCounter + minutecounter);
            SpawnSEnemies( 1 + minutecounter);
            SpawnAEnemies(1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            minutecounter++;
            yield return new WaitForSeconds(10f);

            //2nd minute
            SpawnAEnemies(5 + minutecounter);
            SpawnSEnemies(3 + minutecounter);
            SpawnTEnemies(3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies( 6 + minutecounter);
            SpawnSEnemies( 3 + minutecounter);
            SpawnTEnemies( 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies( 6 + minutecounter);
            SpawnSEnemies( 3 + minutecounter);
            SpawnTEnemies( 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies(7 + minutecounter);
            SpawnSEnemies( 3 + minutecounter);
            SpawnTEnemies(3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            minutecounter++;
            //3rd minute;
            SpawnAEnemies( 5 + minutecounter);
            SpawnSEnemies( 5 + minutecounter);
            SpawnTEnemies( 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies( 6 + minutecounter);
            SpawnSEnemies(5 + minutecounter);
            SpawnTEnemies(10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies(6 + minutecounter);
            SpawnSEnemies(5 + minutecounter);
            SpawnTEnemies(10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies(7 + minutecounter);
            SpawnSEnemies( 5 + minutecounter);
            SpawnTEnemies(10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            minutecounter++;
            //4th minute
            SpawnAEnemies(10 + minutecounter);
            SpawnSEnemies(10 + minutecounter);
            SpawnTEnemies(10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnAEnemies(10 + minutecounter);
            SpawnSEnemies(10 + minutecounter);
            SpawnTEnemies(10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            //wait untill Boss spawn.
        }
    }
    void BonusSpawn()
    {
        if (spawnCounter == 2)
        {
            SpawnTEnemies(3);         
        }
        if (spawnCounter == 4)
        {
            SpawnTEnemies( 3);
            SpawnAEnemies(5);
            spawnCounter = 0;
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 3;
            spawnPosition += player.transform.position;
            //Instantiate(orb, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnTEnemies(int numberOfEnemies, bool Istracking = true)
    {
  for (int i = 0; i<numberOfEnemies; i++)
    {
       
      Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;
 
      spawnPosition += player.transform.position;
     var tenemy = Tpool.Get();
     tenemy.transform.position = spawnPosition;
     tenemy.transform.rotation = Quaternion.identity;
     tenemy.SetActive(true);
    
           
       //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);         
     }
  }

    void SpawnAEnemies(int numberOfEnemies, bool Istracking = true)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;

            spawnPosition += player.transform.position;
            var aenemy = Apool.Get();
            aenemy.transform.position = spawnPosition;
            aenemy.transform.rotation = Quaternion.identity;
            aenemy.SetActive(true);
           

            //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);         
        }
    }
    void SpawnSEnemies(int numberOfEnemies, bool Istracking = true)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;

            spawnPosition += player.transform.position;
            var senemy = Spool.Get();
            senemy.transform.position = spawnPosition;
            senemy.transform.rotation = Quaternion.identity;
            senemy.SetActive(true);
            

            //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);         
        }
    }

    void SpawnBoss()
    {
        if(TimerText.text == "04:00" && BossFight == false)
        {   
            BossFight = true;
            SpawnTEnemies(3);
            SpawnSEnemies(2);
            SpawnAEnemies(2);
            StopCoroutine(SpawnEnemyCoroutine());
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 15;
            spawnPosition += player.transform.position;
            Instantiate(boss, spawnPosition, Quaternion.identity);
         

        }
    }
   
    private void Update()
    {
       
        int seconds = (int)Time.timeSinceLevelLoad;
        minute = seconds / 60;
        second = seconds % 60;
       
        if(second >= 10)
        {
            TimerText.text = "0" + minute + ":" + second; 
        }
        else
        {
            TimerText.text = "0" + minute + ":0" + second;
        }

       if(TimerText.text == "03:45")
        {
            StopCoroutine(SpawnEnemyCoroutine());
            StopCoroutine(coroutine);
        }
     SpawnBoss();

    }
}


