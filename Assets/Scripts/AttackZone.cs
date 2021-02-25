using UnityEngine;
using System.Collections;

public class AttackZone : MonoBehaviour
{
    //todo: учитывать направление камеры
    public Stats stats;
    private float autoSelfDeactivateAfter=0.1f;
    private bool locked;
    private IEnumerator coroutine;

    public IEnumerator WaitAndDeactivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        locked = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && !locked)
        {
            coroutine = WaitAndDeactivate(autoSelfDeactivateAfter);
            StartCoroutine(coroutine);
            locked = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Kill();
            stats.IncKilled(1);

            // print("killed");

            gameObject.SetActive(false);
        }
    }
}
