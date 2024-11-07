using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TishiControl : MonoBehaviour
{
    public GameObject TishiBox;
    public Text TishiText;
    public int xinshoutishivalue=0;
    public GameObject xinshourenwu;

    [TextArea(1, 6)]
    public string[] TiShiLines;
    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {
        TishiText.text = TiShiLines[GameManager.Instance.Tishivalue];
        
    }

    public void showTishi()
    {
        TishiText.text = TiShiLines[GameManager.Instance.Tishivalue];
        TishiBox.SetActive(true);
    }
    public void Xinshoujia()
    {
        if(xinshoutishivalue< TiShiLines.Length-1)
        {
            xinshoutishivalue++;
        }
        showXinshou();
    }
    public void Xinshoujian()
    {
        if (xinshoutishivalue > 0)
        {
            xinshoutishivalue--;
        }
        showXinshou();
    }
    public void showXinshou()
    {
        TishiText.text = TiShiLines[xinshoutishivalue];
        Xinshourenwushow();
    }

    public void Xinshourenwushow()
    {
        for(int i=0;i< TiShiLines.Length; i++)
        {
            xinshourenwu.transform.GetChild(i).gameObject.SetActive(false);
        }
        xinshourenwu.transform.GetChild(xinshoutishivalue).gameObject.SetActive(true);
    }
}
