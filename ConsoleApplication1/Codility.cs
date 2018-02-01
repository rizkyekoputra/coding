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

        public static int PassingCars(int[] A)
        {
            int comp = 0;
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0) comp++;
                if (A[i] == 1 && comp != 0) result += comp;
                if (result > 1000000000) return -1;
            }
            return result;
        }

        // this solution is based on the fact that there must be minimal average slice
        // of length 2 or 3 in all the minimal average slices.
        // we can use the slice of length 4 and 5 to prove it.
        // if there is a slice of length 4 is the minimal average slice, then
        // (a1+a2+a3+a4)/4 <= (a1+a2)/2 -> a3+a4 <= a1+a2
        // (a1+a2+a3+a4)/4 <= (a3+a4)/2 -> a1+a2 <= a3+a4
        // so a1+a2 = a3+a4 -> (a1+a2+a3+a4)/4 = (a1+a2)/2
        // if there is a slice of length 5 is the minimal average slice, then
        // we can use the same method to prove it.
        // it's easy to conclude that (a1+a2+a3+a4+a5)/5 = (a1+a2)/2 = (a3+a4+a5)/3s
        public static int MinAvgTwoSlice(int[] A)
        {
            //int N = A.Length;
            //int[] sum = new int[N + 1];

            //for (int i = 0; i < N; i++)
            //{
            //    sum[i + 1] = sum[i] + A[i];
            //}

            //int minTwoSum = int.MaxValue;
            //int minTwoStartIndex = 0;
            //for (int i = 0; i < N-1; i++)
            //{
            //    int twoSum = (sum[i + 2] - sum[i]);
            //    if (twoSum < minTwoSum)
            //    {
            //        minTwoSum = twoSum;
            //        minTwoStartIndex = i;
            //    }
            //}

            //int minThreeSum = int.MaxValue;
            //int minThreeStartIndex = 0;
            //for (int i = 0; i < N - 2; i++)
            //{
            //    int threeSum = (sum[i + 3] - sum[i]);
            //    if (threeSum < minThreeSum)
            //    {
            //        minThreeSum = threeSum;
            //        minThreeStartIndex = i;
            //    }
            //}

            //if (minTwoSum * 3 <= minThreeSum * 2)
            //{
            //    return minTwoStartIndex;
            //} else
            //{
            //    return minThreeStartIndex;
            //}

            int min_idx = 0;
            double min_value = double.MaxValue;

            for (int idx = 0; idx < A.Length - 1; idx++)
            {
                if ((A[idx] + A[idx + 1]) / 2.0 < min_value)
                {
                    min_idx = idx;
                    min_value = (A[idx] + A[idx + 1]) / 2.0;
                }
                if (idx < A.Length - 2 && (A[idx] + A[idx + 1] + A[idx + 2]) / 3.0 < min_value)
                {
                    min_idx = idx;
                    min_value = (A[idx] + A[idx + 1] + A[idx + 2]) / 3.0;
                }
            }
            return min_idx;
        }

        public static int[] GenomicRangeQuery(string S, int[] P, int[] Q) // "CAGCCTA"
        {
            int N = S.Length;
            int[] result = new int[P.Length];
            int[] posOfA = new int[N + 1];
            int[] posOfC = new int[N + 1];
            int[] posOfG = new int[N + 1];
            int[] posOfT = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                posOfA[i + 1] = S[i] == 'A' ? posOfA[i] + 1 : posOfA[i];
                posOfC[i + 1] = S[i] == 'C' ? posOfC[i] + 1 : posOfC[i];
                posOfG[i + 1] = S[i] == 'G' ? posOfG[i] + 1 : posOfG[i];
                posOfT[i + 1] = S[i] == 'T' ? posOfT[i] + 1 : posOfT[i];
            }

            for (int i = 0; i < P.Length; i++)
            {
                if ((posOfA[Q[i]+1] - posOfA[P[i]]) != 0)
                {
                    result[i] = 1;
                } else if ((posOfC[Q[i] + 1] - posOfC[P[i]]) != 0)
                {
                    result[i] = 2;
                } else if ((posOfG[Q[i] + 1] - posOfG[P[i]]) != 0)
                {
                    result[i] = 3;
                } else if ((posOfT[Q[i] + 1] - posOfT[P[i]]) != 0)
                {
                    result[i] = 4;
                }
            }
            return result;
        }

        public static int Triangle(int[] A)
        {
            if (A.Length < 3)
            {
                return 0;
            }

            Array.Sort(A);

            for (int i = 0; i < A.Length-2; i++)
            {
                if (A[i] > 0 && A[i] > A[i + 2] - A[i + 1])
                {
                    return 1;
                }
            }
            return 0;
        }

        //Quick Sort
        public static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        public static int partition(int[] arr, int low, int high) //10, 50, 5, 1, 9
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;
            return i + 1;
        }

        //MergeSort
        public static void mergeSort(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart < rightEnd)
            {
                int mid = (leftStart + rightEnd) / 2;
                mergeSort(arr, temp, leftStart, mid);
                mergeSort(arr, temp, mid + 1, rightEnd);
                mergeHalf(arr, temp, leftStart, mid, rightEnd);
            }

        }
        public static void mergeHalf(int[] arr, int[] temp, int leftStart, int mid, int rightEnd)
        {
            int leftEnd = mid;
            int rightStart = leftEnd + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while ((left <= leftEnd) && (right <= rightEnd))
            {
                if (arr[left] <= arr[right])
                {
                    temp[index++] = arr[left++];
                } else
                {
                    temp[index++] = arr[right++];
                }
            }
            while (left <= leftEnd)
            {
                temp[index++] = arr[left++];
            }
            while (right <= rightEnd)
            {
                temp[index++] = arr[right++];
            }
            for (int i = leftStart; i <= rightEnd; i++)
            {
                arr[i] = temp[i];
            }
        }

        public static int Brackets(string S)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '('  || S[i] == '{' || S[i] == '[')
                {
                    stack.Push(S[i]);
                } else
                {
                    if (stack.Count <= 0)
                    {
                        return 0;
                    }
                    var temp = stack.Pop();
                    if (temp == '(' && S[i] != ')')
                    {
                        return 0;
                    }
                    if (temp == '{' && S[i] != '}')
                    {
                        return 0;
                    }
                    if (temp == '[' && S[i] != ']')
                    {
                        return 0;
                    }
                }
            }
            if (stack.Count == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int EquiLeader(int[] A)
        {
            int candidate = -1;
            int candidate_count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (candidate == -1)
                {
                    candidate = A[i];
                    candidate_count++;
                } else
                {
                    if (A[i] != candidate)
                    {
                        candidate_count--;
                        if (candidate_count == 0) candidate = -1;
                    } else
                    {
                        candidate_count++;
                    }
                }
            }

            if (candidate_count == 0) return 0;

            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    count++;
                }
            }
            if (count < A.Length / 2) return 0;

            int result = 0;
            int left_count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate) left_count++;
                if ((left_count > (i + 1) / 2) && (count - left_count > (A.Length - i - 1) / 2)) result++;
                
            }

            return result;

            //100% correctness and 0% performance
            //int count1 = 0;
            //int count2 = 0;
            //int leader1 = -1;
            //int leader2 = -1;
            //int leaderSatu = -1;
            //int leaderDua = -1;
            //int result = 0;

            //for (int i = 0; i < A.Length; i++)
            //{
            //    for (int j = 0; j <= i ; j++)
            //    {
            //        for (int k = 0; k <= i; k++)
            //        {
            //            if (A[j] == A[k])
            //            {
            //                count1++;
            //            }
            //        }
            //        if (count1 > (i + 1) /2 && count1 > leader1) leaderSatu = A[j];
            //        count1 = 0;
            //    }

            //    for (int j = i+1; j < A.Length; j++)
            //    {
            //        for (int k = i+1; k < A.Length; k++)
            //        {
            //            if (A[j] == A[k])
            //            {
            //                count2++;
            //            }
            //        }
            //        if (count2 > (A.Length - i - 1) /2 && count2 > leader2) leaderDua = A[j];
            //        count2 = 0;
            //    }
            //    if (leaderSatu != -1 && leaderDua != -1 && leaderSatu == leaderDua) result++;
            //    leaderSatu = -1;
            //    leaderDua = -1;
            //}
            //return result;
        }
    }
}
