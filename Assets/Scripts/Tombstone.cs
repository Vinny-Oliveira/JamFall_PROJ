using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour {

    public TombstoneSO tombstoneSO;
    public UnityEngine.UI.Text txtTombstone;
    public UnityEngine.UI.Text txtNotebook;

    // Start is called before the first frame update
    void Start() {
        txtTombstone.text = tombstoneSO.personName + "\n" + tombstoneSO.dates + "\n\n" + tombstoneSO.quotes + "\n\n" + tombstoneSO.hereLies;
        txtNotebook.text = tombstoneSO.notebook;
    }

}
