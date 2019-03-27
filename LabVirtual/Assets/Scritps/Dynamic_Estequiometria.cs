using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.ServiceModel;
using System;

public class Dynamic_Estequiometria : MonoBehaviour {

    public Button buttonSave;
    public InputField Solucion;
    public InputField Prob;
    public Dropdown Nivels;
    public TMP_InputField Pro;

    public GameObject ButtonAceptar;

    string sol;
    string prob;
    string nivels;
    string context;

    private nivel[] datos = new nivel[5];
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemilabservice.azurewebsites.net/ServiceLab.svc"));
    //private string[] simulaciones = new string[5] { "Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion" }; //orden

    // Use this for initialization
    void Start () {
        GetNivel();

        /*GetContext();
        Debug.Log("Original: "+context);
        string[] mierda = context.Split('\n');
        string lala="";
        for (int i = 0; i < datos.Length; i++)
        {
            Debug.Log(mierda[i]);
            lala += mierda[i] + Environment.NewLine;
        }
        
        Debug.Log("version resubida: @" + lala);*/

        /*string[] simulacionesNombre = new string[3] { "problema", "Solucion", "Contexto" };

        string texto = "Masa atómica del carbono = 12,0107@@Masa atómica del oxígeno = 15,9994@@Encontrar la masa molecular del reactivo O";
        string[] simulacionesData = new string[3] { "C + O₂ = CO₂", "266.41", texto };
        servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, "Nivel1", simulacionesNombre);

        texto = "Masa atómica del carbono = 12.01@@Masa atómica del oxígeno = 15.99@Masa atómica del sodio = 22.99@@Masa atómica del hidrógeno = 1.008@@Encontrar la masa molecular de la mezcla.";
        simulacionesData = new string[3] { "NaHCO₃", "84.01", texto };
        servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, "Nivel2", simulacionesNombre);

        texto = "Masa atómica del azufre = 15.99@@Masa atómica del oxígeno = 32.06@@Masa atómica del hidrógeno = 1.008@@Encontrar la masa atómica total de la mezcla.";
        simulacionesData = new string[3] { "H₂SO₄", "98.07", texto };
        servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, "Nivel3", simulacionesNombre);

        texto = "Masa atómica del potasio = 39.098@@Masa atómica del oxígeno = 15.99@@Masa atómica del cloro = 35.45@@Encontrar la masa atómica de la mezcla.";
        simulacionesData = new string[3] { "KClO₃", "122.55", texto };
        servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, "Nivel4", simulacionesNombre);

        texto = "Masa atómica del carbono = 12.01@@Masa atómica del calcio = 40.078@@Masa atómica del oxígeno = 15.99@@Encontrar la masa atómica de la mezcla.";
        simulacionesData = new string[3] { "CaCO₃", "100.086", texto };
        servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, "Nivel5", simulacionesNombre);*/

        //carga de los datos guardados
        load();
    }

    // Update is called once per frame
    void Update()
    {
        GetNivel();
        if (nivels.Equals("Nivel 1"))
        {
            Solucion.text = datos[0].solucion;
            Pro.text = datos[0].contexto;
            Prob.text = datos[0].problema;

        }
        else if (nivels.Equals("Nivel 2"))
        {
            Solucion.text = datos[1].solucion;
            Pro.text = datos[1].contexto;
            Prob.text = datos[1].problema;
        }
        else if (nivels.Equals("Nivel 3"))
        {
            Solucion.text = datos[2].solucion;
            Pro.text = datos[2].contexto;
            Prob.text = datos[2].problema;
        }
        else if (nivels.Equals("Nivel 4"))
        {
            Solucion.text = datos[3].solucion;
            Pro.text = datos[3].contexto;
            Prob.text = datos[3].problema;
        }
        else if (nivels.Equals("Nivel 5"))
        {
            Solucion.text = datos[4].solucion;
            Pro.text = datos[4].contexto;
            Prob.text = datos[4].problema;
        }
    }

    public void ValidateChange()
    {
        string[] simulacionesNombre = new string[3] { "problema", "Solucion", "Contexto" };
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
                string[] simulacionesData = new string[3] { datos[i].problema, datos[i].solucion, lala };
                servicioWCF.GuardarCambioDinamicos("Estequiometria", simulacionesData, 0, aux, simulacionesNombre);
            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }
        SceneManager.LoadScene("Dynamic_Simulations");
    }
    //Esto consigue el texto del problema despues que se cambia
    public void GetProb()
    {
        prob = Prob.text;
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
        string[] simulacionesNombre = new string[3] { "problema", "Solucion", "Contexto" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                string aux = nombreNivel[i];
                datos[i] = new nivel();
                string[] resultados = servicioWCF.BuscarDatosD("Estequiometria", aux, simulacionesNombre);
                datos[i].nivelName = nombreNivel[i];
                datos[i].problema = resultados[0];
                datos[i].solucion = resultados[1];
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

    public void editarProb()
    {
        if (Prob.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].problema = Prob.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].problema = Prob.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].problema = Prob.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].problema = Prob.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].problema = Prob.text;
            }
        }
    }
    public void editarSolucion()
    {
        if (Solucion.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solucion = Solucion.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solucion = Solucion.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solucion = Solucion.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solucion = Solucion.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solucion = Solucion.text;
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

    public class nivel
    {
        public string nivelName { get; set; }
        public string solucion { get; set; }
        public string contexto { get; set; }
        public string problema { get; set; }
    }
}
