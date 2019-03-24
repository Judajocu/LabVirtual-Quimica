using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSession : MonoBehaviour {

    static public string userID = "";
    static public int groupID = 0;
    // Use this for initialization
    void Start () {
        Debug.Log("usuario logueado:"+userID+" |grupo:"+groupID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cambio(string valor)
    {
        userID = valor;
    }

    public void limpiar(GameObject esto)
    {
        userID = "";
        groupID = 0;
    }

    public string darID()
    {
        return userID;
    }

    public void groupSelected(int valor)
    {
        groupID = valor;
    }

    public int darGroup()
    {
        return groupID;
    }
}
