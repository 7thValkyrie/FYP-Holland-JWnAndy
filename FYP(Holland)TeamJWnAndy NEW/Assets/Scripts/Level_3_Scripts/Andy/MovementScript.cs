using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    bool CollidedNPC = false;                                       // To detect if player is colliding with NPC
    bool allowMovement = true;                                      // To allow the movement of the player
    bool isMoving = false, reallowMovement = false;                 // Check if the player is moving (animation) // To reallow movement after colliding with unwalkable region
    bool flipped = false, facingLeft = false, changeDir = false;    // Check for the player sprite direction
    Vector3 mousePos;                                               // Mouse position (always changing)
    Vector3 travelDir;                                              // For normalized
    Vector3 lastMousePos;                                           // Last mouse position (happen only when you clicked)
    public float MovementSpeed = 3.0f;                              // Movement of the player
    public MouseScript theMouse;                                    
    public GameObject Player;
    public PlayerCollisionScript PlayerCollisionRegion;
    public Sprite PlayerMovingSprite, PlayerIdleSprite;
    public RuntimeAnimatorController PlayerMovingAnimator, PlayerIdleAnimator;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "INTERACTABLE_NPC")
        {
            CollidedNPC = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "INTERACTABLE_NPC")
        {
            CollidedNPC = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        
    }

    public void SetAnimSprite(bool mode)
    {
        if (mode)
        {
            Player.GetComponent<SpriteRenderer>().sprite = PlayerIdleSprite;    // IDLE animation and sprite
            Player.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)PlayerIdleAnimator;
        }

        else
        {
            Player.GetComponent<SpriteRenderer>().sprite = PlayerMovingSprite;  // Move animation and sprite
            Player.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)PlayerMovingAnimator;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Disallow Movment when Game is Paused
        if ((Global.PauseGame || PlayerCollisionRegion.CollidedUnwalkable) && !reallowMovement)
        {
            allowMovement = false;  // Stop movement
        }
        else
        {
            allowMovement = true;   // Resume movement
        }

        //Reset Allow Flag when Player walks out of Unwalkable Region
        if (!PlayerCollisionRegion.CollidedUnwalkable)
        {
            reallowMovement = false;    
        }

        //RayCast Line of Movement
        bool ClearPath = true;
        Color LineColor = Color.green;
        Vector2 Origin, Target;
        Origin = theMouse.gameObject.transform.position;
        Target = PlayerCollisionRegion.transform.position;
        Vector2 RayDir = (Origin - Target).normalized;
        RaycastHit2D []Hit = Physics2D.RaycastAll(Target, RayDir, Vector2.Distance(Origin, Target));
        if (Hit != null)
        {
            foreach (RaycastHit2D hit in Hit)
            {
                if (hit.collider.tag == "UNWALKABLE")
                {
                    LineColor = Color.red;
                    ClearPath = false;
                }
            }
        }
        Debug.DrawLine(Target, Origin, LineColor);

        if (travelDir.x < 0) // Check if sprite is facing left or right
        {
            facingLeft = true;
        }
        else
        {
            facingLeft = false;
        }

        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true; //call this loop once

            //Re-Allow Movement
            if (!theMouse.UnwalkableHover && ClearPath)
            {
                allowMovement = reallowMovement = true; // Mouse must touch walkable region ( Move player )
            }
            else
            {
                reallowMovement = false;                // Stop player
            }

            //Change Mouse Position on GUI to World Coordinates
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            travelDir = mousePos - PlayerCollisionRegion.transform.position;
            travelDir.Normalize();
            lastMousePos = mousePos;
            lastMousePos.z = 0;

            if ((facingLeft && travelDir.x > 0) || (!facingLeft && travelDir.x < 0))
            {
                changeDir = true;   // toggle the direction faced
                flipped = false;
            }
            else
            {
                changeDir = false;
            }

        }// End of Move There Command

        #elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                isMoving = true; //call this loop once

                //Re-Allow Movement
                if (!theMouse.UnwalkableHover && ClearPath)
                {
                    allowMovement = reallowMovement = true; // Mouse must touch walkable region ( Move player )
                }
                else
                {
                    reallowMovement = false;                // Stop player
                }

                //Change Mouse Position on GUI to World Coordinates
                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                travelDir = mousePos - PlayerCollisionRegion.transform.position;
                travelDir.Normalize();
                lastMousePos = mousePos;
                lastMousePos.z = 0;

                if ((facingLeft && travelDir.x > 0) || (!facingLeft && travelDir.x < 0))
                {
                    changeDir = true;   // toggle the direction faced
                    flipped = false;
                }
                else
                {
                    changeDir = false;
                }
            }
        }// End of Move There Command
#endif

        if (PlayerCollisionRegion.transform.position.x != lastMousePos.x && PlayerCollisionRegion.transform.position.y != lastMousePos.y && allowMovement && !Global.StopMovement) // If player is moving and not reached the last mouse position
        {
            if ((lastMousePos - PlayerCollisionRegion.transform.position).sqrMagnitude > 500 && isMoving)   // Collision between player's leg and last mouse position
            {
                this.transform.Translate(travelDir.x * MovementSpeed, travelDir.y * MovementSpeed, 0);      // Move the player
                //	PlayerCollisionRegion.transform.Translate (travelDir.x * MovementSpeed, travelDir.y * MovementSpeed, this.transform.position.z);
            }
            else if ((lastMousePos - PlayerCollisionRegion.transform.position).sqrMagnitude <= 500 && isMoving) // Reached the last mouse position
            {
                isMoving = false;           // Stop moving
                reallowMovement = false;
            }
        }

        //Set Player Sprite & Animation to IDLE if Game is Paused
        if (!allowMovement || Global.StopMovement)
        {
            SetAnimSprite(true);
        }

        //Toggle Player Animation
        if (isMoving)
        {
            if (allowMovement && !Global.StopMovement)
            {
                SetAnimSprite(false);
            }

            if (changeDir && !flipped)  // Direction of sprite
                flipped = true;
        }
        else
        {
            if (allowMovement && !Global.StopMovement)
            {
                Player.GetComponent<SpriteRenderer>().sprite = PlayerIdleSprite;    // IDLE sprite and animation
                Player.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)PlayerIdleAnimator;
            }

            lastMousePos = Vector3.zero; // reset to vector (0,0,0)
            flipped = false;             // reset the flip
        }

        Vector3 tempScale = Player.GetComponent<SpriteRenderer>().transform.localScale;
        if (facingLeft)
        {
            if (tempScale.x > 0)
                tempScale.x = -tempScale.x;
        }
        else
            tempScale.x = Mathf.Abs(tempScale.x);
        Player.GetComponent<SpriteRenderer>().transform.localScale = tempScale;
    }

}
