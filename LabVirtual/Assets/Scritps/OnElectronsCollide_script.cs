using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnElectronsCollide_script : MonoBehaviour {

     public TextMesh conversion;
    public InputField answer;
    public GameObject mover;
    public GameObject scale;
    public GameObject baseScale;
    GameObject game2;

    // Use this for initialization
    void Start()
    {
        answer.gameObject.SetActive(false);
        baseScale.gameObject.SetActive(false);
        scale.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Clean();
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Symbol")
        {
            baseScale.gameObject.SetActive(true);
            scale.gameObject.SetActive(true);
            
            scale.transform.rotation = Quaternion.Euler(0,0,0);
            conversion.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            G2Kg(collision.gameObject);
        }
        answer.gameObject.SetActive(true);
    }

    void G2Kg(GameObject game)
    {
        
        if(game.gameObject.name == "Formula2" || game.gameObject.name == "Formula3" || game.gameObject.name == "Formula5")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net").transform, false);
        }
        if(game.gameObject.name == "Formula4" || game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net").transform, false);
        }
        if(game.gameObject.name == "Formula1")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net").transform, false);
        }
            
    }

    void F2C()
    {

    }

    void Lb2g()
    {

    }

    void Mph2Kmh()
    {

    }

    void J2Kcal()
    {

    }

    void Clean()
    {
        GameObject[] prefavs = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject enemy in prefavs)
            GameObject.Destroy(enemy);
    }
}
