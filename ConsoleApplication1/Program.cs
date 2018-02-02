using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

public class Solution
{
    class NodeBTS
    {
        public int value;
        public NodeBTS left;
        public NodeBTS right;
    }

    class Tree
    {
        public NodeBTS insert(NodeBTS root, int v)
        {
            if (root == null)
            {
                root = new NodeBTS();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }

        public void traverse(NodeBTS root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            Console.Write(root.value + " ");
            traverse(root.right);
        }
    }

    public class Node
    {
        public int index;
        public List<int> adjacents = new List<int>();
        public int distance = -1;

        public Node(int index)
        {
            this.index = index;
        }
    }

    public static int EDGE_DISTANCE = 6;

    public static int foo(int[] x, int a, int b, int i, int j)
    {
        int k = j;
        int ct = 0;
        while (k > i - 1)
        {
            if ((x[k] <= b) && (!(x[k] <= a)))
            {
                ct = ct + 1;
            }
            k = k - 1;
        }
        return ct;
    }

    static int stockPurchaseDay(int[] A, int xi)
    {
        Dictionary<int, int[]> dic = new Dictionary<int, int[]>();
        int jumlahDic = A.Length / 1000 + 1;
        for (int i = 0; i < jumlahDic; i++)
        {
            dic.Add(i, A.Skip(i*1000).Take(1000).ToArray());
        }

        int min = A.Min();
        if (xi < min)
        {
            return -1;
        }
        else
        {
            for (int i = jumlahDic; i > 0; i--)
            {
                if (xi >= dic[jumlahDic-1].Min())
                {
                    return Array.FindLastIndex(dic[jumlahDic - 1], x => x <= xi) + 1 + (jumlahDic - 1) * 1000;
                }
            }
        }
        return 0;
    }

    static void displayPathtoPrincess(int n, String[] grid)
    {
        char[,] gridInt = new char[n, n];
        int mPosX = 0;
        int mPosY = 0;
        int pPosX = 0;
        int pPosY = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                gridInt[i, j] = Convert.ToChar(grid[i][j]);
                if (gridInt[i, j] == 'm')
                {
                    mPosX = i;
                    mPosY = j;
                }
                if (gridInt[i, j] == 'p')
                {
                    pPosX = i;
                    pPosY = j;
                }
            }
        }

        while (pPosX != mPosX || pPosY != mPosY)
        {
            if ((pPosX - mPosX) > 0)
            {
                mPosX += 1;
                Console.WriteLine("DOWN");
            } else if ((pPosX - mPosX) < 0)
            {
                mPosX -= 1;
                Console.WriteLine("Up");
            } else if ((pPosY - mPosY) > 0)
            {
                mPosY += 1;
                Console.WriteLine("RIGHT");
            } else if ((pPosY - mPosY) < 0)
            {
                mPosY -= 1;
                Console.WriteLine("LEFT");
            }
        }
    }

    static double myPow(double x, int n)
    {
        long N = n;
        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }
        double ans = 1;
        for (long i = 0; i < N; i++)
            ans = ans * x;
        return ans;
    }

    static double Pangkat(double x, int y)
    {
        if (y == 0)
        {
            return 1;
        } else if (y > 0)
        {
            return x * Pangkat(x, y - 1);
        }
        return (1/(double)x * Pangkat(x, y + 1));
    }

    static double power(double x, int n)
    {
        if (n == 0)
        {
            return 1;
        }
        if (n > 0)
        {
            double temp = power(x, n / 2);
            if (n % 2 == 0)
            {
                return temp * temp;
            }
            else
            {
                return x * temp * temp;
            }
        }
        else
        {
            double temp = power(x, n / 2);
            if (n % 2 == 0)
            {
                return temp * temp;
            }
            else
            {
                return (1/x) * temp * temp;
            }
        }
    }

    static double myPow2(double x, int n)
    {
        int N = n;
        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }
        return power(x, N);
    }

    static double myPowOptimal(double x, int n)
    {
        if (n < 0)
        {
            x = 1 / x;
            n = -n;
        }
        double ans = 1;
        double current_product = x;
        for (int i = n;  i > 0;  i /= 2)
        {
            if ((i % 2) == 1)
            {
                ans = ans * current_product; 
            }
            current_product = current_product * current_product;
        }
        return ans;
    }

    static int Reverse(int x)
    {
        int result = 0;
        while (x != 0)
        {
            int tail = x % 10;
            int newResult = (result * 10) + tail;
            if ((newResult - tail) / 10 != result)
            {
                return 0;
            }
            result = newResult;
            x = x / 10;
        }
        return result;
    }

    static int[] TwoSum(int[] nums, int target)
    {
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    int temp = target - nums[i];
        //    for (int j = i+1; j < nums.Length; j++)
        //    {
        //        if (nums[j] == temp)
        //        {
        //            return new int[] { i, j };
        //        }
        //    }
        //}
        //return null;

        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }
            map.Add(nums[i], i);
        }
        return new int[] { 0, 0 };
    }

    static bool CekPalindrom(string word)
    {
        for (int i = 0; i < word.Length/2; i++)
        {
            if (word[i] != word[word.Length-1 - i])
            {
                return false;
            }
        }
        return true;
    }

    //Determine whether an integer is a palindrome. Do this without extra space
    //Some hints:
    //Could negative integers be palindromes? (ie, -1)
    //If you are thinking of converting the integer to string, note the restriction of using extra space.
    //You could also try reversing an integer.However, if you have solved the problem "Reverse Integer", you know that the reversed integer might overflow.How would you handle such case?
    //There is a more generic way of solving this problem.
    static bool IsPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            return false;
        }
        int revertedNumber = 0;
        while (x > revertedNumber)
        {
            revertedNumber = revertedNumber * 10 + x % 10;
            x = x / 10;
        }

        return x == revertedNumber || x == revertedNumber / 10;
    }

    //Given a sorted array, remove the duplicates in-place such that each element appear only once and return the new length.
    //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
    //Example:
    //Given nums = [1, 1, 2],
    //Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
    //It doesn't matter what you leave beyond the new length.
    static int RemoveDuplicates(int[] nums)
    {
        if (nums.Count() == 0)
        {
            return 0;
        }
        int count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[count])
            {
                count++;
                nums[count] = nums[i];
            }
        }
        return count + 1;
    }

    //Write a function that takes a string as input and returns the string reversed.
    //Example:
    //Given s = "hello", return "olleh".
    static string ReverseString(string s)
    {
        int n = s.Length;
        StringBuilder newString = new StringBuilder(s);
        for (int i = 0; i < n/2; i++)
        {
            char temp = newString[n - i - 1];
            newString[n-i-1] = newString[i];
            newString[i] = temp;
        }
        return newString.ToString();
    }

    //Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
    //If the last word does not exist, return 0.
    //Note: A word is defined as a character sequence consists of non-space characters only.
    //Example:
    //Input: "Hello World"
    //Output: 5
    static int LengthOfLastWord(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        int result = 0;
        for (int i = s.Length-1; i >= 0; i--)
        {
            if (s[i] != ' ')
            {
                result++;
            }
            else if (s[i] == ' ' && result != 0)
            {
                return result;
            }
        }
        return result;
    }


    //You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
    //You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    //Example
    //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    //Output: 7 -> 0 -> 8
    //Explanation: 342 + 465 = 807.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = new ListNode(0);
        ListNode curr = result, p = l1, q = l2;
        int carry = 0;

        while (p != null || q != null)
        {
            int x = p != null ? p.val : 0;
            int y = q != null ? q.val : 0;

            int temp = x + y + carry;
            carry = temp / 10;
            curr.next = new ListNode(temp % 10);
            curr = curr.next;

            if (p != null) p = p.next;
            if (q != null) q = q.next;
        }
        if (carry > 0)
        {
            curr.next = new ListNode(carry);
        }
        return result.next;
    }

    //Given a string, find the length of the longest substring without repeating characters.
    //Examples:
    //Given "abcabcbb", the answer is "abc", which the length is 3.
    //Given "bbbbb", the answer is "b", with the length of 1.
    //Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    static int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;
        Dictionary<char, int> charList = new Dictionary<char, int>();
        int result = 0, max = 0, j = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (!charList.ContainsKey(s[i]))
            {
                charList.Add(s[i], i);
            } else
            {
                j = (j < charList[s[i]] + 1) ? charList[s[i]] + 1 : j;
                charList[s[i]] = i;
            }
            max = i - j + 1;
            if (max > result) result = max;
        }
        return result;
    }

    //Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.
    //Example:
    //Input: 1->2->4, 1->3->4
    //Output: 1->1->2->3->4->4
    static ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        ListNode newNode = new ListNode(0);
        ListNode curr = newNode;
        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                curr.next = l1;
                l1 = l1.next;
            }
            else
            {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        curr.next = l1 == null ? l2 : l1;
        return newNode.next;
    }

    //Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.
    //Example:
    //Input: 1->2->4, 1->3->4
    //Output: 1->1->2->3->4->4
    static ListNode mergeTwoListsRecursive(ListNode l1, ListNode l2)
    {
        if (l1 == null)
        {
            return l2;
        }
        else if (l2 == null)
        {
            return l1;
        }
        else if (l1.val < l2.val)
        {
            l1.next = mergeTwoListsRecursive(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = mergeTwoListsRecursive(l1, l2.next);
            return l2;
        }

    }

    //There are two sorted arrays nums1 and nums2 of size m and n respectively.
    //Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
    //Example 1:
    //nums1 = [1, 3]
    //    nums2 = [2]
    //    The median is 2.0
    //Example 2:
    //nums1 = [1, 2]
    //    nums2 = [3, 4]
    //    The median is (2 + 3)/2 = 2.5
    static double findMedianSortedArrays(int[] nums1, int[] nums2)
    {
        List<int> newNums = new List<int>();
        int i = 0, j = 0;
        if (nums1.Length == nums2.Length)
        {
            return (double)(nums1[nums1.Length - 1] + nums2[0]) / 2;
        }
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                newNums.Add(nums1[i]);
                i++;
            } else
            {
                newNums.Add(nums2[j]);
                j++;
            }
        }
        if (i == nums1.Length)
        {
            newNums.AddRange(nums2.Skip(j).Take(nums2.Length - j));
        } else
        {
            newNums.AddRange(nums1.Skip(i).Take(nums1.Length - i));
        }
        int length = newNums.Count();
        return length % 2 == 0 ? (double)(newNums[length / 2] + newNums[length / 2 - 1])/2 : newNums[length / 2];
    }

    static void Main(string[] args)
    {
        //ListNode l1 = new ListNode(1);
        //l1.next = new ListNode(2);
        //l1.next.next = new ListNode(4);

        //ListNode l2 = new ListNode(1);
        //l2.next = new ListNode(3);
        //l2.next.next = new ListNode(4);

        int[] nums1 = { 1, 2 };
        int[] nums2 = { 3, 4 };
        //foreach (var item in Codility.GenomicRangeQuery("CAGCCTA", new int[] { 0,0,1 }, new int[] { 0,1,1 }))
        //{
        //    Console.WriteLine(item);
        //}

        Console.WriteLine(Codility.FloodDepth(new int[] { 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2 }));

        //BL SOAL 1
        //int[] A = { 4, 35, 80, 123, 12345, 44, 8, 5, 23, 22, 23, 44, 33, 22 };
        //int k = 20;
        //if (k >= A.Length) k = A.Length;
        //int maxLengthNumber = 0;
        //int colLength = A.Length % k == 0 ? A.Length / k : A.Length / k + 1;

        //foreach (var item in A)
        //{
        //    int temp = item.ToString().Length;
        //    if (maxLengthNumber < temp) maxLengthNumber = temp;
        //}

        //string border = "+" + new string('-', maxLengthNumber);

        //for (int col = 0; col < colLength; col++)
        //{
        //    for (int row = 0; row < k; row++)
        //    {
        //        Console.Write(border);
        //    }
        //    Console.Write('+');
        //    Console.WriteLine();
        //    for (int row = 0; row < k; row++)
        //    {
        //        int index = col * k + row;
        //        if (index == A.Length) break;
        //        int temp = A[index];
        //        int spaceLength = maxLengthNumber - temp.ToString().Length;
        //        Console.Write('|' + new string(' ', spaceLength) + temp);
        //    }
        //    Console.Write('|');
        //    Console.WriteLine();
        //}
        //for (int row = 0; row < (A.Length % k == 0 ? A.Length % k + k : A.Length % k) ; row++)
        //{
        //    Console.Write(border);
        //}
        //Console.Write('+');

        //BL SOAL 2
        //int[] A = { 5, 4, 4, 5, 0, 12 };
        //int tempNum1 = new Int32();
        //int tempNum2 = new Int32();

        //int result = 2;
        //int max = 2;

        //tempNum1 = A[0];
        //tempNum2 = A[1];

        //for (int i = 2; i < A.Length; i++)
        //{
        //    if(A[i] == tempNum1 || A[i] == tempNum2)
        //    {
        //        max += 1;
        //    } else
        //    {
        //        max = 2;
        //        tempNum1 = A[i - 1];
        //        tempNum2 = A[i];
        //    }
        //    if (max > result) result = max;
        //}
        //Console.WriteLine(result);

        //O(n^2)
        //for (int i = 0; i < A.Length; i++)
        //{
        //    for (int j = i+1; j < A.Length; j++)
        //   { 
        //        if (!temp)
        //        {
        //            tempNum = A[j];
        //            max += 1;
        //            temp = true;
        //        } else if (temp)
        //        {
        //            if (A[j] == A[i] || A[j] == tempNum)
        //            {
        //                max += 1;
        //            } else
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    if (result < max)
        //    {
        //        result = max;
        //        max = 1;
        //        temp = false;
        //    } else
        //    {
        //        temp = false;
        //        max = 1;
        //    }
        //}
        //Console.WriteLine(result);

        //BL SOAL 3
        //int[] A = { 1, 1, 1, 2, 2, 3, 4, 4, 3, 3, 2, 2, 1, 1, 2, 5 };
        //List<int> newA = new List<int>();
        //int temp = A[0];
        //newA.Add(temp);
        //int j = 1;

        //for (int i = 1; i < A.Length; i++)
        //{
        //    if (A[i] != temp)
        //    {
        //        newA.Add(A[i]);
        //        temp = A[i];
        //    }
        //}

        //int result = 2;

        //for (int i = 1; i < newA.Count - 1; i++)
        //{
        //    int p = newA[i - 1];
        //    int q = newA[i + 1];
        //    if ((newA[i] > p && newA[i] > q) || (newA[i] < p && newA[i] < q))
        //    {
        //        result += 1;
        //    }
        //}
        //Console.WriteLine(result);

        // x pangkat y
        //double x = Convert.ToDouble(Console.ReadLine());
        //double y = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine(Pangkat(x, y));


        //string word = "010101010011100";
        //int[] arr_word = new int[word.Length];
        //for (int i = 0; i < word.Length; i++)
        //{
        //    arr_word[i] = int.Pase(word[i].ToString());
        //}
        //Array.Sort(arr_word);
        //foreach(var item in arr_word)
        //{
        //    Console.WriteLine(item);
        //}
        //arr_word.ToString();
        //Console.WriteLine(arr_word);
        Console.Read();

        


        //int n = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[n];
        //for (int a_i = 0; a_i < n; a_i++)
        //{
        //    a[a_i] = Convert.ToInt32(Console.ReadLine());
        //    int[] temp = new int[a.Where(x => x != 0).Count()];
        //    Array.Copy(a, temp, temp.Length);
        //    Array.Sort(temp);
        //    if (temp.Length % 2 == 0)
        //    {
        //        float median = ((float)a[temp.Length / 2] + (float)a[temp.Length / 2 - 1]) / 2;
        //        Console.WriteLine(median.ToString("0.0"));
        //    } else
        //    {
        //        float median = (float)a[temp.Length / 2];
        //        Console.WriteLine(median.ToString("0.0"));
        //    }
        //}
        //int[] a = new int[5];
        //Console.WriteLine("before method: {0}" + string.Join(",", a));
        //myMethod(a);
        //Console.WriteLine("after method: {0}" + string.Join(",", a));
        //Console.Read();
    }

    
    public static void myMethod(int[] b)
    {
        b[0] = 5;
    }

    static bool cekSame(string expression)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(' || expression[i] == '{' || expression[i] == '[')
            {
                stack.Push(expression[i]);
            } else
            {
                if (!stack.Any())
                {
                    return false;
                }
                char c = stack.Pop();
                if (c == '(' && (expression[i] != ')'))
                {
                    return false;
                }
                if (c == '{' && (expression[i] != '}'))
                {
                    return false;
                }
                if (c == '[' && (expression[i] != ']'))
                {
                    return false;
                }
            }
        }
        if(stack.Count() == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    static int cekRegion(char[,] grid, int x, int y, char temp_c)
    {
        int flag = 1;
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return 0;
        }
        if (grid[x,y] == '#')
        {
            return 1;
        }
        if (grid[x, y] != '.' && grid[x, y] != '#' && grid[x, y] != temp_c)
        {
            grid[x, y] = '#';
            flag += -10000000;
            for (int row = x - 1; row <= x + 1; row++)
            {
                for (int col = y - 1; col <= y + 1; col++)
                {
                    if (row == x || col == y)
                    {
                        flag += cekRegion(grid, row, col, temp_c);
                    }
                }
            }
        }
        grid[x, y] = '#';
        for (int row = x - 1; row <= x + 1; row++)
        {
            for (int col = y - 1; col <= y + 1; col++)
            {
                if (row == x || col == y)
                {
                    flag += cekRegion(grid, row, col, temp_c);
                }
            }
        }
        
        return flag;
    }

    static int cekwordVer(char[,] grid, int x, int y, string w, int n, int sum)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return 0;
        }
        
        else if(n < w.Length)
        {
            if (grid[x, y] == '\0')
            {
                return 0;
            }
            if (grid[x, y] == w[n])
            {
                if (n == w.Length - 1)
                {
                    return 1;
                }
                grid[x, y] = '\0';
                for (int row = x - 1; row <= x + 1; row++)
                {
                    if (row != x)
                    {
                        sum += cekwordVer(grid, row, y, w, n + 1, 0);
                    }
                }
            }
        }
        return sum;
    }

    static int cekwordHor(char[,] grid, int x, int y, string w, int n, int sum)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return 0;
        }

        else if (n < w.Length)
        {
            if (grid[x, y] == '\0')
            {
                return 0;
            }
            if (grid[x, y] == w[n])
            {
                if (n == w.Length - 1)
                {
                    return 1;
                }
                grid[x, y] = '\0';
                for (int col = y - 1; col <= y + 1; col++)
                {
                    if (col != y)
                    {
                        sum += cekwordHor(grid, x, col, w, n + 1, 0);
                    }
                }
            }
        }
        return sum;
    }

    static int cekwordDia(char[,] grid, int x, int y, string w, int n, int sum)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return 0;
        }

        else if (n < w.Length)
        {
            if (grid[x, y] == '\0')
            {
                return 0;
            }
            if (grid[x, y] == w[n])
            {
                if (n == w.Length - 1)
                {
                    return 1;
                }
                grid[x, y] = '\0';
                sum += cekwordDia(grid, x - 1, y - 1, w, n + 1, 0);
                sum += cekwordDia(grid, x + 1, y + 1, w, n + 1, 0);
            }
        }
        return sum;
    }

    static int cekwordDia2(char[,] grid, int x, int y, string w, int n, int sum)
    {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return 0;
        }

        else if (n < w.Length)
        {
            if (grid[x, y] == '\0')
            {
                return 0;
            }
            if (grid[x, y] == w[n])
            {
                if (n == w.Length - 1)
                {
                    return 1;
                }
                grid[x, y] = '\0';
                sum += cekwordDia2(grid, x+1, y-1, w, n + 1, 0);
                sum += cekwordDia2(grid, x-1, y+1, w, n + 1, 0);
            }
        }
        return sum;
    }

    static int logarithm(int bases, int x)
    {
        return (int)(Math.Log(x) / Math.Log(bases));
    }

    static int largestPalindrome(int n)
    {
        for (int i = 100; i <= 999; i++)
        {
            Console.WriteLine(i);
            if(n % i == 0 && n / i >= 100 && n / i <= 999)
            {
                return n;
            }
        }

        int newN = n - 1; // 799997
        Console.WriteLine(newN);

        return largestPalindrome(firstPalindrome(newN));
    }

    static int firstPalindrome(int n)
    {
        //126533    335621
        List<int> number = new List<int>();
        while(n > 0)
        {
            number.Add(n % 10);
            n /= 10;
        }
        number.Reverse();

        if (number[2] > number[3])
        {
            number[2]--;
            number[3] = number[2]; //125533
            number[4] = number[1]; //125523
            number[5] = number[0]; //125521
        } else if (number[2] < number[3])
        {
            number[3] = number[2]; //335521
            number[4] = number[1]; //335531
            number[5] = number[0]; //335533
        } else if (number[2] == number[3])//335521
        {
            if (number[1] > number[4])//335521
            {
                number[2]--;
                if (number[2] == -1)
                { //129013
                    number[2] = 9;
                    number[1]--;
                }
                number[3] = number[2];
                number[4] = number[1];
                number[5] = number[0];
            } else if (number[1] < number[4]) //325531
            {
                number[4] = number[1];
                number[5] = number[0];
            } else if (number[1] == number[4])
            {
                if (number[0] > number[5]) //800000
                {
                    number[2]--;
                    if (number[2] == -1)
                    {
                        number[2] = 9;
                        number[1]--;
                        if (number[1] == -1)
                        {
                            number[1] = 9;
                            number[0]--;
                        }
                    }
                    number[3] = number[2];
                    number[4] = number[1];
                    number[5] = number[0];
                } else
                {
                    number[5] = number[0];
                }
            }
        }
        int total = 0;
        foreach (var item in number)
        {
            total = 10 * total + item;
        }
        return total;
    }

    static bool isPrime(int num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;
        for (int i = 3; i * i <= num; i += 2)
            if (num % i == 0) return false;
        return true;
    }

    static long primeFactor(long n)
    {
        while (n % 2 == 0)
        {
            n = n / 2;
        }
        if (n == 1)
        {
            return 2;
        }
        int i;
        long sesuatu = (long)Math.Sqrt(n);
        for (i = 3; i <= sesuatu; i = i + 2)
        {
            while (n % i == 0)
            {
                n = n / i;
            }
        }
        if (n > 2)
        {
            return n;
        }
        else
        {
            return i - 2;
        }
    }

    static long fibo(long n)
    {
        int a = 1;
        int b = 1;
        for (int i = 0; i < n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    public static void bfsShortestReach(Node[] node, int s)
    {
        Queue<Node> queue = new Queue<Node>();
        node[s].distance = 0;
        queue.Enqueue(node[s]);
        while (queue.Any())
        {
            Node head = queue.Dequeue();
            foreach (var adjacent in head.adjacents)
            {
                if(node[adjacent].distance == -1)
                {
                    node[adjacent].distance = head.distance + EDGE_DISTANCE;
                    queue.Enqueue(node[adjacent]);
                }
            }
        }
    }

    public static int soal1(int[] arr)
    {
        int i = 0;
        int s = 0;
        while (i < arr.Length) {
            s += arr[i];
            i += 2;
        }
        return s;
    }

    
}