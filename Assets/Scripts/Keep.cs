using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject maincamera;
    [SerializeField] GameObject gameRecord;
    [SerializeField] GameObject bulletpool;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(player1);
        DontDestroyOnLoad(player2);
        DontDestroyOnLoad(maincamera);
        DontDestroyOnLoad(gameRecord);
        DontDestroyOnLoad(bulletpool );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
