using UnityEngine;
using System.Collections;

public class Journal : MonoBehaviour
{
    public bool visible = false;
    public Rect windowRect = new Rect(20, 20, 120, 50);
    public Inventory inventory;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            visible = !visible;
            if (visible)
            {
                inventory.Pause();
            }
            else
            {
                // Return to normal
                inventory.Unpause();
            }
        }
    }

    void OnGUI()
    {
        if (visible)
        {
            windowRect = GUI.Window(0, windowRect, WindowFunction, "Journal");
        }
    }
    void WindowFunction(int windowID)
    {

        // Draw any Controls inside the window here
        //GUI.Label(new Rect(10, 40, 100, 20), GUI.tooltip);
    }
}
