using UnityEngine;

public class PlayerController : MonoBehaviour, ILoad
{
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
        }
    }

    private void Move()
    {
        var nextPos = Vector3.zero;
        var jumpPos = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) nextPos.z = 1;
        else if (Input.GetKey(KeyCode.S)) nextPos.z = -1;

        if (Input.GetKey(KeyCode.A)) nextPos.x = 1;
        else if (Input.GetKey(KeyCode.D)) nextPos.x = -1;

        if (nextPos != Vector3.zero)
        {
            jumpPos.y = rigid.velocity.y;

        }

        rigid.velocity = nextPos.normalized * 3 + jumpPos;
    }
}
