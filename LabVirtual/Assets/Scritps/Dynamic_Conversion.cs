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
    public TMP_InputField Pro;

    public GameObject ButtonAceptar;

    string sol;
    string probInicio;
    string probFinal;
    string nivels;
    string context;

    private nivel[] datos = new nivel[5];
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    #endregion


    // Use this for initialization
    void Start()
    {
        GetNivel();


        /*string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto","Formula","Valor" };

        string texto = "Masa atómica del carbono = 12,0107@@Masa atómica del oxígeno = 15,9994@@Encontrar la masa molecular del reactivo O";
        string[] simulacionesData = new string[5] { "C + O₂ = CO₂", "266.41", texto };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel1", simulacionesNombre);

        texto = "Masa atómica del carbono = 12.01@@Masa atómica del oxígeno = 15.99@Masa atómica del sodio = 22.99@@Masa atómica del hidrógeno = 1.008@@Encontrar la masa molecular de la mezcla.";
        simulacionesData = new string[5] { "NaHCO₃", "84.01", texto };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel2", simulacionesNombre);

        texto = "Masa atómica del azufre = 15.99@@Masa atómica del oxígeno = 32.06@@Masa atómica del hidrógeno = 1.008@@Encontrar la masa atómica total de la mezcla.";
        simulacionesData = new string[5] { "H₂SO₄", "98.07", texto };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel3", simulacionesNombre);

        texto = "Masa atómica del potasio = 39.098@@Masa atómica del oxígeno = 15.99@@Masa atómica del cloro = 35.45@@Encontrar la masa atómica de la mezcla.";
        simulacionesData = new string[5] { "KClO₃", "122.55", texto };
        servicioWCF.GuardarCambioDinamicos("Conversion", simulacionesData, 0, "Nivel4", simulacionesNombre);

        texto = "Masa atómica del carbono = 12.01@@Masa atómica del calcio = 40.078@@Masa atómica del oxígeno = 15.99@@Encontrar la masa atómica de la mezcla.";
        simulacionesData = new string[5] { "CaCO₃", "100.086", texto };
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
            SolValor.text=datos[0].solValor;
            SolFormula.text=datos[0].solFormula;
            Pro.text=datos[0].contexto;
            ProbInicio.text=datos[0].probInicio;
            ProbFinal.text=datos[0].probFinal;

        }
        else if (nivels.Equals("Nivel 2"))
        {
            SolValor.text = datos[1].solValor;
            SolFormula.text = datos[1].solFormula;
            Pro.text = datos[1].contexto;
            ProbInicio.text = datos[1].probInicio;
            ProbFinal.text = datos[1].probFinal;
        }
        else if (nivels.Equals("Nivel 3"))
        {
            SolValor.text = datos[2].solValor;
            SolFormula.text = datos[2].solFormula;
            Pro.text = datos[2].contexto;
            ProbInicio.text = datos[2].probInicio;
            ProbFinal.text = datos[2].probFinal;
        }
        else if (nivels.Equals("Nivel 4"))
        {
            SolValor.text = datos[3].solValor;
            SolFormula.text = datos[3].solFormula;
            Pro.text = datos[3].contexto;
            ProbInicio.text = datos[3].probInicio;
            ProbFinal.text = datos[3].probFinal;
        }
        else if (nivels.Equals("Nivel 5"))
        {
            SolValor.text = datos[5].solValor;
            SolFormula.text = datos[5].solFormula;
            Pro.text = datos[5].contexto;
            ProbInicio.text = datos[5].probInicio;
            ProbFinal.text = datos[5].probFinal;
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
                string[] ayuda = datos[i].contexto.Split('\n');
                string lala = "";
                for (int j = 0; j < ayuda.Length; j++)
                {
                    lala += ayuda[j] + "@";
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
    //Esto consigue lo del contexto
    public void GetContext()
    {
        context = Pro.text;
    }

    public void load()
    {
        string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto", "Formula", "Valor" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                string aux = nombreNivel[i];
                datos[i] = new nivel();
                string[] resultados = servicioWCF.BuscarDatosD("Conversion", aux, simulacionesNombre);
                datos[i].nivelName = nombreNivel[i];
                datos[i].probInicio = resultados[0];
                datos[i].probFinal = resultados[1];
                datos[i].solFormula = resultados[3];
                datos[i].solValor = resultados[4];
                string[] ayuda = resultados[2].Split('@');
                string lala = "";
                for (int j = 0; j < ayuda.Length; j++)
                {
                    lala += ayuda[j] + Environment.NewLine;
                }
                datos[i].contexto = lala;


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
        if (Pro.GetComponent<TMP_InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].contexto = Pro.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].contexto = Pro.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].contexto = Pro.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].contexto = Pro.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].contexto = Pro.text;
            }
        }
    }
    public void editarProbInicio()
    {
        if (ProbInicio.GetComponent<TMP_InputField>().isFocused)
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
        if (ProbFinal.GetComponent<TMP_InputField>().isFocused)
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

    public class nivel
    {
        public string nivelName { get; set; }
        public string solFormula { get; set; }
        public string solValor { get; set; }
        public string contexto { get; set; }
        public string probInicio { get; set; }
        public string probFinal { get; set; }
    }
}
