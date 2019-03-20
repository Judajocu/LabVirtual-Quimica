using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LinksButtons : MonoBehaviour {

    public Button ButtonLink;
    public Text nombre;

    private string link;
    private string linkNombre;

    // Use this for initialization
    void Start () {

        nombre.text = link;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLink(string data)
    {
        link = data;
    }

    public void SetLinkName(string data)
    {
        linkNombre = data;
    }

    public void go()
    {
        Application.OpenURL(link);
    }

}
