﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Com.Com
{
    public static class ExtendMethod
    {

        /// <summary>
        /// 链表末尾添加值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ListNode AddNode(this ListNode node, int x)
        {
            if (node == null)
            {
                return new ListNode(x);
            }

            ListNode t = node;
            while (t.next != null)
            {
                t = t.next;
            }
            t.next = new ListNode(x);

            return node;
        }

        /// <summary>
        /// 链表末尾添加链表（两个链表合并）
        /// </summary>
        /// <param name="node"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ListNode AddListNode(this ListNode node, ListNode node2)
        {
            if (node == null)
            {
                return node2;
            }

            if (node2 == null)
            {
                return node;
            }

            ListNode t = node;
            while (t.next != null)
            {
                t = t.next;
            }
            t.next = node2;

            return node;
        }

        /// <summary>
        /// 链表长度。提交leetcode时这个方法不方便提交，只能用于测试时。
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public static int Length(this ListNode node)
        {
            if (node == null)
            {
                return 0;
            }
            int length = 0;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            return length;
        }

        /// <summary>
        /// 扩展方法。打印链表所有元素(用->连接)。可以处理为null时的情况
        /// </summary>
        /// <returns></returns>
        public static string ToConsoleString(this ListNode head)
        {
            if (head == null)
            {
                return "null";
            }
            string s = head.val.ToString();
            ListNode node = head;
            while (node.next != null)
            {
                node = node.next;
                s += "->" + node.val.ToString();
            }

            return s;
        }

        /// <summary>
        /// Array数组文字打印
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ToConsoleString(this Array arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append(arr.GetValue(i).ToString());
            }
            sb.Append("]");

            return sb.ToString();
        }

        public static string ToConsoleString<T>(this IList<T> arr)
        {
            if (arr == null || arr.Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < arr.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }

                //Console.WriteLine(typeof(T) is IList<object>);
                //Console.WriteLine(typeof(T) is IList<string>);
                //Console.WriteLine(typeof(T) is List<object>);
                //Console.WriteLine(typeof(T) is List<string>);
                //Console.WriteLine(typeof(T) == typeof(List<object>));
                //Console.WriteLine(typeof(T) == typeof(List<string>));
                //Console.WriteLine(typeof(T) == typeof(IList<object>));
                //Console.WriteLine(typeof(T) == typeof(IList<string>));   //true
                //Console.WriteLine(typeof(IList<object>).IsAssignableFrom(typeof(T)));
                //Console.WriteLine(typeof(IList<string>).IsAssignableFrom(typeof(T)));
                //Console.WriteLine(typeof(List<string>).IsAssignableFrom(typeof(T)));   //true

                if (typeof(T).Name == "IList`1")
                {
                    var list1 = arr[i] as IList<string>;
                    if (list1 != null)
                    {
                        sb.Append(list1.ToConsoleString());
                    }
                    else
                    {
                        var list2 = arr[i] as IList<int>;
                        sb.Append(list2.ToConsoleString());
                    }
                }
                else
                {
                    sb.Append(arr[i].ToString());
                }
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
