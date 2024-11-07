using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor: MonoBehaviour
{
    public Texture2D cursorTexture; // ���ͼƬ

    private void OnMouseEnter()
    {
        // ������������ʱ���������ͼƬ
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        // ������뿪����ʱ����ԭ���ͼƬ
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
