using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Imdork.SQLite;
using System;
public class Judgment : MonoBehaviour
{

    public Transform child;
    public GameObject textchild;

    public bool isWhere=false;
    // Start is called before the first frame update
    public bool tiaojian1 = false;
    public bool tiaojian2 = false;
    public bool tiaojian3 = false;


    public bool issql = false;
    public bool ismurder = false;
    public bool is20180115 = false;
    public bool iscrime_scene_report = false;

    public bool isperson = false;
    public bool isNorthwesternDr = false;
    public bool isaddress_number = false;

    public bool isget_fit_now_member = false;
    public bool isgold = false;
    public bool is48Z = false;

    public bool is28819 = false;
    public bool is67318 = false;

    public bool isdrivers_license = false;
    public bool is423327 = false;

    public int panding = 0;
    public int tishi = 0;
    public List<GameObject> pieces = new List<GameObject>();
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> itemsList = new List<GameObject>();

    public GameObject tuodonggezi;
    public int gezishu;
    public GameObject objectparent;

    public int jiluchaxunshu;
    public GameObject tishiwenzi2;


    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Panding()
    {
        if (iscrime_scene_report == true)
        {
            if (ismurder == true && issql == true && is20180115 == true)
            {
                panding = 1;
            }
            else if (ismurder == true && issql == true)
            {
                panding = 11;
            }
            else if (ismurder == true && is20180115 == true)
            {
                panding = 12;
            }
            else if (issql == true && is20180115 == true)
            {
                panding = 13;
            }
            else if (ismurder == true)
            {
                panding = 14;
            }
            else if (issql == true)
            {
                panding = 15;
            }
            else if (is20180115 == true)
            {
                panding = 16;
            }
            else
            {
                panding = 10;
            }
        }
        else if (isperson == true)
        {
            if (isNorthwesternDr == true && isaddress_number == true)
            {
                panding = 2;
                GameManager.Instance.value++;
            }
            else if (isNorthwesternDr == true)
            {
                panding = 21;
            }
            else if (isaddress_number == true)
            {
                panding = 22;
            }
            else
            {
                panding = 20;
            }
        }
        else if (isget_fit_now_member == true)
        {
            if ( isgold == true && is48Z == true)
            {
                panding = 3;
            }
            else if(isgold == true)
            {
                panding = 31;
            }
            else if(is48Z == true)
            {
                panding = 32;
            }
            else
            {
                panding = 30;
            }
        }
        else if(isget_fit_now_member == true)
        {
            if(is28819 == true && is67318 == true)
            {
                panding = 4;
            }
            else if (is28819 == true)
            {
                panding = 41;
            }
            else if(is67318==true)
            {
                panding = 42;
            }
            else
            {
                panding = 40;
            }
        }
        else if(isdrivers_license == true && is423327==true)
        {
            panding = 43;
            GameManager.Instance.value++;
        }
        else
        {
            panding = 0;
        }
    }
    public void tianjia()
    {
        items.Clear();
        foreach (GameObject itemlist in itemsList)
        {
            if (itemlist.transform.childCount > 0)
            {
                child = itemlist.transform.GetChild(0);
                textchild = child.transform.GetChild(0).gameObject;
                items.Add(textchild);
            }
        }
    }
    public void Check()
    {
        if(items.Count==0)
        {
            Debug.Log("你没有输入;");

            return;
        }
        if (items[items.Count-1].name!=";")
        {
            Debug.Log("没有;");
            return;
        }
        else
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                GameObject item = items[i];
                if (item.name == "select" || item.name == "where" || item.name =="and"|| item.name == "orderby")
                {
                    GameObject item1 = items[i + 1];
                    if (item1.name == ";")
                    {
                        return;
                    }
                    GameObject item2 = items[i + 2];
                    if (item2.name == ";")
                    {
                        return;
                    }
                    GameObject item3 = items[i + 3];
                    if (item3.name == ";")
                    {
                        return;
                    }
                    if (item.name == "select")
                    {
                        if (item1.name == "*" && item2.name == "from")
                        {
                            if (item3.name == "crime_scene_report")
                            {
                                iscrime_scene_report = true;
                            }
                            else if (item3.name == "person")
                            {
                                isperson = true;
                            }
                            else if (item3.name == "get_fit_now_member")
                            {
                                isget_fit_now_member = true;
                            }
                            else if(item3.name== "drivers_license")
                            {
                                isdrivers_license = true;
                            }
                        }

                    }
                    else if ((item.name == "where" && item2.name == "=") || (item.name == "and" && item2.name == "=" && isWhere == true)|| (item.name == "and" && item2.name == "like" && isWhere == true)|| (item.name == "where" && item2.name == "like"))
                    {
                        if (item1.name == "type")
                        {
                            if (item3.name == "murder")
                            {
                                Debug.Log("4");
                                ismurder = true;
                                isWhere = true;

                            }

                        }
                        else if (item1.name == "city")
                        {
                            if (item3.name == "sql")
                            {
                                issql = true;
                                isWhere = true;
                            }
                        }
                        else if (item1.name == "data")
                        {
                            if (item3.name == "20180115")
                            {
                                is20180115 = true;
                                isWhere = true;
                            }
                        }
                        else if (item1.name == "address_street_name")
                        {
                            if (item3.name == "NorthwesternDr")
                            {

                                isNorthwesternDr = true;
                                isWhere = true;
                            }
                        }
                        else if (item1.name == "membership_status")
                        {
                            if (item3.name == "gold")
                            {
                                isgold = true;
                                isWhere = true;
                            }
                        }
                        else if (item1.name == "person_id")
                        {
                            if(item3.name == "%48Z%")
                            {
                                is48Z = true;//TODO:获得%%的任务
                                isWhere = true;
                            }
                            if (item3.name=="28819")
                            {
                                is28819 = true;
                                isWhere = true;
                            }
                            if (item3.name == "67318")
                            {
                                is67318 = true;
                                isWhere = true;
                            }
                            if (item3.name=="423327")
                            {
                                is423327 = true; 
                                isWhere = true;
                            }
                        }
                    }
                    else if(item.name =="orderby")
                    {
                        if (item2.name == "desclimit")
                        {

                            if (item1.name == "address_number" && item3.name=="1")
                            {
                                isaddress_number = true;
                            }
                        }
                    }
  
                }
            }
        


        }
    }
    public void tiaojianclear()
    {
      tiaojian1 = false;
      tiaojian2 = false;
      tiaojian3 = false;


      issql = false;
      ismurder = false;
      is20180115 = false;
      iscrime_scene_report = false;

      isperson = false;
      isNorthwesternDr = false;
      isaddress_number = false;

      isget_fit_now_member = false;
      isgold = false;
      is48Z = false;

      is28819 = false;
      is67318 = false;

      isdrivers_license = false;
      is423327 = false;
    }

    public string Path;
    private void Getdb(Action<DbAccess> action)
    {
        //Path数据库文件，一定是StreamingAssets文件夹下 填写的路径文件不需要填写.db后缀
        //创建数据库读取类
        SQLiteHelper helper = new SQLiteHelper(Path);
        //打开数据库 存储数据库操作类
        using (var db = helper.Open())
        {
            //调用数据库委托
            action(db);
        }
        /*
         因为每次使用数据 添/删/改/查 都需要使用完后Close掉 
         重复代码，写无数次太麻烦 因为数据库操作类 继承了IDisposable接口 所以，
         using会自动关闭数据库连接，我们无需手动关闭数据库
         */

    }

    //public void ceshiA()
    //{
    //    Getdb(obj =>
    //    {
    //        //  string reader0 = "SELECT * FROM _facebook_event_checkin_old_20230904 WHERE person_id > '30000'  AND event_id = '4387'";
    //        //   string reader0 = "select* from  _facebook_event_checkin_old_20230904 ";
    //        string reader0 = "select * from  person  ";
    //        var reader = obj.ceshi(reader0);
    //        var keys = SQLiteTools.GetValue(reader);
    //        var pairs = SQLiteTools.GetValues(reader);
    //        //foreach (var item in keys)
    //        //{
    //        //    //打印数据库字段名称  对应字段数值
    //        //    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
    //        //}

    //        for (int i = 0; i < pairs.Length / 100; i++)
    //        {
    //            //遍历字典
    //            foreach (var item in pairs[i])
    //            {
    //                //打印数据库字段名称  对应字段数值
    //                Debug.Log("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
    //            }
    //        }
    //    }
    //                    );
    //}
    public void ceshiB()
    {
        tianjia();
        Getdb(obj =>
        {
            //  string reader0 = "SELECT * FROM _facebook_event_checkin_old_20230904 WHERE person_id > '30000'  AND event_id = '4387'";
            //   string reader0 = "select* from  _facebook_event_checkin_old_20230904 ";

            //  string reader0 = "select * from  person  ";
            string reader0 = "";
            int jiluhavingcountT = 0;
            foreach (GameObject item in items)
            {
                reader0 = reader0 + " "+item.name;
                if (jiluhavingcountT == 1)
                {
                    jiluhavingcountT = 0;
                    reader0 = reader0 + " ) ";
                }
                if (item.name== "having count")
                {
                    reader0 = reader0 + " ( ";
                    jiluhavingcountT = 1;
                }

            }
            Debug.Log(reader0);
            //   reader0 = "select * from person where address_street_name = 'Northwestern Dr' order by address_number desc limit '1'";
            // reader0 = "select * from person where address_street_name = 'Northwestern Dr' and address_number > '100'";
            //reader0 = "SELECT * FROM 'person' WHERE license_id = '202298' OR license_id = '291182' OR license_id = '918773' ";
            //  reader0 = "select emp.name , dept.name from emp , dept where emp.dept_id = dept.id ; ";
            //reader0 = "SELECT * FROM 'facebook_event_checkin'where event_name LIKE '%concert%' and date LIKE '201712%' group by person_id having count( person_id ) = 3";
            // reader0 = "select * from facebook_event_checkin                                                            group by person_id having count( person_id )  = 3";
            //          select * from  facebook_event_checkin where event_name like '%concert%'

          //  reader0 = "SELECT person.name, income.annual_income FROM income JOIN person ON income.ssn = person.ssn WHERE annual_income > 450000";//多表查询
            string baocuot;
            var reader = obj.ceshi(reader0,out baocuot);
          //  var keys = SQLiteTools.GetValue(reader);
            var pairs = SQLiteTools.GetValues(reader);
            Debug.Log(baocuot);
            if(baocuot.Contains("incomplete input"))
            {
                Debug.Log("输入不完整,检查你是否没有选择想要查询的表单或数据");
                cuowu("输入不完整,检查你是否没有选择想要查询的表单或数据");
                return;
            }
            else if(baocuot.Contains("syntax error"))
            {
                Debug.Log("语法错误");
                cuowu("语法错误");
                return;

            }
            else if(baocuot.Contains("no such column"))
            {
                Debug.Log("这个列名无法从数据库表中找到");
                cuowu("这个列名无法从数据库表中找到");
                return;
            }

            try
            {
                Debug.Log(pairs.Length);
                Debug.Log(reader.FieldCount);//列数
            }
            catch (System.NullReferenceException ex)
            {
                if (ex.Message.Contains("Object reference not set to an instance of an object"))
                {
                    Debug.Log("查询结果为空");
                    cuowu("查询结果为空,或检查一下你的输入是否有误");
                }
                return ;
            }

            //foreach (var item in keys)
            //{
            //    //打印数据库字段名称  对应字段数值
            //    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
            //}
            int maxlength = 0;
            if(pairs.Length>11)
            {
                maxlength = 11;
            }
            else
            {
                maxlength = pairs.Length;
            }
            gezishu = 0;
            int jilut = 0;

            for (int i=0;i< tuodonggezi.transform.GetChild(0).childCount; i++)
            {
                tuodonggezi.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }

            foreach (var item in pairs[0])
            {
                gezishu++;
                tuodonggezi.transform.GetChild(0).GetChild(jilut).gameObject.SetActive(true);
                tuodonggezi.transform.GetChild(0).GetChild(jilut).gameObject.GetComponent<Image>().color=Color.yellow;
                tuodonggezi.transform.GetChild(0).GetChild(jilut).GetChild(0).gameObject.GetComponent<Text>().text = item.Key ;
                jilut++;
            }
            tuodonggezi.GetComponent<RectTransform>().sizeDelta = new Vector2(gezishu * 163 - 3, tuodonggezi.GetComponent<RectTransform>().rect.height);
            tuodonggezi.transform.GetChild(0).gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(160,100);
            if (gezishu>5)
            {
                tuodonggezi.transform.GetChild(0).gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(850/gezishu, tuodonggezi.transform.GetChild(0).gameObject.GetComponent<GridLayoutGroup>().cellSize.y);
                tuodonggezi.GetComponent<RectTransform>().sizeDelta = new Vector2(856+gezishu*3 , tuodonggezi.GetComponent<RectTransform>().rect.height);
            }
            for (int i = 0; i < maxlength; i++)
            {
                //遍历字典
                foreach (var item in pairs[i])
                {
                    //打印数据库字段名称  对应字段数值   GO.GetComponent<Text>().text = "6666";
                    Debug.Log("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                    tuodonggezi.transform.GetChild(0).GetChild(jilut).gameObject.GetComponent<Image>().color = Color.white;
                    tuodonggezi.transform.GetChild(0).GetChild(jilut).gameObject.SetActive(true);
                    tuodonggezi.transform.GetChild(0).GetChild(jilut).GetChild(0).gameObject.GetComponent<Text>().text = ""+(item.Value);
                    jilut++;

                }
            }
            jiluchaxunshu = pairs.Length;
            objectparent.SetActive(true);


            //  GameObject.Find("TishiWenzi").GetComponent<Wenzicontrol>().tishi(jiluchaxunshu);//考虑不存在的情况
            tishiwenzi2.SetActive(true);
            GameObject tishiWenziObject = GameObject.Find("TishiWenzi2");
            if (tishiWenziObject != null)
            {
                Wenzicontrol wenzicontrol = tishiWenziObject.GetComponent<Wenzicontrol>();
                if (wenzicontrol != null)
                {
                    wenzicontrol.tishi(jiluchaxunshu);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
                       );

        pandingjingdu();
    }

    private void pandingjingdu()
    {
        if(GameManager.Instance.isMortySchapiro == true && GameManager.Instance.value==0)
        {
            GameManager.Instance.value = 1;
        }
        else if(GameManager.Instance.isJeremyBowers == true && GameManager.Instance.value == 1)
        {
            GameManager.Instance.value = 2;
        }
        else if (GameManager.Instance.isMirandaPriestly == true && GameManager.Instance.value == 2)
        {
            GameManager.Instance.value = 3;
        }
    }

    private void cuowu(string t)
    {
        tishiwenzi2.SetActive(true);
        GameObject tishiWenziObject = GameObject.Find("TishiWenzi2");
        if (tishiWenziObject != null)
        {
            Wenzicontrol wenzicontrol = tishiWenziObject.GetComponent<Wenzicontrol>();
            if (wenzicontrol != null)
            {
                wenzicontrol.cuowutishi(t);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
