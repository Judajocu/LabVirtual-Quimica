using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Script : MonoBehaviour {

    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    TextMesh promedio_tiempos;

    List<int> intentos = Simulation_Balance.intentos;
    List<float> tiempos = Simulation_Balance.tiempos;

    // Use this for initialization
    void Start () {
        cant_intentos = GameObject.Find("Intentos").GetComponent<TextMesh>();
        promedio_intentos = GameObject.Find("Promedio_intentos").GetComponent<TextMesh>();
        promedio_tiempos = GameObject.Find("Promedio_tiempo").GetComponent<TextMesh>();
        GetAverageTrys();
        GetIntentosCount();
        GetAverageTime();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetAverageTrys()
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
        int sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            sum += intentos[i];
        }
        cant_intentos.text = "Total de intentos :" + sum;
    }

    void GetAverageTime()
    {
        float sum = 0;
        for (int i = 0; i < tiempos.Count; i++)
        {
         // Debug.Log(tiempos[i]);
            sum += tiempos[i];
        }
        sum /= tiempos.Count;
        sum = 60.0f - sum;

        promedio_tiempos.text = "Promedio de tiempo:" + sum;
    }

}
