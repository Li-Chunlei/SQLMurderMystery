using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerEventManager : MonoBehaviour
{
    public DialogueManager dialoguemanager;
    public List<GameObject> AnswerImage = new List<GameObject>();


    public void Aanswer1()
    {
        dialoguemanager.currentLine = 9;

        if (GameManager.Instance.is20080115==false)
        {
            dialoguemanager.showDialogue();
        }
        dialoguemanager.currentLine--;

    }
    public void Aanswer2()
    {
        dialoguemanager.currentLine = 10;

        if (GameManager.Instance.isMurder==false)
        {          
            dialoguemanager.showDialogue();
            AnswerImage[0].SetActive(true);
        }
        dialoguemanager.currentLine--;

    }
    public void Aanswer3()
    {
        dialoguemanager.currentLine = 11;

        if (GameManager.Instance.issql == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[1].SetActive(true);
        }
        dialoguemanager.currentLine--;

    }
    public void Aanswer4()
    {
        dialoguemanager.currentLine = 41;

        if (GameManager.Instance.is48Z == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[2].SetActive(true);
            AnswerImage[3].SetActive(true);
        }
        dialoguemanager.currentLine--;

    }
    public void Aanswer5()
    {
        dialoguemanager.currentLine = 42;

        if (GameManager.Instance.isH4ZW == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[4].SetActive(true);
        }
        dialoguemanager.currentLine--;
    }
    public void Aanswer6()
    {
     if (GameManager.Instance.isTesla == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[5].SetActive(true);

        }
        if (GameManager.Instance.isModelS == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[6].SetActive(true);
        }
        if (GameManager.Instance.isfemale == false)
        {
            dialoguemanager.showDialogue();
            AnswerImage[7].SetActive(true);
        }
     //  dialoguemanager.currentLine--;
    }


}
