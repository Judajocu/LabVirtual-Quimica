using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class balance_behavior : MonoBehaviour {

    private float DeltaTiempo, posicion = 0;
    private float Velocidad, Gravedad = 4.0f;
    bool istrigger;
    Vector3 original;

    // Use this for initialization
    void Start()
    {
        //transform.localScale += new Vector3(0.1F, 0.1F, 0);
        original = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (istrigger)
        //{
        //    //Debug.Log("no es visible");
        //    transform.position = original;
        //}

        if (!istrigger)
        {
            //gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            gravedad();
        }
    }

    void OnTriggerExit(Collider other)
    {
        istrigger = false;
    }

    void OnTriggerEnter(Collider other)
    {
        istrigger = true;
    }

    public void gravedad()
    {
        Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        Velocidad += (-1 * Gravedad * (Time.time - DeltaTiempo));
        posicion = Velocidad * (Time.time - DeltaTiempo);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + posicion, gameObject.transform.position.z);

        DeltaTiempo = Time.time;


    }


}
