using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("value")][SerializeField] private int value;
    [FormerlySerializedAs("info")][SerializeField] private string info;
    [FormerlySerializedAs("icon")][SerializeField] private Sprite icon;

    public int Value() => value;
    public string Info() => info;
    public Sprite Sprite() => icon;
}
