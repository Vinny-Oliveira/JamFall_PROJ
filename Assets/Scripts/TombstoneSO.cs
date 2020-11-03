using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "myTombstone", menuName = "ScriptableObjects/TombstoneSO", order = 1)]
public class TombstoneSO : ScriptableObject {

    public string personName;
    public string dates;
    public string quotes;
    public string hereLies;
    public string notebook;
    public List<ItemSO> neededItemsList = new List<ItemSO>();

}
