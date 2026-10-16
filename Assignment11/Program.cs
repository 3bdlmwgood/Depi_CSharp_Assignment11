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

            var firstProductOutOfStock = ProductsList.First(p => p.UnitsInStock == 0);
            Console.WriteLine($"First Product Out Of Stick: {firstProductOutOfStock.ProductName}");

            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            var firstExpensiveProduct = ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"First product with price > 1000: {firstExpensiveProduct?.ProductName ?? "None"}");

            #endregion

            #region 3. Retrieve the second number greater than 5

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNumberGreaterThan5 = arr.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number greater than 5: {secondNumberGreaterThan5}");

            #endregion

            #endregion

            #region Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine($"Number of odd numbers: {numbers.Count(n => n % 2 == 1)}");

            #endregion

            #region 2. Return a list of customers and how many orders each has.

            var customerOrderCounts = CustomersList.Select(
                c => new { c.CustomerName, OrderCount = c.Orders.Count() });

            foreach (var item in customerOrderCounts)
                Console.WriteLine($"{item.CustomerName}: {item.OrderCount} orders");

            #endregion

            #region 3. Return a list of categories and how many products each has

            var categoryCounts = ProductsList.GroupBy(p => p.Category)
               .Select(g => new { Category = g.Key, ProductCount = g.Count() });

            foreach (var item in categoryCounts)
                Console.WriteLine($"{item.Category} Category: {item.ProductCount} products");

            #endregion

            #region 4. Get the total of the numbers in an array.

            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");

            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            string[] dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");
            Console.WriteLine($"Total dictionary characters: {dictionaryWords.Sum(word => word.Length)}");

            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            Console.WriteLine($"Shortest word length: {dictionaryWords.Min(word => word.Length)}");

            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txtinto Array of String First).

            Console.WriteLine($"Longest word length: {dictionaryWords.Max(word => word.Length)}");

            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            Console.WriteLine($"Average word length: {dictionaryWords.Average(word => word.Length)}");

            #endregion

            #region 9. Get the total units in stock for each product category. (missed)

            var unitsByCategory = ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });

            foreach (var item in unitsByCategory)
                Console.WriteLine($"{item.Category}: {item.TotalUnits} units in stock");

            #endregion

            #region 10. Get the cheapest price among each category's products (missed)

            var cheapestPriceByCategory = ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });

            foreach (var item in cheapestPriceByCategory)
                Console.WriteLine($"{item.Category}: cheapest price = {item.CheapestPrice}");

            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let) (missed)

            var cheapestProductsByCategory =
                from p in ProductsList
                group p by p.Category into productGroup
                let cheapestPrice = productGroup.Min(p => p.UnitPrice)
                select new
                {
                    Category = productGroup.Key,
                    Products = productGroup.Where(p => p.UnitPrice == cheapestPrice)
                };

            foreach (var item in cheapestProductsByCategory)
            {
                Console.WriteLine($"{item.Category} - cheapest product(s):");
                foreach (var product in item.Products)
                    Console.WriteLine($"  {product.ProductName} - {product.UnitPrice}");
            }

            #endregion

            #region 12. Get the most expensive price among each category's products. (missed)

            var mostExpensivePriceByCategory = ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });

            foreach (var item in mostExpensivePriceByCategory)
                Console.WriteLine($"{item.Category}: most expensive price = {item.MostExpensivePrice}");

            #endregion

            #region 13. Get the products with the most expensive price in each category. (missed)

            var mostExpensiveProductsByCategory = ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Products = g.Where(p => p.UnitPrice == g.Max(x => x.UnitPrice))
                });

            foreach (var item in mostExpensiveProductsByCategory)
            {
                Console.WriteLine($"{item.Category} - most expensive product(s):");
                foreach (var product in item.Products)
                    Console.WriteLine($"  {product.ProductName} - {product.UnitPrice}");
            }

            #endregion

            #region 14. Get the average price of each category's products. (missed)

            var averagePriceByCategory = ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });

            foreach (var item in averagePriceByCategory)
                Console.WriteLine($"{item.Category}: average price = {item.AveragePrice:F2}");

            #endregion

            #endregion

            #region Set Operators

            #region 1. Find the unique Category names from Product List

            var uniqueCategories = ProductsList.Select(p => p.Category).Distinct();
            Console.WriteLine("\nUnique categories:");
            foreach (var category in uniqueCategories)
                Console.WriteLine(category);

            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customernames.

            var productFirstLetters = ProductsList.Select(p => p.ProductName[0].ToString());
            var customerFirstLetters = CustomersList.Select(c => c.CustomerName[0].ToString());
            var allUniqueFirstLetters = productFirstLetters.Union(customerFirstLetters);

            Console.WriteLine("\nUnique first letters from products and customers:");
            foreach (var letter in allUniqueFirstLetters)
                Console.WriteLine(letter);

            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.

            var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters);
            Console.WriteLine("\nCommon first letters:");
            foreach (var letter in commonFirstLetters)
                Console.WriteLine(letter);

            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            var productOnlyFirstLetters = productFirstLetters.Except(customerFirstLetters);
            Console.WriteLine("\nProduct first letters not found among customer first letters:");
            foreach (var letter in productOnlyFirstLetters)
                Console.WriteLine(letter);

            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            var lastThreeCharacters = CustomersList
                .Select(c => c.CustomerName.Length >= 3
                    ? c.CustomerName.Substring(c.CustomerName.Length - 3)
                    : c.CustomerName)
                .Concat(ProductsList.Select(p => p.ProductName.Length >= 3
                    ? p.ProductName.Substring(p.ProductName.Length - 3)
                    : p.ProductName));

            Console.WriteLine("\nLast three characters of customer and product names:");
            foreach (var ending in lastThreeCharacters)
                Console.WriteLine(ending);

            #endregion

            #endregion

            #region Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington

            var firstThreeWashingtonOrders = CustomersList
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Take(3);

            Console.WriteLine("\nFirst three orders from customers in Washington:");
            foreach (var order in firstThreeWashingtonOrders)
                Console.WriteLine($"Order ID: {order.OrderID}, Date: {order.OrderDate}");

            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.

            var remainingWashingtonOrders = CustomersList
                .Where(c => c.City == "Washington")
                .SelectMany(c => c.Orders)
                .Skip(2);

            Console.WriteLine("\nWashington orders after skipping the first two:");
            foreach (var order in remainingWashingtonOrders)
                Console.WriteLine($"Order ID: {order.OrderID}, Date: {order.OrderDate}");

            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

            int[] partitionNumbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var untilLessThanIndex = partitionNumbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine("\nElements before a number is less than its index:");
            foreach (var n in untilLessThanIndex)
                Console.WriteLine(n);
            #endregion

            #region 4.Get the elements of the array starting from the first element divisible by 3.

            var fromFirstDivisibleBy3 = partitionNumbers.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("\nElements starting from the first number divisible by 3:");
            foreach (var n in fromFirstDivisibleBy3)
                Console.WriteLine(n);

            #endregion

            #region 5. Get the elements of the array starting from the first element less than its position.

            var fromFirstLessThanIndex = partitionNumbers.SkipWhile((n, index) => n >= index);
            Console.WriteLine("\nElements starting from the first number less than its index:");
            foreach (var n in fromFirstLessThanIndex)
                Console.WriteLine(n);

            #endregion

            #endregion

            #region Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            bool containsEi = dictionaryWords.Any(word => word.Contains("ei"));
            Console.WriteLine($"\nDoes any dictionary word contain 'ei'? {containsEi}");

            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            var categoriesWithOutOfStockProducts = ProductsList
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0));

            Console.WriteLine("\nCategories with at least one product out of stock:");
            foreach (var group in categoriesWithOutOfStockProducts)
            {
                Console.WriteLine(group.Key);
                foreach (var product in group)
                    Console.WriteLine($"  {product.ProductName} - Stock: {product.UnitsInStock}");
            }


            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            var categoriesWithAllProductsInStock = ProductsList
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0));

            Console.WriteLine("\nCategories where all products are in stock:");
            foreach (var group in categoriesWithAllProductsInStock)
            {
                Console.WriteLine(group.Key);
                foreach (var product in group)
                    Console.WriteLine($"  {product.ProductName} - Stock: {product.UnitsInStock}");
            }


            #endregion

            #endregion

            #region Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5

            List<int> Numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            #endregion

            #region 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input

            #endregion

            #region 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            
            //string[] arr = { "from", "salt", "earn", " last", "near", "form" };
            
            #endregion

            #endregion
        }
    }
}
