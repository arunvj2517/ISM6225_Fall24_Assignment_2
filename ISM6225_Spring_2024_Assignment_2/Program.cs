using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

         // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

             // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

           // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

           // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

           // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

           // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Identified Edge Case: Before sorting, we could remove duplicates using from the array.
                nums = nums.Distinct().ToArray();  // Using inbuilt function to remove duplicates.

                // Sort the array in ascending order to correctly find missing numbers between elements
                Array.Sort(nums);
                List<int> missingNumbers = new List<int>();
                for (int i = 0; i< nums.Length - 1; i++)
                {
                    // Check if the difference between consecutive elements is greater than 1
                    if (nums[i+1] - nums[i] > 1)
                    {
                        // If so, add the missing numbers to the list
                        for (int j = nums[i] + 1; j < nums[i + 1]; j++)
                        {
                            missingNumbers.Add(j);
                        }
                        
                    }
                }
                return missingNumbers; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Identified Edge case: Empty array
                if (nums.Length == 0) return new int[0];

                //if not empty below code gets executed
                int[] result = new int[nums.Length];
                int index = 0;
                for (int i = 0;i< nums.Length;i++)
                {
                    // Check if the number is even
                    if (nums[i]%2 == 0)
                    {
                        result[index++] = nums[i];

                    }
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the number is odd
                    if (nums[i] % 2 != 0)
                    {
                        result[index++] = nums[i];

                    }
                }
                return result; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Identified Edge case: No solution found for which I am returning [-1,-1] after the for loop.
            //  Edge case: If the array has only one element then we cannot find two numbers that add up to the target. In order to cover that added the below 
            //return Statement based in the length of the array.
            if (nums.Length < 2) return new int[] { -1, -1 };

            try
            {
                // iterate through the array to find two numbers that add up to the target
                for (int i=0; i < nums.Length; i++)
                {
                    // iterate a seccond loop starting from the next index of the first loop to find the second number
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                      
                    }
                }
                return new int[] { -1, -1 }; // Return -1 if no solution found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            /*try
            {
                Array.Sort(nums);
                return nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];

               
            }
            catch (Exception)
            {
                throw;
            }*/

            // Above is the correct solution but below is the optimized solution as per suggestion of copilot.

            //Identified Edge Case 1: Above solution does not work for negative numbers.We have to consider the posibility of negative numbers.

            // Identified Edge case 2: If there are fewer than three elements, we can't calculate the maximum product of three numbers.

            if (nums.Length < 3) return -1; // returning -1 if there are fewer than three elements.

            try
            {
                // Initialize the three largest and two smallest values
                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;

                foreach (int num in nums)
                {
                    // Update the three largest values
                    if (num > max1)
                    {
                        max3 = max2;
                        max2 = max1;
                        max1 = num;
                    }
                    else if (num > max2)
                    {
                        max3 = max2;
                        max2 = num;
                    }
                    else if (num > max3)
                    {
                        max3 = num;
                    }

                    // Update the two smallest values
                    if (num < min1)
                    {
                        min2 = min1;
                        min1 = num;
                    }
                    else if (num < min2)
                    {
                        min2 = num;
                    }
                }

                // The maximum product is either the product of the top three largest numbers
                // or the product of the two smallest (negative) numbers and the largest positive number
                return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            // Edge case Identified: Negative numbers cannot be converted to binary hence we do that checking before proceeding to actual logic.
            if (decimalNumber < 0) return "Negative numbers cannot be converted to binary.";

            try
            {
                if (decimalNumber == 0)
                    return "0"; // this special case was suggested by copilot

                StringBuilder binaryResult = new StringBuilder();

                while (decimalNumber > 0)
                {
                    binaryResult.Insert(0, decimalNumber % 2); // Prepend binary digit (0 or 1)
                    decimalNumber /= 2; // Divide number by 2
                }

                return binaryResult.ToString();
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            //Edge cases Identified: If the array is empty or has only one element, we cannot find the minimum.
            // Edge case: Empty array
            if (nums.Length == 0) return -1; // returning -1 if the array is empty.

            // Edge case: Array with one element
            if (nums.Length == 1) return nums[0];

            try
            {
                int leftMost = 0;
                int rightMost = nums.Length - 1;

                while (leftMost < rightMost)
                {
                    int mid = leftMost + (rightMost - leftMost) / 2;

                    if (nums[mid] > nums[rightMost])
                    {
                        // Minimum is in the right half
                        leftMost = mid + 1;
                    }
                    else
                    {
                        // Minimum is in the left half including mid
                        rightMost = mid;
                    }
                }
                return nums[leftMost]; 
            }
    catch (Exception)
    {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Initial approach is to convert the number to a string and check if it is equal to its reverse but as per copilot suggestion I am trying below approach 
            try
            {
                // Edge case Identified : Negative numbers are not palindrome
                if (x < 0) return false; // added  as per suggestion of copilot to handle negative numbers.

                // Edge case Identified: Single-digit numbers are always palindromes
                if (x >= 0 && x < 10) return true;


                int original = x;
                int reversed = 0;

                // Reversing the integer by extracting digits from the end
                while (x > 0)
                {
                    int digit = x % 10;  // Get the last digit 
                    reversed = reversed * 10 + digit; // Append the digit to the reversed number
                    x /= 10;  // Remove the last digit from x
                }

                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
            }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            //Edge case Identified: Negative numbers are not valid inputs for Fibonacci sequence.
            if (n < 0) return -1; // returning -1 for negative numbers.
            // Edge case Identified: If n is 0 or 1, we can return the result directly.
            if (n == 0) return 0;
            if (n == 1) return 1;
            try
            { 

                int a = 0, b = 1, sum = 0;

                for (int i = 2; i <= n; i++)
                {
                    sum = a + b; // Calculate the next Fibonacci number
                    a = b;  // Move forward in the sequence
                    b = sum;
                }

                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
