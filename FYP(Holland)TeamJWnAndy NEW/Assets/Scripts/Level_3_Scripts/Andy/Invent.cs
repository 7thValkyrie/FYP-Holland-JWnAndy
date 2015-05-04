using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invent : MonoBehaviour 
{
    //Singleton Structure
    protected static Invent mInstance;
    public static Invent Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<Invent>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }

    void Awake() 
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy(this.gameObject);
            return;
         } 
         else 
         {
             mInstance = this;
         }
        DontDestroyOnLoad(this.gameObject);
    }

    public List<Item> ItemsList = new List<Item>();     // Create a list of item
    public GameObject[] Slot;                           // Create storage for the item to hold
    private int UniqueID = 0;                           // Each item have their own unique ID (so that can access the item easily)
    public Sprite[] ListOfSprites;                      // Create sprite for the item
    public AspectRatio AspectParent;

    public Item InstantiatedItem;

	// Use this for initialization
	void Start () 
    {
        //if (mInstance == null)
            mInstance = this;
        Debug.Log("Invent Start");

        ItemsList.Clear();
        for (short i = 0; i < Global.GlobalItemsList.Count; ++i)
        {
            Item NewItem = Instantiate(InstantiatedItem, Global.GlobalItemsList[i].StoragePos, Quaternion.identity) as Item; // Create the item in the storage
            NewItem.transform.parent = AspectParent.transform;
            NewItem.transform.localScale = Global.GlobalItemsList[i].StorageScale;
            NewItem.transform.localPosition = Global.GlobalItemsList[i].StoragePos;
            NewItem.StoragePos = Global.GlobalItemsList[i].StoragePos;
            NewItem.GetComponent<SpriteRenderer>().sprite = NewItem.StorageSprite = Global.GlobalItemsList[i].StorageSprite;
            NewItem.IType = Global.GlobalItemsList[i].IType;                                                             // Set the type of the item
            NewItem.ID = Global.GlobalItemsList[i].ID;                                                             // Set te ID of the item
            NewItem.Slot = Global.GlobalItemsList[i].Slot;                                                  // Set which slot to create
            ItemsList.Add(NewItem);
        }
	}

    public Sprite DetermineSprite(Item.ItemType IType)      // Function to determine which sprite belong to the item
    {
        return ListOfSprites[(int)IType];
    }

    public bool AddItem(Item.ItemType IType)                // Function to add item
	{
        if (ItemsList.Count < 6)                            // Make sure storage will no exceed 6
        {
            ++UniqueID;                                     // Generate a new unique ID

            Item TempItem = Instantiate(InstantiatedItem, Slot[ItemsList.Count].gameObject.transform.position, Quaternion.identity) as Item; // Create the item in the storage
            TempItem.StoragePos = Slot[ItemsList.Count].gameObject.transform.position;
            TempItem.transform.localScale = AspectParent.SetObjScale(TempItem.gameObject);
            TempItem.transform.parent = AspectParent.transform;
            TempItem.IType = IType;                                                             // Set the type of the item
            TempItem.ID = UniqueID;                                                             // Set te ID of the item
            TempItem.Slot = ItemsList.Count+1;                                                  // Set which slot to create
            TempItem.GetComponent<SpriteRenderer>().sprite = TempItem.StorageSprite = DetermineSprite(TempItem.IType);   // Render the correct sprite of the item 
            ItemsList.Add(TempItem);                                                            // Add into the List (to increase the storage)
            Global.ItemsCount = ItemsList.Count;                                                // Set the item count in the storage

            Debug.Log("Item Added! Item: " + (int)IType);
            Debug.Log("Total Item Count: " + Global.ItemsCount);

            return true;
        }
        return false;
	}

    public void DeleteItem(int ItemSlot)                                                // Delete the item
    {
        bool Push = false;                                                              // After deleting the item, push the following item forward
        if (ItemSlot-1 < ItemsList.Count)                                               // Make sure that there is item in the storage
        {
            Debug.Log("Item Deleted! Item: " + (int)ItemsList[ItemSlot - 1].IType);
            //Destroy(ItemsList[ItemSlot - 1].gameObject);                                // Delete the gameobject
            ItemsList[ItemSlot - 1].gameObject.SetActive(false);
            ItemsList.Remove(ItemsList[ItemSlot - 1]);                                  // Remove from the List (to decrease the storage)
            Global.ItemsCount = ItemsList.Count;                                        // Set the item count in the storage   
            Debug.Log("Total Item Count: " + Global.ItemsCount);
            Push = true;                                                                // Push the following item forward
        }

        if (Push)
        {
            //Push Back all other Items
            for (int i = 0; i < ItemsList.Count; ++i)       // Loop through the list
            {
                if (ItemsList[i].Slot > ItemSlot)           // Push back all item after the deleted item 
                {
                    --ItemsList[i].Slot;                    // Decrease item's slot
                    ItemsList[i].transform.position = Slot[ItemsList[i].Slot-1].gameObject.transform.position;  // Move the Sprite
                }
            }
            Push = false;                                   // Make sure that the item is pushed once
        }
    }

    // Update is called once per frame
    void Update()
    {
        int SlotToDelete = -1;                          // Detect if there is item
        for (int i = 0; i < ItemsList.Count; ++i)       // Loop through the storage
        {
            if (ItemsList[i].Delete)                    // Check if deleting the item
            {   
                SlotToDelete = ItemsList[i].Slot;       // Set the slot to be deleted
                break;
            }
        }
        
        //Something needs to be deleted
        if (SlotToDelete != -1)
        {
            DeleteItem(SlotToDelete);                   // Delete the item from the storage
        }
    }
}
