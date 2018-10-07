using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Result_Script : MonoBehaviour {

    #region Variables
    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    TextMesh promedio_tiempos;
    TextMesh nota_resultante;

    public GameObject menu;

    public Button ButtonMenu;

    List<int> intentos = Simulation_Balance.intentos;
    List<float> tiempos = Simulation_Balance.tiempos;

    SettingsProffesorScript settings = new SettingsProffesorScript();
    bool type = Niveles_prefab_script.levels;
    float intervalo;
    int penalidad;
    #endregion

    // Use this for initialization
    void Start () {
        cant_intentos = GameObject.Find("Intentos").GetComponent<TextMesh>();
        promedio_tiempos = GameObject.Find("Promedio_tiempo").GetComponent<TextMesh>();
        nota_resultante = GameObject.Find("Nota_resultante").GetComponent<TextMesh>();
        intervalo = settings.Getintervalo();
        penalidad = settings.Gettrys();
        GetIntentosCount();
        GetGrade();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateMenu()
    {
        
        SceneManager.LoadScene("Options_Student");
    }

    public float GetAverageTrys()
    {
        float sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            //Debug.Log(intentos[i]);
            sum += intentos[i];
        }
        Debug.Log("intentos total" + sum);
        sum /= intentos.Count;
        Debug.Log("size de intentos"+intentos.Count);
        Debug.Log("El total de intentos contados"+intentos.Count);
        //promedio_intentos.text = "Promedio por simulación :" + sum;

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
        float lele;
        for (int i = 0; i < tiempos.Count; i++)
        {
         // Debug.Log(tiempos[i]);
            sum += tiempos[i];
            lele = tiempos[i];
            Debug.Log("tiempos en nivel" + i + "tiempo:" +  lele);
        }
        sum /= tiempos.Count;
        Debug.Log("cantidades de tiempo" + tiempos.Count);
        //sum = 60.0f - sum;

        promedio_tiempos.text = "Promedio de tiempo:" + sum;

        return sum;
    }

    public float CheckTrys(float trys, float time)
    {
        if (trys < penalidad)
        {
            time += 0.0f;
        }
        if (trys < penalidad*2 && trys > penalidad)
        {
            time += 5.0f;
        }
        if (trys > penalidad*3)
        {
            time += 10.0f;
        }

        return time;
    }

    public string AssingGrade(float final_time)
    {
        string grade = "";

        if (final_time <= 10.0f)
            grade = "A";

        if (final_time >= 10.1f && final_time <= 20.0f)
            grade = "B";

        if (final_time >= 20.1f && final_time <= 30.0f)
            grade = "C";

        if (final_time >= 30.1f)
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
