using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] crystals = GameObject.FindGameObjectsWithTag("EXP");
            foreach(GameObject crystal in crystals)
            {
                float distance = Vector3.Distance(player.transform.position, crystal.transform.position);
                if(distance <= 8.6)
                {
                    Destroy(crystal);
                    player.AddExp();
                }
                
            }
            Destroy(gameObject);
                      
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
