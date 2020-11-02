using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public ItemSO itemSO;
    public UnityEngine.UI.Image image;
    string itemName;

    private void Start() {
        itemName = itemSO.itemName;
        image.sprite = itemSO.sprite;
    }

}
