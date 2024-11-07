using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor: MonoBehaviour
{
    public Texture2D cursorTexture; // 鼠标图片

    private void OnMouseEnter()
    {
        // 当鼠标进入物体时，更改鼠标图片
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        // 当鼠标离开物体时，还原鼠标图片
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
