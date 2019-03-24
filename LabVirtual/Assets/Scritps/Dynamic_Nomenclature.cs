using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ServiceModel;

public class Dynamic_Nomenclature : MonoBehaviour {

    #region Varialbes
    public Button buttonSave;
    public InputField Solucion;
    public InputField Problema;
    public Dropdown Nivels;
    //public TMP_InputField Pro;
    public Dropdown Formulas;
    public InputField Elementos;

    string nivels;
    string nivelsFormula;
    private int n;
    private int nTotal = 26;

    private nivel[] datos = new nivel[5];
    private string countOpciones = "Símbolo";
    string[] simulacionesNombre = new string[3] { "Solucion", "problema", "Elementos" };
    string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    #endregion

    // Use this for initialization
    void Start () {

        
         for (int i = 0; i < datos.Length; i++)
        {
            datos[i] = new nivel();
            datos[i].Forms = new string[nTotal];
        }

        GetNivel();
        /*
        //"Solucion", "problema", "Elementos"
        string EElementos = "Mn@Fe@Ag@Ni@Cr@Co@Pb@Zn@Cu@Pt@Au@Th@U@S@H@P@O@N@F@Br@I@Cl@Se@Si@C@B";
        string[] simulacionesData = new string[3] { "CS₂", "Disulfuro de carbono", EElementos };
        servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, "Nivel1", simulacionesNombre);

        EElementos = "Mn@Fe@Ag@Ni@Cr@Co@Pb@Zn@Cu@Pt@Au@Th@U@S@H@P@O@N@F@Br@I@Cl@Se@Si@C@B";
        simulacionesData = new string[3] { "PI₃", "Triyoduro de fósforo", EElementos };
        servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, "Nivel2", simulacionesNombre);

        EElementos = "Mn@Fe@Ag@Ni@Cr@Co@Pb@Zn@Cu@Pt@Au@Th@U@S@H@P@O@N@F@Br@I@Cl@Se@Si@C@B";
        simulacionesData = new string[3] { "SiH₄", "Tetrahidruro de silicio", EElementos };
        servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, "Nivel3", simulacionesNombre);

        EElementos = "Mn@Fe@Ag@Ni@Cr@Co@Pb@Zn@Cu@Pt@Au@Th@U@S@H@P@O@N@F@Br@I@Cl@Se@Si@C@B";
        simulacionesData = new string[3] { "Cl₂O₅", "Pentaóxido de dicloro", EElementos };
        servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, "Nivel4", simulacionesNombre);

        EElementos = "Mn@Fe@Ag@Ni@Cr@Co@Pb@Zn@Cu@Pt@Au@Th@U@S@H@P@O@N@F@Br@I@Cl@Se@Si@C@B";
        simulacionesData = new string[3] { "Br₂O", "Monóxido de dibromo", EElementos };
        servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, "Nivel5", simulacionesNombre);

        H₂S₃P₄N₅
         arr[0] = "CS\u2082";
       arr[1] = "PI\u2083";
       arr[2] = "SiH\u2084";
       arr[3] = "Cl\u2082O\u2085";
       arr[4] = "Br\u2082O";
        Nivel 5

        Formula: Monóxido de dibromo
        Elementos: Mn @ Fe @ Ag @ Ni @ Cr @ Co @ Pb @ Zn @ Cu Pt @ Au @ Th @ U @ S @ H @ P @ O @ N @ F @ Br @ I @ Cl @ Se @ Si @ C @ B
        */
        load();

    }

    // Update is called once per frame
    void Update () {

        GetNivel();
        if (nivels.Equals("Nivel 1"))
        {
            n = 0;
            actualizarFor(n);

        }
        else if (nivels.Equals("Nivel 2"))
        {
            n = 1;
            actualizarFor(n);
        }
        else if (nivels.Equals("Nivel 3"))
        {
            n = 2;
            actualizarFor(n);
        }
        else if (nivels.Equals("Nivel 4"))
        {
            n = 3;
            actualizarFor(n);
        }
        else if (nivels.Equals("Nivel 5"))
        {
            n = 4;
            actualizarFor(n);
        }

    }

    public void ValidateChange()
    {
        
        for (int i = 0; i < datos.Length; i++)
        {
            try
            {

                //"Solucion", "problema", "Elementos"

                string lala = "";
                for (int j = 0; j < datos[i].Forms.Length; j++)
                {
                    lala += datos[i].Forms[j] + "@";
                }
                string aux = nombreNivel[i];
                string[] simulacionesData = new string[3] { datos[i].solucion, datos[i].problema, lala};
                servicioWCF.GuardarCambioDinamicos("Nomenclatura", simulacionesData, 0, aux, simulacionesNombre);
            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }

        SceneManager.LoadScene("Dynamic_Simulations");
    }
    

    //Esto consigue el texto del dropdown
    public void GetNivel()
    {
        nivels = Nivels.options[Nivels.value].text;
    }

    public void GetNivelFormula()
    {
        nivelsFormula = Formulas.options[Formulas.value].text;
    }
    //Esto consigue lo del contexto

    public void load()
    {

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                string aux = nombreNivel[i];
                string[] resultados = servicioWCF.BuscarDatosD("Nomenclatura", aux, simulacionesNombre);
                datos[i].nivelName = nombreNivel[i];

                datos[i].solucion = resultados[0];
                datos[i].problema = resultados[1];

                string[] ayuda = resultados[2].Split('@');
                for (int j = 0; j < nTotal; j++)
                {
                    datos[i].Forms[j] = ayuda[j];
                }


            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }
    }


    public void editarSolucion()
    {
        if (Solucion.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            datos[n].solucion = Solucion.text;
        }
    }
    public void editarproblema()
    {
        if (Problema.GetComponent<InputField>().isFocused)
        {
            datos[n].problema = Problema.text;
            
        }
    }
    public void editarContexto()
    {
        if (Elementos.GetComponent<InputField>().isFocused)
        {
            GetNivelFormula();

            for (int i = 0; i < nTotal; i++)
            {
                if (nivelsFormula.Equals(countOpciones + " " + (i + 1)))
                {
                    datos[n].Forms[i] = Elementos.text;
                }
            }

        }
    }

    public void actualizarFor(int a)
    {
        Solucion.text = datos[a].solucion;
        Problema.text = datos[a].problema;

        GetNivelFormula();

        for (int i = 0; i < nTotal; i++)
        {
            if (nivelsFormula.Equals(countOpciones+" "+(i+1)))
            {
                Elementos.text = datos[a].Forms[i];
            }
        }

    }

    public class nivel
    {
        public string nivelName { get; set; }
        public string solucion { get; set; }
        public string problema { get; set; }
        public string[] Forms { get; set; }

    }
}



   

