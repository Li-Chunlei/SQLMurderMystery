using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemChangePos : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform orignaParent;
    public DialogueManager dialogueManager;
    
    public Transform picput;//DOTO：修bug

    public void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        orignaParent = transform.parent;//确定初始父节点
        transform.SetParent(transform.parent.parent.parent);//改变父节点
        transform.position = eventData.position;//让图片跟着鼠标移动
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject.name == "Image") //检测到目标对象为Image
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent); //将对象的父亲设为目标对象的父亲
            transform.position =
                eventData.pointerCurrentRaycast.gameObject.transform.parent.position; //将对象的位置变成目标对象父亲的位置
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(orignaParent); //改变目标对象的父亲为初始父亲
            eventData.pointerCurrentRaycast.gameObject.transform.position = orignaParent.position; //将目标对象的位置变成初始父亲的位置
            Debug.Log("2");
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "Item") //检测到目标对象为Item
        {
            Debug.Log("itemchange");
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform); //将此对象的父亲设置为目标对象的
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; //将此对象的位置设为目标对象的位置
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "notebook")
        {
            transform.gameObject.SetActive(false);
            if (dialogueManager != null)
            {
                dialogueManager.currentLine--;
            }
            if (transform.GetChild(0).name == "Murder")
            {
                GameManager.Instance.isMurder = true;
            }
            else if (transform.GetChild(0).name == "sql")
            {
                GameManager.Instance.issql = true;
            }
            else if (transform.GetChild(0).name == "20080115")
            {
                GameManager.Instance.is20080115 = true;
            }
            else if (transform.GetChild(0).name == "Huiyuan")
            {
                GameManager.Instance.isHuiyuan = true;
            }
            else if (transform.GetChild(0).name == "48Z")
            {
                GameManager.Instance.is48Z = true;
            }
            else if (transform.GetChild(0).name == "H4ZW")
            {
                GameManager.Instance.isH4ZW = true;
            }
            else if (transform.GetChild(0).name == "NorthWesternDr")
            {
                GameManager.Instance.isNorthWesternDr = true;
                if(GameManager.Instance.Tishivalue == 1)
                {
                    GameManager.Instance.Tishivalue = 2;
                }

            }
            else if (transform.GetChild(0).name == "MortySchapiro")
            {
                GameManager.Instance.isMortySchapiro = true;
                if (GameManager.Instance.Tishivalue == 2)
                {
                    GameManager.Instance.Tishivalue = 3;
                }
            }
            else if (transform.GetChild(0).name == "14887")
            {
                GameManager.Instance.is14887 = true;
            }
            else if (transform.GetChild(0).name == "28819")
            {
                GameManager.Instance.is28819 = true;
            }
            else if (transform.GetChild(0).name == "67318")
            {
                GameManager.Instance.is67318 = true;
            }
            else if (transform.GetChild(0).name == "173289")
            {
                GameManager.Instance.is173289 = true;
            }
            else if (transform.GetChild(0).name == "423327")
            {
                GameManager.Instance.is423327 = true;
            }
            else if (transform.GetChild(0).name == "Jeremy Bowers")
            {
                GameManager.Instance.isJeremyBowers = true;
                if (GameManager.Instance.Tishivalue == 4)
                {
                    GameManager.Instance.Tishivalue = 5;
                }
            }
            else if (transform.GetChild(0).name == "42W")
            {
                GameManager.Instance.is42W = true;
            }
            else if(transform.GetChild(0).name== "202298")
            {
                GameManager.Instance.is202298 = true;
            }
            else if (transform.GetChild(0).name == "291182")
            {
                GameManager.Instance.is291182 = true;
            }
            else if (transform.GetChild(0).name == "918773")
            {
                GameManager.Instance.is918773 = true;
                if (GameManager.Instance.Tishivalue == 7)
                {
                    GameManager.Instance.Tishivalue = 8;
                }
            }
            else if (transform.GetChild(0).name == "Red Korb")
            {
                GameManager.Instance.isRedKorb = true;
                if (GameManager.Instance.isMirandaPriestly == true && GameManager.Instance.isRedKorb == true && GameManager.Instance.isReginaGeorge == true && GameManager.Instance.Tishivalue == 8)
                {
                    GameManager.Instance.Tishivalue = 9;
                    GameManager.Instance.value = 3;
                }
            }
            else if (transform.GetChild(0).name == "Regina George")
            {
                GameManager.Instance.isReginaGeorge = true;
                if (GameManager.Instance.isMirandaPriestly == true && GameManager.Instance.isRedKorb == true && GameManager.Instance.isReginaGeorge == true && GameManager.Instance.Tishivalue == 8)
                {
                    GameManager.Instance.Tishivalue = 9;
                    GameManager.Instance.value = 3;

                }
            }
            else if (transform.GetChild(0).name == "Miranda Priestly")
            {
                GameManager.Instance.isMirandaPriestly = true;
                if(GameManager.Instance.isMirandaPriestly == true && GameManager.Instance.isRedKorb == true && GameManager.Instance.isReginaGeorge == true && GameManager.Instance.Tishivalue == 8)
                {
                    GameManager.Instance.Tishivalue = 9;
                    GameManager.Instance.value = 3;

                }
            }
            else if (transform.GetChild(0).name == "Tesla")
            {
                GameManager.Instance.isTesla = true;
                GameManager.Instance.isredhair = true;
                GameManager.Instance.isinformations = true;
            }
            else if (transform.GetChild(0).name == "ModelS")
            {
                GameManager.Instance.isModelS = true;
            }
            else if (transform.GetChild(0).name == "female")
            {
                GameManager.Instance.isfemale = true;
            }

            if (GameManager.Instance.isMortySchapiro == true && GameManager.Instance.value == 0)
            {
                GameManager.Instance.value = 1;
            }
            else if (GameManager.Instance.isJeremyBowers == true && GameManager.Instance.value == 1)
            {
                GameManager.Instance.value = 2;
            }
            GameObject.Find("TextAnimationControl").GetComponent<TextAnimation>().ActivateText(eventData.pointerCurrentRaycast.gameObject.transform.position, "你收集到了新的信息，请打开笔记本查看");
        }
        else if(eventData.pointerCurrentRaycast.gameObject.name == "answer")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform); //将此对象的父亲设置为目标对象的
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; //将此对象的位置设为目标对象的位置
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;

        }
        else if(orignaParent.name=="Item")
        {
            Debug.Log("11");
            orignaParent = transform.parent;
        }

            transform.SetParent(orignaParent); //恢复父节点
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}