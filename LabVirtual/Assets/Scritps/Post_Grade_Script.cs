using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.IO;
using System.Text;

public class Post_Grade_Script : MonoBehaviour
{

    static string url = "https://jsonblob.com/api/jsonBlob";

    void PostData()
    {
        string path = Application.persistentDataPath + "/Nota Simulation.json";
        string jsonString = File.ReadAllText(path);
        Hashtable headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        byte[] body = Encoding.UTF8.GetBytes(jsonString);
        WWW www = new WWW(url, body, headers);
        StartCoroutine("PostdataEnumerator", www);
    }
    IEnumerator PostdataEnumerator(WWW www)
    {
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Data Submitted");
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
