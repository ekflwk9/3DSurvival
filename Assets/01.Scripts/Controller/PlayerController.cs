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
            if ((int)rigid.velocity.y == 0)
            {
                rigid.velocity = Vector3.up * 7;
            }

            //var pos = this.transform.position;
            //pos.y += 1;

            //var direction = Vector3.down * 100;
            //RaycastHit rayHit;

            //if (Physics.Raycast(pos, direction, out rayHit))
            //{
            //    if (rayHit.collider.CompareTag("Ground"))
            //    {
            //        if (pos.y < rayHit.point.y)
            //        {
            //        }
            //    }
            //}
        }
    }
}
