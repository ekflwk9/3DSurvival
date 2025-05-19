using UnityEngine;

public class PlayerController : MonoBehaviour, ILoad
{
    [SerializeField] private float moveSpeed = 3.5f;

    public bool isMove { get; private set; }
    private Rigidbody rigid;

    private Vector3[] jumpPos =
    {
        new Vector3(0.35f, 0f, 0.35f),
        new Vector3(0.35f, 0f, -0.35f),
        new Vector3(-0.35f, 0f, 0.35f),
        new Vector3(-0.35f, 0f, -0.35f)
    };

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
            var canJump = false;
            var pos = this.transform.position;
            pos.y += 0.4f;

            for (int i = 0; i < 4; i++)
            {
                RaycastHit rayHit;

                //4��� �� �Ѱ��� ���� ����ִ� ������ ��� ���� ����
                if (Physics.Raycast(pos + jumpPos[i], Vector3.down, out rayHit, 0.5f))
                {
                    if (rayHit.collider.CompareTag("Ground"))
                    {
                        canJump = true;
                        break;
                    }
                }
            }

            if (canJump) rigid.velocity = Vector3.up * 7;
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

    //        //ī�޶� �� �� , �� �� ���� ������Ʈ
    //        Vector3 camForward = camPos.forward;
    //        Vector3 camRight = camPos.right;

    //        //ī�޶��� Y���� �ٶ󺸸� �ȵǱ⿡ 0���� �ʱ�ȭ
    //        camForward.y = 0;
    //        camRight.y = 0;

    //        //�̵��ؾ� �ϴ� �� = �� �� Ű + ī�޶� �� �� / �� �� Ű + ī�޶� �� �� 
    //        Vector3 forward = key.z * camForward;
    //        Vector3 right = key.x * camRight;

    //        //�� ����
    //        var nextPos = forward + right;

    //        //���� �̵� ���� Quaternion��ȯ / ���� ���⿡�� direction�������� 1.8�� �ӵ��� �ٶ󺻴�. (���� ���� ���� ������ ȸ���Ѵ�.)
    //        Quaternion direction = Quaternion.LookRotation(nextPos);
    //        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, direction, rotateSpeed);
    //        //anim.SetBool("Move", true);
    //    }
    //}
}