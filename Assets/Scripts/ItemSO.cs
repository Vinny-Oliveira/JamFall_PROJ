using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "myItem", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject, System.IEquatable<ItemSO> {

    public string itemName;
    public Sprite sprite;

    #region EQUALITY_OVERLOAD
    public override bool Equals(object other) {
        return Equals(other as ItemSO);
    }

    public bool Equals(ItemSO itemSO) {
        if (!itemSO) { return false; }

        return itemName == itemSO.itemName;
    }

    public override int GetHashCode() {
        return base.GetHashCode();
    }

    #endregion

}
