using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 5f;
    void Start()
    {
      
    }

    // Update is called once per frame

    void Update()
    {

        timer -= Time.deltaTime;
        transform.position += transform.up * 10 * Time.deltaTime;
         if (timer <= 0f)
            {
                timer = 5f;
                gameObject.SetActive(false);
            }

    }

}
