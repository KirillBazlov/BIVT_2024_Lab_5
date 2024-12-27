using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks.Sources;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);
        Console.WriteLine($"{n} {k}");
        if (n <= 0 || (k <= 0 && k >= n)) 
            return answer;

        answer = Combinations(n, k);
        
        // end

        return answer;
    }

    public int Combinations(int n, int k)
    {
        int C = Factorial(n) / (Factorial(k) * Factorial(n - k));

        return C;
    }

    public int Factorial(int n)
    {
        int F = 1;
        for (int i = 1; i <= n; i++)
            F *= i;

        return F;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] <= 0 || second[i] <= 0)
                return -1;                    

            if (first[i] + first[(i + 1) % 3] <= first[(i + 2) % 3] || 
                    second[i] + second[(i + 1) % 3] <= second[(i + 2) % 3])
            {
                return -1;
            }
        }
               
        if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2])) {
            answer = 1;
        }            
        else if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2])) {
            answer = 2;
        }
            
        // end

            // first = 1, second = 2, equal = 0, error = -1

        return answer;
    }

    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double S = Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);

        return S;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours

        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
            answer = 1;
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time))
            answer = 2;

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }   

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours

        int time = 1;

        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
            time++;

        answer = time;

        // end

        return answer;
    }

    public double GetDistance(double v, double a, int t)
    {
        double S = v * t + (a * t * t) / 2;

        return S;
    }

    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        int AMaxIdx = FindMaxIndex(A), BMaxIdx = FindMaxIndex(B);
        double[] C; int CMaxIdx;
        double max;

        if (AMaxIdx < BMaxIdx) { C = A; CMaxIdx = AMaxIdx;  max = A[AMaxIdx]; }
        else { C = B; CMaxIdx = BMaxIdx; max = B[BMaxIdx]; }
      
        double avg = 0;
        for (int i = CMaxIdx + 1; i < C.Length; i++)
            avg += C[i];
        avg /= C.Length - CMaxIdx - 1;

        for (int i = 0; i < C.Length; i++)
        {
            if (C[i] == max)
                C[i] = avg;
        }

        // end
    }

    static int FindMaxIndex(double[] array)
    {
        int maxidx = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] > array[maxidx])
                maxidx = i;

        return maxidx;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        int AMaxRow = FindDiagonalMaxIndex(A), BMaxCol = FindDiagonalMaxIndex(B);

        for (int i = 0; i < A.GetLength(0); i++) 
        {
            int tmp = A[AMaxRow, i];
            A[AMaxRow, i] = B[i, BMaxCol];
            B[i, BMaxCol] = tmp;
        }

        // end
    }

    static int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxIdx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)        
            if (matrix[i, i] > matrix[maxIdx, maxIdx])
                maxIdx = i;
        
        return maxIdx;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1  ~??? No matrix in the task~
        // ~I will create FindMaxIndex for int[] array~
        // create and use DeleteElement(array, index);

        DeleteElement(ref A, FindMaxIndex(A)); DeleteElement(ref B, FindMaxIndex(B));
        int[] tmp = new int[A.Length + B.Length];

        for (int i = 0; i < A.Length; i++)
        {
            tmp[i] = A[i];
            tmp[i + A.Length] = B[i];
        }
        tmp[tmp.Length - 1] = B[B.Length - 1];

        A = tmp;

        // end
    }
    static int FindMaxIndex(int[] array)
    {
        int maxidx = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] > array[maxidx])
                maxidx = i;

        return maxidx;
    }

    static void DeleteElement(ref int[] array, int index)
    {
        int[] tmp = new int[array.Length - 1];

        for (int i = 0; i < array.Length; i++)
        {
            if (i < index) { tmp[i] = array[i]; }
            else if (i > index) { tmp[i - 1] = array[i]; }
        }

        array = tmp;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        SortArrayPart(ref A, FindMaxIndex(A) + 1);
        SortArrayPart(ref B, FindMaxIndex(B) + 1);

        // end
    }

    static void SortArrayPart(ref int[] array, int startIndex)
    {
        for (int i = startIndex + 1, j = startIndex + 2; i < array.Length;)
        {
            if (i == startIndex || array[i] >= array[i - 1]) { i = j; j++; }
            else
            {
                int tmp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = tmp;
                i--;
            }
        }
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);       

        int maxIdxRow = 0, maxIdxCol = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
                if (matrix[i, j] > matrix[maxIdxRow, maxIdxCol])
                {
                    maxIdxRow = i;
                    maxIdxCol = j;
                }

        int minIdxRow = 0, minIdxCol = 1;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            for (int j = i + 1; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < matrix[minIdxRow, minIdxCol])
                {
                    minIdxRow = i;
                    minIdxCol = j;
                }

        RemoveColumn(ref matrix, maxIdxCol);
        if (maxIdxCol != minIdxCol)
        {
            minIdxCol += (maxIdxCol > minIdxCol) ? 1 : -1;
            RemoveColumn(ref matrix, minIdxCol);
        }           

        // end
    }

    static void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] tmp = new int[n, m - 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                if (j < columnIndex)
                    tmp[i, j] = matrix[i, j];
                else if (j > columnIndex)
                    tmp[i, j - 1] = matrix[i, j];
            }

        matrix = tmp;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        int AmaxColIdx = FindMaxColumnIndex(A), BmaxColIdx = FindMaxColumnIndex(B);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            int tmp = A[i, AmaxColIdx];
            A[i, AmaxColIdx] = B[i, BmaxColIdx];
            B[i, BmaxColIdx] = tmp;
        }

        // end
    }

    static int FindMaxColumnIndex(int[,] matrix)
    {
        int maxRowIdx = 0, maxColIdx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > matrix[maxRowIdx, maxColIdx]) 
                {
                    maxColIdx = j;
                    maxRowIdx = i;
                }                    
        
        return maxColIdx;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        for (int i = 0; i < matrix.GetLength(0); i++)
            SortRow(ref matrix, i);

        // end
    }

    static void SortRow(ref int[,] matrix, int rowIndex)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i] >= matrix[rowIndex, i - 1]) { i = j; j++; }
            else
            {
                int tmp = matrix[rowIndex, i];
                matrix[rowIndex, i] = matrix[rowIndex, i - 1];
                matrix[rowIndex, i - 1] = tmp;
                i--;
            }
        }
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);        

        SortNegative(ref A); SortNegative(ref B);

        // end
    }

    static void SortNegative(ref int[] array)
    {
        int negativeCount = 0;
        foreach (int i in array)
            if (i < 0)
                negativeCount++;

        int[] negativeArray = new int[negativeCount];

        for (int i = 0, j = 0; i < array.Length; i++)
            if (array[i] < 0)
            {
                negativeArray[j] = array[i];
                j++;
            }                

        for (int i = 1, j = 2; i < negativeArray.Length;)
        {
            if (i == 0 || negativeArray[i] <= negativeArray[i - 1]) { i = j; j++; }
            else
            {
                int tmp = negativeArray[i];
                negativeArray[i] = negativeArray[i - 1];
                negativeArray[i - 1] = tmp;
                i--;
            }
        }

        for (int i = 0, j = 0; i < array.Length; i++)
            if (array[i] < 0)
            {
                array[i] = negativeArray[j];
                j++;
            }

    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);        

        // end
    }  
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        SortDiagonal(ref A); SortDiagonal(ref B);

        // end
    }

    static void SortDiagonal(ref int[,] matrix)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[i, i] >= matrix[i - 1, i - 1]) { i = j; j++; }
            else
            {
                int tmp = matrix[i, i];
                matrix[i, i] = matrix[i - 1, i - 1];
                matrix[i - 1, i - 1] = tmp;
                i--;
            }
        }
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        DeleteNoZeroColumns(ref A); DeleteNoZeroColumns(ref B);

        // end
    }

    public void DeleteNoZeroColumns(ref int[,] matrix)
    {
        bool[] ZeroColumnArray = new bool[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, j] == 0)
                    ZeroColumnArray[j] = true;

        for (int i = ZeroColumnArray.Length - 1; i >= 0; i--)
            if (!ZeroColumnArray[i])
                RemoveColumn(ref matrix, i);                    
        //////////////
    }


    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        rows = new int[matrix.GetLength(0)];

        for (int i = 0;i < matrix.GetLength(0); i++)
            rows[i] = CountNegativeInRow(matrix, i);

        cols = FindMaxNegativePerColumn(matrix);

        // end
    }

    static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[rowIndex, j] < 0)
                count++;

        return count;
    }

    static int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] maxes = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, j] > max && matrix[i, j] < 0)
                    max = matrix[i, j];

            maxes[j] = max;
        }
            
        return maxes;                
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        int AmaxRowIdx, AmaxColumnIdx;
        FindMaxIndex(A, out AmaxRowIdx, out AmaxColumnIdx);
        SwapColumnDiagonal(ref A, AmaxColumnIdx);

        int BmaxRowIdx, BmaxColumnIdx;
        FindMaxIndex(B, out BmaxRowIdx, out BmaxColumnIdx);
        SwapColumnDiagonal(ref B, BmaxColumnIdx);

        // end
    }

    static void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0; column = 0;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }                            
    }

    static void SwapColumnDiagonal(ref int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            int tmp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = tmp;
        }
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        int ARow = FindRowWithMaxNegativeCount(A), BRow = FindRowWithMaxNegativeCount(B);

        for (int j = 0; j < A.GetLength(1); j++)
        {
            int tmp = A[ARow, j];
            A[ARow, j] = B[BRow, j];
            B[BRow, j] = tmp;
        }

        // end
    }

    static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxNegRow = 0, RowIdx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int countInRow = CountNegativeInRow(matrix, i);
            if (countInRow > maxNegRow)
            {
                maxNegRow = countInRow;
                RowIdx = i;
            }
                
        }            

        return RowIdx;
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        answerFirst = FindSequence(first, 0, first.Length);
        answerSecond = FindSequence(second, 0, second.Length);

        // end
    }

    static int FindSequence(int[] array, int A, int B)
    {
        bool increase = false, decrease = false;

        for (int i = A; i < B - 1; i++)
        {
            if (array[i] < array[i + 1])
                increase = true;
            else if (array[i] > array[i + 1])
                decrease = true;            
        }

        if (increase && decrease)
            return 0;
        return (increase) ? 1 : -1;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        for (int i = 0; i < first.Length - 1; i++)
            for (int j = i; j < first.Length; j++)
                if (FindSequence(first, i, j) == 1)
                    answerFirst

        // end
    }    

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion

    public void PrintArray(double[] array)
    {
        foreach (double i in array)
            Console.Write($"{i} ");
        Console.WriteLine();
    }
    public void PrintArray(int[] array)
    {
        foreach (int i in array)
            Console.Write($"{i} ");
        Console.WriteLine();
        Console.WriteLine();
    }

    public void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
