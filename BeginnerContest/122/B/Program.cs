﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTemplate {
    class Program {
        static void Main (string[] args) {
            var S = Console.ReadLine ();
            var N = S.Count ();
            foreach (var max in Enumerable.Range (1, N).Reverse ()) {
                var firsts = Enumerable.Range (0, N - max + 1);
                // Console.WriteLine (max);
                // PrintEnum (firsts);
                // foreach (var item in firsts.Select (i => String.Concat (S.Skip (i).Take (max)))) {
                //     Console.WriteLine (item);
                // }
                if (firsts.Any (i => S.Skip (i).Take (max).All (c => c == 'A' || c == 'C' || c == 'G' || c == 'T'))) {
                    Console.WriteLine (max);
                    return;
                }
            }
            Console.WriteLine (0);
            return;
        }
        /* Input & Output*/
        static int ReadInt () {
            return int.Parse (Console.ReadLine ());
        }
        static List<int> ReadInts () {
            return Console.ReadLine ().Split (' ').Select (c => int.Parse (c)).ToList ();
        }
        static List<List<int>> ReadColumns (int n) {
            /*
            入力例
            A1 B1
            A2 B2
            ...
            An Bn

            出力例
            [[A1,A2,...,An], [B1,B2,...,Bn]]
            */
            var seq = Enumerable.Range (0, n).Select (i => ReadInts ()).ToList ();
            return Enumerable.Range (0, seq.First ().Count ()).Select (i => seq.Select (items => items[i]).ToList ()).ToList ();
        }
        static void PrintEnum<T> (IEnumerable<T> list) {
            Console.Write (list.First ());
            foreach (var item in list.Skip (1)) {
                Console.Write ($" {item}");
            }
            Console.Write ("\n");
        }
        static void PrintLnEnum<T> (IEnumerable<T> list) {
            foreach (var item in list) {
                Console.WriteLine (item);
            }
        }

        /* Numeric Function */
        static int Fact (int n) {
            return Enumerable.Range (1, n).Aggregate (1, ((i, k) => i * k));
        }
        static int PermNum (int n, int m) {
            if (m > n) {
                return 0;
            }
            return Enumerable.Range (n - m, m + 1).Aggregate (1, ((i, k) => i * k));
        }
        static int CombNum (int n, int m) {
            return PermNum (n, m) / Fact (m);
        }
        // 最大公約数 (m ≧ n)
        static int GCD (int m, int n) {
            if (n == 0) {
                return m;
            } else {
                return GCD (n, m % n);
            }
        }
        // 最小公倍数 (m ≧ n)
        static int LCM (int m, int n) {
            return GCD (m, n) / (m * n);
        }

    }
}