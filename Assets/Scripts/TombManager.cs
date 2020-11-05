using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TombManager : MonoBehaviour {

    [Header("Game Objects")]
    public Tombstone activeTomb;
    public Camera mainCam;
    
    [Header("Tombstones and Player Items")]
    public List<Tombstone> listTombstones = new List<Tombstone>();
    public List<Item> inventoryItems = new List<Item>();
    public List<TombstoneSO> tombstonePool = new List<TombstoneSO>();
    public List<ItemSO> itemPool = new List<ItemSO>();
    
    [Header("UI")]
    public UnityEngine.UI.Button btnEndGame;
    public GameObject endGamePanel;
    public UnityEngine.UI.Text txtSavedSouls;
    public UnityEngine.UI.Text txtEmprisionedSouls;

    private void Start() {
        AssignRandomTombs();
        AssignItems();
    }

    /// <summary>
    /// Assign TombstoneSOs to the list of tombstones
    /// </summary>
    void AssignRandomTombs() { 
        if (listTombstones.Count > tombstonePool.Count) {
            return;
        }

        GameUtilities.RandomizeList(ref tombstonePool);
        for (int i = 0; i < listTombstones.Count; i++) {
            listTombstones[i].tombstoneSO = tombstonePool[i];
            listTombstones[i].WriteOnTombstone();
        }
    }

    /// <summary>
    /// Randomize list of items
    /// </summary>
    void AssignItems() { 
        if (inventoryItems.Count > itemPool.Count) {
            return;
        }

        GameUtilities.RandomizeList(ref itemPool);
        for (int i = 0; i < inventoryItems.Count; i++) {
            inventoryItems[i].itemSO = itemPool[i];
            inventoryItems[i].SetItem();
        }
    }

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
        List<Tombstone> savedSouls = listTombstones.Where(x => x.HasEveryItem()).ToList();
        List<Tombstone> emprisionedSouls = listTombstones.Where(x => !x.HasEveryItem()).ToList();

        // Text for saved souls
        txtSavedSouls.text = "";
        if (savedSouls.Count > 0) {
            txtSavedSouls.text = "These souls received the items they needed to fulfilled their destinies and were sent to the afterlife:\n";
            foreach (var saved in savedSouls) {
                txtSavedSouls.text += saved.tombstoneSO.personName + "\n";
            }
        }
        
        // Text for emprisioned souls
        txtEmprisionedSouls.text = "";
        if (emprisionedSouls.Count > 0) {
            txtEmprisionedSouls.text = "Unfortunately, these souls are still missing the items that would release them and are still bound to the land of the living:\n";
            foreach (var emprisioned in emprisionedSouls) {
                txtEmprisionedSouls.text += emprisioned.tombstoneSO.personName + "\n";
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
