using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Script : MonoBehaviour {

    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    List<int> intentos = Simulation_Balance.intentos;

    // Use this for initialization
    void Start () {
        cant_intentos = GameObject.Find("Intentos").GetComponent<TextMesh>();
        promedio_intentos = GameObject.Find("Promedio").GetComponent<TextMesh>();
        GetAverage();
        GetIntentosCount();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetAverage()
    {
        float sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            Debug.Log(intentos[i]);
            sum += intentos[i];
        }
        sum /= intentos.Count;

        promedio_intentos.text = "Promedio por simulación :" + sum;
    }

    void GetIntentosCount()
    {
        cant_intentos.text = "Total de intentos :" + intentos.Count;
    }

}
