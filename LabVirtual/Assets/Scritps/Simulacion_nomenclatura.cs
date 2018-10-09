using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Simulacion_nomenclatura : MonoBehaviour {

    public Button ButtonMenu;

    public GameObject menu;

    // Use this for initialization
    void Start()
    {
        timeup = settings.Gettime();
        CheckType();
        letra_a = GameObject.Find("letra_a").GetComponent<TextMesh>();
        letra_b = GameObject.Find("letra_b").GetComponent<TextMesh>();
        letra_c = GameObject.Find("letra_c").GetComponent<TextMesh>();
        letra_d = GameObject.Find("letra_d").GetComponent<TextMesh>();
        letra_e = GameObject.Find("letra_e").GetComponent<TextMesh>();
        letra_f = GameObject.Find("letra_f").GetComponent<TextMesh>();
        CheckTime();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
    }

    public void CheckTime()
    {
        time_left += Time.deltaTime;
        TimeOver();
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }
}
