using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnElectronsCollide_script : MonoBehaviour {

     public TextMesh Conversion;
    public InputField answer;

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
        if (collision.gameObject.tag == "Symbol")
        {
            Conversion.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
        }
        answer.transform.position = new Vector3(1.65f, -1.2f);
    }
}
