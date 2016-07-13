using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Sort<T> where T : Card
{
    //Perform Bubble Sort on List and return sorted List
    public static List<T> SortList (List<T> list)
    {
        int x = list.Count - 1;
        while(x > 0)
        {
            int swap = 0;
            for (int y = 0; y < x; y++)
            {
                if (list[y] > list[y+1])
                {
                    T temp = list[y];
                    list[y] = list[y + 1];
                    list[y + 1] = temp;
                    swap = y;
                }
            }
            x = swap;
        }
        return list;
    }
}