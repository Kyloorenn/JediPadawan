using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPool : MonoBehaviour
{
    [SerializeField] GameObject crystalPrefab;
    List<GameObject> pooledcrystal = new List<GameObject>();

    int crystalIndex;
    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            pooledcrystal.Add(Instantiate(crystalPrefab));
            crystalPrefab.SetActive(false);
        }
        for (int i = 0; i < 100; i++)
        {
            GameObject b = GameObject.Find("CrystalPool");
            GameObject a = pooledcrystal[i];
            a.transform.parent = b.transform;
        }

    }
    public GameObject Get()
    {
        crystalIndex %= pooledcrystal.Count;
        var result = pooledcrystal[crystalIndex++];
        if (!result.activeInHierarchy && result != null)
        {
            return result;
        }
        else
        {
            //add one more
            pooledcrystal.Add(Instantiate(crystalPrefab));
            return crystalPrefab;
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
