using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class DoubleClikeTuPian : MonoBehaviour,IPointerClickHandler
{
    private bool isDoubleClicked = false;
    private float doubleClickTime = 0.3f; // ˫����ʱ����������Ϊ��λ��
    private Vector3 originalScale; // ԭʼ�����ű���
    public int timeToScale=1;
    public Vector3 targetScale = new Vector3(3f, 3f, 3f);// �Ŵ��Ĵ�С
    private Vector3 worldCenter;
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private bool isScale =false;
    public void Start()
    {
        //  Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane);
        //   worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        worldCenter = new Vector3(0, 0, 0);
         rectTransform = GetComponent<RectTransform>();
         originalPosition = rectTransform.anchoredPosition;

}
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDoubleClicked)
        {
            if(!isScale)
            {
                StartCoroutine(ScaleObject());// ����Ѿ���˫��״̬��ִ�зŴ����
            }
            else
            {
                StartCoroutine(ScaleObject2());
            }
            isDoubleClicked = false;
        }
        else
        {
            // �������˫��״̬���ȴ�һ��ʱ�������˫��
            isDoubleClicked = true;
        }

    }

    IEnumerator ScaleObject()
    {
        Vector2 centerPosition = new Vector2(0, 0); // ��Ļ������RectTransform�е�������(0, 0)
        float timeElapsed = 0;

        while (timeElapsed < timeToScale)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / timeToScale);

           // transform.position = worldCenter;
            rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, centerPosition, timeElapsed / timeToScale);
            yield return null; // �ȴ���һ֡
        }
        isScale = true;
    }

    IEnumerator ScaleObject2()
    {
        Vector2 centerPosition = new Vector2(0, 0); // ��Ļ������RectTransform�е�������(0, 0)
        float timeElapsed = 0;

        while (timeElapsed < timeToScale)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp( targetScale, new Vector3(1f, 1f, 1f), timeElapsed / timeToScale);

            // transform.position = worldCenter;
            rectTransform.anchoredPosition = Vector2.Lerp(centerPosition, originalPosition, timeElapsed / timeToScale);
            yield return null; // �ȴ���һ֡
        }
        isScale = false;
    }
}

