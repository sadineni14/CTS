# Algorithms and Data Structures – E-Commerce Search & Financial Forecasting (C#)

## Overview

This repository contains implementations of two fundamental algorithmic concepts in C#:

1. **E-Commerce Platform Search Function**

   * Linear Search
   * Binary Search
   * Time Complexity Analysis

2. **Financial Forecasting**

   * Recursive Algorithm
   * Future Value Prediction
   * Recursion Optimization Techniques

These exercises demonstrate how algorithm selection impacts performance and efficiency in real-world applications.

---

# Exercise 1: E-Commerce Platform Search Function

## Scenario

An e-commerce platform contains thousands of products. Users expect search results to be returned quickly and efficiently. This exercise compares Linear Search and Binary Search to determine the most suitable approach for product searching.

---

## Understanding Asymptotic Notation

### What is Big O Notation?

Big O notation describes how the execution time of an algorithm grows as the input size increases.

Common complexities:

| Complexity | Name              |
| ---------- | ----------------- |
| O(1)       | Constant Time     |
| O(log n)   | Logarithmic Time  |
| O(n)       | Linear Time       |
| O(n log n) | Linearithmic Time |
| O(n²)      | Quadratic Time    |

Big O helps developers predict algorithm performance for large datasets.

---

## Search Operation Scenarios

### Best Case

The target product is found immediately.

Example:

* Searching for the first element in Linear Search.
* Searching for the middle element in Binary Search.

### Average Case

The target product is found somewhere in the middle of the collection.

### Worst Case

The target product is:

* At the end of the collection, or
* Not present at all.

---

## Product Class Structure

Each product contains:

* Product ID
* Product Name
* Category

Example:

```csharp
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
}
```

---

## Algorithms Implemented

### Linear Search

Checks every product one by one until the target is found.

Steps:

1. Start from the first product.
2. Compare product IDs.
3. Continue until the product is found or the array ends.

### Binary Search

Works only on a sorted array.

Steps:

1. Find the middle element.
2. Compare with target.
3. Search left half or right half.
4. Repeat until found.

---

## Time Complexity Comparison

| Algorithm     | Best Case | Average Case | Worst Case |
| ------------- | --------- | ------------ | ---------- |
| Linear Search | O(1)      | O(n)         | O(n)       |
| Binary Search | O(1)      | O(log n)     | O(log n)   |

---

## Which Search Algorithm is Better?

### Linear Search

Advantages:

* Simple implementation.
* Works on unsorted data.

Disadvantages:

* Slow for large datasets.

### Binary Search

Advantages:

* Much faster for large datasets.
* Efficient searching.

Disadvantages:

* Requires sorted data.

### Recommendation

Binary Search is more suitable for large e-commerce platforms because product catalogs often contain thousands or millions of products. Its logarithmic time complexity allows significantly faster searches compared to Linear Search.

---

# Exercise 2: Financial Forecasting

## Scenario

A financial forecasting system predicts future values of investments based on historical growth rates.

This exercise demonstrates how recursion can be used to calculate future investment values.

---

## Understanding Recursion

### What is Recursion?

Recursion is a programming technique where a method calls itself to solve a smaller version of the same problem.

A recursive solution consists of:

1. Base Case
2. Recursive Case

Example:

Future Value for Year n depends on Future Value for Year n−1.

---

## Financial Forecast Formula

Future Value:

FV = PV × (1 + r)^n

Where:

* FV = Future Value
* PV = Present Value
* r = Growth Rate
* n = Number of Years

Recursive Relation:

FV(n) = FV(n−1) × (1 + r)

Base Case:

FV(0) = PV

---

## Recursive Algorithm

Steps:

1. If years = 0, return present value.
2. Otherwise:

   * Calculate value for previous year.
   * Multiply by growth factor.
3. Return the result.

---

## Time Complexity Analysis

### Recursive Solution

Recurrence:

T(n) = T(n−1) + O(1)

Result:

Time Complexity: O(n)

Space Complexity: O(n)

The space complexity is due to recursive function calls stored on the call stack.

---

## Optimization Techniques

### Memoization

Store previously calculated results.

Benefits:

* Avoids repeated calculations.
* Improves efficiency.

### Mathematical Formula

Using:

```csharp
Math.Pow(1 + rate, years)
```

Benefits:

* Faster execution.
* No recursive overhead.
* More suitable for large datasets.

---

## Comparison of Approaches

| Approach    | Time Complexity                               | Space Complexity |
| ----------- | --------------------------------------------- | ---------------- |
| Recursion   | O(n)                                          | O(n)             |
| Memoization | O(n)                                          | O(n)             |
| Math.Pow()  | O(log n) or better (implementation dependent) | O(1)             |

---

# Learning Outcomes

After completing these exercises, you will understand:

* Big O notation
* Algorithm performance analysis
* Best, average, and worst-case complexities
* Linear Search
* Binary Search
* Recursion
* Recursive optimization techniques
* Real-world applications of search and forecasting algorithms

---

## Technologies Used

* C#
* .NET
* Object-Oriented Programming (OOP)
* Data Structures and Algorithms

---

## Conclusion

These exercises demonstrate two important concepts in software development:

1. Efficient searching using Linear Search and Binary Search.
2. Predictive computation using Recursive Financial Forecasting.

Choosing the right algorithm can significantly improve application performance, scalability, and user experience.
