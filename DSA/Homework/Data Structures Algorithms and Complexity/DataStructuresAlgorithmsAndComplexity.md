## Data Structures, Algorithms and Complexity Homework

1. **What is the expected running time of the following C# code?**

  ```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
                  { start++; count++; }
              else
                  end--;
      }
      return count;
  }
  ```
  Expexted running time  in this case is O(n^2) because each element is precessed n times. 

2. **What is the expected running time of the following C# code?**

  ```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
          if (matrix[row, 0] % 2 == 0)
              for (int col=0; col<matrix.GetLength(1); col++)
                  if (matrix[row,col] > 0)
                      count++;
      return count;
  }
  ```
  Worst case: expected running time is O(n*m) because each n element is processed m times.
  Best case: expected running time is O(n) because each element is processed only one time.

3. **(*) What is the expected running time of the following C# code?**
  ```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++)
          sum += matrix[row, col];
      if (row + 1 < matrix.GetLength(1))
          sum += CalcSum(matrix, row + 1);
      return sum;
  }

  Console.WriteLine(CalcSum(matrix, 0));
  ```
	Best case: expected running time is O(n). This case is valid if matrix contains only 1 row.
    Worst case: expected running time is O(n*m) because function calls itself, if matrix contains more than 1 row.
