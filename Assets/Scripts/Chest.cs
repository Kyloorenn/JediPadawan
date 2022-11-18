using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;
    GameObject player;
    public AudioSource pickcoin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            Destroy(gameObject,1f);
            pickcoin.Play();
            player.AddCoin(100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
