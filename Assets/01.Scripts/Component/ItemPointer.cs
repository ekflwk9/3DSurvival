using UnityEngine;

public class ItemPointer : MonoBehaviour
{
    private bool isTouch;
    private IInteraction item;

    /// <summary>
    /// InputSystem전용 호출 메서드
    /// </summary>
    public void Click()
    {
        if (!GameManager.stopGame && isTouch)
        {
            item.OnInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (!isTouch)
            {
                var pos = this.transform.position;
                var direction = other.transform.position - pos;

                RaycastHit rayHit;

                if (Physics.Raycast(pos, direction, out rayHit, 1.5f))
                {
                    if (rayHit.collider.CompareTag("Item"))
                    {
                        isTouch = true;

                        if(other.gameObject.TryGetComponent<ITouch>(out var touch))
                        {
                            touch.OnTouch();
                        }

                        if(other.gameObject.TryGetComponent<IInteraction>(out var target))
                        {
                            item = target;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            isTouch = false;
            GameManager.ui.SetIntegerUi(UiCode.Touch, 0);
        }
    }
}
