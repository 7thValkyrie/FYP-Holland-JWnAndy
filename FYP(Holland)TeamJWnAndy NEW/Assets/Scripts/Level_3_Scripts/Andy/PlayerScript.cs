using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public Transform[] PlayerLastPos;

    // Use this for initialization
    void Start()
    {
        if (Global.CurrentPosID != -1 && PlayerLastPos.Length > Global.CurrentPosID)
            this.transform.position = PlayerLastPos[Global.CurrentPosID].position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
