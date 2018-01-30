using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Codility
    {
        public static int BinnaryGap(int N)
        {
            int result = 0;
            int temp = 0;
            int i = 0;
            string bit = Convert.ToString(N, 2);
            while (i < bit.Length)
            {
                if (bit[i] == '1')
                {
                    result = temp > result ? temp : result;
                    temp = 0;
                } else
                {
                    temp++;
                }
                i++;
            }
            return result;
        }

        public static int OddOccurrencesInArray(int[] A)
        {
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result ^= A[i];
            }
            return result;
        }

        public static int[] CyclicRotation(int[] A, int K)
        {
            int[] result = new int[A.Length];
            K = K % A.Length;
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = A[(A.Length + i - K) % A.Length];
            }
            return result;
        }

        public static int TapeEquilibrium(int[] A)
        {
            int sum = 0;
            int result = 9999999;
            int max = 0;
            int curr = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
            }
            for (int i = 1; i < A.Length; i++)
            {
                max = Math.Abs(curr - (sum - curr)) ;
                result = result < max ? result : max;
                curr += A[i];
            }
            return result;
        }

        public static int FrogJmp(int X, int Y, int D)
        {
            int result = (Y - X) / D;
            if ((Y - X) % D != 0)
            {
                result++;
            }
            return result;
        }

        public static int PermMissingElem(int[] A)
        {
            int N = A.Length + 1;
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            for (int i = 0; i < A.Length; i++)
            {
                map.Add(A[i], true);
            }
            for (int i = 1; i <= N; i++)
            {
                if (!map.ContainsKey(i))
                {
                    return i;
                }
            }
            return 1;
        }

        public static int PermCheck(int[] A)
        {
            int N = A.Length;
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            for (int i = 0; i < A.Length; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    return 0;
                }
                map.Add(A[i], true);
            }
            for (int i = 1; i <= N; i++)
            {
                if (!map.ContainsKey(i))
                {
                    return 0;
                }
            }
            return 1;

            //bool[] seen = new bool[A.Length + 1];

            //// repeated elements
            //for (int i = 0; i < A.Length; i++)
            //{
            //    if (A[i] < 1 || A[i] > A.Length) return 0;
            //    if (seen[A[i]] == true) return 0;
            //    else seen[A[i]] = true;
            //}

            //return 1;
        }

        public static int FrogRiverOne(int X, int[] A)
        {
            HashSet<int> map = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= X) map.Add(A[i]);
                if (map.Count == X) return i;
            }
            return -1;
        }

        public static int MissingInteger(int[] A)
        {
            int N = A.Length;
            HashSet<int> map = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= N) map.Add(A[i]);
            }
            for (int i = 1; i <= map.Count + 1; i++)
            {
                if (!map.Contains(i)) return i;
            }
            return 1;
        }

        public static int[] MaxCounters(int N, int[] A)
        {
            int[] result = new int[N];
            int max = 0;
            int lastMax = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N)
                {
                    lastMax = max;
                } else
                {
                    result[A[i] - 1] = Math.Max(result[A[i] - 1], lastMax);
                    result[A[i] - 1]++;
                    max = max > result[A[i] - 1] ? max : result[A[i] - 1];
                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Max(result[i], lastMax);
            }
            return result;
        }

        public static int CountDiv(int A, int B, int K)
        {
            return (B / K) - (A / K) + (A % K == 0 ? 1 : 0);
        }
    }
}
