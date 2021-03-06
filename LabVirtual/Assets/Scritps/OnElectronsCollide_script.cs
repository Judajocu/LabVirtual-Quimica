﻿using System.Collections;
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
    public GameObject massFirst;
    public GameObject massSecond;
    public GameObject superficie;
    public TextMesh ExpectedA;
    int check = 2;

    //bool activar;
    public double anterior=0;

    Scene activeScene;

    // Use this for initialization
    void Start()
    {
        answer.gameObject.SetActive(false);
        baseScale.gameObject.SetActive(false);
        scale.gameObject.SetActive(false);
        massFirst.gameObject.SetActive(false);
        massSecond.gameObject.SetActive(false);
        superficie.gameObject.SetActive(false);

        //activar = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnTriggerExit2D(Collider2D collision)
    public void resultado(GameObject collision)
    {
        Clean();
        Debug.Log("collisionando");
        if (collision.gameObject.tag == "Symbol")
        {
            baseScale.gameObject.SetActive(true);
            scale.gameObject.SetActive(true);
            massFirst.gameObject.SetActive(true);
            massSecond.gameObject.SetActive(true);
            superficie.gameObject.SetActive(true);

            GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("funcionar", true);
            GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("funcionar", true);

            scale.transform.rotation = Quaternion.Euler(0,0,0);
            conversion.text = collision.transform.gameObject.GetComponentInChildren<Text>().text;
            switch(GetSceneName())
            {
                case "Conversion Nivel 1":
                    G2Kg(collision.gameObject);
                    break;
                case "Conversion Nivel 2":
                    //F2C(collision.gameObject);
                    break;
                case "Conversion Nivel 3":
                    //Lb2g(collision.gameObject);
                    break;
                case "Conversion Nivel 4":
                    //Mph2Kmh(collision.gameObject);
                    break;
                case "Conversion Nivel 5":
                    //J2Kcal(collision.gameObject);
                    break;
            }
            
        }
        answer.gameObject.SetActive(true);
    }

    void G2Kg(GameObject game)
    {

        
        /*if(game.gameObject.name == "Formula2" || game.gameObject.name == "Formula3" || game.gameObject.name == "Formula5")
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
        }*/
            
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

    public void editar()
    {
        
        double actual = double.Parse(answer.text);
        double resp = double.Parse(ExpectedA.text);
        if (actual != anterior)
        {
            int moving = 0;
            Debug.Log("se ingreso texto");
            //mensaje para que la masa vuelva a su posicion origianl
            if (actual > resp)
            {
                if (check == 2 || check == 1)
                {
                    check = 1;
                    float degrees = -500;
                    Vector3 to = new Vector3(0, 0, degrees);
                    Debug.Log(scale.transform.eulerAngles.z.ToString());
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to, Time.deltaTime);
                    Debug.Log(scale.transform.eulerAngles.z.ToString());

                    GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("changeSize", 1.5F);
                    baseScale.GetComponentInChildren<Text>().text = "<";
                    moving = 0;
                }
                if(check == 0)
                {
                    Debug.Log("Changing ways i");
                    check = 1;
                    /*float ChangeZ = -scale.transform.eulerAngles.z;
                    Vector3 to2 = new Vector3(0, 0, ChangeZ);
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to2, Time.deltaTime);
                    Debug.Log(scale.transform.eulerAngles);*/
                    scale.transform.rotation = Quaternion.identity;
                    float degrees = -500;
                    Vector3 to = new Vector3(0, 0, degrees);
                    Debug.Log(scale.transform.eulerAngles.z.ToString());
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to, Time.deltaTime);
                    Debug.Log(scale.transform.eulerAngles.z.ToString());

                    GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("changeSize", 1.5F);
                    baseScale.GetComponentInChildren<Text>().text = "<";
                    moving = 0;
                }
                
            }
            if(actual < resp)
            {
                if(check == 2 || check == 0)
                {
                    check = 0;
                    float degrees = 500;
                    Vector3 to = new Vector3(0, 0, degrees);
                    Debug.Log(scale.transform.rotation.z.ToString());
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to, Time.deltaTime);
                    Debug.Log(scale.transform.eulerAngles.z.ToString());

                    GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("changeSize", 0.2F);
                    baseScale.GetComponentInChildren<Text>().text = ">";
                    moving = 0;
                }
                if(check == 1)
                {
                    Debug.Log("Changing ways d");
                    check = 0;
                    /*float ChangeZ = -scale.transform.eulerAngles.z;
                    Vector3 to2 = new Vector3(0, 0, ChangeZ);
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to2, Time.deltaTime);
                    Debug.Log(scale.transform.eulerAngles);*/
                    scale.transform.rotation = Quaternion.identity;
                    float degrees = 500;
                    Vector3 to = new Vector3(0, 0, degrees);
                    scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to, Time.deltaTime);

                    GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                    GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("changeSize", 0.2F);
                    baseScale.GetComponentInChildren<Text>().text = ">";
                    moving = 0;
                }

            }
            if (actual == resp)
            {
                scale.transform.rotation = Quaternion.identity;
                float degrees = 0;
                Vector3 to = new Vector3(0, 0, degrees);
                scale.transform.eulerAngles = Vector3.Lerp(scale.transform.rotation.eulerAngles, to, Time.deltaTime);
                
                GameObject.FindGameObjectWithTag("m1").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("Reinicio", true);
                GameObject.FindGameObjectWithTag("m2").GetComponent<balance_behavior>().SendMessage("changeSize", 0.6F);
                baseScale.GetComponentInChildren<Text>().text = "=";
                moving = 0;
            }
            //comparar valor
            anterior = actual;
        }
    }

    public void changeScale()
    {

    }
}
