using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrix;

public static class Test {

    private static Matrix mat1 = new Matrix(new int[,] {
        {1,2,3},
        {4,5,6},
        {7,8,9}
    });

    private static Matrix mat2 = new Matrix(new double[,] {
        {1.5, 2.5, 3.5},
        {0.9, 3, 1.2}
    });

    private static Matrix mat3 = new Matrix(0, 0);

    private static Matrix mat4 = new Matrix(new int[,] {
        {10,20,30},
        {40,50,60},
        {70,80,90}
    });

    private static Matrix mat5 = new Matrix(new int[,] {
        {6,2,3},
        {9,1,4},
        {8,5,1}
    });

    private static Matrix mat6 = new Matrix(new int[,] {{3}});

    private static Matrix mat7 = new Matrix(new int[,] {
        {6,2},
        {9,1},
    });

    public static void Playground() {
        Console.WriteLine(mat5.Invert());
    }

}