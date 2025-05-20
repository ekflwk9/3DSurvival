using System.Collections;
using System.Text;
using UnityEngine;

public class Trap : MonoBehaviour, IStart
{
    private StringBuilder target = new StringBuilder(30);

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnStart()
    {
        StartCoroutine(AttackRange());
    }

    private IEnumerator AttackRange()
    {
        while (true)
        {
            //if(target.Length != 0) GameManager.eventManager.Hit(target);
            yield return Service.oneSecond;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (target.Length == 0)
            {
                target.Append(collision.gameObject.name);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (target.Length != 0)
            {
                target.Clear();
            }
        }
    }
}
