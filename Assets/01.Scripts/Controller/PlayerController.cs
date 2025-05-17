using UnityEngine;

public class PlayerController : MonoBehaviour, ILoad
{
    [SerializeField] private float moveSpeed;

    public bool isMove { get; private set; }
    private Rigidbody rigid;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        rigid = GetComponent<Rigidbody>();
        var a = new GameObject();
        a.name = "Spawn";
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
        isMove = false;

        if (Input.GetKey(KeyCode.W)) nextPos.z = 1;
        else if (Input.GetKey(KeyCode.S)) nextPos.z = -1;

        if (Input.GetKey(KeyCode.A)) nextPos.x = -1;
        else if (Input.GetKey(KeyCode.D)) nextPos.x = 1;

        if (nextPos != Vector3.zero)
        {
            nextPos = (this.transform.forward * nextPos.z) + (this.transform.right * nextPos.x);
            jumpPos.y = rigid.velocity.y;
            isMove = true;
        }

        rigid.velocity = nextPos.normalized * moveSpeed + jumpPos;
    }
}
