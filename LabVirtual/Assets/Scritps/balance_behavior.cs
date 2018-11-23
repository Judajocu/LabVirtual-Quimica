using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class balance_behavior : MonoBehaviour {

    private float DeltaTiempo, posicion = 0;
    private float Velocidad, Gravedad = 4.0f;
    bool istrigger, activar;
    Vector3 original;
    float valor_original = 0.6F;

    // Use this for initialization
    void Start()
    {
        //transform.localScale += new Vector3(0.1F, 0.1F, 0);
        original = gameObject.transform.position;
        activar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activar)
        {
            if (istrigger)
            {
                //Debug.Log("no es visible");
                //transform.position = original;
                posicion = 0;
                Velocidad = 0;
                DeltaTiempo = Time.time;
            }

            if (!istrigger)
            {
                //gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                gravedad();
            }
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

    public void funcionar(bool valor)
    {
        activar = valor;
        posicion = 0;
        Velocidad = 0;
        DeltaTiempo = Time.time;
    }

    public void Reinicio(bool valor)
    {
        //activar = valor;
        posicion = 0;
        Velocidad = 0;
        DeltaTiempo = Time.time;
        transform.position = original;
    }

    public void changeSize(float valor)
    {
        transform.localScale = new Vector3(valor, valor, 0);
    }



}
