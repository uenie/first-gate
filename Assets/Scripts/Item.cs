using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour
{
    public enum ItemType { Weapon, Equipment, Food, Potion, Book, Other };

    public ItemType itemType;
    public float speedOfRotation = 1.0f;
    public Inventory inventory;

    public void Use()
    {
        if (itemType == ItemType.Food)
        {
            //FindObjectOfType(typeof(Stats)).AddLife(50);
            print("using mushroom");
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speedOfRotation);
        transform.Rotate(Vector3.up * Time.deltaTime * speedOfRotation, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int indexOfEmpty = -1;
            int length = inventory.items.Length;
            for (int index = 0; index < length; index++)
            {
                if (inventory.items[index] == null)
                {
                    //Debug.Log("inventory.items[index]==null, inventory.items[index].gameObject.name == :" + inventory.items[index].gameObject.name);
                    indexOfEmpty = index;
                    break;
                }
                else
                {
                    //Debug.Log("inventory.items[index]!=null, inventory.items[index].gameObject.name == :" + inventory.items[index].gameObject.name);
                }
            }
            if (indexOfEmpty >= 0)
            {
                inventory.items.SetValue(this, indexOfEmpty);
                //Destroy(gameObject);
                gameObject.active = false;
            }
            // Debug.Log("length: " + inventory.items.Length);
            // Debug.Log("indexOfEmpty: " + indexOfEmpty);
            // Debug.Log("inventory.items[indexOfEmpty]: " + inventory.items[indexOfEmpty]);
        }
    }

}
