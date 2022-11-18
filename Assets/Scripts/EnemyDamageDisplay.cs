using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class EnemyDamageDisplay : MonoBehaviour
{

    public static EnemyDamageDisplay Create(Vector3 position, int damageAmount)
    {
        Transform damagedisplayTransform = Instantiate(GameAssets.i.DamageDisplay, position, Quaternion.identity);
        EnemyDamageDisplay damagedisplay = damagedisplayTransform.GetComponent<EnemyDamageDisplay>();
        damagedisplay.Setup(damageAmount);
        return damagedisplay;
    }
   private TMP_Text textMesh;
    private void Awake()
    {
        textMesh = transform.GetComponent<TMP_Text>();
    }
   public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }
   
   void Start()
    {
        
    } 
  
       // Update is called once per frame
            void Update()
    {
        float moveSpeed = 2f;
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;
    }
}
