using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    List<GameObject> pooledProjectiles = new List<GameObject>();

    int projectileIndex;

    private void Awake()
    {
        for (int i = 0; i < 300; i++)
        {
            pooledProjectiles.Add(Instantiate(projectilePrefab));
        }
        for (int i = 0; i < 300; i++)
        {
            GameObject b = GameObject.Find("ProjectilePool");
            GameObject a = pooledProjectiles[i];
            a.transform.parent = b.transform;

        }

    }
    public GameObject GetP()
    {

        projectileIndex %= pooledProjectiles.Count;
        var result = pooledProjectiles[projectileIndex++];
        if (!result.activeInHierarchy)
        {
            return result;
        }
        else
        {
            //add one more
            pooledProjectiles.Add(Instantiate(projectilePrefab));
            return projectilePrefab;
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
