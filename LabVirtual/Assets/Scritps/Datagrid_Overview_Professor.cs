using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datagrid_Overview_Professor : MonoBehaviour {

    public GameObject prefab_groups;
    public GameObject prefab_groupcode;
    public GameObject prefab_avggrades;
    public int Cant_grupos;

	// Use this for initialization
	void Start () {
        Populate();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Populate()
    {
        GameObject gameObject;
        for (int i = 0; i < Cant_grupos; i++)
        {
            gameObject = (GameObject)Instantiate(prefab_groups, transform);
            gameObject = (GameObject)Instantiate(prefab_groupcode, transform);
            gameObject = (GameObject)Instantiate(prefab_avggrades, transform);
        }
    }

}
