using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoubleClickInput : MonoBehaviour, IPointerClickHandler
{
    public InputField inputField; // ���Input Field
    private float lastClickTime = 0; // �ϴε����ʱ��
    private float doubleClickTime = 0.3f; // ˫���ļ��ʱ��

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            // ��⵽˫���¼�������Input Field

            inputField.gameObject.SetActive(true);
            inputField.Select();
        }
    }

    public void OnEndEdit()
    {
        // ��Input Field��ֵ�ı�ʱ�����¸��ӵ�����
        inputField.gameObject.transform.GetChild(0).name = "'"+inputField.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text+"'";
        //  inputField.gameObject.transform.GetChild(0).name = "1";
    }
}

