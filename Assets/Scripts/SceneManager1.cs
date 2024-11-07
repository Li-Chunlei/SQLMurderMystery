using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SceneManager1 : MonoBehaviour
{
    public int selectedSceneIndex; // ѡ�еĳ�������



    public void OnButtonClick()
    {
        // ����ѡ�еĳ���
        SceneManager.LoadScene(selectedSceneIndex);
        Judgment judgment = GetComponent<Judgment>();

    }


   

}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneManager1))]
public class ChangeSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // ��ȡ���������б�
        string[] sceneNames = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < sceneNames.Length; i++)
        {
            sceneNames[i] = EditorBuildSettings.scenes[i].path;
        }

        // �ڼ�����л��������б�
        SceneManager1 script = (SceneManager1)target;
        script.selectedSceneIndex = EditorGUILayout.Popup("Selected Scene", script.selectedSceneIndex, sceneNames);
    }
}
#endif

