using System.Collections;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.Intrinsics.X86;
using static Assignment11.ListGenerator;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region Element Operators

            #region 1. Get first Product out of Stock

            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            #endregion

            #region 3. Retrieve the second number greater than 5

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #endregion

            #region Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array

            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #region 2. Return a list of customers and how many orders each has.

            #endregion

            #region 3. Return a list of categories and how many products each has

            #endregion

            #region 4. Get the total of the numbers in an array.

            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txtinto Array of String First).

            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            #endregion

            #region 9. Get the total units in stock for each product category. (missed)

            #endregion

            #region 10. Get the cheapest price among each category's products (missed)

            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let) (missed)

            #endregion

            #region 12. Get the most expensive price among each category's products. (missed)

            #endregion

            #region 13. Get the products with the most expensive price in each category. (missed)

            #endregion

            #region 14. Get the average price of each category's products. (missed)

            #endregion

            #endregion

            #region Set Operators

            #region 1. Find the unique Category names from Product List

            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customernames.

            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.

            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            #endregion

            #endregion

            #region Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington

            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.

            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #region 4.Get the elements of the array starting from the first element divisible by 3.

            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #region 5. Get the elements of the array starting from the first element less than its position.

            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #endregion

            #endregion

            #region Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            #endregion

            #endregion

            #region Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5

            List<int> Numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            #endregion

            #region 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input

            #endregion

            #region 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            
            string[] arr = { "from", "salt", "earn", " last", "near", "form" };
            
            #endregion

            #endregion
        }
    }
}
