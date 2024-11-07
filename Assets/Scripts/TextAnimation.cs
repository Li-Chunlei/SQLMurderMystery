using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TextAnimation : MonoBehaviour
{
    public Text textUI;
    public float animationDuration = 1.5f; // ��������ʱ�䣨�룩
    public float animationSpeed = 1.0f;     // �����ٶ�

    private float elapsedTime = 0.0f;

    private void Start()
    {
    }

    private IEnumerator AnimateText(int shangt,int yout)
    {
        while (elapsedTime < animationDuration)
        {
            // �����ֵ����
            float t = elapsedTime / animationDuration;

            // �����µ��ı�λ�ã������ƶ���ͬʱ��С��
            Vector2 newPosition = new Vector2(Mathf.Lerp(0, shangt, t), Mathf.Lerp(0, yout, t));
            float newScale = Mathf.Lerp(1, 0, t);

            // Ӧ���µ�λ�ú�����
            textUI.rectTransform.anchoredPosition = newPosition;
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // ���¾�����ʱ��
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        // �����ı������Ա�����
        textUI.gameObject.SetActive(false);
    }

    // ����Ҫʱ�������ʹ���ı�����
    public void ActivateText(Vector3 position,string text)
    {
        // �����ı��ĳ�ʼλ��
        textUI.text = text;
        textUI.rectTransform.anchoredPosition = position;
        textUI.gameObject.SetActive(true);
        elapsedTime = 0.0f;
        StartCoroutine(AnimateText(850,500));
    }
    public void ActivateText2(Vector3 position, string text)
    {
        // �����ı��ĳ�ʼλ��
        textUI.text = text;
        textUI.rectTransform.anchoredPosition = position;
        textUI.gameObject.SetActive(true);
        elapsedTime = 0.0f;
        StartCoroutine(AnimateText(500,0));
    }
    // GameObject.Find("TextAnimationControl").GetComponent<TextAnimation>().ActivateText(); ���÷���
}