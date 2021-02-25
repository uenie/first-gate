using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform rabbitPrefab;
    public float yOffset = 5.0f;
    public int howManyToSpawn = 10;
    public float waitSeconds = 5.0f;
    private bool locked;
    private IEnumerator coroutine;

    public IEnumerator WaitAndSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(rabbitPrefab, new Vector3(
            transform.position.x, transform.position.y + yOffset, transform.position.z),
            new Quaternion(rabbitPrefab.transform.rotation.x,rabbitPrefab.transform.rotation.y,rabbitPrefab.transform.rotation.z,rabbitPrefab.transform.rotation.w));
        howManyToSpawn--;
        locked = false;
    }

    void Update()
    {
        if (howManyToSpawn > 0 && !locked)
        {
            coroutine = WaitAndSpawn(waitSeconds);
            StartCoroutine(coroutine);
            locked = true;
        }
    }
}
