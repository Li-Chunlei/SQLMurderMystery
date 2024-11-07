using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Imdork.SQLite;
using System;

public class Test : MonoBehaviour
{

   
    private void OnGUI()
    {
        if(GUILayout.Button("创建表"))
        {

            //创建一个表方法  创建表名UserInfo
            //字段名称 UID    类型为 INTEGER
            // User Password  类型为STRING
            //将LoginTime 类型 设置为DATETIME
            Getdb(db => db.CreateTable("UserInfo", new[] { "UID", "User", "Password", "LoginTime" },
                new[] { "INTEGER", "STRING", "STRING", "DATETIME" }));
            
        }

        if(GUILayout.Button("插入数据"))
        {
            //插入字段为 UID / User/ Password / LoginTime
            //对应数据 5201314 imdork 142536   本地时间
                                               //生成时间字符串代码：
                                               //DateTime.Now.ToString("s")
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password","LoginTime" }
            , new [] { "5201314", "imdork", "142536", DateTime.Now.ToString("s") }));
                  
        }
        if(GUILayout.Button("插入数据2"))
        {
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password", "LoginTime" }
           , new[] { "135703", "ddxj1", "56893s", DateTime.Now.ToString("s") }));
        }

        if(GUILayout.Button("删除数据"))
        {

            //删除UID 大于50全部数据
            //                      表名        判断字段        判断符号        具体数据
            Getdb(db => db.Delete("UserInfo", new[] { "UID" }, new[] { ">" }, new[] { "50" }));
           
        }

        if(GUILayout.Button("更改数据"))
        {
            //查询该账号UID 大于50数值 的全部符合条件数据  并更改密码为123456
            Getdb(db => db.UpdateIntoSpecific("UserInfo", new[] { "UID" }, new[] { ">" },
               new[] { "50" }, new[] { "Password" }, new[] { "123456" }));         
        }

        if(GUILayout.Button("更改数据2"))
        {
            Getdb(db => db.UpdateIntoSpecific("UserInfo",
               new[] { "UID" }, new[] { ">" }, new[] { "50" }, new[] { "Password" }, new[] { "142536" })); 
        }

        if(GUILayout.Button("查询数据"))
        {
            //调用Getdb方法
            Getdb(db =>
            {
                //查询该账号UID 大于50  对应的 LoginTime 和 User 对应字段数据
                var reader = db.SelectWhere("UserInfo", new[] { "User","LoginTime" },
                     new[] { "UID" }, new[] { ">" }, new[] { "50" });

                //调用SQLite工具解析 对应数据
                Dictionary<string, object> pairs = SQLiteTools.GetValue(reader);

                //获取User字段 对应数据
                 print("User账号是：" + pairs["User"]);

                //获取账号登录时间
                print("LoginTime登录时间是：" + pairs["LoginTime"]);

            }
            );
        }

        if(GUILayout.Button("查询全部数据库"))
        {
            //调用Getdb方法
            Getdb
            (
               db =>
               {
                   //读取表的全部数据
                   var reader = db.ReadFullTable("UserInfo");
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
       
        if(GUILayout.Button("根据条件查询全部数据"))
        {
            Getdb(obj =>
            {
                var reader = obj.SelectsWhere("UserInfo",
                    new[] { "UID", "User" }, new[] { ">", "=" }, new[] { "50", "imdork" });

                var keys = SQLiteTools.GetValue(reader);

                foreach (var item in keys)
                {
                    //打印数据库字段名称  对应字段数值
                    print("数据库字段名为：" + item.Key + "  对应数据值为：" + item.Value);
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
        Getdb( db =>
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
