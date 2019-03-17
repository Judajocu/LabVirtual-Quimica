using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSession : MonoBehaviour {

    static public string userID = "";
	// Use this for initialization
	void Start () {
        Debug.Log("usuario logueado:"+userID);
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
    }
}
