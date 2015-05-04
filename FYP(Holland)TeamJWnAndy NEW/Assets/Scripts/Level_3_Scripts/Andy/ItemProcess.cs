using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemProcess : MonoBehaviour
{
    public static List<Item> ListOfItemsInWorld_Static = new List<Item>(); // All the item in the world (All Scene)
    public Item[] ListOfItemsInWorld;                                      // All the item in the world (Own Scene)
	
    void Start()
    {
        for (int i = 0; i < ListOfItemsInWorld.Length; ++i)     // Loop through the size of the item (Own Scene)
        {
            ListOfItemsInWorld[i].ID = -2 * (i + 1);                // Generates a unique World ID (this is the item ID) - Own Scene

            bool Unique = true;                                 // Check if there is any one item is similar
            for (int j = 0; j < ListOfItemsInWorld_Static.Count; ++j)  // Loop through the item in the world (All Scene)
            {
                if (ListOfItemsInWorld_Static[j].ID == ListOfItemsInWorld[i].ID) // Check if ID (All Scene) is same as ID (Own Scene)
                {
                    Unique = false;

                    if (ListOfItemsInWorld_Static[j].Delete)    // Detect if deleting the item (All Scene)
                    {
                        ListOfItemsInWorld[i].gameObject.SetActive(false);
                    }
                }
            }
            if (Unique)
            {
                ListOfItemsInWorld_Static.Add(ListOfItemsInWorld[i]); // Add the item into the inventory (All Scene)
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)   
	{
		if (col.gameObject.tag == "INTERACTABLE_ITEM")
		{
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "INTERACTABLE_OBJECT")
		{
		}
	}

    public void Collect()
    {
        Global.StopMovement = true;                                        // Stop the movement of the player

        if (Invent.Instance.AddItem(Global.CurrentItemType))                     // Check if the item is added
        {
            for (int i = 0; i < ListOfItemsInWorld.Length; ++i)            // Loop through the item size
            {
                if (ListOfItemsInWorld[i].ID == Global.CurrentItemID)      // Check if the unique ID is being collected then delete it afterward
                {
                    //Destroy(ListOfItemsInWorld[i].gameObject);
                    ListOfItemsInWorld[i].Delete = true;

                    for (int j = 0; j < ListOfItemsInWorld_Static.Count; ++j)
                    {
                        if (ListOfItemsInWorld_Static[j].ID == Global.CurrentItemID)
                            ListOfItemsInWorld_Static[j].Delete = true;
                    }
                    break;
                }
            }
        }

        Global.StopMovement = false;                                   // Reset the movement of the player to move
    }
}
