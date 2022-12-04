using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject troopersPrefab; 
    List<GameObject> pooledEnemies = new List<GameObject>();

    int enemyIndex;
    private void Awake()
    {
        for (int i = 0; i < 300; i++)
        {
            pooledEnemies.Add(Instantiate(troopersPrefab));
            troopersPrefab.SetActive(false);
        }
        for (int i = 0; i < 300; i++)
        {
            GameObject b = GameObject.Find("TEnemyPool");
            GameObject a = pooledEnemies[i];
            a.transform.parent = b.transform;
        }
       
    }
    public GameObject Get()
    {
       enemyIndex %= pooledEnemies.Count;
        var result = pooledEnemies[enemyIndex++];
        if (!result.activeInHierarchy)
        {
            return result;
        }
        else
        {
            //add one more
            pooledEnemies.Add(Instantiate(troopersPrefab));
            return troopersPrefab;
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
