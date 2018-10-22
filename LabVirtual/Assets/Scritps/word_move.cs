using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_move : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;
    private float time = 0.0f;
    float top;
    float down;
    private float limite = 0.08f;
    private float interpolationPeriod = 0.1f;

    bool isPicked;

    // Use this for initialization
    void Start () {
        top = transform.position.y + limite;
        down = transform.position.y - limite;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {

            isPicked = false;

        }

        if (isPicked == true)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (pos);

        }

        if (isPicked == false)
        {
            time += Time.deltaTime;

            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                MoveElement();
            }

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

   /* void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);

        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPos;
    }*/
}
