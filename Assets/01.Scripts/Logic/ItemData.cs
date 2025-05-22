using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("info")][SerializeField] private string itemName;
    [FormerlySerializedAs("info")][SerializeField] private string info;
    [FormerlySerializedAs("icon")][SerializeField] private Sprite icon;

    public string Name() => itemName;
    public string Info() => info;
    public Sprite Sprite() => icon;
}
