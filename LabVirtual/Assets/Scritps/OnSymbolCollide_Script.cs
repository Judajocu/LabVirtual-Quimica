﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnSymbolCollide_Script : MonoBehaviour {

    public TextMesh Symbol;

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
            Debug.Log(gameObject.GetComponent<Text>().text + " " + collision.transform.gameObject.GetComponentInChildren<Text>().text);
            Symbol.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
        }
    }
    
}
