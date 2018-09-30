using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General_script_prefab : MonoBehaviour {

    public Button buttonOk;

    public GameObject ok;
    public GameObject PopUpGO;
    public static GameObject game;

    // Use this for initialization
    void Start ()
    {
        game = Instantiate(PopUpGO, new Vector3(-0.5f, -0.6150017f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ValidateDestroyWarning()
    {
        Debug.Log("Fuck this or that");
        Destroy(game.gameObject);
    }
}
