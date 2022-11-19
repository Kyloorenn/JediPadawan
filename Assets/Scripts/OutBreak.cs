using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBreak : MonoBehaviour
{
    [SerializeField] Player player;
    private ParticleSystem ps;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, -3f, 0);


    }
}
