using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public AttackZone az;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            az.gameObject.SetActive(true);
        }
    }
}
