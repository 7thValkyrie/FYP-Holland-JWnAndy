using UnityEngine;
using System.Collections;

public class GearScript : MonoBehaviour
{
	public DoorScript[] Door;
	public float clickTimer = 0.0f;
	private const int MAX_DOOR = 3;
	private int[] destroyIndex = new int[MAX_DOOR];
	private int currentIndex = 0;
	public ParticleSystem[] gearLightBig = new ParticleSystem[2];
	public ParticleSystem[] gearLightSmall = new ParticleSystem[2];
    public float timer = 0.0f;
	public Sprite[] Tex = new Sprite[2];


	void Start()
	{
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[0];
		for (int i = 0; i < MAX_DOOR; ++i)
		{
			destroyIndex[i] = -1;
		}
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "MOUSE")
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == Tex[0])
            {
                gearLightBig[0].Play();
                gearLightSmall[0].Play();

                gearLightBig[1].Stop();
                gearLightSmall[1].Stop();
            }
            else
            {
                gearLightBig[0].Stop();
                gearLightSmall[0].Stop();

                gearLightBig[1].Play();
                gearLightSmall[1].Play();
            }

            #if UNITY_STANDALONE || UNITY_EDITOR
            // Mouse click
            if (Input.GetMouseButtonDown(0))
            {
                clickTimer = 3.0f;
                timer = 0.2f;

                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == Tex[0])
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[1];
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[0];
                }

                for (int i = 0; i < Door.Length; ++i)   
                {
                    bool proceed = true;

                    Door[i].isMoved = !Door[i].isMoved;

                    // if door is parent
                    if (Door[i].isParent)
                    {
                        for (int j = 0; j < Door[i].Child.Length; ++j)
                        {
                            //check if child is active
                            if (Door[i].Child[j].gameObject.activeSelf)
                            {
                                //Who has higher piority
                                if (Door[i].Child[j].priority > Door[i].priority)
                                {
                                    proceed = false;
                                }
                            }
                        }
                    }

                    if (proceed)
                    {
                        //If door is child
                        if (Door[i].isChild)
                        {
                            bool allChildDead = true;

                            // Loop through own parent's child
                            for (int j = 0; j < Door[i].Parent.Child.Length; ++j)
                            {
                                // check if all child are active
                                if (Door[i].Parent.Child[j].gameObject.activeSelf)
                                {
                                    allChildDead = false;
                                }
                            }

                            // reset parent to "normal" red door
                            if (allChildDead)
                            {
                                Door[i].Parent.isChild = false;
                                Door[i].Parent.isParent = false;
                            }
                        }

                        if (Door[i].gameObject.activeSelf)
                        {
                            destroyIndex[currentIndex] = i;
                            ++currentIndex;

                            Door[i].Stop = false;
                        }
                        else
                        {
                            Door[i].gameObject.SetActive(true);

                            if (Door[i].Dir == DoorScript.TransDir.LEFT)
                            {
                                Door[i].gameObject.transform.Translate(new Vector3(0.2f, 0, 0));
                            }
                            else
                            {
                                Door[i].gameObject.transform.Translate(new Vector3(-0.2f, 0, 0));
                            }

                            destroyIndex[currentIndex] = i;
                            ++currentIndex;

                            //Check if Door is Child
                            if (Door[i].isChild)
                            {
                                //Set it back to Parent Door
                                if (Door[i].Parent.gameObject.activeSelf)
                                {
                                    Door[i].Parent.isParent = true;
                                }
                            }
                        }
                    }
                }
            }
        #elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                clickTimer = 3.0f;
                timer = 0.2f;

                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == Tex[0])
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[1];
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[0];
                }

                for (int i = 0; i < Door.Length; ++i)   
                {
                    bool proceed = true;

                    Door[i].isMoved = !Door[i].isMoved;

                    // if door is parent
                    if (Door[i].isParent)
                    {
                        for (int j = 0; j < Door[i].Child.Length; ++j)
                        {
                            //check if child is active
                            if (Door[i].Child[j].gameObject.activeSelf)
                            {
                                //Who has higher piority
                                if (Door[i].Child[j].priority > Door[i].priority)
                                {
                                    proceed = false;
                                }
                            }
                        }
                    }

                    if (proceed)
                    {
                        //If door is child
                        if (Door[i].isChild)
                        {
                            bool allChildDead = true;

                            // Loop through own parent's child
                            for (int j = 0; j < Door[i].Parent.Child.Length; ++j)
                            {
                                // check if all child are active
                                if (Door[i].Parent.Child[j].gameObject.activeSelf)
                                {
                                    allChildDead = false;
                                }
                            }

                            // reset parent to "normal" red door
                            if (allChildDead)
                            {
                                Door[i].Parent.isChild = false;
                                Door[i].Parent.isParent = false;
                            }
                        }

                        if (Door[i].gameObject.activeSelf)
                        {
                            destroyIndex[currentIndex] = i;
                            ++currentIndex;

                            Door[i].Stop = false;
                        }
                        else
                        {
                            Door[i].gameObject.SetActive(true);

                            if (Door[i].Dir == DoorScript.TransDir.LEFT)
                            {
                                Door[i].gameObject.transform.Translate(new Vector3(0.2f, 0, 0));
                            }
                            else
                            {
                                Door[i].gameObject.transform.Translate(new Vector3(-0.2f, 0, 0));
                            }

                            destroyIndex[currentIndex] = i;
                            ++currentIndex;

                            //Check if Door is Child
                            if (Door[i].isChild)
                            {
                                //Set it back to Parent Door
                                if (Door[i].Parent.gameObject.activeSelf)
                                {
                                    Door[i].Parent.isParent = true;
                                }
                            }
                        }
                    }
                }
            }
#endif
        }
    }

	void OnTriggerExit2D (Collider2D col)
	{
		if(col.gameObject.tag == "MOUSE")
		{
			gearLightBig[0].Stop();
			gearLightSmall[0].Stop();
            gearLightBig[1].Stop();
            gearLightSmall[1].Stop();
		}
	}

	void Update ()
	{
		if (clickTimer > 0)
		{
			clickTimer -= Time.deltaTime;

			if (clickTimer <= 0)
			{
				clickTimer = 0.0f;
			}
		}

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                this.gameObject.transform.localScale = new Vector2(1.0f, 1.0f);
                timer = 0.0f;
            }
            else
            {
                this.gameObject.transform.localScale = new Vector2(0.9f, 0.9f);
            }
        }

		for (int i = 0; i < MAX_DOOR; ++i)
		{
			if (destroyIndex[i] != -1)
			{
				short Negate = 1;
				if (Door[destroyIndex[i]].Dir == DoorScript.TransDir.LEFT)
				{
					Negate = -1;
				}

				if (!Door[destroyIndex[i]].isMoved)
				{
					Negate *= -1;
				}

				if (Door[destroyIndex[i]].gameObject.activeSelf && Door[destroyIndex[i]].Stop == false)
				{
					Door [destroyIndex[i]].gameObject.transform.Translate (new Vector3(0.05f*Negate, 0, 0));
				}
				else
				{
					destroyIndex[i] = -1;
				}
				currentIndex = 0;
			}
		}

//#if UNITY_STANDALONE || UNITY_EDITOR
//        // Mouse click
//        if (Input.GetMouseButtonDown(0))
//        {
//            clickTimer = 3.0f;

//            //// Mouse movement
//            //Vector3 WorldMousePos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//            //Vector2 MousePos2D = new Vector2 (WorldMousePos3D.x, WorldMousePos3D.y);
//            //Vector2 dir = Vector2.zero;

//            //RaycastHit2D hit = Physics2D.Raycast (MousePos2D, dir);

//            //// if collided with something
//            //if (hit != null && hit.collider != null)
//            //{
//            for (int i = 0; i < Door.Length; ++i)
//            {
//                bool proceed = true;

//                // if collide with gear
//                if (Mouse.transform.collider == this.transform.collider2D)
//                {
//                    Door[i].isMoved = !Door[i].isMoved;

//                    // if door is parent
//                    if (Door[i].isParent)
//                    {
//                        for (int j = 0; j < Door[i].Child.Length; ++j)
//                        {
//                            //check if child is active
//                            if (Door[i].Child[j].gameObject.activeSelf)
//                            {
//                                //Who has higher piority
//                                if (Door[i].Child[j].priority > Door[i].priority)
//                                {
//                                    proceed = false;
//                                }
//                            }
//                        }
//                    }

//                    if (proceed)
//                    {
//                        //If door is child
//                        if (Door[i].isChild)
//                        {
//                            bool allChildDead = true;

//                            // Loop through own parent's child
//                            for (int j = 0; j < Door[i].Parent.Child.Length; ++j)
//                            {
//                                // check if all child are active
//                                if (Door[i].Parent.Child[j].gameObject.activeSelf)
//                                {
//                                    allChildDead = false;
//                                }
//                            }

//                            // reset parent to "normal" red door
//                            if (allChildDead)
//                            {
//                                Door[i].Parent.isChild = false;
//                                Door[i].Parent.isParent = false;
//                            }
//                        }

//                        if (Door[i].gameObject.activeSelf)
//                        {
//                            destroyIndex[currentIndex] = i;
//                            ++currentIndex;

//                            Door[i].Stop = false;
//                        }
//                        else
//                        {
//                            Door[i].gameObject.SetActive(true);

//                            if (Door[i].Dir == DoorScript.TransDir.LEFT)
//                            {
//                                Door[i].gameObject.transform.Translate(new Vector3(0.2f, 0, 0));
//                            }
//                            else
//                            {
//                                Door[i].gameObject.transform.Translate(new Vector3(-0.2f, 0, 0));
//                            }

//                            destroyIndex[currentIndex] = i;
//                            ++currentIndex;

//                            //Check if Door is Child
//                            if (Door[i].isChild)
//                            {
//                                //Set it back to Parent Door
//                                if (Door[i].Parent.gameObject.activeSelf)
//                                {
//                                    Door[i].Parent.isParent = true;
//                                }
//                            }
//                        }
//                    }
//                }
//                //}
//            }
//        }
//#elif UNITY_ANDROID
//        foreach (Touch touch in Input.touches)
//        {
//            if (touch.phase == TouchPhase.Began)
//            {
//                clickTimer = 3.0f;

//                // Mouse movement
//                Vector3 WorldMousePos3D = Camera.main.ScreenToWorldPoint (touch.position);
//                Vector2 MousePos2D = new Vector2 (WorldMousePos3D.x, WorldMousePos3D.y);
//                Vector2 dir = Vector2.zero;

//                RaycastHit2D hit = Physics2D.Raycast (MousePos2D, dir);

//                // if collided with something
//                if (hit != null && hit.collider != null)
//                {
//                    for (int i = 0; i < Door.Length; ++ i)
//                    {
//                        bool proceed = true;

//                        // if collide with gear
//                        if (hit.collider == transform.collider2D)
//                        {
//                            Door[i].isMoved = ! Door[i].isMoved;

//                            // if door is parent
//                            if (Door[i].isParent)
//                            {
//                                for (int j = 0; j < Door[i].Child.Length; ++j)
//                                {
//                                    //check if child is active
//                                    if (Door[i].Child[j].gameObject.activeSelf)
//                                    {
//                                        //Who has higher piority
//                                        if (Door[i].Child[j].priority > Door[i].priority)
//                                        {
//                                            proceed = false;
//                                        }
//                                    }
//                                }
//                            }

//                            if (proceed)
//                            {
//                                //If door is child
//                                if (Door[i].isChild)
//                                {
//                                    bool allChildDead = true;

//                                    // Loop through own parent's child
//                                    for (int j = 0; j < Door[i].Parent.Child.Length; ++j)
//                                    {
//                                        // check if all child are active
//                                        if (Door[i].Parent.Child[j].gameObject.activeSelf)
//                                        {
//                                            allChildDead = false;
//                                        }
//                                    }

//                                    // reset parent to "normal" red door
//                                    if (allChildDead)
//                                    {
//                                        Door[i].Parent.isChild = false;
//                                        Door[i].Parent.isParent = false;
//                                    }
//                                }

//                                if (Door[i].gameObject.activeSelf)
//                                {
//                                    destroyIndex[currentIndex] = i;
//                                    ++currentIndex;
							
//                                    Door[i].Stop = false;
//                                }
//                                else
//                                {
//                                    Door [i].gameObject.SetActive (true);

//                                    if (Door[i].Dir == DoorScript.TransDir.LEFT)
//                                    {
//                                        Door [i].gameObject.transform.Translate(new Vector3(0.2f, 0, 0));
//                                    }
//                                    else
//                                    {
//                                        Door [i].gameObject.transform.Translate(new Vector3(-0.2f, 0, 0));
//                                    }

//                                    destroyIndex[currentIndex] = i;
//                                    ++currentIndex;

//                                    //Check if Door is Child
//                                    if (Door[i].isChild)
//                                    {
//                                        //Set it back to Parent Door
//                                        if (Door[i].Parent.gameObject.activeSelf)
//                                        {
//                                            Door[i].Parent.isParent = true;
//                                        }
//                                    }
//                                }
//                            }
//                        } 
//                    }
//                }
//            }
//        }
//        #endif
    }
}
