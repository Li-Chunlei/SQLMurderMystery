using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    //  public static DialogueManager instance;
    public AnswerEventManager answerEventManager;
    public GameObject dialogueBox;
    public GameObject dialogueAnswerBox;
    public GameObject dialogueAnswerBox2;
    public Text dialogueText, nameText;

    public GameObject MortySchapiro;
    public GameObject JeremyBower;
    public GameObject RedKorb;
    public GameObject ReginaGeorge;
    public GameObject MirandaPriestly;
    public GameObject Slotlingshi;
    public GameObject GameOverImage;


    public Image blackScreen;
    public float fadeTime = 3f;

    public int LengthLimit;
    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField] public int currentLine;

    public Sprite[] peopleimages;
    public GameObject   peopleimage;
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        if (instance != this)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}
    void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
        LengthLimit = 8;
        if (GameManager.Instance.value==1)
        {
            currentLine = 16;
            Debug.Log("11");
            LengthLimit = 22;
        }
        else if(GameManager.Instance.value == 2)
        {
            currentLine = 51;
            LengthLimit = 54;
        }
        else if(GameManager.Instance.value==3)
        {
            currentLine = 80;
            LengthLimit = 82;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.is48Z == true && GameManager.Instance.isH4ZW == true && GameManager.Instance.value == 1)
        {
            LengthLimit = 50;
        }
        else if (GameManager.Instance.is20080115==true && GameManager.Instance.isMurder == true && GameManager.Instance.issql==true && GameManager.Instance.value == 0)
        {
            LengthLimit = 16;
        }

        if (dialogueBox.activeInHierarchy)
        {

            if (currentLine == 20)//ToDo:要改
            {
                MortySchapiro.SetActive(true);
                Slotlingshi.SetActive(true);
            }
            else if(currentLine==54 )
            {
                Slotlingshi.SetActive(true);    
                if(GameManager.Instance.isJeremyBowers == true)
                {
                    JeremyBower.SetActive(true);
                    LengthLimit = 56;
                }
            }
            else if (currentLine == 82)
            {
                Slotlingshi.SetActive(true);
                if (GameManager.Instance.isRedKorb == true && GameManager.Instance.isReginaGeorge == true && GameManager.Instance.isMirandaPriestly == true)
                {
                    ReginaGeorge.SetActive(true);
                    MirandaPriestly.SetActive(true);
                    RedKorb.SetActive(true);
                    LengthLimit = 82;
                }
            }
            if ((MortySchapiro.transform.parent.name == "answer"))
            {
                MortySchapiro.transform.parent.gameObject.SetActive(false);
            }
            if ((JeremyBower.transform.parent.name == "answer"))
            {
                JeremyBower.transform.parent.gameObject.SetActive(false);
            }
            if ((MirandaPriestly.transform.parent.name == "answer"))
            {
                MirandaPriestly.transform.parent.gameObject.SetActive(false);
                //跳转到游戏结束
                GameOverImage.SetActive(true);
            }
            else if ((ReginaGeorge.transform.parent.name == "answer")|| (RedKorb.transform.parent.name == "answer"))
                    {
                GameOverImage.SetActive(true);

            }
            if (Input.GetMouseButtonUp(0) &&(!(MortySchapiro.activeInHierarchy)|| (MortySchapiro.transform.parent.name == "answer"))&& (!(JeremyBower.activeInHierarchy)))
            {

                if (GameManager.Instance.value == 1 && currentLine==22)
                    {
                    StartCoroutine(FadeInAndOut());
                    LengthLimit = 40;
                    }
                if (GameManager.Instance.value == 2 && currentLine == 56)
                {
                    StartCoroutine(FadeInAndOut());
                    LengthLimit = 78;

                }
                if (currentLine < LengthLimit)
                {
                    currentLine++;

                    CheckName();
                    CheckHuida();
                    dialogueText.text = dialogueLines[currentLine];
                }
                else if(currentLine == dialogueLines.Length-1)
                {
                    dialogueBox.SetActive(false);
                }
                if (currentLine == 16 && GameManager.Instance.Tishivalue == 0)
                {
                    GameManager.Instance.Tishivalue = 1;
                    Debug.Log("11");
                }
                if (currentLine == 46  &&GameManager.Instance.Tishivalue == 3)
                {
                    GameManager.Instance.Tishivalue = 4;
                }
                if (currentLine == 58 && GameManager.Instance.Tishivalue == 5)
                {

                    GameManager.Instance.Tishivalue = 6;
                }
                if (currentLine == 78 && GameManager.Instance.Tishivalue == 6)
                {

                    GameManager.Instance.Tishivalue = 7;
                }
                if (currentLine == 71)
                {
                    GameObject.Find("AnswerEventManager").GetComponent<AnswerEventManager>().Aanswer6();
                }


            }
        }

    }
    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            if (dialogueLines[currentLine].Contains("警长"))
            {
                peopleimage.GetComponent<Image>().sprite = peopleimages[0];
            }
            else if (dialogueLines[currentLine].Contains("主角"))
            {
                peopleimage.GetComponent<Image>().sprite = peopleimages[1];
            }
            else
            {
                peopleimage.GetComponent<Image>().sprite = peopleimages[2];
            }
            currentLine++;
           
        }
    }

    private void CheckHuida()
    {
        if(currentLine == 8)
        {
            dialogueAnswerBox.SetActive(true);
            if(GameManager.Instance.is20080115==true)
            {
                dialogueAnswerBox.transform.GetChild(0).gameObject.SetActive(false);
            }
            if(GameManager.Instance.isMurder == true)
            {
                dialogueAnswerBox.transform.GetChild(1).gameObject.SetActive(false);
            }
            if(GameManager.Instance.issql == true)
            {
                dialogueAnswerBox.transform.GetChild(2).gameObject.SetActive(false);
            }
        }    
        if(currentLine==40)
        {
            dialogueAnswerBox2.SetActive(true);
        }
    }
    public void showDialogue()
    {
        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
    }

    IEnumerator FadeInAndOut()
    {
        blackScreen.CrossFadeAlpha(255, fadeTime / 2, false);
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(5f);
        dialogueBox.SetActive(true);
        blackScreen.CrossFadeAlpha(1, fadeTime / 2, false);
    }


}