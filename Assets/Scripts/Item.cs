using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public ItemSO itemSO;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Button button;
    string itemName;

    private void Start() {
        if (itemSO) { 
            itemName = itemSO.itemName;
            image.sprite = itemSO.sprite;
        }
    }

    public void SetItem() {
        itemName = itemSO.itemName;
        image.sprite = itemSO.sprite;
    }
    
    public void ResetItem() {
        itemSO = null;
        itemName = null;
        image.sprite = null;
    }

}
