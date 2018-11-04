using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPropertyCollide_SCript : MonoBehaviour {

    #region Variables
    public GameObject Symbol1;
    public GameObject Symbol2;
    public GameObject Symbol3;
    public GameObject Symbol4;
    public GameObject Symbol5;

    GameObject gameSymbol;
    GameObject gameMass;
    GameObject gameElectrons;
    public GameObject pesos;
    public GameObject electronegatividad;

    public GameObject Mass1;
    public GameObject Mass2;
    public GameObject Mass3;
    public GameObject Mass4;
    public GameObject Mass5;

    public GameObject Electron1;
    public GameObject Electron2;
    public GameObject Electron3;
    public GameObject Electron4;
    public GameObject Electron5;
    #endregion
    
    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        pesos.gameObject.SetActive(false);
        electronegatividad.gameObject.SetActive(false);
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

            pesos.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Signo"));
            switch (collision.gameObject.name)
            {
                case "Signo1":
                    gameSymbol = Instantiate(Symbol1, new Vector3(-5.5f, -23f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo4":
                    gameSymbol = Instantiate(Symbol2, new Vector3(-5.5f, -23f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo5":
                    gameSymbol = Instantiate(Symbol3, new Vector3(-5.5f, -23f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo6":
                    gameSymbol = Instantiate(Symbol4, new Vector3(-5.5f, -23f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Signo7":
                    gameSymbol = Instantiate(Symbol5, new Vector3(-5.5f, -23f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }           
        }

        if (collision.gameObject.tag == "Weight")
        {
            electronegatividad.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Mass"));
            switch (collision.gameObject.name)
            {
                case "Peso2":
                    gameSymbol = Instantiate(Mass1, new Vector3(-3f, -23f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso4":
                    gameSymbol = Instantiate(Mass2, new Vector3(-3f, -23f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso5":
                    gameSymbol = Instantiate(Mass3, new Vector3(-3f, -23f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso6":
                    gameSymbol = Instantiate(Mass4, new Vector3(-3f, -23f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Peso7":
                    gameSymbol = Instantiate(Mass5, new Vector3(-3f, -23f, -7885.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }
        }

        if (collision.gameObject.tag == "Electrons")
        {
            Destroy(GameObject.FindGameObjectWithTag("Electrones"));
            switch (collision.gameObject.name)
            {
                case "Electrones2":
                    gameSymbol = Instantiate(Electron1, new Vector3(-6f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones3":
                    gameSymbol = Instantiate(Electron2, new Vector3(-6f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones5":
                    gameSymbol = Instantiate(Electron3, new Vector3(-6f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones6":
                    gameSymbol = Instantiate(Electron4, new Vector3(-6f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
                case "Electrones7":
                    gameSymbol = Instantiate(Electron5, new Vector3(-6f, -21f, -7887.205f), Quaternion.identity);
                    gameSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Element").transform, false);
                    break;
            }
        }
    }
}
