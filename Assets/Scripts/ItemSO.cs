using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "myItem", menuName = "Item/ItemSO", order = 1)]
public class ItemSO : ScriptableObject {

    public string itemName;
    public Sprite sprite;

}
