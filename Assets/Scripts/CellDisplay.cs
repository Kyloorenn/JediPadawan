using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CellDisplay : MonoBehaviour
{      
    public Inventory.itemList thisItem;
    public int thisitemNumber = 0;
    public Image artDisplay;
    public Sprite[] artIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        artDisplay.gameObject.SetActive(thisitemNumber > 0);
        artDisplay.sprite = artIcon[(int)thisItem];
    }
}
