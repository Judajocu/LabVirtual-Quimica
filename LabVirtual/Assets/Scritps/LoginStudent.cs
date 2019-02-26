using System.Collections;
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

    MoodleAPI moodleAPI;

    public Button buttonLogin;

    private string ID;
    private string Password;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
              
    }

    public void ValidateLogin()
    {
        ID = id.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        CheckApi(ID, Password);
        if (ID!=string.Empty && Password != string.Empty)
        {
            //prueva guardado de datos en la base de datos
            try
            {
                ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));

                int mat = Int32.Parse(ID);
                servicioWCF.RegistrarMatricula(mat, Password);
            }
            catch (System.Exception)
            {

            }

            print("Sup");
            SceneManager.LoadScene("Overview-Student");
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
