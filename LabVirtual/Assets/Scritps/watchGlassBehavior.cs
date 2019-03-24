using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class watchGlassBehavior : MonoBehaviour {

    public TextMesh palabra =null;
    private string word = null;
    private int wordindex = 0;

    public int result;
    private List<string> lista = new List<string>();
    public string[] arr = new string[5];
    bool valor_respuesta;

    // Use this for initialization
    void Start () {

        /*arr[0] = "CS\u2082";
        arr[1] = "PI\u2083";
        arr[2] = "SiH\u2084";
        arr[3] = "Cl\u2082O\u2085";
        arr[4] = "Br\u2082O";*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resultado(GameObject esto)
    {
        //esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "D";
        wordindex++;
        //word = word + esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text;
        //llenando lista de elementos
        lista.Add(esto.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text);
        word = contarRepetidos(lista);
        palabra.text = word;
    }

    private string contarRepetidos(List<string> list)
    {
        string formula = null;
        string anterior = null;
        int count = 1;
        //recorre la lista de elementos
        foreach (string l in list)
        {
            //si la letra anterior guardada esta vacia
            if (!string.IsNullOrEmpty(anterior))
            {
                //si el elemento actual es igual al anterior cuenta el numero de repeticiones
                if(anterior == l)
                {
                    count++;
                }
                else
                { //si no debuelve el contador al valor por defecto y adquiere el subindice se la letra actual
                    string sub = sufijo(count);
                    formula = formula + anterior;
                    if (!string.IsNullOrEmpty(sub))
                    {
                        formula = formula + sub;
                    }
                    count = 1;
                }

                anterior = l;
            }
            else
            { //si no simplemente guarda el elemento actual para comparar en el siguiente lugar
                anterior = l;
            }
        }

        string sub2 = sufijo(count);
        formula = formula + anterior;
        if (!string.IsNullOrEmpty(sub2))
        {
            formula = formula + sub2;
        }
        //count = 1;



        return formula;
    }

    private string sufijo(int cant)
    {
        string sufijo = null;
        if(cant == 2)
        {
            sufijo= "\u2082";
        }

        if (cant == 3)
        {
            sufijo = "\u2083";
        }
        if (cant == 4)
        {
            sufijo = "\u2084";
        }
        if (cant == 5)
        {
            sufijo = "\u2085";
        }
        if (cant == 6)
        {
            sufijo = "\u2086";
        }
        if (cant == 7)
        {
            sufijo = "\u2087";
        }
        if (cant == 8)
        {
            sufijo = "\u2088";
        }
        if (cant == 9)
        {
            sufijo = "\u2089";
        }

        return sufijo;
    }

    public void BorrarFormula()
    {
        word = null;
        palabra.text = null;
        wordindex = 0;
        lista.Clear();

    }

    public void BorrarFormula2(GameObject esto)
    {
        word = null;
        palabra.text = null;
        wordindex = 0;
        lista.Clear();

    }

    public void ComprobarFormula()
    {
        string r = arr[result];
        if(r== palabra.text)
        {
            palabra.text = "Correcto";
        }
        else
        {
            palabra.text = "Incorrecto";
        }

    }

    public void enviar(GameObject esto)
    {
        string r = arr[result];
        if (r == palabra.text)
        {
            //palabra.text = "Correcto";
            valor_respuesta = true;
        }
        else
        {
            //palabra.text = "Incorrecto";
            valor_respuesta = false;
        }

        GameObject.FindGameObjectWithTag("nomenclatura").GetComponent<Simulacion_nomenclatura>().SendMessage("respuesta", valor_respuesta);

    }

    public void rellenar(string[] esto)
    {
        for(int i = 0; i < 5; i++)
        {
            arr[i] = esto[i];
        }
    }
}
