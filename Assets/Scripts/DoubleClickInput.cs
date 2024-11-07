using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoubleClickInput : MonoBehaviour, IPointerClickHandler
{
    public InputField inputField; // 你的Input Field
    private float lastClickTime = 0; // 上次点击的时间
    private float doubleClickTime = 0.3f; // 双击的间隔时间

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            // 检测到双击事件，激活Input Field

            inputField.gameObject.SetActive(true);
            inputField.Select();
        }
    }

    public void OnEndEdit()
    {
        // 当Input Field的值改变时，更新格子的名字
        inputField.gameObject.transform.GetChild(0).name = "'"+inputField.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text+"'";
        //  inputField.gameObject.transform.GetChild(0).name = "1";
    }
}

