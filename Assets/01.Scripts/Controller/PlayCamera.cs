using UnityEngine;
using UnityEngine.InputSystem;

public class PlayCamera : MonoBehaviour, ILoad
{
    [SerializeField] private float sensitivity = 0.06f;

    private Animator anim;
    private Vector2 mouse;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnLoad()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        anim = GetComponent<Animator>();
        GameManager.Add(this);
    }

    private void Update()
    {
        if (!GameManager.stopGame)
        {
            Mouse();
        }
    }

    private void Mouse()
    {
        if (mouse.y < -90) mouse.y = -90;
        else if (mouse.y > 60) mouse.y = 60;

        this.transform.rotation = Quaternion.Euler(-mouse.y, mouse.x, 0);
        GameManager.player.transform.rotation = Quaternion.Euler(0, mouse.x, 0);
    }

    /// <summary>
    /// InputSystem전용 호출 메서드
    /// </summary>
    /// <param name="context"></param>
    public void Mouse(InputAction.CallbackContext context)
    {
        mouse += context.ReadValue<Vector2>() * sensitivity;
    }

    /// <summary>
    /// 재생할 카메라 액션 이름
    /// </summary>
    /// <param name="_actionName"></param>
    public void Action(string _actionName)
    {
        anim.Play(_actionName, 0, 0);
    }

    private void EndAction()
    {
        //애니메이션 호출 전용 메서드
        anim.Play("Idle", 0, 0);
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