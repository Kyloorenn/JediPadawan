using System;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;  
    [SerializeField] GameObject stormtrooper;
    [SerializeField] GameObject assaultrobot;
    [SerializeField] GameObject player;
    [SerializeField] GameObject supportrobot;
    [SerializeField] GameObject giant;
    [SerializeField] GameObject orb;
    [SerializeField] GameObject boss;
    private int minutecounter = 0;
    private bool BossFight = false;
    int spawnCounter = 0;
    private IEnumerator coroutine;
    int minute, second;
    PlayerCamera playerCamera;
    private void Start()
    {
        Player player = GetComponent<Player>();
        coroutine = SpawnEnemyCoroutine();
        StartCoroutine(coroutine);
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
    }

   
    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            //SpawnEnemies(giant, 2);
            //yield return new WaitForSeconds(30f);
            //1st minute monster patterns;
            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            SpawnEnemies(supportrobot, 1 + minutecounter);
            SpawnEnemies(assaultrobot, 1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(10f);

            SpawnEnemies(stormtrooper, 3 + minutecounter);
            SpawnEnemies(supportrobot, 1 + spawnCounter + minutecounter);
            SpawnEnemies(assaultrobot, 2 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);

            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            SpawnEnemies(supportrobot, 1 + spawnCounter + minutecounter);
            SpawnEnemies(assaultrobot, 1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(10f);

            SpawnEnemies(stormtrooper, 3 + minutecounter);
            SpawnEnemies(supportrobot, 2 + minutecounter);
            SpawnEnemies(assaultrobot, 2 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);

            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            SpawnEnemies(supportrobot, 1 + minutecounter);
            SpawnEnemies(assaultrobot, 1 + minutecounter);
            spawnCounter++;
            BonusSpawn();
            minutecounter++;
            yield return new WaitForSeconds(10f);

            //2nd minute
            SpawnEnemies(assaultrobot, 5 + minutecounter);
            SpawnEnemies(supportrobot, 3 + minutecounter);
            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 6 + minutecounter);
            SpawnEnemies(supportrobot, 3 + minutecounter);
            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 6 + minutecounter);
            SpawnEnemies(supportrobot, 3 + minutecounter);
            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 7 + minutecounter);
            SpawnEnemies(supportrobot, 3 + minutecounter);
            SpawnEnemies(stormtrooper, 3 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            minutecounter++;
            //3rd minute;
            SpawnEnemies(assaultrobot, 5 + minutecounter);
            SpawnEnemies(supportrobot, 5 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 6 + minutecounter);
            SpawnEnemies(supportrobot, 5 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 6 + minutecounter);
            SpawnEnemies(supportrobot, 5 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 7 + minutecounter);
            SpawnEnemies(supportrobot, 5 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            minutecounter++;
            //4th minute
            SpawnEnemies(assaultrobot, 10 + minutecounter);
            SpawnEnemies(supportrobot, 10 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            yield return new WaitForSeconds(15f);
            SpawnEnemies(assaultrobot, 10 + minutecounter);
            SpawnEnemies(supportrobot, 10 + minutecounter);
            SpawnEnemies(stormtrooper, 10 + spawnCounter + minutecounter);
            spawnCounter++;
            BonusSpawn();
            //wait untill Boss spawn.
        }
    }
    void BonusSpawn()
    {
        if (spawnCounter == 2)
        {
            SpawnEnemies(stormtrooper, 3);         
        }
        if (spawnCounter == 4)
        {
            SpawnEnemies(stormtrooper, 3);
            SpawnEnemies(assaultrobot, 5);
            spawnCounter = 0;
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 3;
            spawnPosition += player.transform.position;
            Instantiate(orb, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool Istracking = true)
    {
  for (int i = 0; i<numberOfEnemies; i++)
    {
       Enemy enemy = GetComponent<Enemy>();
      Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 8;
 
      spawnPosition += player.transform.position;
       Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);         
     }
  }


void SpawnBoss()
    {
        if(TimerText.text == "04:00" && BossFight == false)
        {   
            BossFight = true;
            SpawnEnemies(stormtrooper, 3);
            SpawnEnemies(supportrobot, 2);
            SpawnEnemies(assaultrobot, 2);
            StopCoroutine(SpawnEnemyCoroutine());
            Vector3 spawnPosition = UnityEngine.Random.insideUnitCircle.normalized * 15;
            spawnPosition += player.transform.position;
            Instantiate(boss, spawnPosition, Quaternion.identity);
         

        }
    }
   
    private void Update()
    {
        playerCamera.volume.enabled = Titlemanage.saveData.gameProcessing;
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


