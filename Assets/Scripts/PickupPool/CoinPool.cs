using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    List<GameObject> pooledcoin = new List<GameObject>();

    int coinIndex;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            pooledcoin.Add(Instantiate(coinPrefab));
            coinPrefab.SetActive(false);
        }
        for (int i = 0; i < 20; i++)
        {
            GameObject b = GameObject.Find("CoinPool");
            GameObject a = pooledcoin[i];
            a.transform.parent = b.transform;
        }

    }
    public GameObject Get()
    {
        coinIndex %= pooledcoin.Count;
        var result = pooledcoin[coinIndex++];
        if (!result.activeInHierarchy)
        {
            return result;
        }
        else
        {
            //add one more
            pooledcoin.Add(Instantiate(coinPrefab));
            return coinPrefab;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
