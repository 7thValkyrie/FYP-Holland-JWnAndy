using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour 
{
	// For Pause
	public PauseScript PS;

	// *** Global Variables *** //
	public static bool PauseGame = false;                                           // bool to pause the game
    public static bool TriggerDialogue = false;                                     // When to trigger dialogue
    public static bool TriggerItemUI = false;                                       // When to pick up the item
    public static bool StopMovement = false;                                        // When to disable the player movement
	private static bool Render = true;                                              // When to display the pause menu
	public static Item.ItemType CurrentItemType = Item.ItemType.ITEM_DEFAULT;       // Detect the type of item, the player is currently taking
    public static int CurrentItemID = -1;                                           // Detect which item to be deleted
    public static int ItemsCount = 0;                                               // Total numbber of item collected
    public static int CurrentPosID = -1;                                            // Player position stored for each scene
    public static List<Item> GlobalItemsList = new List<Item>();

    public static bool Minigame_Win = false;

	// Update Function
	void Update()
	{
		if (PauseGame)
		{
			PS.gameObject.SetActive (Render);   // Render the Pause Menu
		} 
		else 
		{
			PS.gameObject.SetActive(false);     // Do not Render the Pause Menu
		}
	}

	public static void SetPause(bool bPause, bool bRender = true)   // Function to trigger the pause game
	{
		PauseGame = bPause;
		Render = bRender;
	}
}
