using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UiButton : MonoBehaviour, 
IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IAwake
{
    protected TMP_Text title;
    protected GameObject touchImage;

    private void Awake() => GameManager.startManager.Add(this);

    public virtual void OnAwake()
    {
        touchImage = this.transform.Find("Touch").gameObject;
        title = this.transform.Find("Text").GetComponent<TMP_Text>();
    }

    public abstract void Click();

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.fade.onFade) Click();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (!GameManager.fade.onFade) touchImage.SetActive(true);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if(touchImage.activeSelf) touchImage.SetActive(false);
    }
}