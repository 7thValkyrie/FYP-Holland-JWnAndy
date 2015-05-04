using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingScript : MonoBehaviour
{
    public enum EFade
    {
        FADE_IN,
        FADE_OUT
    } public EFade FadeType = EFade.FADE_OUT;

    public bool Faded = false;
    private Image myImage;
    public MovementScript PlayerMovement;

    void Start()
    {
        myImage = GetComponent<Image>();
        PlayerMovement.enabled = false;
    }

    void Update()
    {
        switch (FadeType)
        {
            case EFade.FADE_OUT:

                if (myImage.color.a > 0.1)
                {
                    myImage.color = new Color(0, 0, 0, Mathf.Lerp(myImage.color.a, 0.0f, 2*Time.deltaTime));
                }
                else
                {
                    myImage.color = new Color(0, 0, 0, 0);
                    this.gameObject.SetActive(false);
                    PlayerMovement.enabled = true;
                }
                break;

            case EFade.FADE_IN:

                if (myImage.color.a < 0.9f)
                {
                    PlayerMovement.SetAnimSprite(true);
                    PlayerMovement.enabled = false;
                    myImage.color = new Color(0, 0, 0, Mathf.Lerp(myImage.color.a, 1.0f, 2*Time.deltaTime));
                }
                else
                {
                    myImage.color = new Color(0, 0, 0, 1);
                    PlayerMovement.enabled = true;
                    Faded = true;
                }
                break;
        }
    }
}