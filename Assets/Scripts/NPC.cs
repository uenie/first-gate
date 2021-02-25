using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
    public bool near = false;

    public bool showButton = true;
    public Rect talkButtonRect;
    public bool testDialogWindow = true;
    public Rect dialogWindowRect;
    public Rect dialogWindowRect_2;

    public bool dialog = true;
    public bool dialog2 = false;
    public bool dialog3 = false;

    void OnGUI()
    {
        //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a title");
        if (near && showButton && testDialogWindow)
        {
            if (dialog && !dialog2 && !dialog3)
            {
                if (GUI.Button(talkButtonRect, "Talk to NPC"))
                {
                    dialog = false;
                    dialog2 = true;
                    dialog3 = true;
                }
            }
            if (dialog2)
            {
                if (GUI.Button(dialogWindowRect, "Some Dialog 2"))
                {
                    dialog = true;
                    dialog2 = false;
                    dialog3 = false;
                }
            }
            if (dialog3)
            {
                if (GUI.Button(dialogWindowRect_2, "Some Dialog 3"))
                {
                    dialog = true;
                    dialog2 = false;
                    dialog3 = false;
                }
            }
        }
    }
	void Start () {
	
	}
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            near = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            near = false;
        }
    }


}
