using UnityEngine;
using System.Collections;
using System;

public class Inventory : MonoBehaviour {
    public bool visible = false;
    public HeroCamera heroCamera;
    public HeroMotor heroMotor;
    public Inventory inventory;
    public Rect windowRect = new Rect(20, 20, 120, 50);
    public Rect buttonRect = new Rect(0, 0, 32, 32);
    public GUIStyle guiStyle = GUIStyle.none;
    public float slowTime = 0.0F;
    public float normalTime = 1.0F;
    public float tempXSpeed = 200;
    public float tempYSpeed = 200;
    public Item[] items = new Item[128];
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = null;
        }
    }
    public void Pause() {
        // Slow Time
        Time.timeScale = slowTime;

        // Off Controls
        if (heroCamera.xSpeed > 0 && heroCamera.ySpeed > 0) {
            tempXSpeed = heroCamera.xSpeed;
            tempYSpeed = heroCamera.ySpeed;
        }
        heroMotor.canMove = false;
        heroCamera.xSpeed = 0.0F;
        heroCamera.ySpeed = 0.0F;
        Screen.lockCursor = false;
        Cursor.visible = true;
    }
    public void Unpause() {
        // Normal Time
        Time.timeScale = normalTime;

        // Enable Controls
        if (tempXSpeed > 0 && tempYSpeed > 0) {
            heroCamera.xSpeed = tempXSpeed;
            heroCamera.ySpeed = tempYSpeed;
        }
        heroMotor.canMove = true;
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {

            visible = !visible;
            
            if (visible) {
                Pause();

            } else {
                // Return to normal
                Unpause();
            }
        }
    }

    void OnGUI() {
        if (visible) {
            windowRect = GUI.Window(0, windowRect, WindowFunction, "Inventory");
        }
    }
    void WindowFunction(int windowID)
    {
        Rect tempRect = buttonRect;
        int y = 1;
        int x = 1;
        for (int i = 0; i < items.Length; i++)
        {
            if (y < 8)
            {
                if (x < 16)
                {
                    tempRect.x = (x * 32);
                    if (GUI.Button(tempRect, items[i].gameObject.name,guiStyle))
                    {
                        //drop item
                        items[i].gameObject.SetActive(true);
                        Instantiate(items[i].gameObject, new Vector3(gameObject.transform.position.x+10, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
                        items[i] = null; 
                    }
                    x++;
                }
                else
                {
                    tempRect.y = (y * 32);
                    y++;
                    x = 0;
                }
            }
            else
            {
                tempRect.x = (x * 32);
                x++;
                y = 0;

            }
            

            /*
            for (int y=0; y < 4; y++)
            {
                tempRect.y += y * 32;
                for (int x=0; x < 4; x++)
                {
                    tempRect.x += x * 32;
                    GUI.Button(tempRect, items[i].gameObject.name);
                }
            }
            */
            //Debug.Log(items[i].gameObject.name);
        } 
    }

    void OnMouseDown() {
        //Screen.lockCursor = true;
    }

}

