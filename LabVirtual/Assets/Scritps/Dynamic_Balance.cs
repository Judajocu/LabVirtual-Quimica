using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class Dynamic_Balance : MonoBehaviour {

    #region Variables
    string Sol_lvl_1;
    string Sol_lvl_2;
    string Sol_lvl_3;
    string Sol_lvl_4;
    string Sol_lvl_5;
    string Ec_lvl_1;
    string Ec_lvl_2;
    string Ec_lvl_3;
    string Ec_lvl_4;
    string Ec_lvl_5;

    TextMesh S_lvl_1;
    TextMesh S_lvl_2;
    TextMesh S_lvl_3;
    TextMesh S_lvl_4;
    TextMesh S_lvl_5;
    TextMesh E_lvl_1;
    TextMesh E_lvl_2;
    TextMesh E_lvl_3;
    TextMesh E_lvl_4;
    TextMesh E_lvl_5;

    Scene activeScene;
    #endregion

    // Use this for initialization
    void Start() {
        Load();
        AssingMesh();
        AssingValues();
    }

    // Update is called once per frame
    void Update() {

    }

    public void AssingMesh()
    {
        switch (GetSceneName())
        {
            case "Balanceo Nivel 1":
                S_lvl_1 = GameObject.Find("Ecuation").GetComponent<TextMesh>();
                E_lvl_1 = GameObject.Find("Cant_result").GetComponent<TextMesh>();
                return;
            case "Balanceo Nivel 2":
                S_lvl_2 = GameObject.Find("Ecuation").GetComponent<TextMesh>();
                E_lvl_2 = GameObject.Find("Cant_result").GetComponent<TextMesh>();
                return;
            case "Balanceo Nivel 3":
                S_lvl_3 = GameObject.Find("Ecuation").GetComponent<TextMesh>();
                E_lvl_3 = GameObject.Find("Cant_result").GetComponent<TextMesh>();
                return;
            case "Balanceo Nivel 4":
                S_lvl_4 = GameObject.Find("Ecuation").GetComponent<TextMesh>();
                E_lvl_4 = GameObject.Find("Cant_result").GetComponent<TextMesh>();
                return;
            case "Balanceo Nivel 5":
                S_lvl_5 = GameObject.Find("Ecuation").GetComponent<TextMesh>();
                E_lvl_5 = GameObject.Find("Cant_result").GetComponent<TextMesh>();
                return;
        }
        
    }
    public void AssingValues()
    {
        switch (GetSceneName())
        {
            case "Balanceo Nivel 1":
                S_lvl_1.text = Sol_lvl_1;
                E_lvl_1.text =Ec_lvl_1;
                return;
            case "Balanceo Nivel 2":
                S_lvl_1.text = Sol_lvl_1;
                E_lvl_1.text = Ec_lvl_1;
                return;
            case "Balanceo Nivel 3":
                S_lvl_1.text = Sol_lvl_1;
                E_lvl_1.text = Ec_lvl_1;
                return;
            case "Balanceo Nivel 4":
                S_lvl_1.text = Sol_lvl_1;
                E_lvl_1.text = Ec_lvl_1;
                return;
            case "Balanceo Nivel 5":
                S_lvl_1.text = Sol_lvl_1;
                E_lvl_1.text = Ec_lvl_1;
                return;
        }
    }

    //Get Shit answer
    public void Load()
    {
        string path = Application.persistentDataPath + "/Dynamic balance.json";
        if (!File.Exists(@path))
        {
            Sol_lvl_1 = "2 2";
            Sol_lvl_2 = "0 2";
            Sol_lvl_3 = "3 2";
            Sol_lvl_4 = "4 2";
            Sol_lvl_5 = "2 2";
            Ec_lvl_1 = "__H2O₂ = __H₂O+O₂";
            Ec_lvl_2 = "H₂ + Cl₂ = _HCl";
            Ec_lvl_3 = "N₂+ _H₂ = _NH₃";
            Ec_lvl_4 = "_Na + O₂ = _Na₂O";
            Ec_lvl_5 = "__NAOH + H2SO₄ = Na₂SO₄ + _H₂O";
        }
        else
        {
            
            string jsonString = File.ReadAllText(path);
            JSONObject DynamicJson = (JSONObject)JSON.Parse(jsonString);
            Sol_lvl_1 = DynamicJson["Sol_lvl_1"];
            Sol_lvl_2 = DynamicJson["Sol_lvl_2"];
            Sol_lvl_3 = DynamicJson["Sol_lvl_3"];
            Sol_lvl_4 = DynamicJson["Sol_lvl_4"];
            Sol_lvl_5 = DynamicJson["Sol_lvl_5"];
            Ec_lvl_1 = DynamicJson["Ec_lvl_1"];
            Ec_lvl_2 = DynamicJson["Ec_lvl_2"];
            Ec_lvl_3 = DynamicJson["Ec_lvl_3"];
            Ec_lvl_4 = DynamicJson["Ec_lvl_4"];
            Ec_lvl_5 = DynamicJson["Ec_lvl_5"];
        }
    }

    public string GetSceneName()
    {
        activeScene = SceneManager.GetActiveScene();
        return activeScene.name;
    }

}
