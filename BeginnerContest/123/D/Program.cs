﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static AtCoderTemplate.MyExtensions;
using static AtCoderTemplate.MyInputOutputs;
using static AtCoderTemplate.MyNumericFunctions;

namespace AtCoderTemplate {
    class Program {

        static void Main (string[] args) {
            var XYZK = ReadInts ();
            var X = XYZK[0];
            var Y = XYZK[1];
            var Z = XYZK[2];
            var K = XYZK[3];
            var A = ReadLongs ();
            var B = ReadLongs ();
            var C = ReadLongs ();

            var AplusB = A.SelectMany (a => B.Select (b => b + a)).OrderByDescending (x => x).Take (K);
            var AplusBplusC = AplusB.SelectMany (ab => C.Select (c => ab + c)).OrderByDescending (x => x).Take (K);
            PrintColomn (AplusBplusC);
        }
    }

    static class MyInputOutputs {
        /* Input & Output*/
        public static int ReadInt () {
            return int.Parse (Console.ReadLine ());
        }
        public static long ReadLong () {
            return long.Parse (Console.ReadLine ());
        }
        public static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        public static List<long> ReadLongs () {
            return Console.ReadLine ().Split (' ').Select (c => long.Parse (c)).ToList ();
        }
        public static List<List<int>> ReadIntColumns (int n) {
            /*
            入力例
            A1 B1
            A2 B2
            ...
            An Bn

            出力例
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var rows = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            var m = rows.FirstOrDefault ()?.Count () ?? 0;
            return Enumerable.Range (0, m).Select (i => rows.Select (items => items[i]).ToList ()).ToList ();
        }
        public static List<List<long>> ReadLongColumns (int n) {
            /*
            入力例
            A1 B1
            A2 B2
            ...
            An Bn

            出力例
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var rows = Enumerable.Range (0, n).Select (i => ReadLongs ()).ToList ();
            var m = rows.FirstOrDefault ()?.Count () ?? 0;
            return Enumerable.Range (0, m).Select (i => rows.Select (items => items[i]).ToList ()).ToList ();
        }
        public static void PrintRow<T> (IEnumerable<T> list) {
            /* 横ベクトルで表示
            A B C D ...
            */
            if (!list.IsEmpty ()) {
                Console.Write (list.First ());
                foreach (var item in list.Skip (1)) {
                    Console.Write ($" {item}");
                }
            }
            Console.Write ("\n");
        }
        public static void PrintColomn<T> (IEnumerable<T> list) {
            /* 縦ベクトルで表示
            A
            B
            C
            D
            ...
            */
            foreach (var item in list) {
                Console.WriteLine (item);
            }
        }
        public static void Print2DArray<T> (IEnumerable<IEnumerable<T>> sources) {
            foreach (var row in sources) {
                PrintRow (row);
            }
        }

        public static void PrintIf<T1, T2> (bool condition, T1 trueResult, T2 falseResult) {
            if (condition) {
                Console.WriteLine (trueResult);
            } else {
                Console.WriteLine (falseResult);
            }
        }
    }

    static class MyNumericFunctions {
        public static int Fact (int n) {
            return Enumerable.Range (1, n).Aggregate (1, ((i, k) => i * k));
        }
        public static int PermNum (int n, int m) {
            if (m > n) {
                return 0;
            }
            return Enumerable.Range (n - m, m + 1).Aggregate (1, ((i, k) => i * k));
        }
        public static int CombNum (int n, int m) {
            return PermNum (n, m) / Fact (m);
        }
        // 最大公約数 (m ≧ n)
        public static int GCD (int m, int n) {
            if (n == 0) {
                return m;
            } else {
                return GCD (n, m % n);
            }
        }
        // 最小公倍数 (m ≧ n)
        public static int LCM (int m, int n) {
            return GCD (m, n) / (m * n);
        }
    }

    static class MyExtensions {
        public static bool IsEmpty<T> (this IEnumerable<T> source) {
            return source.Count () == 0;
        }

        /// <summary>
        /// 一つ前の値との差を得る
        /// O(N * log(N))
        /// </summary>
        public static IEnumerable<int> Diff (this IEnumerable<int> source) {
            var list = source.ToList ();
            return Enumerable.Range (1, list.Count - 1)
                .Select (i => list[i] - list[i - 1]);
        }

        /// <summary>
        /// 累積和を得る
        /// O(N * log(N))
        /// </summary>
        public static IEnumerable<int> CumSum (this IEnumerable<int> source) {
            var list = source.ToList ();
            var result = new List<int> { list[0] };
            foreach (var i in Enumerable.Range (1, source.Count () - 1)) {
                result.Add (result[i - 1] + list[i]);
            }
            return result;
        }

        /// <summary>
        /// 昇順にソートしたインデックスを得る
        /// </summary>
        public static IEnumerable<int> SortIndex<T> (this IEnumerable<T> source) {
            return source
                .Select ((item, i) => new { Item = item, Index = i })
                .OrderBy (x => x.Item)
                .Select (x => x.Index);
        }
    }
}