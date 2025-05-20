using System.Text;
using UnityEngine;

public class ItemPointer : MonoBehaviour
{
    private StringBuilder itemName = new StringBuilder(50);

    /// <summary>
    /// InputSystem전용 호출 메서드
    /// </summary>
    public void Click()
    {
        if (!GameManager.stopGame && itemName.Length != 0)
        {
            //GameManager.trigger.
            itemName.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (itemName.Length == 0)
            {
                var pos = this.transform.position;
                var direction = other.transform.position - pos;
                
                RaycastHit rayHit;

                if (Physics.Raycast(pos, direction, out rayHit, 1.5f))
                {
                    if (rayHit.collider.CompareTag("Item"))
                    {
                        itemName.Append(other.gameObject.name);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (itemName.Length != 0)
            {
                itemName.Clear();
            }
        }
    }
}
