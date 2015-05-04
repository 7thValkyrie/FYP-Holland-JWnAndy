using UnityEngine;
using System.Collections;

public class JW_LevelDesign_bitImg : MonoBehaviour {
	private int levelWidth;
	private int levelHeight;
	
	
	//level from Texture
	public Transform stone;
	public Transform ground;
	public Transform lava;
    public Transform ExitCave;
	public Transform Entrance;

	private Color[] tileColor;
	public Color stoneColor;
	public Color groundColor;
	public Color lavaColor;
    public Color ExitCaveColor;
	public Color EntranceColor;

	public Texture2D levelTexture;
	// Use this for initialization
	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadlevel ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void loadlevel	()
	{
		tileColor = new Color [levelWidth * levelHeight];
		tileColor = levelTexture.GetPixels();
		
		for (int y = 0; y < levelHeight; y++) 
		{
			for( int x = 0; x < levelWidth; x++)
			{
				if(tileColor[x+y*levelWidth] == groundColor)
				{
					Instantiate(ground, new Vector3(x, y), Quaternion.identity);
				}
				if(tileColor[x+y*levelWidth] == stoneColor)
				{
					Instantiate(stone, new Vector3(x, y), Quaternion.identity);
				}
				if(tileColor[x+y*levelWidth] == lavaColor)
				{
					Instantiate(lava, new Vector3(x, y), Quaternion.identity);
				}
                if (tileColor[x + y * levelWidth] == ExitCaveColor)
                {
                    Instantiate(ExitCave, new Vector3(x, y), Quaternion.identity);
                }
				if (tileColor[x + y * levelWidth] == EntranceColor)
				{
					Instantiate(Entrance, new Vector3(x, y), Quaternion.identity);
				}
				
			}
		}
	}
}
