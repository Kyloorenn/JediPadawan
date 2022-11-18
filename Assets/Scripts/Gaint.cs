using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Gaint : MonoBehaviour
{   
    // enum GaintState : int
    //{
    //    Idle = 0,
    //    Chasing = 1,
    //    Attacking = 2
    //}

    //GiantState giantState = GaintState.Idle;
    //private Animator animator;
    //float waitTimer = 2f;
    //// Start is called before the first frame update
    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
          
    //}

    //// Update is called once per frame
    //private void Update()
    //{
    //    switch (giantState)
    //    {
    //        case GaintState.Idle:
    //            waitTimer -= Time.deltaTime;
    //            if(waitTimer  <= 0)
    //            {
    //                giantState = GaintState.chasing;
    //            }
    //            break;
    //        case GaintState.Chasing:
               
    //            float distance = Vector3.Distance(transform.position, player.transform.position);
    //            animator.SetBool("Iswalking", true);
    //           if(distance < 5f)
    //            {
    //                giantState = GiantState.Attacking;
    //            }
    //            break;
    //        case GiantState.Attacking:
    //            animator.SetBool("Iswalking", false);
    //            animator.SetTrigger("Attack");
    //            giantState = GaintState.Attacking;
    //            break;
            
    //    }
    //}

    
}
