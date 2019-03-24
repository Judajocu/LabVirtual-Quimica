using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ServiceModel;

public class Dynamic_Table : MonoBehaviour {

    #region Varialbes
    public Button buttonSave;
    public InputField SolSimbolo;
    public InputField SolMasa;
    public InputField SolElectron;
    public InputField SolElemento;
    public Dropdown Nivels;
    //public TMP_InputField Pro;
    public Dropdown Formulas;
    public Dropdown FormulasNum;
    public InputField opciones;

    public GameObject ButtonAceptar;
    
    string nivels;
    string nivelsFormula;
    string nivelsFormulaNum;
    private int n;
    private int num = 5;

    private nivel[] datos = new nivel[5];
    private string[] countOpciones = new string[3] { "Símbolo", "Masa", "Electrones"};
    private string[] countOpcionesNum = new string[5] { "Opción 1", "Opción 2", "Opción 3", "Opción 4", "Opción 5" };
    private string[] nombreNivel = new string[5] { "Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" };
    private string[] simulacionesNombre = new string[5] { "Soluciones", "Elemento", "Simbolos", "Masas", "Electrones" };
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    #endregion

    // Use this for initialization
    void Start () {

        
         for (int i = 0; i < datos.Length; i++)
        {
            datos[i] = new nivel();
            datos[i].FormsSimbolos = new string[num];
            datos[i].FormsMasas = new string[num];
            datos[i].FormsElectrones = new string[num];
        }

        GetNivel();

        //"Soluciones", "Elemento", "Simbolos", "Masas", "Electrones"
        /*
        string ESoluciones = "Cl@35.45@2,8,7";
        string ESimbolos = "Cl@Mg@Sc@Ar@S";
        string EMasa = "35.45@44.96@24.31@32.06@39.95";
        string EElectron = "2,8,6@2,8,7@2,8,8@2,8,2@2,8,9,2";
        string[] simulacionesData = new string[5] { ESoluciones, "Cloro", ESimbolos, EMasa, EElectron};
        servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, "Nivel1", simulacionesNombre);

        ESoluciones = "CSc@44.96@2,8,9,2";
        ESimbolos = "Cl@Mg@Sc@Ar@S";
        EMasa = "35.45@44.96@24.31@32.06@39.95";
        EElectron = "2,8,6@2,8,7@2,8,8@2,8,2@2,8,9,2";
        simulacionesData = new string[5] { ESoluciones, "Escandio", ESimbolos, EMasa, EElectron };
        servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, "Nivel2", simulacionesNombre);

        ESoluciones = "Mg@24.31@2,8,2";
        ESimbolos = "Cl@Mg@Sc@Ar@S";
        EMasa = "35.45@44.96@24.31@32.06@39.95";
        EElectron = "2,8,6@2,8,7@2,8,8@2,8,2@2,8,9,2";
        simulacionesData = new string[5] { ESoluciones, "Magnesio", ESimbolos, EMasa, EElectron };
        servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, "Nivel3", simulacionesNombre);

        ESoluciones = "Ar@39.95@2,8,8";
        ESimbolos = "Cl@Mg@Sc@Ar@S";
        EMasa = "35.45@44.96@24.31@32.06@39.95";
        EElectron = "2,8,6@2,8,7@2,8,8@2,8,2@2,8,9,2";
        simulacionesData = new string[5] { ESoluciones, "Argón", ESimbolos, EMasa, EElectron };
        servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, "Nivel4", simulacionesNombre);

        ESoluciones = "S@32.06@2,8,6";
        ESimbolos = "Cl@Mg@Sc@Ar@S";
        EMasa = "35.45@44.96@24.31@32.06@39.95";
        EElectron = "2,8,6@2,8,7@2,8,8@2,8,2@2,8,9,2";
        simulacionesData = new string[5] { ESoluciones, "Azufre", ESimbolos, EMasa, EElectron };
        servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, "Nivel5", simulacionesNombre);
        
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
        //"Nivel1", "Nivel2", "Nivel3", "Nivel4", "Nivel5" 
        //"Soluciones", "Elemento", "Simbolos", "Masas", "Electrones"
        //simbolos
        // masas
        //electrones


        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                //string[] ayuda = datos[i].contexto.Split('\n');
                string lala1 = "";
                string lala2 = "";
                string lala3 = "";
                string solucionesAll = datos[i].solSimbolo + "@"+datos[i].solMasa + "@"+datos[i].solElectron;
                for (int j = 0; j < num; j++)
                {
                    lala1+=datos[i].FormsSimbolos[j] + "@";
                    lala2 += datos[i].FormsMasas[j] + "@";
                    lala3 += datos[i].FormsElectrones[j] + "@";
                }
                string aux = nombreNivel[i];
                string[] simulacionesData = new string[5] { solucionesAll, datos[i].elemento, lala1, lala2, lala3 };
                servicioWCF.GuardarCambioDinamicos("Tabla Periodica", simulacionesData, 0, aux, simulacionesNombre);
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

    public void GetNivelFormulaNum()
    {
        nivelsFormulaNum = FormulasNum.options[FormulasNum.value].text;
    }
    //Esto consigue lo del contexto

    public void load()
    {
        //"Soluciones", "Elemento", "Simbolos", "Masas", "Electrones"

        for (int i = 0; i < datos.Length; i++)
        {
            try
            {
                string aux = nombreNivel[i];
                //datos[i] = new nivel();
                string[] resultados = servicioWCF.BuscarDatosD("Tabla Periodica", aux, simulacionesNombre);
                
                datos[i].nivelName = nombreNivel[i];

                string[] resSoluciones = resultados[0].Split('@');
                datos[i].solSimbolo = resSoluciones[0];
                datos[i].solMasa = resSoluciones[1];
                datos[i].solElectron = resSoluciones[2];

                datos[i].elemento = resultados[1];

                string[] ayuda = resultados[2].Split('@'); //simbolos
                string[] ayuda2 = resultados[3].Split('@');// masas
                string[] ayuda3 = resultados[4].Split('@');//electrones

                for (int j = 0; j < num; j++)
                {
                    datos[i].FormsSimbolos[j] = ayuda[j];
                    datos[i].FormsMasas[j] = ayuda2[j];
                    datos[i].FormsElectrones[j] = ayuda3[j];
                }


            }
            catch (System.Exception ex)
            {
                print(ex.ToString());
            }
        }
    }


    public void editarSolSimbolo()
    {
        if (SolSimbolo.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solSimbolo = SolSimbolo.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solSimbolo = SolSimbolo.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solSimbolo = SolSimbolo.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solSimbolo = SolSimbolo.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solSimbolo = SolSimbolo.text;
            }
        }
    }
    public void editarSolMasa()
    {
        if (SolMasa.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solMasa = SolMasa.text;

            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solMasa = SolMasa.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solMasa = SolMasa.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solMasa = SolMasa.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solMasa = SolMasa.text;
            }
        }
    }
    public void editarSolElectrones()
    {
        if (SolElectron.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].solElectron = SolElectron.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].solElectron = SolElectron.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].solElectron = SolElectron.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].solElectron = SolElectron.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].solElectron = SolElectron.text;
            }
        }
    }
    public void editarElemento()
    {
        if (SolElemento.GetComponent<InputField>().isFocused)
        {
            GetNivel();
            if (nivels.Equals("Nivel 1"))
            {
                datos[0].elemento = SolElemento.text;
            }
            else if (nivels.Equals("Nivel 2"))
            {
                datos[1].elemento = SolElemento.text;
            }
            else if (nivels.Equals("Nivel 3"))
            {
                datos[2].elemento = SolElemento.text;
            }
            else if (nivels.Equals("Nivel 4"))
            {
                datos[3].elemento = SolElemento.text;
            }
            else if (nivels.Equals("Nivel 5"))
            {
                datos[4].elemento = SolElemento.text;
            }
        }
    }
    public void editarContexto()
    {
        if (opciones.GetComponent<InputField>().isFocused)
        {
            GetNivelFormula();
            GetNivelFormulaNum();

            for (int i = 0; i < countOpcionesNum.Length; i++)
            {
                if (nivelsFormula.Equals(countOpciones[0]))
                {
                    //simbolos
                    if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                    {
                        datos[n].FormsSimbolos[i] = opciones.text;
                    }
                }
                else if (nivelsFormula.Equals(countOpciones[1]))
                {
                    // masas
                    if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                    {
                        datos[n].FormsMasas[i] = opciones.text;
                    }
                }
                else if (nivelsFormula.Equals(countOpciones[2]))
                {
                    //electrones
                    if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                    {
                        datos[n].FormsElectrones[i] = opciones.text;
                    }
                }
            }

        }
    }
    

    public void actualizarFor(int a)
    {
        SolSimbolo.text = datos[a].solSimbolo;
        SolMasa.text = datos[a].solMasa;
        SolElectron.text = datos[a].solElectron;
        SolElemento.text = datos[a].elemento;

        GetNivelFormula();
        GetNivelFormulaNum();

        for (int i = 0; i < countOpcionesNum.Length; i++)
        {
            if (nivelsFormula.Equals(countOpciones[0]))
            {
                //simbolos
                if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                {
                    opciones.text = datos[a].FormsSimbolos[i];
                }

            }
            else if (nivelsFormula.Equals(countOpciones[1]))
            {
                // masas
                if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                {
                    opciones.text = datos[a].FormsMasas[i];
                }
            }
            else if (nivelsFormula.Equals(countOpciones[2]))
            {
                //electrones
                if (nivelsFormulaNum.Equals(countOpcionesNum[i]))
                {
                    opciones.text = datos[a].FormsElectrones[i];
                }
            }
        }

    }

    public class nivel
    {
        public string nivelName { get; set; }
        public string solSimbolo { get; set; }
        public string solMasa { get; set; }
        public string solElectron { get; set; }
        public string elemento { get; set; }
        public string[] FormsSimbolos { get; set; }
        public string[] FormsMasas { get; set; }
        public string[] FormsElectrones { get; set; }

    }

}


    

