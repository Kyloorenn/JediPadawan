using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    //public float speed = 10f;
    //public float rotateSpeed = 2f;
    //public float tuning = 0.2f;  
    //public Rigidbody2D rb2d;
    //private Transform playerTransform;
    //private Transform daggerTransform;
    //private Vector2 startSpeed;
    //private Vector2 x;
    //private Vector2 y;
    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        //rb2d.velocity = -transform.right * speed;
        //startSpeed = rb2d.velocity;
        //playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //daggerTransform = GetComponent<Transform>();
        //float x = (playerTransform.position.x - daggerTransform.position.x);
        //float y = (playerTransform.position.y - daggerTransform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.up * 8 * Time.deltaTime;
        //transform.Rotate(0, 0, 2f);
        //float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        //transform.position = new Vector3(transform.position.x, y, 0.0f);
        //rb2d.velocity = rb2d.velocity - startSpeed * Time.deltaTime * 1.5f;
        Destroy(gameObject, 3f);
    }
}
