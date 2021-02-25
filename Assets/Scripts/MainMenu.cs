using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Rect play, load, settings, exit;

    // Use this for initialization
    void Start()
    {
        //Set Cursor to be visible
        Cursor.visible = true;
    }

    void OnGUI()
    {
        if (GUI.Button(play, "Начать игру"))
            SceneManager.LoadScene(1);

        if (GUI.Button(load, "Загрузить игру"))
            Debug.Log("Clicked Загрузить игру");

        if (GUI.Button(settings, "Настройки"))
            Debug.Log("Clicked Настройки");

        if (GUI.Button(exit, "Выход из игры"))
            Application.Quit();
    }
}
