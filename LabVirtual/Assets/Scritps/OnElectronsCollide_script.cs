using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnElectronsCollide_script : MonoBehaviour {

     public TextMesh conversion;
    public InputField answer;
    public GameObject mover;
    public GameObject scale;
    public GameObject baseScale;

    Scene activeScene;

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

    void OnTriggerExit2D(Collider2D collision)
    {
        Clean();
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Symbol")
        {
            baseScale.gameObject.SetActive(true);
            scale.gameObject.SetActive(true);
            
            scale.transform.rotation = Quaternion.Euler(0,0,0);
            conversion.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            switch(GetSceneName())
            {
                case "Conversion Nivel 1":
                    G2Kg(collision.gameObject);
                    break;
                case "Conversion Nivel 2":
                    F2C(collision.gameObject);
                    break;
                case "Conversion Nivel 3":
                    Lb2g(collision.gameObject);
                    break;
                case "Conversion Nivel 4":
                    Mph2Kmh(collision.gameObject);
                    break;
                case "Conversion Nivel 5":
                    J2Kcal(collision.gameObject);
                    break;
            }
            
        }
        answer.gameObject.SetActive(true);
    }

    void G2Kg(GameObject game)
    {
        
        if(game.gameObject.name == "Formula2" || game.gameObject.name == "Formula3" || game.gameObject.name == "Formula5")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if(game.gameObject.name == "Formula4" || game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if(game.gameObject.name == "Formula1")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
            
    }

    void F2C(GameObject game)
    {
        if (game.gameObject.name == "Formula2" || game.gameObject.name == "Formula4" || game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);            
        }
        if (game.gameObject.name == "Formula1" || game.gameObject.name == "Formula5")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula3")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
    }

    void Lb2g(GameObject game)
    {
        if (game.gameObject.name == "Formula2" || game.gameObject.name == "Formula3" || game.gameObject.name == "Formula5")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula1" || game.gameObject.name == "Formula4")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);            
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
    }

    void Mph2Kmh(GameObject game)
    {
        if (game.gameObject.name == "Formula1" || game.gameObject.name == "Formula4" || game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula5" || game.gameObject.name == "Formula3")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula2")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
    }

    void J2Kcal(GameObject game)
    {
        if (game.gameObject.name == "Formula1" || game.gameObject.name == "Formula2" || game.gameObject.name == "Formula6")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula4" || game.gameObject.name == "Formula3")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
        if (game.gameObject.name == "Formula5")
        {
            GameObject game1 = (GameObject)Instantiate(mover, new Vector3(-4.03f, 2.474f, 0f), Quaternion.identity);
            GameObject game3 = (GameObject)Instantiate(mover, new Vector3(-2.281f, 2.474f, 0f), Quaternion.identity);
            game1.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
            game3.transform.SetParent(GameObject.FindWithTag("Net2").transform, false);
        }
    }

    void Clean()
    {
        GameObject[] prefavs = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject enemy in prefavs)
            GameObject.Destroy(enemy);
    }

    public string GetSceneName()
    {
        activeScene = SceneManager.GetActiveScene();
        return activeScene.name;
    }
}
