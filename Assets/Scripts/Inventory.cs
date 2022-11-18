using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    //A list of all items in the game
    public enum itemList
    {
        none = 0,
        coins = 1,
        LightSaber = 2,
        HealthPotion = 3,
        JediToken = 4,
    }
    public Transform InventoryBag;
    public CellDisplay InventoryCell;
    public int cellNumber = 12;
    public bool getCoin;
    GoldCoin goldCoin;
    Player player;
    //public List<itemList> inventoryItems = new List<itemList>();
    //public List<int> itemNumber = new List<int>();
    public List<CellDisplay> AllInventoryCell = new List<CellDisplay>();
    
    //Increase cells in player's inventory
    public void ChangeCell(int cellNumber)
    {   
        for(int i = 0; i < cellNumber; i++)
        {
            AllInventoryCell.Add(Instantiate(InventoryCell, InventoryBag));
            AllInventoryCell[AllInventoryCell.Count - 1].gameObject.SetActive(true);
        } 
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Player's inventory
        ChangeCell(cellNumber);
        goldCoin = GetComponent<GoldCoin>();
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        //if(getCoin == true )
        //{   
        //    for(int i = 0; i < AllInventoryCell.Count; i++)
        //    {
        //        if (AllInventoryCell[i].thisItem == itemList.none)
        //        {
        //            AllInventoryCell[i].thisItem = GetComponent<GoldCoin>().coinItem;
        //            AllInventoryCell[i].thisitemNumber = player.coins;
        //            break;
        //        }
        //    }
            
        //}
    }
}
