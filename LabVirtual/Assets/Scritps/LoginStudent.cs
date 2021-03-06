﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Moodle;
using System;
using System.ServiceModel;

public class LoginStudent : MonoBehaviour {

    public GameObject id;
    public GameObject password;
    public GameObject login;

    public GameObject letrero;

    private string pass;
    private string identification;

    MoodleAPI moodleAPI;

    public Button buttonLogin;

    private string ID;
    private string Password;
    private bool logueo = false;

	// Use this for initialization
	void Start () {
        letrero.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        identification = id.GetComponent<InputField>().text;
        pass = password.GetComponent<InputField>().text;

    }

    public void ValidateLogin()
    {
        ID = id.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        //CheckApi(ID, Password);
        if (ID!=string.Empty && Password != string.Empty)
        {
            //prueva guardado de datos en la base de datos
            string problem = "no se hizo la coneccion";
            GameObject.FindGameObjectWithTag("seccion").GetComponent<UserSession>().SendMessage("cambio", ID);
            try
            {
                
                ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));

                

                logueo = servicioWCF.verificarEstudiante(ID,Password);
                //Debug.Log("logueo:" + logueo);

                //servicioWCF.updateNota("Nomenclatura", "20140001", "A",1);
                //servicioWCF.RegistrarSimulacionEst("Nomenclatura", "20140002", "A");

                /*string[] prueba = servicioWCF.devolverNotasEst(ID);
                for (int i = 0; i < prueba.Length; i++)
                {
                    Debug.Log(ID+" nota 1:" + prueba[i]);
                }*/

                /*
                //int mat = Int32.Parse(ID);
                servicioWCF.RegistrarMatricula(ID, Password);

                string esto = "20140805";
                //int esto = 20140805;
                string f = servicioWCF.ObtenerPass(esto);
                print(f);

                //servicioWCF.ObtenerEstudiantes(esto);
                */

                //registro de estudiantes
                /*
                problem = "no registro estudiantes";
                servicioWCF.RegistrarEsudiante("20140001", "Mauricio", "Perez", 20140001);
                servicioWCF.RegistrarEsudiante("20140002", "Melvin", "Pons", 20140002);
                servicioWCF.RegistrarEsudiante("20140003", "Marco", "Peralta", 20140003);

                problem = "no registro profesor";
                servicioWCF.RegistrarProfesor("001", "Ignacio", "Gonzales");

                problem = "no registro curso";
                servicioWCF.RegistrarCurso("Quimica101", "001");
                

                problem = "no registro cursoEstudiante";
                servicioWCF.RegistrarCursoestudiante(1, "20140001");
                servicioWCF.RegistrarCursoestudiante(1, "20140002");
                servicioWCF.RegistrarCursoestudiante(1, "20140003");

                servicioWCF.RegistrarSimulacion("Nomenclatura", 0, 120);
                servicioWCF.RegistrarSimulacion("Balanceo", 0, 120);
                servicioWCF.RegistrarSimulacion("Estequiometria", 0, 120);
                servicioWCF.RegistrarSimulacion("Tabla Periodica", 0, 120);
                servicioWCF.RegistrarSimulacion("Conversion", 0, 120);

                servicioWCF.RegistrarSimulacionEst(1, "20140001", "A");
                servicioWCF.RegistrarSimulacionEst(2, "20140001", "B");
                servicioWCF.RegistrarSimulacionEst(3, "20140001", "A");
                servicioWCF.RegistrarSimulacionEst(4, "20140001", "B");
                servicioWCF.RegistrarSimulacionEst(5, "20140001", "C");
                */


            }
            catch (System.Exception ex)
            {
                print(problem);
                print(ex.ToString());
            }

            if (logueo)
            {
                print("Sup");
                SceneManager.LoadScene("Group_Selection");
            }
            else
            {
                letrero.gameObject.SetActive(true);
            }
        }
    }
    public void ValidateBack()
    {
        SceneManager.LoadScene("Entryway");
    }

    public void CheckApi(string user, string pass)
    {
        moodleAPI = GetComponent<MoodleAPI>();
        

        moodleAPI.OnTokenRetrieved += sender => {
            // The user has successfully logged in

            // We setup the data that we will record on this attempt
            IDictionary<string, string> result = new ScormDataBuilder()
                                    .SetLessonStatus("completed")
                                    .SetMinScore(0)
                                    .SetMaxScore(100)
                                    .SetRawScore(75)
                                    .SetSessionTime(new TimeSpan(1, 10, 25))
                                    .Build();

            uint scormId = 1; // This id can be retrieve calling “GetScorms” method and filtering it.
            uint attempt = 1; // If this attempt has been already made the previous data will be overwritten. If you want to know the attempt count you need to call “GetScormAttemptCount” method before.

            moodleAPI.InsertScormTracks(scormId, attempt, result); // 2. We will make a new attempt
        };

        moodleAPI.GetToken(user, pass);

        moodleAPI.OnScormTracksInserted += (sender, trackIds) => {
            // A Scorm attempt was successfully recorded
            Debug.Log("asd");
        };


    }

}
