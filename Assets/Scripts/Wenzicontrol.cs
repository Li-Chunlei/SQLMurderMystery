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
            this.GetComponent<Text>().text = "����ѯ����100+������,ֻΪ����ʾ��ǰ11�У����������������������ѯ��Χ";
        }
        else if(t>1)
        {
            this.GetComponent<Text>().text = "����ѯ����" + t.ToString() + "������,��Ϊ��ȫ����ʾ�����������������������ѯ��Χ";
        }
        else
        {
            this.GetComponent<Text>().text = "����ѯ����" + t.ToString() + "������,";
        }
    }
    
    public void cuowutishi(string t)
    {
        this.GetComponent<Text>().text = t;
    }

}
