using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Imdork.SQLite;
using System;

public class TestSQLMurder : MonoBehaviour
{
    string[] tableNames = { "_facebook_event_checkin_old_20230904", "_get_fit_now_check_in_old_20230904", "_get_fit_now_check_in_old_20230904_1" };
    string[][] columnNames = {
        new string[] { "person_id", "event_id", "event_name","date" },
        new string[] { "membership_id", "check_in_date", "check_in_time","check_out_time" },
        new string[] { "membership_id", "check_in_date", "check_in_time","check_out_time" }};
    // 用于存储玩家选择的参数
    int selectedTableNameIndex = 0;
    int selectedColumnNameIndex = 0;
    string valueInput = "";
    private void OnGUI()
    {
        GUILayout.Label("表名：");
        selectedTableNameIndex = GUILayout.SelectionGrid(selectedTableNameIndex, tableNames, 1);
        GUILayout.Label("列名：");
        string[] availableColumnNames = columnNames[selectedTableNameIndex];
        selectedColumnNameIndex = GUILayout.SelectionGrid(selectedColumnNameIndex, availableColumnNames, 1);

        GUILayout.Label("值：");
        valueInput = GUILayout.TextField(valueInput);
        if (GUILayout.Button("查询数据"))
        {
            // 根据玩家选择的参数进行查询
            string selectedTableName = tableNames[selectedTableNameIndex];
            string selectedColumnName = availableColumnNames[selectedColumnNameIndex];

            Getdb(db =>
            {
                Debug.Log(valueInput);
                Debug.Log(valueInput);
                Debug.Log(selectedTableName);
                Debug.Log(selectedTableName);
                Debug.Log(selectedColumnName);
                Debug.Log(selectedColumnName);
                var reader = db.SelectWhere(selectedTableName, new[] { selectedColumnName }, new[] {"="}, new[] { valueInput });
                //    Dictionary<string, object> pairs = SQLiteTools.GetValue(reader);
                // 处理查询结果
                //   print(selectedTableName + "中" + selectedColumnName + "=" + valueInput + "的为" + pairs[selectedColumnName]);
                var keys = SQLiteTools.GetValue(reader);

                foreach (var item in keys)
                {
                    //打印数据库字段名称  对应字段数值
                    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                }

            });
        }
        if (GUILayout.Button("根据条件查询全部数据"))
        {
            Getdb(obj =>
            {
                var reader = obj.SelectsWhere("_facebook_event_checkin_old_20230904",  new[] { "person_id", "event_id" }, new[] { ">", "=" }, new[] { "30000", "4387" });

                var keys = SQLiteTools.GetValue(reader);

                foreach (var item in keys)
                {
                    //打印数据库字段名称  对应字段数值
                    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                }
            }
            );
        }
        if (GUILayout.Button("测试A"))
        {
            Getdb(obj =>
            {
              //  string reader0 = "SELECT * FROM _facebook_event_checkin_old_20230904 WHERE person_id > '30000'  AND event_id = '4387'";
             //   string reader0 = "select* from  _facebook_event_checkin_old_20230904 ";
                string reader0 = "select * from  person  ";
                var reader = obj.ceshi(reader0,out string t);    
                var keys = SQLiteTools.GetValue(reader);
                var pairs = SQLiteTools.GetValues(reader);
                //foreach (var item in keys)
                //{
                //    //打印数据库字段名称  对应字段数值
                //    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                //}

                for (int i = 0; i < pairs.Length/100; i++)
                {
                    //遍历字典
                    foreach (var item in pairs[i])
                    {
                        //打印数据库字段名称  对应字段数值
                        print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                    }
                }
            }
                        );
        }
        //if (GUILayout.Button("切换表格"))
        //{
        //    switch(currentTableName)
        //    {
        //        case "_facebook_event_checkin_old_20230904":
        //            currentTableName = "_get_fit_now_check_in_old_20230904";
        //            print("表格切换为_get_fit_now_check_in_old_20230904");
        //            break;
        //        case "_get_fit_now_check_in_old_20230904":
        //            currentTableName = "_facebook_event_checkin_old_20230904";
        //            print("表格切换为_facebook_event_checkin_old_20230904");
        //            break;
        //    }
        //}
        // 获取当前表格名称对应的数据类型
        //string[] currentDataTypes = tableDict[currentTableName];
        // 调用查询方法，并传递表格名称和数据类型

        if (GUILayout.Button("创建表"))
        {

            //创建一个表方法  创建表名UserInfo
            //字段名称 UID    类型为 INTEGER
            // User Password  类型为STRING
            //将LoginTime 类型 设置为DATETIME
            Getdb(db => db.CreateTable("facebook_event_checkin_old_20230904", new[] { "person_id", "event_id", "event_name", "data" },
                new[] { "INTEGER", "INTEGER", "TEXT", "INTEGER" }));

        }

        if (GUILayout.Button("插入数据"))
        {
            //插入字段为 UID / User/ Password / LoginTime
            //对应数据 5201314 imdork 142536   本地时间
            //生成时间字符串代码：
            //DateTime.Now.ToString("s")
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password", "LoginTime" }
            , new[] { "5201314", "imdork", "142536", DateTime.Now.ToString("s") }));

        }
        if (GUILayout.Button("插入数据2"))
        {
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password", "LoginTime" }
           , new[] { "135703", "ddxj1", "56893s", DateTime.Now.ToString("s") }));
        }

        if (GUILayout.Button("删除数据"))
        {

            //删除UID 大于50全部数据
            //                      表名        判断字段        判断符号        具体数据
            Getdb(db => db.Delete("UserInfo", new[] { "UID" }, new[] { ">" }, new[] { "50" }));

        }

        if (GUILayout.Button("更改数据"))
        {
            //查询该账号UID 大于50数值 的全部符合条件数据  并更改密码为123456
            Getdb(db => db.UpdateIntoSpecific("UserInfo", new[] { "UID" }, new[] { ">" },
               new[] { "50" }, new[] { "Password" }, new[] { "123456" }));
        }

        if (GUILayout.Button("更改数据2"))
        {
            Getdb(db => db.UpdateIntoSpecific("UserInfo",
               new[] { "UID" }, new[] { ">" }, new[] { "50" }, new[] { "Password" }, new[] { "142536" }));
        }

        

        if (GUILayout.Button("查询全部数据库"))
        {
            Getdb
          (
             db =>
             {
                 //读取表的全部数据
                 var reader = db.ReadFullTable("_facebook_event_checkin_old_20230904");
                 //获取全部数据
                 var pairs = SQLiteTools.GetValues(reader);
                 //遍历字典数组
                 for (int i = 0; i < pairs.Length; i++)
                 {
                     //遍历字典
                     foreach (var item in pairs[i])
                     {
                         //打印数据库字段名称  对应字段数值
                         print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
                     }
                 }
             }
          );


        }

      


    }
    /// <summary>
    /// 数据库路径
    /// </summary>
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

    private void Getdb2(Action<DbAccess> action)
    {
        //创建数据库读取类
        SQLiteHelper helper = new SQLiteHelper(Path);
        //打开数据库 存储数据库操作类
        var db = helper.Open();
        //调用数据库委托
        action(db);
        //关闭数据库
        db.CloseSqlConnection();

    }

    private void FindBool()
    {
        Getdb(db =>
        {
            //查询全部数据
            var reader = db.ReadFullTable("表名");

            //读取下一行数据 第一次调用则 读取数据库第一行数据
            while (SQLiteTools.Read(reader))
            {
                bool value = SQLiteTools.GetValue(reader, "字段名", i => reader.GetBoolean(i));
            }

        });
    }

}
