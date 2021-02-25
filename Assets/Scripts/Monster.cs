using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public Transform target;
    public float speed=4.0f;
    public bool angry = false;
    public bool dead = false;

	void Start () {
	
	}
    void Update()
    {
        if (angry && !dead)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    
	}
    void OnCollisionEnter(Collision collision)
    {
        if (!dead && collision.gameObject.tag == "Player")
        {
            // Get Angry
            angry = true;
            // Hunt a Player
            target = collision.gameObject.transform;
            // Harm a Player
            collision.gameObject.GetComponent<Stats>().AddLife(-10);
        }
    }
    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            //gameObject.transform.Rotate(Vector3.up, 90);
            transform.RotateAroundLocal(Vector3.right, 90);
            transform.localScale = transform.localScale * 0.75f;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        }
    }
}
