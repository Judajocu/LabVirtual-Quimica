using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnElectronsCollide_script : MonoBehaviour {

     public TextMesh Electrons;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Electrons")
        {
            Electrons.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
        }
    }
}
