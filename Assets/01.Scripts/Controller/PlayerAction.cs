using UnityEngine;

public class PlayerAction : MonoBehaviour, ILoad
{
    private Animator anim;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnLoad()
    {
        anim = GetComponent<Animator>();
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
        var isMove = GameManager.player.isMove;
        if(isMove) anim.SetBool("Move", isMove);   
    }
}
