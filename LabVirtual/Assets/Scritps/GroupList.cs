using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GroupList : MonoBehaviour {

    public GameObject GroupEntryPrefab;

    Datagrid_Overview_Professor datagrid;
    Groups_Professor groupsP;

    bool type = false;

    int lastChangeCounter;

	// Use this for initialization
	void Start () {

        datagrid = GameObject.FindObjectOfType<Datagrid_Overview_Professor>();
        groupsP = GameObject.FindObjectOfType<Groups_Professor>();

        CheckType();

    }
	
	// Update is called once per frame
	void Update () {
        Show();
    }

    public void datagridO()
    {
        if (datagrid.GetChangeCounter() == lastChangeCounter)
        {
            return;
        }
        else
        {
            lastChangeCounter = datagrid.GetChangeCounter();

            while (this.transform.childCount > 0)
            {
                Transform firstchild = this.transform.GetChild(0);
                firstchild.SetParent(null);
                Destroy(firstchild.gameObject);
            }

            string[] groups = datagrid.GetGroups_codes("Quimica I");

            foreach (var group in groups)
            {
                GameObject gameObject = (GameObject)Instantiate(GroupEntryPrefab, transform);
                gameObject.transform.SetParent(this.transform);
                gameObject.transform.Find("Text_GroupCode").GetComponent<Text>().text = group;
                gameObject.transform.Find("Text_AVGGrade").GetComponent<Text>().text = datagrid.GetGrades(group, "Quimica I").ToString();

            }
        }
    }

    public void datagridP()
    {
        if (groupsP.GetChangeCounter() == lastChangeCounter)
        {
            return;
        }
        else
        {
            lastChangeCounter = groupsP.GetChangeCounter();

            while (this.transform.childCount > 0)
            {
                Transform firstchild = this.transform.GetChild(0);
                firstchild.SetParent(null);
                Destroy(firstchild.gameObject);
            }

            string[] groups = groupsP.GetGroups_codes("Quimica I");

            foreach (var group in groups)
            {
                GameObject gameObject = (GameObject)Instantiate(GroupEntryPrefab, transform);
                gameObject.transform.SetParent(this.transform);
                gameObject.transform.Find("Text_GroupCode").GetComponent<Text>().text = group;
                gameObject.transform.Find("Text_AVGGrade").GetComponent<Text>().text = groupsP.GetGrades(group, "Quimica I").ToString();

            }
        }
    }

    public void Show()
    {
        if (CheckType())
            datagridP();
        else
            datagridO();
    }

    public bool CheckType()
    {
        string name = SceneManager.GetActiveScene().name;
        if(name.Equals("Groups_Professor"))
        {
            lastChangeCounter = groupsP.GetChangeCounter() - 1;
            return true;
        }
        lastChangeCounter = datagrid.GetChangeCounter() - 1;
        return false;
    }

}
