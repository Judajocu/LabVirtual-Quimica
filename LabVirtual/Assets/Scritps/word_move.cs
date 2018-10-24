using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_move : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;
    private float time = 0.0f;
    float top;
    float down;
    private float limite = 0.08f;
    private float interpolationPeriod = 0.08f;

    bool isPicked;
    bool istrigger;
    bool correccion;
    Vector3 original;

    public float DeltaTiempo, posicion = 0;
    public float Velocidad, Gravedad = 4.0f;

    // Use this for initialization
    void Start () {
        top = transform.position.y + limite;
        down = transform.position.y - limite;
        DeltaTiempo = Time.time;
        original = gameObject.transform.position;
        correccion = false;
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {

            isPicked = false;
            top = transform.position.y + limite;
            down = transform.position.y - limite;
            //transform.position = original;


        }

        if (isPicked)
        {
            Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            DeltaTiempo = Time.time;
        }

        if (!isPicked)
        {
            time += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                MoveElement();
            }

        }

        /*if (istrigger)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }*/

        if (istrigger)
        {
            if (correccion)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
                top = transform.position.y + limite;
                down = transform.position.y - limite;
                correccion = false;
            }

            posicion = 0;
            Velocidad = 0;
            DeltaTiempo = Time.time;
        }

        if (!istrigger && !isPicked)
        {
            //gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            gravedad();
        }
        

    }

    void OnMouseDown()
    {

        isPicked = true;

    }

    void MoveElement()
    {

        transform.Translate(MovingDirection * Time.smoothDeltaTime);

        if (transform.position.y > top)
        {
            MovingDirection = Vector3.down;
        }
        else if (transform.position.y < down)
        {
            MovingDirection = Vector3.up;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        istrigger = false;
        correccion = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "vaso ensallo 1")
        {
            istrigger = true;
            Debug.Log("deteccion hecha");
        }
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
