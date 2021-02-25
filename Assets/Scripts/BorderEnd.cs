using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BorderEnd : MonoBehaviour
{
    public bool nearPlayer = false;
    public Rect buttonRect;
    public string nextScene;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            nearPlayer = true;
        }
        if (nearPlayer)
        {
            SceneManager.LoadScene(nextScene);
            print("Next level - " + nextScene);
        }
    }
}
