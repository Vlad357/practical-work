using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycles : MonoBehaviour
{

    private void Start()
    {
        print("____Задание 1____");
        SumaryEvenNumsRange(1, 9);
        print("____Задание 2____");
        SumaryEvenNumsInArray(new int[] {1,2,3,4,5,6,7,8,9});
        print("____Задание 3____");
        FindNumIdInArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5);
        print("____Задание 4____");
        int[] array = SortingBySelection(new int[]{ 5,3,6,8,9,21,7,0,4,2,1});
        PrintArray(array);
    }
    private void SumaryEvenNumsRange(int a, int b)
    {
        if(a > b)
        {
            return;
        }

        int sum = 0;

        for(int i = a; i < b+1; i++)
        {
            if(i%2!=0)
            {
                continue;
            }
            sum += i;
        }

        print(sum);
    }

    private void SumaryEvenNumsInArray(int[] a)
    {
        int sum = 0;

        foreach (int item in a)
        {
            if(item % 2 != 0)
            {
                continue;
            }
            sum += item;
        }

        print(sum);
    }

    private void FindNumIdInArray(int[] array, int a)
    {
        int b = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == a)
            {
                b = i;
            }
        }
        print(b);
    }

    private int[] SortingBySelection(int[] array)
    {
        int temp;
        for (int i = 0; i < array.Length; i++)
        {
            int id = i;

            for(int j = i; j < array.Length; j++)
            {
                if (array[id] > array[j])
                {
                    id = j;
                }
            }
            temp = array[id];
            array[id] = array[i];
            array[i] = temp;
        }
        return array;
    }

    private void PrintArray(int[] array)
    {
        string arrayStr = "";
        foreach(object obj in array)
        {
            arrayStr += $"{obj.ToString()}, ";
        }
        print(arrayStr);
    }
}
