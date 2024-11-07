using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
public class DoubleClikeTuPian : MonoBehaviour,IPointerClickHandler
{
    private bool isDoubleClicked = false;
    private float doubleClickTime = 0.3f; // 双击的时间间隔（以秒为单位）
    private Vector3 originalScale; // 原始的缩放比例
    public int timeToScale=1;
    public Vector3 targetScale = new Vector3(3f, 3f, 3f);// 放大后的大小
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
                StartCoroutine(ScaleObject());// 如果已经是双击状态，执行放大操作
            }
            else
            {
                StartCoroutine(ScaleObject2());
            }
            isDoubleClicked = false;
        }
        else
        {
            // 如果不是双击状态，等待一段时间来检测双击
            isDoubleClicked = true;
        }

    }

    IEnumerator ScaleObject()
    {
        Vector2 centerPosition = new Vector2(0, 0); // 屏幕中心在RectTransform中的坐标是(0, 0)
        float timeElapsed = 0;

        while (timeElapsed < timeToScale)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / timeToScale);

           // transform.position = worldCenter;
            rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, centerPosition, timeElapsed / timeToScale);
            yield return null; // 等待下一帧
        }
        isScale = true;
    }

    IEnumerator ScaleObject2()
    {
        Vector2 centerPosition = new Vector2(0, 0); // 屏幕中心在RectTransform中的坐标是(0, 0)
        float timeElapsed = 0;

        while (timeElapsed < timeToScale)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp( targetScale, new Vector3(1f, 1f, 1f), timeElapsed / timeToScale);

            // transform.position = worldCenter;
            rectTransform.anchoredPosition = Vector2.Lerp(centerPosition, originalPosition, timeElapsed / timeToScale);
            yield return null; // 等待下一帧
        }
        isScale = false;
    }
}

