using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
    public bool visible = false;
    public Inventory inventory;
    //public Rect windowRect = new Rect(20, 20, 120, 50);
    public Camera mapCamera;
    public Canvas mapCanvas;
    public Rect viewportRect;

    void Update()
    {
        //mapCamera.rect = viewportRect;
        //mapCamera.rect = new Rect(0.25F, 0.25F, 0.5F, 0.5F);
        //mapCamera.rect = mapCanvas.pixelRect;
        //mapCamera.pixelRect = mapCanvas.pixelRect;
        if (Input.GetKeyDown(KeyCode.M))
        {
            visible = !visible;
            if (visible)
            {
                inventory.Pause();
                mapCamera.enabled = true;
                mapCanvas.gameObject.SetActive(true);
            }
            else {
                // Return to normal
                inventory.Unpause();
                mapCamera.enabled = false;
                mapCanvas.gameObject.SetActive(false);
            }
            //Debug.Log("mapCanvas.pixelRect: " + mapCanvas.pixelRect);
            //Debug.Log("mapCamera.pixelRect: " + mapCamera.pixelRect);

        }
    }
    void OnGUI()
    {
        if (visible)
        {
            //windowRect = GUI.Window(0, windowRect, WindowFunction, "Map");
        }
    }
    void WindowFunction(int windowID)
    {

        // Draw any Controls inside the window here
        //GUI.Label(new Rect(10, 40, 100, 20), GUI.tooltip);
    }
}
