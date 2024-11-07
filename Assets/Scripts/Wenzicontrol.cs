using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wenzicontrol : MonoBehaviour
{

    // Start is called before the first frame update


    public void tishi(int t)
    {
        if(t>10)
        {
            this.GetComponent<Text>().text = "您查询到了100+个数据,只为您显示了前11行，请添加限制条件，缩减查询范围";
        }
        else if(t>1)
        {
            this.GetComponent<Text>().text = "您查询到了" + t.ToString() + "个数据,已为您全部显示，请添加限制条件，缩减查询范围";
        }
        else
        {
            this.GetComponent<Text>().text = "您查询到了" + t.ToString() + "个数据,";
        }
    }
    
    public void cuowutishi(string t)
    {
        this.GetComponent<Text>().text = t;
    }

}
