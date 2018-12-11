using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.IO;

public class Get_Groups_Grades : MonoBehaviour {

    static string url = "https://jsonblob.com/api/jsonBlob";
    string path = Application.persistentDataPath + "/Nota Grupos.json";

    string name;
    string grade;

    List<string> notas = new List<string>();
    void GetData()
    {
        if (!File.Exists(@path))
        {
            notas.Add("0");
            notas.Add("0");
            notas.Add("0");
        }
        //sending the request to url
        WWW www = new WWW(url);
        StartCoroutine("GetdataEnumerator", url);
    }

    IEnumerator GetdataEnumerator(WWW www)
    {
        //Wait for request to complete
        yield return www;
        if (www.error != null)
        {
            string serviceData = www.text;
            //Data is in json format, we need to parse the Json.
            Debug.Log(serviceData);
            JSONObject json = (JSONObject)JSON.Parse(serviceData);
            if (json == null)
            {
                notas.Add("0");
                notas.Add("0");
                notas.Add("0");
                json.Add(name, grade);
                json.Add("Grupo 001", notas[0]);
                json.Add("Grupo 001", notas[1]);
                json.Add("Grupo 001", notas[2]);
                Debug.Log("No data converted");
                File.WriteAllText(path,json.ToString());
            }
            File.WriteAllText(path, json.ToString());
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
