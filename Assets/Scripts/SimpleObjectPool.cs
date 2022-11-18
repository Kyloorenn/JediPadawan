using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    List<GameObject> pooledObjects = new List<GameObject>();

    int objectIndex;

    private void Awake()
    {
        for(int i = 0; i <1000; i++)
        {   
            pooledObjects.Add(Instantiate(bulletPrefab));           
        }
        for (int i = 0; i < 1000; i++)
        {
            GameObject b = GameObject.Find("ObjectPool");
            GameObject a = pooledObjects[i];
            a.transform.parent = b.transform;

        }

    }

    public GameObject Get()
    {
        //if(objectIndex >= pooledObjects.Count)
        //{
        //     objectIndex = 0;
        //}
        objectIndex %= pooledObjects.Count;
        var result = pooledObjects[objectIndex++];
        if (!result.activeInHierarchy)
        {
            return result;
        }
        else
        {   
            //add one more
            pooledObjects.Add(Instantiate(bulletPrefab));
            return bulletPrefab;
        }
    }


    public GameObject Get(Vector3 position, Quaternion rotation)
    {
        //if(objectIndex >= pooledObjects.Count)
        //{
        //     objectIndex = 0;
        //}
        objectIndex %= pooledObjects.Count;
        var result = pooledObjects[objectIndex++];
        result.transform.position = position;
        result.transform.rotation = rotation;
        result.SetActive(true);
        if (!result.activeInHierarchy)
        {
            return result;
        }
        else
        {
            //add one more
            pooledObjects.Add(Instantiate(bulletPrefab));
            return bulletPrefab;
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
