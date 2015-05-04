using UnityEngine;
using System.Collections;

public class LevelTransitionScript : MonoBehaviour 
{
    public string Scene;
    public int TriggerID = -1;
    public FadingScript fade;

    public Item.ItemType Requirement = Item.ItemType.ITEM_DEFAULT;

    void Start()
    {
    }

    void OnTriggerStay2D(Collider2D col)
    {
        bool Proceed = false;
        if (Requirement == Item.ItemType.ITEM_DEFAULT)
            Proceed = true;
        else
        {
            for (int i = 0; i < Invent.Instance.ItemsList.Count; ++i)
            {
                if (Invent.Instance.ItemsList[i].IType == Requirement)
                    Proceed = true;
            }
        }

        if (col.gameObject.tag == "Player" && Proceed || col.gameObject.tag == "odysseyFW")
        {
            Global.CurrentPosID = TriggerID;

            Global.GlobalItemsList.Clear();
            Debug.Log("COUNT: " + Invent.Instance.ItemsList.Count);
            for (short i = 0; i < Invent.Instance.ItemsList.Count; ++i)
            {
                Item NewItem = new Item();
                NewItem.StoragePos = Invent.Instance.ItemsList[i].transform.localPosition;
                NewItem.StorageSprite = Invent.Instance.ItemsList[i].StorageSprite;
                NewItem.StorageScale = Invent.Instance.ItemsList[i].transform.localScale;
                NewItem.IType = Invent.Instance.ItemsList[i].IType;                                                // Set the type of the item
                NewItem.ID = Invent.Instance.ItemsList[i].ID;                                                      // Set te ID of the item
                NewItem.Slot = Invent.Instance.ItemsList[i].Slot;                                                  // Set which slot to create
                Global.GlobalItemsList.Add(NewItem);
            }

            fade.gameObject.SetActive(true);
            fade.FadeType = FadingScript.EFade.FADE_IN;
            if (fade.Faded)
                Application.LoadLevel (Scene);
        }
    }
}
