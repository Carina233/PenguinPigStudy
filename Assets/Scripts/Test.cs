using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    /// <summary>
    /// ��̬
    /// </summary>
    // ��̬�ֶ�
    //private static int staticValue;

    //// ��̬���캯��
    //static Test()
    //{
    //    // ��ʼ����̬�ֶ�
    //    staticValue = 42;
    //    Debug.Log("��̬���캯�������ã�staticValue ��ʼ��Ϊ " + staticValue);
    //}

    //void Start()
    //{
    //    Debug.Log("Start ���������ã�staticValue ��ֵΪ " + staticValue);
    //}


    //�ַ�ƴ���Ż�
    //void Start()
    //{
    //    // ʹ�� StringBuilder �����ַ���ƴ��
    //    StringBuilder sb = new StringBuilder();

    //    for (int i = 0; i < 100; i++)
    //    {
    //        sb.Append("This is line number ");
    //        sb.Append(i);
    //        sb.Append("\n");
    //    }

    //    // �� StringBuilder ת��Ϊ�ַ���
    //    string result = sb.ToString();
    //    Debug.Log(result);
    //}


    private void Start()
    {
        List<string> list = new List<string>() { "25", "��3", "26", "����" };
        IEnumerator listEnumerator = list.GetEnumerator();
        while (listEnumerator.MoveNext())
        {
            Debug.Log(listEnumerator.Current);
        }
    }


}

