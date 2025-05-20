using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("itemasd")][SerializeField] private string itemName;

    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject dropPrefab;
}
