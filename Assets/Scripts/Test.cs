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


    //private void Start()
    //{
    //    List<string> list = new List<string>() { "25", "��3", "26", "����" };
    //    IEnumerator listEnumerator = list.GetEnumerator();
    //    while (listEnumerator.MoveNext())
    //    {
    //        Debug.Log(listEnumerator.Current);
    //    }
    //}


}

