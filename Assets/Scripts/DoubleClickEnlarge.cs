using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;



public class DoubleClickEnlarge : MonoBehaviour, IPointerClickHandler
{
    private bool isDoubleClicked = false;
    private float doubleClickTime = 0.3f; // 双击的时间间隔（以秒为单位）
    private Vector3 originalScale; // 原始的缩放比例
    private Vector3 enlargedScale = new Vector3(1.2f, 1.2f, 1.2f); // 放大后的缩放比例
    public GameObject fangdawuping;

    public List<GameObject> list = new List<GameObject>();
    private void Start()
    {
        originalScale = transform.localScale; // 记录原始缩放比例
        for (int i = 2; i < fangdawuping.transform.childCount; i++)
        {
            list.Add(fangdawuping.transform.GetChild(i).gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDoubleClicked)
        {
            // 如果已经是双击状态，执行放大操作
            transform.localScale = enlargedScale;
            isDoubleClicked = false;
            fangdawuping.SetActive(true);
            fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text = transform.GetChild(0).gameObject.GetComponent<Text>().text;
            jiance();
        }
        else
        {
            // 如果不是双击状态，等待一段时间来检测双击
            isDoubleClicked = true;
            Invoke("ResetDoubleClickFlag", doubleClickTime);
        }
    }

    private void ResetDoubleClickFlag()
    {
        isDoubleClicked = false;
        transform.localScale = originalScale; // 恢复到原始缩放比例
    }

    private void jiance()
    {
        for (int i = 2  ; i < fangdawuping.transform.childCount; i++)
        {
            fangdawuping.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Security footage shows that there were 2 witnesses."))
        {
            Debug.Log("1111");
            list[0].SetActive(true);
            
        }
        if(fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Morty Schapiro"))
        {
            Debug.Log("2222");
            list[1].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("14887"))
        {
            Debug.Log("3333");
            list[2].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("28819"))
        {
            Debug.Log("4444");
            list[3].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("67318"))
        {
            Debug.Log("5555");
            list[4].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("173289"))
        {
            Debug.Log("6666");
            list[5].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("423327"))
        {
            Debug.Log("7777");
            list[6].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Jeremy Bowers"))
        {
            Debug.Log("8888");
            list[7].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("202298"))
        {
            list[8].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("291182"))
        {
            list[9].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("918773"))
        {
            list[10].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Red Korb"))
        {
            list[11].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Regina George"))
        {
            list[12].SetActive(true);
        }
        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("Miranda Priestly"))
        {
            list[13].SetActive(true);
        }






        if (fangdawuping.transform.GetChild(0).gameObject.GetComponent<Text>().text.Contains("10011"))
        {
            list[0].SetActive(true);
            GameManager.Instance.Xinshou1 = true;
        }
    }
}