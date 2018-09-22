using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Script : MonoBehaviour {

    #region Variables
    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    TextMesh promedio_tiempos;
    TextMesh nota_resultante;

    List<int> intentos = Simulation_Balance.intentos;
    List<float> tiempos = Simulation_Balance.tiempos;

    
    #endregion

    // Use this for initialization
    void Start () {
        cant_intentos = GameObject.Find("Intentos").GetComponent<TextMesh>();
        promedio_intentos = GameObject.Find("Promedio_intentos").GetComponent<TextMesh>();
        promedio_tiempos = GameObject.Find("Promedio_tiempo").GetComponent<TextMesh>();
        nota_resultante = GameObject.Find("Nota_resultante").GetComponent<TextMesh>();
        GetIntentosCount();
        GetGrade();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetAverageTrys()
    {
        float sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            Debug.Log(intentos[i]);
            sum += intentos[i];
        }
        sum /= intentos.Count;

        promedio_intentos.text = "Promedio por simulación :" + sum;

        return sum;
    }

    public void GetIntentosCount()
    {
        int sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            sum += intentos[i];
        }
        cant_intentos.text = "Total de intentos :" + sum;
    }

    public float GetAverageTime()
    {
        float sum = 0;
        for (int i = 0; i < tiempos.Count; i++)
        {
         // Debug.Log(tiempos[i]);
            sum += tiempos[i];
        }
        sum /= tiempos.Count;
        //sum = 60.0f - sum;

        promedio_tiempos.text = "Promedio de tiempo:" + sum;

        return sum;
    }

    public float CheckTrys(float trys, float time)
    {
        if (trys < 3)
        {
            time -= 0.0f;
        }
        if (trys < 5 && trys > 2)
        {
            time -= 5.0f;
        }
        if (trys > 5)
        {
            time -= 10.0f;
        }

        return time;
    }

    public string AssingGrade(float final_time)
    {
        string grade = "";

        if (final_time >= 50.0f)
            grade = "A";

        if (final_time <= 49.0f && final_time >= 40.0f)
            grade = "B";

        if (final_time <= 39.0f && final_time >= 30.0f)
            grade = "C";

        if (final_time <= 29.0f)
            grade = "D";

        return grade;
    }

    public void GetGrade()
    {
        float time = GetAverageTime();
        float trys = GetAverageTrys();
        float final_time = CheckTrys(trys, time);
        string grade = AssingGrade(final_time);

        nota_resultante.text = "Calificacion resultante:" + grade;
    }
}
