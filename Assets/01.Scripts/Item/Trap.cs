using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour, IStart
{
    [SerializeField] private int damage = 5;

    private bool isTouch;
    private IHit target;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnStart()
    {
        StartCoroutine(AttackRange());
    }

    private IEnumerator AttackRange()
    {
        while (true)
        {
            if (isTouch) target.OnHit(damage);
            yield return Service.oneSecond;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<IHit>(out var hitTarget))
            {
                isTouch = true;
                target = hitTarget;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
