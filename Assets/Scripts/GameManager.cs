using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonPattern<GameManager>
{
    // Start is called before the first frame update
    public int value;
    [SerializeField]
    private int tishivalue;
    //public int Tishivalue;
    public int Tishivalue
    {

        get { return tishivalue; }
        set
        {
            tishivalue = value;
            GameObject.Find("TiShiControl").GetComponent<TishiControl>().showTishi();
        }
    }

    public bool is20080115;
    public bool isMurder;
    public bool issql;

    public bool isHuiyuan;
    public bool is48Z;
    public bool isH4ZW;

    public bool isNorthWesternDr;
    public bool isMortySchapiro;
    public bool is14887;
    public bool is28819;
    public bool is67318;
    public bool is173289;
    public bool is423327;
    public bool isJeremyBowers;
    public bool is42W;
    public bool is202298;
    public bool is291182;
    public bool is918773;
    public bool isRedKorb;
    public bool isReginaGeorge;
    public bool isMirandaPriestly;

    public bool isTesla;
    public bool isModelS;
    public bool isfemale;
    public bool isinformations;
    public bool isredhair;

    public bool Xinshou1;





    public bool isfanzuixianchangbaogao;
    public bool isxiangguanrenyuanmingdan;
    public bool isjianshengfang;
    public bool isxiangguanrenyuanmingdan2;
    public bool isjiashizheng;


}
