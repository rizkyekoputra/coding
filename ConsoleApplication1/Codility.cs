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

        public static int NumberSolitaire(int[] A)
        {
            int[] dp = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                dp[i] = int.MinValue;
            }

            dp[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                int max = dp[i - 1];
                int loop = 1;
                while (loop <= 6 && i - loop >= 0)
                {
                    max = Math.Max(dp[i - loop], max);
                    loop++;
                }
                dp[i] = max + A[i];
            }
            return dp[A.Length - 1];
        }

        public static int TieRopes(int K, int[] A)
        {
            int temp = 0;
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                temp += A[i];
                if (temp >= K)
                {
                    count++;
                    temp = 0;
                }
            }
            return count;
        }

        public static int AbsDistinct(int[] A)
        {
            HashSet<int> map = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                int temp = A[i] < 0 ? A[i] * -1 : A[i];
                if (!map.Contains(temp))
                {
                    map.Add(temp);
                }
            }
            return map.Count;
        }

        public static int FloodDepth(int[] A)
        {
            int maxLeft = 0;
            int bottom = 100000000;
            int result = 0;
            int depth = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > maxLeft)
                {
                    depth = maxLeft - bottom > 0 ? maxLeft - bottom : 0;
                    result = Math.Max(result, depth);
                    maxLeft = A[i];
                    bottom = 100000000;
                }
                bottom = Math.Min(bottom, A[i]);
                depth = A[i] - bottom;
                result = Math.Max(result, depth);
            }
            return result;
        }

        public static int Distinct(int[] A)
        {
            HashSet<int> map = new HashSet<int>();
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (!map.Contains(A[i]))
                {
                    map.Add(A[i]);
                    count++;
                }
            }
            return count;
        }

        public static int MaxProductOfThree(int[] A)
        {
            Array.Sort(A);
            int N = A.Length;

            return Math.Max(A[N - 1] * A[N - 2] * A[N - 3], A[0] * A[1] * A[N - 1]);
        }

        public static int NumberOfDiscIntersections(int[] A)
        {
            long N = A.Length;
            if (N < 2) return 0;
            long count = N * (N - 1) / 2;
            long[] right = new long[N];
            long[] left = new long[N];

            for (int i = 0; i < A.Length; i++)
            {
                right[i] = (long)i + A[i];
                left[i] = (long)i - A[i];
            }

            Array.Sort(right);
            Array.Sort(left);
            int j = 0;
            for (int i = 0; i < N; i++)
            {
                for (; j < N; j++)
                {
                    if (left[j] > right[i])
                    {
                        count -= N - j;
                        break;
                    }
                }
                if (j == N) break;
            }
            if (count > 10E6)
            {
                return -1;
            } else
            {
                return (int)count;
            }
        }

        public static int StoneWall(int[] H)
        {
            Stack<int> stack = new Stack<int>();
            int count = 0;

            for (int i = 0; i < H.Length; i++)
            {
                while(stack.Count > 0 && stack.Peek() > H[i])
                {
                    stack.Pop();
                }
                if (stack.Count != 0 && stack.Peek() == H[i])
                {
                    continue;
                } else
                {
                    count++;
                    stack.Push(H[i]);
                }
            }
            return count;
        }

        public static int Fish(int[] A, int[] B)
        {
            int survival = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (B[i] == 1)
                {
                    stack.Push(A[i]);
                }
                else
                {
                    while(stack.Count != 0)
                    {
                        if (A[i] < stack.Peek())
                        {
                            break;
                        } else
                        {
                            stack.Pop();
                        }
                    }
                    if (stack.Count == 0) survival++;
                }
            }
            survival += stack.Count;
            return survival;
        }

        //that, given a zero-indexed array A consisting of N non-negative integers, returns the minimum distance between two distinct elements of A.
        //For example, given array A such that:
        //  A[0] = 8
        //  A[1] = 24
        //  A[2] = 3
        //  A[3] = 20
        //  A[4] = 1
        //  A[5] = 17
        //the function should return 2, because(A[2] − A[4]) = 2 and no other two distinct elements of A have a smaller distance.
        //Given array A such that:
        //  A[0] = 7
        //  A[1] = 21
        //  A[2] = 3
        //  A[3] = 42
        //  A[4] = 3
        //  A[5] = 7
        //the function should return 0, because A[0] − A[5] = A[2] − A[4] = 0 and it is the smallest possible distance between two distinct elements of the array.
        public static int soal1(int[] A)
        {
            Array.Sort(A);
            int min = int.MaxValue;
            for (int i = 0; i < A.Length - 1; i++)
            {
                min = Math.Min(min, Math.Abs(A[i] - A[i + 1]));
            }
            return min;
        }

        //Everyone has a favorite number.Jacob's favorite number is X and Jayden's favorite number is Y.A non-empty zero-indexed array A consisting of N integers is given.Jacob and Jayden are interested in occurrences of their favorite numbers X and Y in array A.They are looking for the longest leading fragment (prefix) of array A in which there is an equal number of occurrences of X and Y.More formally, they are looking for the largest P, such that 0 ≤ P<N and the number of occurrences of X equals the number of occurrences of Y in the sequence A[0], A[1], ..., A[P].
        //For example, consider X = 7, Y = 42 and the following array A:
        //A[0] = 6
        //A[1] = 42
        //A[2] = 11
        //A[3] = 7
        //A[4] = 1
        //A[5] = 42
        //There are three prefixes of array A containing the same number of occurrences of X and Y:
        //P = 0: A[0..0] = [6] contains neither 7 nor 42;
        //P = 3: A[0..3] = [6, 42, 11, 7]
        //        contains one 7 and one 42;
        //        P = 4: A[0..4] = [6, 42, 11, 7, 1]
        //        also contains one 7 and one 42.
        //The largest value of P we are looking for is 4, because the only longer corresponding prefix A[0..5] contains one 7 and two 42s.
        //For another example, given
        //    X = 6, Y = 13
        //    A[0] = 13
        //    A[1] = 13
        //    A[2] = 1
        //    A[3] = 6
        //the function should return −1, bacause there is no prefix containing the same number of occurrences of 6 and 13.
        public static int soal2(int X, int Y, int[] A)
        {
            int N = A.Length;
            int result = -1;
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                    nX += 1;
                else if (A[i] == Y)
                    nY += 1;
                if (nX == nY && nX != 0)
                    result = i;
            }
            return result;
        }

        //A six-sided die is a small cube with a different number of pips on each face(side), ranging from 1 to 6. On any two opposite sides of the cube, the number of pips adds up to 7; that is, there are three pairs of opposite sides: 1 and 6, 2 and 5, and 3 and 4.
        //There are N dice lying on a table, each showing the pips on its top face.In one move, you can take one die and rotate it to an adjacent face.For example, you can rotate a die that shows 1 so that it shows 2, 3, 4 or 5. However, it cannot show 6 in a single move, because the faces with one pip and six pips visible are on opposite sides rather than adjacent.
        //You want to show the same number of pips on the top faces of all N dice.Given that each of the dice can be moved multiple times, count the minimum number of moves needed to get equal faces.
        //Write a function:
        //class Solution { public int solution(int[] A); }
        //        that, given a zero-indexed array A consisting of N integers describing the number of pips(from 1 to 6) shown on each die's top face, returns the minimum number of moves necessary for each die to show the same number of pips.
        //For example, given:
        //A = [1, 2, 3], the function should return 2, as you can pick the first two dice and rotate each of them in one move so that they all show three pips on the top face.Notice that you can also pick any other pair of dice in this case.
        //A = [1, 1, 6], the function should also return 2. The only optimal answer is to rotate the last die so that it shows one pip.It is necessary to use two rotations to achieve this.
        //A = [1, 6, 2, 3], the function should return 3. For instance, you can make all dice show 2: just rotate each die which is not showing 2 (and notice that for each die you can do this in one move).
        //Assume that:
        public static int soal3 (int[] A)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (!map.ContainsKey(A[i]))
                {
                    map.Add(A[i], 1);
                } else
                {
                    map[A[i]]++;
                }
            }

            int result = int.MaxValue;
            int temp = 0;

            foreach (var item in map)
            {
                int finalPip = item.Key;
                foreach (var value in map)
                {
                    if (value.Key != finalPip)
                    {
                        if (7 - value.Key == finalPip)
                        {
                            temp += 2;
                        }
                        else
                        {
                            temp++;
                        }
                    }
                }
                result = Math.Min(result, temp);
                temp = 0;
            }
            

            return result;
        }

        //For example, given S = "(()(())())", the function should return 1 and given S = "())", the function should return 0, as explained above.
        public static int nesting(string S)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    stack.Push('(');
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return 0;
                    }
                    stack.Pop();
                }
            }
            if (stack.Count == 0) return 1;
            else return 0;
        }

        //A zero-indexed array A consisting of N integers is given.The dominator of array A is the value that occurs in more than half of the elements of A.
        //For example, consider array A such that
        //A[0] = 3    A[1] = 4    A[2] = 3
        //A[3] = 2    A[4] = 3    A[5] = -1
        //A[6] = 3    A[7] = 3
        //The dominator of A is 3 because it occurs in 5 out of 8 elements of A (namely in those with indices 0, 2, 4, 6 and 7) and 5 is more than a half of 8.
        public static int dominator(int[] A)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!dic.ContainsKey(A[i]))
                {
                    dic.Add(A[i], 1);
                } else
                {
                    dic[A[i]]++;
                }
            }
            int maxCount = 0;
            int valueMaxCount = -1;
            foreach (var item in dic)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    valueMaxCount = item.Key;
                }
            }
            if (maxCount > A.Length / 2)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] == valueMaxCount) return i;
                }
            }
            return -1;
        }
    }
}
