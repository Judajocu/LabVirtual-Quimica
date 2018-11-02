using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnSymbolCollide_Script : MonoBehaviour {

    #region Variables
    public GameObject Symbol1;
    public GameObject Symbol2;
    public GameObject Symbol3;
    public GameObject Symbol4;
    public GameObject Symbol5;

    public GameObject Mass1;
    public GameObject Mass2;
    public GameObject Mass3;
    public GameObject Mass4;
    public GameObject Mass5;

    public GameObject Electron1;
    public GameObject Electron2;
    public GameObject Electron3;
    public GameObject Electron4;
    public GameObject Electron5;
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Symbol")
        {
            (GameObject)Instantiate(, new Vector3(-1.4f, 4.05223f), Quaternion.identity);
        }
    }
    
}
