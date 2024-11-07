using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Imdork.SQLite;
using System;
public class EventManager : MonoBehaviour
{
    public GameObject Picput;
    public GameObject information;
    public GameObject information0;
    public GameObject information1;
    public GameObject information2;
    public GameObject information3;
    public GameObject information41;
    public GameObject information42;
    public GameObject information43;
    public GameObject rili;
    public Judgment judgment;
    public List<GameObject> GeziItem = new List<GameObject>();

    public GameObject openA;
    public List<GameObject> A = new List<GameObject>();
    public GameObject openB;
    public List<GameObject> B = new List<GameObject>();
    public GameObject openC;
    public List<GameObject> C = new List<GameObject>();
    public GameObject openD;
    public List<GameObject> D = new List<GameObject>();

    public GameObject jiashizhen;
    public GameObject jiashiwu;
    public GameObject idwu;

    public GameObject notebook;
    public GameObject buttonList;
    public GameObject diannao;
    public GameObject diannaoButton;
    public GameObject Objectparent;

    public SceneManager1 sceneManager1;

    public GameObject sqlkuname;
    public GameObject objectparent;

    public GameObject crime_scene_report;
    public GameObject person;
    public GameObject get_fit_now_member;
    public GameObject get_fit_now_check_in;
    public GameObject drivers_license;
    public GameObject facebook_event_checkin;



    public void xianshi()
    {
        information.SetActive(true);

        judgment.tianjia();
        judgment.Check();
        judgment.Panding();
     //   informationclear();
        information.SetActive(true);
        if (judgment.panding == 1)
        {
            information1.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (judgment.panding == 2)
        {
            information2.SetActive(true);
        }
        else if (judgment.panding == 3)
        {
            information3.SetActive(true);
        }
        else if (judgment.panding == 41)
        {
            information41.SetActive(true);
        }
        else if (judgment.panding == 42)
        {
            information42.SetActive(true);
        }
        else if (judgment.panding == 43)
        {
            information43.SetActive(true);
        }
        if (judgment.panding == 0)
        {
            information0.SetActive(true);
        }

    }
    public void guanbi()
    {
    //    informationclear();
        judgment.tiaojianclear();
        Objectparent.SetActive(false);
        foreach (GameObject piece in judgment.pieces)
        {
            piece.transform.SetParent(Picput.transform);
            piece.GetComponent<PuzzlePiece>().TTtransform();
        }
        judgment.pieces.Clear();
    }

    public void Rili()
    {
        if (rili.activeInHierarchy)
        {
            rili.SetActive(false);
        }
        else
        {
            rili.SetActive(true);
        }
    }
    public void OpenA()
    {
        if (openA.activeInHierarchy)
        {
            guanbiquanbu();
        }
        else
        {
            guanbiquanbu();
            openA.SetActive(true);
            foreach (GameObject a in A)
            {
                a.SetActive(true);
            }
        }
    }
    public void OpenB()
    {
        if (openB.activeInHierarchy)
        {
            guanbiquanbu();
        }
        else
        {
            guanbiquanbu();
            openB.SetActive(true);
            foreach (GameObject b in B)
            {
                b.SetActive(true);
            }
        }
    }

    public void OpenC()
    {
        if (openC.activeInHierarchy)
        {
            guanbiquanbu();
        }
        else
        {
            guanbiquanbu();
            openC.SetActive(true);
            foreach (GameObject c in C)
            {
                c.SetActive(true);
            }
        }

    }
    public void OpenD()
    {
        if (openD.activeInHierarchy)
        {
            guanbiquanbu();
        }
        else
        {
            guanbiquanbu();
            openD.SetActive(true);
            foreach (GameObject d in D)
            {
                d.SetActive(true);
            }
        }

    }
    public void openjiashizhen()
    {
        if (jiashizhen.activeInHierarchy)
        {
            jiashizhen.SetActive(false);
            jiashiwu.SetActive(false);
            idwu.SetActive(false);
        }
        else
        {
            jiashizhen.SetActive(true);
            jiashiwu.SetActive(true);
            idwu.SetActive(true);
        }
    }

    public void guanbiquanbu()
    {
        foreach (GameObject a in A)
        {
            a.SetActive(false);
        }
        foreach (GameObject b in B)
        {
            b.SetActive(false);
        }
        foreach (GameObject c in C)
        {
            c.SetActive(false);
        }
        foreach (GameObject d in D)
        {
            d.SetActive(false);
        }
        openA.SetActive(false);
        openB.SetActive(false);
        openC.SetActive(false);
        openD.SetActive(false);
    }
    public void informationclear()
    {
        information0.SetActive(false);
        information.SetActive(false);
        information1.SetActive(false);
        information2.SetActive(false);
        information3.SetActive(false);
        information41.SetActive(false);
        information42.SetActive(false);
        information43.SetActive(false);
    }

    public void bijibengxiaoshi()
    {
        if (notebook.activeInHierarchy == false)
        {
            notebook.SetActive(true);
            if (GameManager.Instance.is20080115 == true)
            {
                notebook.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isMurder == true)
            {
                notebook.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (GameManager.Instance.issql == true)
            {
                notebook.transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isHuiyuan == true)
            {
                notebook.transform.GetChild(3).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isH4ZW == true)
            {
                notebook.transform.GetChild(4).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is48Z == true)
            {
                notebook.transform.GetChild(5).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isNorthWesternDr == true)
            {
                notebook.transform.GetChild(6).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isMortySchapiro == true)
            {
                notebook.transform.GetChild(7).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is14887 == true)
            {
                notebook.transform.GetChild(8).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is67318 == true)
            {
                notebook.transform.GetChild(9).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is28819 == true)
            {
                notebook.transform.GetChild(10).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is173289 == true)
            {
                notebook.transform.GetChild(11).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is423327 == true)
            {
                notebook.transform.GetChild(12).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isJeremyBowers == true)
            {
                notebook.transform.GetChild(13).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is42W == true)
            {
                notebook.transform.GetChild(14).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is202298 == true)
            {
                notebook.transform.GetChild(15).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is291182 == true)
            {
                notebook.transform.GetChild(16).gameObject.SetActive(true);
            }
            if (GameManager.Instance.is918773 == true)
            {
                notebook.transform.GetChild(17).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isRedKorb == true)
            {
                notebook.transform.GetChild(18).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isReginaGeorge == true)
            {
                notebook.transform.GetChild(19).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isMirandaPriestly == true)
            {
                notebook.transform.GetChild(20).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isTesla == true)
            {
                notebook.transform.GetChild(21).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isModelS == true)
            {
                notebook.transform.GetChild(22).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isfemale == true)
            {
                notebook.transform.GetChild(23).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isredhair == true)
            {
                notebook.transform.GetChild(24).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isinformations == true)
            {
                notebook.transform.GetChild(25).gameObject.SetActive(true);
            }
        }
        else
        {
            notebook.SetActive(false);
        }
    }

    public void fanhuizoulang()
    {
        if (diannao.activeInHierarchy == false)
        {
            sceneManager1.OnButtonClick();
        }
    }
    public void guanbidiannao()
    {
        if (diannao.activeInHierarchy)
        {
            diannao.SetActive(false);
            diannaoButton.SetActive(true);
            objectparent.SetActive(false);
        }
        else
        {
            if (GameManager.Instance.isfanzuixianchangbaogao == true)
            {
                buttonList.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isxiangguanrenyuanmingdan == true)
            {
                buttonList.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isjianshengfang == true)
            {
                buttonList.transform.GetChild(2).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isxiangguanrenyuanmingdan2 == true)
            {
                buttonList.transform.GetChild(3).gameObject.SetActive(true);
            }
            if (GameManager.Instance.isjiashizheng == true)
            {
                buttonList.transform.GetChild(4).gameObject.SetActive(true);
            }
            diannao.SetActive(true);
            diannaoButton.SetActive(false);
        }
    }

    public void openAbook()
    {
        GameManager.Instance.isfanzuixianchangbaogao = true;
    }
    public void openBbook()
    {
        GameManager.Instance.isxiangguanrenyuanmingdan = true;
    }

    public void openCbook()
    {
        GameManager.Instance.isjianshengfang = true;
    }
    public void openDbook()
    {
        GameManager.Instance.isxiangguanrenyuanmingdan2 = true;
    }
    public void openEbook()
    {
        GameManager.Instance.isjiashizheng = true;
    }
    public void openSql(string name)
    {
        sqlkuname.name =name;
        sqlkuname.GetComponent<Text>().text = name;
        crime_scene_report.SetActive(false);
        person.SetActive(false);
        get_fit_now_member.SetActive(false);
        drivers_license.SetActive(false);
        facebook_event_checkin.SetActive(false);
        if (name== "crime_scene_report")
        {
            crime_scene_report.SetActive(true);
        }
        else if(name=="person")
        {
            person.SetActive(true);
        }
        else if(name== "get_fit_now_member")
        {
            get_fit_now_member.SetActive(true);
        }
        else if(name== "drivers_license")
        {
            drivers_license.SetActive(true);
        }
        else if(name== "facebook_event_checkin")
        {
            facebook_event_checkin.SetActive(true);
        }
    }

}


