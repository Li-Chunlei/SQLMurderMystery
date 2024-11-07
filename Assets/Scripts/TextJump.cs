using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextJump : MonoBehaviour
{
    public float animationDuration = 0.5f; // 动画持续时间（秒）
    public float animationSpeed = 1.0f;     // 动画速度
    [SerializeField]
    private float elapsedTime = 0.0f;
    private Text textUI;
    private void Awake()
    {
        textUI = this.gameObject.GetComponent<Text>();
    }
    void OnEnable()
    {
        elapsedTime = 0.0f;
        StartCoroutine(Textjump());
        Debug.Log("1");

    }
    private IEnumerator Textjump()
    {
        while (elapsedTime < animationDuration)
        {
            // 计算插值参数
            float t = elapsedTime / animationDuration;

           
            float newScale = Mathf.Lerp((float)1,(float)0.75, t);

            // 应用新的位置和缩放
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // 计算插值参数
            float t = elapsedTime / animationDuration;


            float newScale = Mathf.Lerp((float)0.75, (float)1.25, t);

            // 应用新的位置和缩放
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // 计算插值参数
            float t = elapsedTime / animationDuration;


            float newScale = Mathf.Lerp((float)1.25, (float)1, t);

            // 应用新的位置和缩放
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        // 隐藏文本对象，以备重用
    }


}
