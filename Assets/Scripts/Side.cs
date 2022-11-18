using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Side : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] GameObject enemy;
    [SerializeField] SpriteRenderer EnemyspriteRenderer;


    GameObject player;
    public int EnemyHealth;
    bool EnemyInvincible = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    internal void Damage(int damage)
    {
        if (EnemyInvincible == false)
        {
            StartCoroutine(Invincible());

            EnemyHealth -= damage;
            if (EnemyHealth <= 0)
            {
                Destroy(enemy);
            }
        }
    }

    IEnumerator Invincible()
    {


        EnemyInvincible = true;
        EnemyspriteRenderer.color = UnityEngine.Color.red;
        yield return new WaitForSeconds(0.3f);
        EnemyspriteRenderer.color = UnityEngine.Color.white;

        EnemyInvincible = false;



    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        transform.position += new Vector3(1.5f, 0f, 0f)* Time.deltaTime* speed;
    }

   
}
