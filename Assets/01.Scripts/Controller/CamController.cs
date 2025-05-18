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

    //private void Move()
    //{
    //    mouse.x += Input.GetAxisRaw("Mouse X") * sensitive;
    //    mouse.y += Input.GetAxisRaw("Mouse Y") * sensitive;

    //    if (mouse.y > 25f) mouse.y = 25f;                                            //카메라 각도 제한
    //    if (mouse.y < -45f) mouse.y = -45f;

    //    var thisPos = this.transform;
    //    thisPos.rotation = Quaternion.Euler(-mouse.y, mouse.x, 0);                   //카메라 회전 적용

    //    pos = GameManager.player.transform.position + thisPos.forward * -3f;         //카메라 위치 캐릭터보다 -3 떨어진 위치
    //    pos += Vector3.up * 1.5f;                                                    //위로 1.5

    //    thisPos.position = pos;                                                      //위치 적용
    //}
}
