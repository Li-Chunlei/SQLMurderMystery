using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XinshouJiaoChen : MonoBehaviour
{
    public GameObject xinshou1;
    public GameObject booktupian;
    public void Xianshi()
    {
        if(booktupian.activeInHierarchy)
        {
            booktupian.SetActive(false);

        }
        else
        {
            booktupian.SetActive(true);
            if (GameManager.Instance.Xinshou1 == true)
            {
                xinshou1.SetActive(true);
            }
        }

    }

}
