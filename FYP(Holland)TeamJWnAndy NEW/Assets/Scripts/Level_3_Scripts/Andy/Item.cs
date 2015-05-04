using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
    public GameObject Buttons;

    public enum ItemType
    {
        ITEM_DEFAULT,
        ITEM_COIN,
        ITEM_SWORD,
        ITEM_BLOOD,
        ITEM_JEWEL,
        ITEM_LETHEWATER,
        ITEM_BONE,
        ITEM_SALIVA,
        ITEM_LYRE,
        ITEM_COMB
    } public ItemType IType = ItemType.ITEM_DEFAULT;

    bool MouseHovering = false;         // Detect if mouse is hovering over the item
    public bool Delete = false;         // Flag to detect if item is to be deleted 
    public int ID = -1, Slot = -1;      // All Item have own ID and own Slot index (negative stand for null)
    public Vector3 StoragePos = Vector3.zero, StorageScale = new Vector3(1,1,1);
    public Sprite StorageSprite;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Global.CurrentItemType = this.IType;    // Set the type of the item
            Global.CurrentItemID = this.ID;         // Set the ID of the item
		}
        if (col.gameObject.tag == "MOUSE")
        {
            MouseHovering = true;                   // Set Mouse hovering over item
        }
        if (col.gameObject.tag == "Player")
        {
            if (Global.TriggerItemUI)               // Check if the mouse is clicked on the Item
            {
                Buttons.SetActive(true);            // Render the Button
                Global.TriggerItemUI = false;       // Reset flag for the mouse clicking
            }
        }
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MOUSE")
        {
            MouseHovering = false;
        }
        if (col.gameObject.tag == "Player")
        {
            Buttons.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && MouseHovering) // Right Click
        {
            Delete = true;  // Delete the item
        }

        if (Delete)
            this.gameObject.SetActive(false);

        if (AspectRatio.AspectChanged)
        {
            this.StoragePos = this.transform.position;
        }
    }
}
