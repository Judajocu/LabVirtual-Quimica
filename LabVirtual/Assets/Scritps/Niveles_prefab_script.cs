using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Niveles_prefab_script : MonoBehaviour {

    #region Variables
    public Button buttonquit;
    public Button buttonnivel1;
    public Button buttonnivel2;
    public Button buttonnivel3;
    public Button buttonnivel4;
    public Button buttonnivel5;

    public GameObject niveles;
    public GameObject quit;
    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject nivel3;
    public GameObject nivel4;
    public GameObject nivel5;
    public static GameObject game;
    public GameObject placeholder;
    
    public static bool levels;
    Simulation_Options_Scripts simulation = new Simulation_Options_Scripts();
    SettingsProffesorScript settings = new SettingsProffesorScript();
    int selected;
    #endregion

    // Use this for initialization
    void Start () {
        CheckSettings();
        selected = simulation.GetSelected();
        Debug.Log(selected);
        levels = false;
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void ValidateNiveles()
    {
        Debug.Log("fuck this GO");
        Destroy(game);
        InstantiateNiveles();
    }

    public void Validatenivel1()
    {
        CheckType1();
        Debug.Log(levels);
        CheckSimulation("1");
    }

    public void Validatenivel2()
    {
        CheckType1();
        Debug.Log(levels);
        CheckSimulation("2");
    }

    public void Validatenivel3()
    {
        CheckType1();
        Debug.Log(levels);
        CheckSimulation("3");
    }

    public void Validatenivel4()
    {
        CheckType1();
        Debug.Log(levels);
        CheckSimulation("4");
    }

    public void Validatenivel5()
    {
        CheckType1();
        Debug.Log(levels);
        CheckSimulation("5");
    }

    public void InstantiateNiveles()
    {
        game = Instantiate(niveles, new Vector3(0f, 0f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);

    }

    public void ExitNiveles()
    {
        Destroy(game);
        game = Instantiate(placeholder, new Vector3(0f, 0f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
    }

    public void CheckSimulation(string nivel)
    {
        switch (simulation.GetSelected())
        {
            case 1:
                SceneManager.LoadScene("Balanceo nivel "+nivel);
                return;
            case 2:
                //SceneManager.LoadScene("Tabla nivel " + nivel);
                return;
            case 3:
                //SceneManager.LoadScene("conversion nivel " + nivel);
                return;
            case 4:
                //SceneManager.LoadScene("nomenclatura nivel " + nivel);
                return;
            case 5:
                //SceneManager.LoadScene("estequiometria nivel " + nivel);
                return;
        }
    }

    public void CheckType1()
    {
        levels = true;
    }

    public void CheckType2()
    {
        levels = false;
    }

    public void CheckSettings()
    {
        if (settings.Gettime() == 0)
        {
            float x = 60;
            settings.SetTime(x);
        }
        if (settings.Gettrys() == 0)
        {
            settings.SetTrys(5);
        }
        if (settings.Getintervalo() == 0)
        {
            settings.Setintervalos(5);
        }
    }

}
