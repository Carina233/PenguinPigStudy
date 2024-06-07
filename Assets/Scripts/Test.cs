using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    /// <summary>
    /// 静态
    /// </summary>
    // 静态字段
    //private static int staticValue;

    //// 静态构造函数
    //static Test()
    //{
    //    // 初始化静态字段
    //    staticValue = 42;
    //    Debug.Log("静态构造函数被调用，staticValue 初始化为 " + staticValue);
    //}

    //void Start()
    //{
    //    Debug.Log("Start 方法被调用，staticValue 的值为 " + staticValue);
    //}


    //字符拼接优化
    //void Start()
    //{
    //    // 使用 StringBuilder 进行字符串拼接
    //    StringBuilder sb = new StringBuilder();

    //    for (int i = 0; i < 100; i++)
    //    {
    //        sb.Append("This is line number ");
    //        sb.Append(i);
    //        sb.Append("\n");
    //    }

    //    // 将 StringBuilder 转换为字符串
    //    string result = sb.ToString();
    //    Debug.Log(result);
    //}


    private void Start()
    {
        List<string> list = new List<string>() { "25", "哈3", "26", "花朵" };
        IEnumerator listEnumerator = list.GetEnumerator();
        while (listEnumerator.MoveNext())
        {
            Debug.Log(listEnumerator.Current);
        }
    }


}

