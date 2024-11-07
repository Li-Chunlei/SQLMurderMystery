using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPattern<T> : MonoBehaviour where T : SingletonPattern<T>
{
    public static T Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)//��������û�й���gameobject
        {
            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else//���أ�ԭ���͹�����gameobject�ĳ���������else
        {
            Destroy(this);
        }
    }
}
