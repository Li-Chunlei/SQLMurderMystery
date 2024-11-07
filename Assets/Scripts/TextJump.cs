using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextJump : MonoBehaviour
{
    public float animationDuration = 0.5f; // ��������ʱ�䣨�룩
    public float animationSpeed = 1.0f;     // �����ٶ�
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
            // �����ֵ����
            float t = elapsedTime / animationDuration;

           
            float newScale = Mathf.Lerp((float)1,(float)0.75, t);

            // Ӧ���µ�λ�ú�����
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // ���¾�����ʱ��
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // �����ֵ����
            float t = elapsedTime / animationDuration;


            float newScale = Mathf.Lerp((float)0.75, (float)1.25, t);

            // Ӧ���µ�λ�ú�����
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // ���¾�����ʱ��
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // �����ֵ����
            float t = elapsedTime / animationDuration;


            float newScale = Mathf.Lerp((float)1.25, (float)1, t);

            // Ӧ���µ�λ�ú�����
            textUI.transform.localScale = new Vector3(newScale, newScale, 1);

            // ���¾�����ʱ��
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        // �����ı������Ա�����
    }


}
