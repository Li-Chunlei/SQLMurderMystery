using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PuzzlePiece : MonoBehaviour
{
    public bool yunxing = false; 
    public Judgment judgment;
    public Vector3 Ttransform;
    public Transform old_parent_transform;
    void Start()
    {
        //Judgment judgment = GetComponent<Judgment>();
        judgment = GameObject.Find("Judgment").GetComponent<Judgment>();
        Ttransform = transform.position;
        old_parent_transform = transform.parent;
    }
    void Update()
    {

        if (transform.parent != null)
        {
            // 检查父对象的名称是否为"A"
            if (transform.parent.name == "Item" )
            {

                if(yunxing==false)
                {
                    judgment.pieces.Add(transform.gameObject);
                }
                yunxing = true;
                if (transform.parent.tag == "FengHao" && transform.tag=="FengHao")
                {
                    judgment.tiaojian1 = true;
                }
                else if (transform.parent.tag == "Caozuo" && transform.tag == "Caozuo")
                {
                    judgment.tiaojian2 = true;
                }
                else if(transform.parent.tag == "WuTI" && transform.tag == "WuTI")
                {
                    judgment.tiaojian3 = true;
                }

            }
            else
            {
                yunxing = false;
            }
        }
        else
        {
            yunxing = false;
        }
    }
    public void TTtransform()
    {
        transform.position = Ttransform;
     //   transform.parent = old_parent_transform;
        transform.SetParent(old_parent_transform);
       
    }
}

