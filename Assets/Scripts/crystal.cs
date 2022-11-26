using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class crystal : MonoBehaviour
{
   
    GameObject player;
  private float speed = 0.5f;
    GameRecord gameRecord;
    // Start is called before the first frame update

    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player");
        gameRecord = GameObject.FindGameObjectWithTag("Record").GetComponent<GameRecord>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            gameRecord.exp_gained += 20;
            player.AddExp();
            gameObject.SetActive(false);
            
        }
    }
   
    void Update()
    {

        
        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;
        Vector3 direction = destination - source;
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;
        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
        
       
    }
}
