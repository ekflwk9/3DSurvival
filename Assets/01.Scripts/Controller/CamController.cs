using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Vector2 mouse;

    private void Update()
    {
        mouse.x += Input.GetAxisRaw("Mouse X");
        mouse.y += Input.GetAxisRaw("Mouse Y");

        if (mouse.y < -90) mouse.y = -90;
        else if (mouse.y > 60) mouse.y = 60;

        this.transform.rotation = Quaternion.Euler(-mouse.y, mouse.x, 0);
        GameManager.player.transform.rotation = Quaternion.Euler(0, mouse.x, 0);
    }
}
