using UnityEngine;

public class Fade : MonoBehaviour, IAwake
{
    public bool onFade { get; private set; }

    private Animator anim;
    private Void fadeFunction;

    private void Awake() => GameManager.lifeCycle.Add(this);

    public void OnAwake()
    {
        anim = GetComponent<Animator>();
        GameManager.Add(this);
    }

    /// <summary>
    /// ���̵� �ΰ� ���ÿ� 
    /// </summary>
    /// <param name="_fadeFunction"></param>
    public void FadeAction(Void _fadeFunction)
    {
        anim.Play("FadeIn", 0, 0);
        fadeFunction = _fadeFunction;
        onFade = true;
    }

    /// <summary>
    /// ���̵� �ƿ��� �����
    /// </summary>
    public void FadeAction()
    {
        anim.Play("FadeOut", 0, 0);
        onFade = false;
    }

    private void FadeEvent()
    {
        if (fadeFunction != null)
        {
            fadeFunction();
            fadeFunction = null;
        }
    }
}