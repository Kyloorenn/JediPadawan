using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider2D;
    public AudioSource pickcoin;
    GameObject player;
    public float speed = 0.2f;
    public Inventory.itemList coinItem;
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;           
            player.AddCoin(1);
            pickcoin.Play();           
            Destroy(gameObject,1f);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
       
    }

    // Update is called once per frame
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
