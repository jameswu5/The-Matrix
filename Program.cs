using System;
using System.Collections.Generic;
using System.Text;

public class Program {
    private static Matrix mat1 = new Matrix(new int[,] {
        {1,2,3},
        {4,5,6},
        {7,8,9}
    });

    private static Matrix mat2 = new Matrix(new double[,] {
        {1.5, 2.5, 3.5},
        {0.9, 3, 1.2}
    });

    private static Matrix mat3 = new Matrix(3, 4);

    public static void Main() {
        Console.WriteLine(mat3);
    }
}
