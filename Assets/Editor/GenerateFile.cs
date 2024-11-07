using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GenerateFile : Editor
{
    [MenuItem("Tools/CreateDir/CreateStreamingAssets")]
    public static void CreateStreamingAssets()
    {
        CreateDirectory(Application.streamingAssetsPath);
    }
    [MenuItem("Tools/CreateDir/CreateResources")]
    public static void CreateResource()
    {
        string Path = string.Format("{0}/{1}", Application.dataPath, typeof(Resources).Name);
        CreateDirectory(Path);
    }

    [MenuItem("Tools/CreateFile/CreateSQLite")]
    public static void CreateSQLite()
    {
        string Path = string.Format("{0}/NewSQLite.db", Application.streamingAssetsPath);
        CreateFile(Path);
    }

    /// <summary>
    /// 创建文件夹方法
    /// </summary>
    /// <param name="Path">文件路径</param>
    public static void CreateDirectory(string Path)
    {
        //如果找不到文件夹
        if (!Directory.Exists(Path))
        {
            //创建文件夹
            Directory.CreateDirectory(Path);
            //刷新
            AssetDatabase.Refresh();
        }
    }

    /// <summary>
    /// 创建文件的方法
    /// </summary>
    /// <param name="Path"></param>
    public static void CreateFile(string Path)
    {
        //如果找不到文件
        if (!File.Exists(Path))
        {
            //创建文件
            File.WriteAllLines(Path, new[] { "" });
            //刷新
            AssetDatabase.Refresh();
        }
    }
}
