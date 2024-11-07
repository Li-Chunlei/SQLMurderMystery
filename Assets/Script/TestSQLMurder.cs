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
    // ���ڴ洢���ѡ��Ĳ���
    int selectedTableNameIndex = 0;
    int selectedColumnNameIndex = 0;
    string valueInput = "";
    private void OnGUI()
    {
        GUILayout.Label("������");
        selectedTableNameIndex = GUILayout.SelectionGrid(selectedTableNameIndex, tableNames, 1);
        GUILayout.Label("������");
        string[] availableColumnNames = columnNames[selectedTableNameIndex];
        selectedColumnNameIndex = GUILayout.SelectionGrid(selectedColumnNameIndex, availableColumnNames, 1);

        GUILayout.Label("ֵ��");
        valueInput = GUILayout.TextField(valueInput);
        if (GUILayout.Button("��ѯ����"))
        {
            // �������ѡ��Ĳ������в�ѯ
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
                // �����ѯ���
                //   print(selectedTableName + "��" + selectedColumnName + "=" + valueInput + "��Ϊ" + pairs[selectedColumnName]);
                var keys = SQLiteTools.GetValue(reader);

                foreach (var item in keys)
                {
                    //��ӡ���ݿ��ֶ�����  ��Ӧ�ֶ���ֵ
                    print("���ݿ��ֶ���Ϊ��" + item.Key + "  ��Ӧ����ֵΪ��" + item.Value);
                }

            });
        }
        if (GUILayout.Button("����������ѯȫ������"))
        {
            Getdb(obj =>
            {
                var reader = obj.SelectsWhere("_facebook_event_checkin_old_20230904",  new[] { "person_id", "event_id" }, new[] { ">", "=" }, new[] { "30000", "4387" });

                var keys = SQLiteTools.GetValue(reader);

                foreach (var item in keys)
                {
                    //��ӡ���ݿ��ֶ�����  ��Ӧ�ֶ���ֵ
                    print("���ݿ��ֶ���Ϊ��" + item.Key + "  ��Ӧ����ֵΪ��" + item.Value);
                }
            }
            );
        }
        if (GUILayout.Button("����A"))
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
                //    //��ӡ���ݿ��ֶ�����  ��Ӧ�ֶ���ֵ
                //    print("���ݿ��ֶ���Ϊ��" + item.Key + "  ��Ӧ����ֵΪ��" + item.Value);
                //}

                for (int i = 0; i < pairs.Length/100; i++)
                {
                    //�����ֵ�
                    foreach (var item in pairs[i])
                    {
                        //��ӡ���ݿ��ֶ�����  ��Ӧ�ֶ���ֵ
                        print("���ݿ��ֶ���Ϊ��" + item.Key + "  ��Ӧ����ֵΪ��" + item.Value);
                    }
                }
            }
                        );
        }
        //if (GUILayout.Button("�л����"))
        //{
        //    switch(currentTableName)
        //    {
        //        case "_facebook_event_checkin_old_20230904":
        //            currentTableName = "_get_fit_now_check_in_old_20230904";
        //            print("����л�Ϊ_get_fit_now_check_in_old_20230904");
        //            break;
        //        case "_get_fit_now_check_in_old_20230904":
        //            currentTableName = "_facebook_event_checkin_old_20230904";
        //            print("����л�Ϊ_facebook_event_checkin_old_20230904");
        //            break;
        //    }
        //}
        // ��ȡ��ǰ������ƶ�Ӧ����������
        //string[] currentDataTypes = tableDict[currentTableName];
        // ���ò�ѯ�����������ݱ�����ƺ���������

        if (GUILayout.Button("������"))
        {

            //����һ������  ��������UserInfo
            //�ֶ����� UID    ����Ϊ INTEGER
            // User Password  ����ΪSTRING
            //��LoginTime ���� ����ΪDATETIME
            Getdb(db => db.CreateTable("facebook_event_checkin_old_20230904", new[] { "person_id", "event_id", "event_name", "data" },
                new[] { "INTEGER", "INTEGER", "TEXT", "INTEGER" }));

        }

        if (GUILayout.Button("��������"))
        {
            //�����ֶ�Ϊ UID / User/ Password / LoginTime
            //��Ӧ���� 5201314 imdork 142536   ����ʱ��
            //����ʱ���ַ������룺
            //DateTime.Now.ToString("s")
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password", "LoginTime" }
            , new[] { "5201314", "imdork", "142536", DateTime.Now.ToString("s") }));

        }
        if (GUILayout.Button("��������2"))
        {
            Getdb(db => db.InsertIntoSpecific("UserInfo", new[] { "UID", "User", "Password", "LoginTime" }
           , new[] { "135703", "ddxj1", "56893s", DateTime.Now.ToString("s") }));
        }

        if (GUILayout.Button("ɾ������"))
        {

            //ɾ��UID ����50ȫ������
            //                      ����        �ж��ֶ�        �жϷ���        ��������
            Getdb(db => db.Delete("UserInfo", new[] { "UID" }, new[] { ">" }, new[] { "50" }));

        }

        if (GUILayout.Button("��������"))
        {
            //��ѯ���˺�UID ����50��ֵ ��ȫ��������������  ����������Ϊ123456
            Getdb(db => db.UpdateIntoSpecific("UserInfo", new[] { "UID" }, new[] { ">" },
               new[] { "50" }, new[] { "Password" }, new[] { "123456" }));
        }

        if (GUILayout.Button("��������2"))
        {
            Getdb(db => db.UpdateIntoSpecific("UserInfo",
               new[] { "UID" }, new[] { ">" }, new[] { "50" }, new[] { "Password" }, new[] { "142536" }));
        }

        

        if (GUILayout.Button("��ѯȫ�����ݿ�"))
        {
            Getdb
          (
             db =>
             {
                 //��ȡ���ȫ������
                 var reader = db.ReadFullTable("_facebook_event_checkin_old_20230904");
                 //��ȡȫ������
                 var pairs = SQLiteTools.GetValues(reader);
                 //�����ֵ�����
                 for (int i = 0; i < pairs.Length; i++)
                 {
                     //�����ֵ�
                     foreach (var item in pairs[i])
                     {
                         //��ӡ���ݿ��ֶ�����  ��Ӧ�ֶ���ֵ
                         print("���ݿ��ֶ���Ϊ��" + item.Key + "  ��Ӧ����ֵΪ��" + item.Value);
                     }
                 }
             }
          );


        }

      


    }
    /// <summary>
    /// ���ݿ�·��
    /// </summary>
    public string Path;

    private void Getdb(Action<DbAccess> action)
    {
        //Path���ݿ��ļ���һ����StreamingAssets�ļ����� ��д��·���ļ�����Ҫ��д.db��׺
        //�������ݿ��ȡ��
        SQLiteHelper helper = new SQLiteHelper(Path);
        //�����ݿ� �洢���ݿ������
        using (var db = helper.Open())
        {
            //�������ݿ�ί��
            action(db);
        }
        /*
         ��Ϊÿ��ʹ������ ��/ɾ/��/�� ����Ҫʹ�����Close�� 
         �ظ����룬д������̫�鷳 ��Ϊ���ݿ������ �̳���IDisposable�ӿ� ���ԣ�
         using���Զ��ر����ݿ����ӣ����������ֶ��ر����ݿ�
         */

    }

    private void Getdb2(Action<DbAccess> action)
    {
        //�������ݿ��ȡ��
        SQLiteHelper helper = new SQLiteHelper(Path);
        //�����ݿ� �洢���ݿ������
        var db = helper.Open();
        //�������ݿ�ί��
        action(db);
        //�ر����ݿ�
        db.CloseSqlConnection();

    }

    private void FindBool()
    {
        Getdb(db =>
        {
            //��ѯȫ������
            var reader = db.ReadFullTable("����");

            //��ȡ��һ������ ��һ�ε����� ��ȡ���ݿ��һ������
            while (SQLiteTools.Read(reader))
            {
                bool value = SQLiteTools.GetValue(reader, "�ֶ���", i => reader.GetBoolean(i));
            }

        });
    }

}
