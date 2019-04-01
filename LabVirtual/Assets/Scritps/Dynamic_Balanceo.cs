using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.ServiceModel;

public class Dynamic_Balanceo : MonoBehaviour {

    #region Varialbes
    public Button buttonSave;
    public InputField SolIzquierda;
    public InputField SolDerecha;
    public InputField Prob;
    public Dropdown Nivels;
    public TMP_InputField Pro;

    public GameObject ButtonAceptar;

    string sol;
    string prob;
    string nivels;
    string context;

    private nivel[] datos = new nivel[5];
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    //private string[] simulaciones = new string[5] { "Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion" }; //orden
    #endregion


    // Use this for initialization
    void Start () {
        GetNivel();

        /*string[] simulacionesNombre = new string[3] { "problema", "SolIzq", "SolDer" };

        string[] simulacionesData = new string[3] { "__H2O₂ = __H₂O + O₂", "2", "2" };
        servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0,"Nivel1",simulacionesNombre);
        
        simulacionesData = new string[3] { "H₂ + Cl₂ = _HCl", "0", "2" };
        servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0, "Nivel2", simulacionesNombre);
        
        simulacionesData = new string[3] { "N₂+ _H₂ = _NH₃", "3", "2" };
        servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0, "Nivel3", simulacionesNombre);
        
        simulacionesData = new string[3] { "_Na + O₂ = _Na₂O", "4", "2" };
        servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0, "Nivel4", simulacionesNombre);
        
        simulacionesData = new string[3] { "__NAOH + H2SO₄ = Na₂SO₄ + _H₂O", "2", "2" };
        servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0, "Nivel5", simulacionesNombre);*/

        //carga de los datos guardados
        load();
        /*print("1:"+datos[0].problema+" izq: "+ datos[0].solIzq + " der:"+ datos[0].solDer);
        print("2:" + datos[1].problema + " izq: " + datos[0].solIzq + " der:" + datos[0].solDer);
        print("3:" + datos[2].problema + " izq: " + datos[0].solIzq + " der:" + datos[0].solDer);
        print("4:"+datos[3].problema + " izq: " + datos[0].solIzq + " der:" + datos[0].solDer);
        print("5:"+datos[4].problema + " izq: " + datos[0].solIzq + " der:" + datos[0].solDer);*/

    }
	
	// Update is called once per frame
	void Update () {
        GetNivel();
        if(nivels.Equals("Nivel 1")){
            SolIzquierda.text = datos[0].solIzq;
            SolDerecha.text = datos[0].solDer;
            Prob.text = datos[0].problema;

        }
        else if (nivels.Equals("Nivel 2")){
            SolIzquierda.text = datos[1].solIzq;
            SolDerecha.text = datos[1].solDer;
            Prob.text = datos[1].problema;
        }
        else if (nivels.Equals("Nivel 3")){
            SolIzquierda.text = datos[2].solIzq;
            SolDerecha.text = datos[2].solDer;
            Prob.text = datos[2].problema;
        }
        else if (nivels.Equals("Nivel 4")){
            SolIzquierda.text = datos[3].solIzq;
            SolDerecha.text = datos[3].solDer;
            Prob.text = datos[3].problema;
        }
        else if (nivels.Equals("Nivel 5")){
            SolIzquierda.text = datos[4].solIzq;
            SolDerecha.text = datos[4].solDer;
            Prob.text = datos[4].problema;
        }
    }

    public void ValidateChange()
    {
        string[] simulacionesNombre = new string[3] { "problema", "SolIzq", "SolDer" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            print("lo que devuelve es:");
            try
            {
                string aux = nombreNivel[i];
                string[] simulacionesData = new string[3] { datos[i].problema, datos[i].solIzq, datos[i].solDer };
                servicioWCF.GuardarCambioDinamicos("Balanceo", simulacionesData, 0, aux, simulacionesNombre);
                /*for (int j = 0; j < resultados.Length; j++)
                {
                    print("nivel: " + nombreNivel[i] + ", " + resultados[j] );
                }*/
            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }
        SceneManager.LoadScene("Dynamic_Simulations");
    }
    //Esto consigue el texto de la solucion despues que se cambia
    public void GetSol()
    {
        sol = SolIzquierda.text + " "+ SolDerecha.text;
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
        string[] simulacionesNombre = new string[3] { "problema", "SolIzq", "SolDer" };
        string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };

        for (int i = 0; i < datos.Length; i++)
        {
            print("lo que devuelve es:");
            try {
                string aux = nombreNivel[i];
                datos[i] = new nivel();
                string[] resultados = servicioWCF.BuscarDatosD("Balanceo", aux, simulacionesNombre);
                datos[i].nivelName= nombreNivel[i];
                datos[i].problema = resultados[0];
                datos[i].solIzq = resultados[1];
                datos[i].solDer = resultados[2];
                /*for (int j = 0; j < resultados.Length; j++)
                {
                    print("nivel: " + nombreNivel[i] + ", " + resultados[j] );
                }*/
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
    public void editarIzq()
    {
        if (SolIzquierda.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solIzq=SolIzquierda.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solIzq = SolIzquierda.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solIzq = SolIzquierda.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solIzq = SolIzquierda.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solIzq = SolIzquierda.text;
            }
        }
    }
    public void editarDer()
    {
        if (SolDerecha.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solDer=SolDerecha.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solDer = SolDerecha.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solDer = SolDerecha.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solDer = SolDerecha.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solDer = SolDerecha.text;
            }
        }
    }

    public class nivel
    {
        public string nivelName { get; set; }
        public string solIzq { get; set; }
        public string solDer { get; set; }
        public string problema { get; set; }
    }

}
