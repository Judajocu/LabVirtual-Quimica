using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupList : MonoBehaviour {

    public GameObject GroupEntryPrefab;

    Datagrid_Overview_Professor datagrid;

    int lastChangeCounter;

	// Use this for initialization
	void Start () {

        datagrid = GameObject.FindObjectOfType<Datagrid_Overview_Professor>();

        lastChangeCounter = datagrid.GetChangeCounter()-1;

    }
	
	// Update is called once per frame
	void Update () {

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
}
