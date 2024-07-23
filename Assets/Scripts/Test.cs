using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        int[] nums
            = new int[10] { 3, 4, 5, 6, 7,2, 1, 1, 2, 3};
        SortArray(nums,0,nums.Length-1);
        Debug.Log(nums);
    }
    public void SortArray(int[] nums,int left, int right)
    {
       if(left==right) return;
        int temp;

       int mid = left;
        int i = left + 1;
        int j = right;
        for (; i!=j;)
        {
            
            if((nums[i] < nums[mid])|| (nums[i] == nums[mid]))
            {
                i++;
            }
            else if(nums[j] > nums[mid])
            {
                j--;
            }
            else
            {
                temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++; j--;
            }
       }
        temp = nums[i];
        nums[i] = nums[mid];
        nums[mid] = temp;
        SortArray(nums,left,j);
       SortArray(nums, j+1, right);

        

    }
    public void Swap(int[] nums,int i,int j)
    {
        
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    //void start()
    // {
    //     int[] num = { 1, 2, 3 };
    //     Array.Sort(num);
    // }


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


    //private void Start()
    //{
    //    List<string> list = new List<string>() { "25", "哈3", "26", "花朵" };
    //    IEnumerator listEnumerator = list.GetEnumerator();
    //    while (listEnumerator.MoveNext())
    //    {
    //        Debug.Log(listEnumerator.Current);
    //    }
    //}


}

