using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPattern<T> : MonoBehaviour where T : SingletonPattern<T>
{
    public static T Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)//其他场景没有挂载gameobject
        {
            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else//加载（原本就挂载了gameobject的场景）触发else
        {
            Destroy(this);
        }
    }
}
