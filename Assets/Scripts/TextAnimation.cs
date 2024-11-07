using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TextAnimation : MonoBehaviour
{
    public Text textUI;
    public float animationDuration = 1.5f; // 动画持续时间（秒）
    public float animationSpeed = 1.0f;     // 动画速度

    private float elapsedTime = 0.0f;

    private void Start()
    {
    }

    private IEnumerator AnimateText(int shangt,int yout)
    {
        while (elapsedTime < animationDuration)
        {
            // 计算插值参数
            float t = elapsedTime / animationDuration;

            // 计算新的文本位置（向上移动，同时缩小）
            Vector2 newPosition = new Vector2(Mathf.Lerp(0, shangt, t), Mathf.Lerp(0, yout, t));
            float newScale = Mathf.Lerp(1, 0, t);

            // 应用新的位置和缩放
            textUI.rectTransform.anchoredPosition = newPosition;
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        // 隐藏文本对象，以备重用
        textUI.gameObject.SetActive(false);
    }

    // 在需要时激活并重新使用文本对象
    public void ActivateText(Vector3 position,string text)
    {
        // 设置文本的初始位置
        textUI.text = text;
        textUI.rectTransform.anchoredPosition = position;
        textUI.gameObject.SetActive(true);
        elapsedTime = 0.0f;
        StartCoroutine(AnimateText(850,500));
    }
    public void ActivateText2(Vector3 position, string text)
    {
        // 设置文本的初始位置
        textUI.text = text;
        textUI.rectTransform.anchoredPosition = position;
        textUI.gameObject.SetActive(true);
        elapsedTime = 0.0f;
        StartCoroutine(AnimateText(500,0));
    }
    // GameObject.Find("TextAnimationControl").GetComponent<TextAnimation>().ActivateText(); 调用方法
}