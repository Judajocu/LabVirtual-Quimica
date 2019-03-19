using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.ServiceModel;
using System;

public class Dynamic_Conversion : MonoBehaviour {

    #region Varialbes
    public Button buttonSave;
    public InputField SolFormula;
    public InputField SolValor;
    public InputField ProbInicio;
    public InputField ProbFinal;
    public Dropdown Nivels;
    //public TMP_InputField Pro;
    public Dropdown Formulas;
    public InputField SolForApoyo;

    public GameObject ButtonAceptar;

    string sol;
    string probInicio;
    string probFinal;
    string nivels;
    string nivelsFormula;
    string context;
    private int n;

    private nivel[] datos = new nivel[5];
    private string[] countFormulas = new string[6] { "Formula 1", "Formula 2", "Formula 3", "Formula 4", "Formula 5", "Formula 6" };
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    #endregion


    // Use this for initialization
    void Start()
    {
        for(int i=0; i< datos.Length; i++)
        {
            datos[i] = new nivel();
            datos[i].Forms = new string[6];
        }
        
        GetNivel();


        /*string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto","Formula","Valor" };

        string texto = "f(g) = g / 1000@f(g) = g * 0.0001@f(g) = g / 10000@f(g) =  g + 10@f(g) = 100 / g@f(g) = g * (3/5) + 100";
        string[] simulacionesData = new string[5] { "3g", "Kg", texto, "f(g) = g / 1000", "0.003" };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel1", simulacionesNombre);

        texto = "f(F) = F / 1000@f(F) = 13.6 * F@f(F) = F * 1.6@f(F) = F / 4184@f(F) = (5/9)(F-32)@f(F) = F * 453.59";
        simulacionesData = new string[5] { "74 °F", "°C", texto, "f(F) = (5/9)(F-32)", "22.22" };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel2", simulacionesNombre);

        texto = "f(lb) = lb * 5648@f(lb) = 159 * lb@f(lb) = lb * 1.68581@f(lb) = lb / 0.4184@f(lb) = (2/9) * lb@f(lb) = lb * 453.59";
        simulacionesData = new string[5] { "816 lb", "g", texto, "f(lb) = lb * 453.59", "370131" };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel3", simulacionesNombre);

        texto = "f(Mp/h) = Mp/h * 1000@f(Mp/h) = Mp/h / 4184@f(Mp/h) = Mp/h * 1.6@f(Mp/h) = 0.53 * Mp/h@f(Mp/h) = 261 + Mp/h@f(Mp/h) = Mp/h * 5619";
        simulacionesData = new string[5] { "70 Mp/h", "Km/h", texto, "f(Mp/h) = Mp/h * 1.6", "112.654" };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel4", simulacionesNombre);

        texto = "f(J) = 216 * J@f(J) = J * 0.25@f(J) = 3.515 + J@f(J) = J / 4184@f(J) = J / 5619@f(J) = J * 453.59";
        simulacionesData = new string[5] { "80 J", "Kilocalorias", texto, "f(J) = J / 4184", "0.0191205" };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel5", simulacionesNombre);*/

        //carga de los datos guardados
        load();
    }

    // Update is called once per frame
    void Update()
    {
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
        string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto", "Formula", "Valor" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                //string[] ayuda = datos[i].contexto.Split('\n');
                string lala = "";
                for (int j = 0; j < datos[i].Forms.Length; j++)
                {
                    lala += datos[i].Forms[j] + "@";
                }
                string aux = nombreNivel[i];
                string[] simulacionesData = new string[5] { datos[i].probInicio, datos[i].probFinal, lala , datos[i].solFormula , datos[i].solValor };
                servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, aux, simulacionesNombre);
            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }

        SceneManager.LoadScene("Dynamic_Simulations");
    }
    //Esto consigue el texto del problema despues que se cambia
    public void GetProbInicio()
    {
        probInicio = ProbInicio.text;
    }

    public void GetProbFinal()
    {
        probFinal = ProbFinal.text;
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
        string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto", "Formula", "Valor" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                string aux = nombreNivel[i];
                //datos[i] = new nivel();
                string[] resultados = servicioWCF.BuscarDatosD("Conversion", aux, simulacionesNombre);
                datos[i].nivelName = nombreNivel[i];
                datos[i].probInicio = resultados[0];
                datos[i].probFinal = resultados[1];
                datos[i].solFormula = resultados[3];
                datos[i].solValor = resultados[4];
                string[] ayuda = resultados[2].Split('@');
                //string lala = "";
                for (int j = 0; j < ayuda.Length; j++)
                {
                    datos[i].Forms[j] = ayuda[j];
                    //lala += ayuda[j] + Environment.NewLine;
                }


            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }
    }

    
    public void editarSolValor()
    {
        if (SolValor.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solValor = SolValor.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solValor = SolValor.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solValor = SolValor.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solValor = SolValor.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solValor = SolValor.text;
            }
        }
    }
    public void editarSolFormula()
    {
        if (SolFormula.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solFormula = SolFormula.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solFormula = SolFormula.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solFormula = SolFormula.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solFormula = SolFormula.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solFormula = SolFormula.text;
            }
        }
    }
    public void editarContexto()
    {
        if (SolForApoyo.GetComponent<InputField>().isFocused)
        {
            GetNivelFormula();

            for (int i = 0; i < countFormulas.Length; i++)
            {
                if (nivelsFormula.Equals(countFormulas[i]))
                {
                    datos[n].Forms[i]=SolForApoyo.text;
                }
            }

        }
    }
    public void editarProbInicio()
    {
        if (ProbInicio.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].probInicio = ProbInicio.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].probInicio = ProbInicio.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].probInicio = ProbInicio.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].probInicio = ProbInicio.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].probInicio = ProbInicio.text;
            }
        }
    }
    public void editarProbFinal()
    {
        if (ProbFinal.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].probFinal = ProbFinal.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].probFinal = ProbFinal.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].probFinal = ProbFinal.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].probFinal = ProbFinal.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].probFinal = ProbFinal.text;
            }
        }
    }

    public void actualizarFor(int a)
    {
        SolValor.text = datos[a].solValor;
        SolFormula.text = datos[a].solFormula;
        ProbInicio.text = datos[a].probInicio;
        ProbFinal.text = datos[a].probFinal;

        GetNivelFormula();

        for (int i = 0; i < countFormulas.Length; i++)
        {
            if (nivelsFormula.Equals(countFormulas[i]))
            {
                SolForApoyo.text= datos[a].Forms[i];
            }
        }
        
    }

    public class nivel
    {
        public string nivelName { get; set; }
        public string solFormula { get; set; }
        public string solValor { get; set; }
        public string probInicio { get; set; }
        public string probFinal { get; set; }
        public string[] Forms { get; set; }

    }
}
