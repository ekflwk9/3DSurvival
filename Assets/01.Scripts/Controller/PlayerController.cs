using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ILoad, IJump
{
    [SerializeField] private float moveSpeed = 3.5f;

    public bool isMove { get; private set; }
    private Rigidbody rigid;

    private Vector3[] jumpPos =
    {
        new Vector3(0f, 0.4f, 0f),
        new Vector3(0f, 0.4f, -0.35f),
        new Vector3(0f, 0.4f, 0.35f),
        new Vector3(-0.35f, 0.4f, 0f),
        new Vector3(0.35f, 0.4f, 0f)
    };

    private Vector3 movePos;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!GameManager.stopGame)
        {
            Move();
        }
    }

    private void Move()
    {
        var nextPos = Vector3.zero;
        var jumpPos = Vector3.zero;
        jumpPos.y = rigid.velocity.y;

        if (movePos != Vector3.zero)
        {
            nextPos = (this.transform.forward * movePos.y) + (this.transform.right * movePos.x);
        }

        rigid.velocity = nextPos.normalized * moveSpeed + jumpPos;
    }

    /// <summary>
    /// InputSystem전용 호출 메서드
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        movePos = context.ReadValue<Vector3>();
        isMove = false;

        if (movePos != Vector3.zero) isMove = true;
    }

    /// <summary>
    /// InputSystem전용 호출 메서드
    /// </summary>
    public void Jump()
    {
        var pos = this.transform.position;

        for (int i = 0; i < 5; i++)
        {
            RaycastHit rayHit;

            //4방면 중 한개라도 땅에 닿아있는 판정일 경우 점프 가능
            if (Physics.Raycast(pos + jumpPos[i], Vector3.down, out rayHit, 0.55f))
            {
                if (rayHit.collider.CompareTag("Ground"))
                {
                    rigid.velocity = Vector3.up * 7;
                    break;
                }
            }
        }
    }

    public void OnJump(float _jumpPower)
    {
        rigid.velocity = Vector3.up * _jumpPower;
    }

    //private void Move()
    //{
    //    var nextPos = Vector3.zero;
    //    var jumpPos = Vector3.zero;
    //    isMove = false;

    //    if (Input.GetKey(KeyCode.W)) nextPos.z = 1;
    //    else if (Input.GetKey(KeyCode.S)) nextPos.z = -1;

    //    if (Input.GetKey(KeyCode.A)) nextPos.x = -1;
    //    else if (Input.GetKey(KeyCode.D)) nextPos.x = 1;

    //    if (nextPos != Vector3.zero)
    //    {
    //        nextPos = (this.transform.forward * nextPos.z) + (this.transform.right * nextPos.x);
    //        isMove = true;
    //    }

    //    jumpPos.y = rigid.velocity.y;
    //    rigid.velocity = nextPos.normalized * moveSpeed + jumpPos;
    //}

    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        var canJump = false;
    //        var pos = this.transform.position;

    //        for (int i = 0; i < 5; i++)
    //        {
    //            RaycastHit rayHit;
    //            //Debug.DrawRay(pos + jumpPos[i], Vector3.down, Color.red, 0.5f);

    //            //4방면 중 한개라도 땅에 닿아있는 판정일 경우 점프 가능
    //            if (Physics.Raycast(pos + jumpPos[i], Vector3.down, out rayHit, 0.55f))
    //            {
    //                if (rayHit.collider.CompareTag("Ground"))
    //                {
    //                    canJump = true;
    //                    break;
    //                }
    //            }
    //        }

    //        if (canJump) rigid.velocity = Vector3.up * 7;
    //    }
    //}

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