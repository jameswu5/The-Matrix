using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// The base matrix class handling operations.
/// </summary>
class Matrix {
    private int m;
    private int n;
    private double[,] matrix;

    /// <summary>
    /// Constructor creating an empty matrix with all values defaulted to 0.
    /// </summary>
    /// <param name="m">Number of rows of the matrix</param>
    /// <param name="n">Number of columns of the matrix</param>
    public Matrix(int m, int n) {
        this.m = m;
        this.n = n;
        matrix = new double[m, n];
    }

    /// <summary>
    /// Constructor creating a matrix with inputted values
    /// </summary>
    /// <param name="matrix">A 2D array containing the values of the matrix</param>
    public Matrix(double[,] matrix) {
        m = matrix.GetLength(0);
        n = matrix.GetLength(1);
        this.matrix = matrix;
    }

    /// <summary>
    /// Constructor creating a matrix with inputted values
    /// </summary>
    /// <param name="matrix">A 2D array containing the values of the matrix</param>
    public Matrix(int[,] matrix) {
        m = matrix.GetLength(0);
        n = matrix.GetLength(1);
        this.matrix = new double[m, n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                this.matrix[i, j] = matrix[i, j];
            }
        }
    }

    /// <summary>
    /// Converts the matrix to a string to display in the terminal.
    /// </summary>
    /// <returns>A string representation of the matrix</returns>
    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sb.Append(matrix[i, j]);
                sb.Append(' ');
            }
            sb.Append('\n');
        }
        return sb.ToString();
    }
}