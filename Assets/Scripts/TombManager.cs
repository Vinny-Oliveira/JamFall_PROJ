using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombManager : MonoBehaviour {

    public Tombstone activeTomb;
    public Tombstone ActiveTomb { set { activeTomb = value; } }
    public List<Tombstone> listTombstones = new List<Tombstone>();
    public List<Item> inventoryItems = new List<Item>();
    public UnityEngine.UI.Button btnEndGame;

    /// <summary>
    /// Click on inventory items
    /// </summary>
    /// <param name="itemClicked"></param>
    public void OnInventoryItemClicked(Item itemClicked) { 
        foreach (var item in activeTomb.items) { 
            if (!item.itemSO) {
                item.itemSO = itemClicked.itemSO;
                item.SetItem();
                itemClicked.button.interactable = false;
                btnEndGame.gameObject.SetActive(CanEnableEndGameButton());
                return;
            }
        }
    }

    /// <summary>
    /// Click on tomb items
    /// </summary>
    /// <param name="itemClicked"></param>
    public void OnTombItemClicked(Item itemClicked) { 
        foreach (var item in inventoryItems) { 
            if (itemClicked.itemSO != null && itemClicked.itemSO == item.itemSO) {
                itemClicked.ResetItem();
                item.button.interactable = true;
                btnEndGame.gameObject.SetActive(false);
                return;
            }
        }
    }

    /// <summary>
    /// Checks if the End Game button can be enabled
    /// </summary>
    /// <returns></returns>
    public bool CanEnableEndGameButton() { 
        foreach (var tomb in listTombstones) { 
            foreach (var item in tomb.items) { 
                if (!item) {
                    return false;
                }
            }
        }

        return true;
    }

    public void OnEndGameButtonPressed() { 
        
    }
}
