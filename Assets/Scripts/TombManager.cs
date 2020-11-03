using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombManager : MonoBehaviour {

    public Tombstone activeTomb;
    public Camera mainCam;
    public List<Tombstone> listTombstones = new List<Tombstone>();
    public List<Item> inventoryItems = new List<Item>();
    public UnityEngine.UI.Button btnEndGame;
    public GameObject endGamePanel;
    public UnityEngine.UI.Text txtEndGame;

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
                if (!item.itemSO) {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// End the game and display the results
    /// </summary>
    public void OnEndGameButtonPressed() {
        endGamePanel.SetActive(true);
        txtEndGame.text = "";
        foreach (var tombstone in listTombstones) { 
            if (tombstone.HasEveryItem()) {
                txtEndGame.text += tombstone.tombstoneSO.personName + " has been released to the afterlife.\n";
            } else {
                txtEndGame.text += tombstone.tombstoneSO.personName + " is still bound to the land of the living.\n";
            }
        }
    }

    /// <summary>
    /// Switch to a nw active tombstone
    /// </summary>
    /// <param name="newTombstone"></param>
    public void ChangeTombstone(Tombstone newTombstone) {
        activeTomb.tombCanvas.SetActive(false);
        activeTomb = newTombstone;
        activeTomb.tombCanvas.SetActive(true);
        mainCam.transform.position = activeTomb.cameraHolder.position;
        mainCam.transform.rotation = activeTomb.cameraHolder.rotation;
    }
}
