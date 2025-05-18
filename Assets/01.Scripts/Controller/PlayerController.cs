using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ILoad
{
    [SerializeField] private float moveSpeed = 3.5f;

    public bool isMove { get; private set; }
    private Rigidbody rigid;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!GameManager.stopGame)
        {
            Move();
            Jump();
        }
    }

    private void Move()
    {
        var nextPos = Vector3.zero;
        var jumpPos = Vector3.zero;
        isMove = false;

        if (Input.GetKey(KeyCode.W)) nextPos.z = 1;
        else if (Input.GetKey(KeyCode.S)) nextPos.z = -1;

        if (Input.GetKey(KeyCode.A)) nextPos.x = -1;
        else if (Input.GetKey(KeyCode.D)) nextPos.x = 1;

        if (nextPos != Vector3.zero)
        {
            nextPos = (this.transform.forward * nextPos.z) + (this.transform.right * nextPos.x);
            isMove = true;
        }

        jumpPos.y = rigid.velocity.y;
        rigid.velocity = nextPos.normalized * moveSpeed + jumpPos;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var pos = this.transform.position;
            pos.y += 1;

            var direction = Vector3.down * 100;
            RaycastHit rayHit;

            if (Physics.Raycast(pos, direction, out rayHit))
            {
                if (rayHit.collider.CompareTag("Ground"))
                {
                    var distance = pos.y - rayHit.point.y;
                    distance = distance < 0 ? distance * -1 : distance;

                    if (distance < 1.3f)
                    {
                        rigid.velocity = Vector3.up * 7;
                    }
                }
            }
        }
    }

    //private void Move()
    //{
    //    var key = Vector3.zero;
    //    key.z = Input.GetAxisRaw("Vertical");
    //    key.x = Input.GetAxisRaw("Horizontal");

    //    if (key != Vector3.zero)
    //    {
    //        var camPos = GameManager.cam.transform;

    //        //카메라 앞 뒤 , 좌 우 방향 업데이트
    //        Vector3 camForward = camPos.forward;
    //        Vector3 camRight = camPos.right;

    //        //카메라의 Y축은 바라보면 안되기에 0으로 초기화
    //        camForward.y = 0;
    //        camRight.y = 0;

    //        //이동해야 하는 곳 = 앞 뒤 키 + 카메라 앞 뒤 / 좌 우 키 + 카메라 좌 우 
    //        Vector3 forward = key.z * camForward;
    //        Vector3 right = key.x * camRight;

    //        //값 적용
    //        var nextPos = forward + right;

    //        //현재 이동 값을 Quaternion변환 / 현재 방향에서 direction방향으로 1.8의 속도로 바라본다. (값이 높을 수록 빠르게 회전한다.)
    //        Quaternion direction = Quaternion.LookRotation(nextPos);
    //        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, direction, rotateSpeed);
    //        //anim.SetBool("Move", true);
    //    }
    //}
}
