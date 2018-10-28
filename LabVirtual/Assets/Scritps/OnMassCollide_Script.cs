using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnMassCollide_Script : MonoBehaviour {

    public TextMesh Mass;

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
        if (collision.gameObject.tag == "Weight")
        {
            Debug.Log(gameObject.GetComponent<Text>().text + " " + collision.transform.gameObject.GetComponentInChildren<Text>().text);
            Mass.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
        }
    }
}
