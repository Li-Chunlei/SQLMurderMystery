using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCheck : MonoBehaviour
{
    public Transform child;
    public GameObject textchild;
    private void Update()
    {
        if (this.transform.childCount > 0)
        {
            child = this.transform.GetChild(0);
            textchild = child.transform.GetChild(0).gameObject;
            if(textchild.name=="type")
            {
                Debug.Log("type");
            }
            else if (textchild.name == "city")
            {
                Debug.Log("city");
            }
            else if (textchild.name == "date")
            {
                Debug.Log("date");
            }
        }
    }

}
