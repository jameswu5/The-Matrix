using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// The base matrix class handling operations.
/// </summary>
class Matrix {
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    private double[,] matrix;

    /// <summary>
    /// Create an empty matrix with all values defaulted to 0.
    /// </summary>
    /// <param name="m">Number of rows of the matrix</param>
    /// <param name="n">Number of columns of the matrix</param>
    public Matrix(int m, int n) {
        Rows = m;
        Columns = n;
        matrix = new double[m, n];
    }

    /// <summary>
    /// Create a matrix with inputted values
    /// </summary>
    /// <param name="matrix">A 2D array containing the values of the matrix</param>
    public Matrix(double[,] matrix) {
        Rows = matrix.GetLength(0);
        Columns = matrix.GetLength(1);
        this.matrix = matrix;
    }

    /// <summary>
    /// Create a matrix with inputted values
    /// </summary>
    /// <param name="matrix">A 2D array containing the values of the matrix</param>
    public Matrix(int[,] matrix) {
        Rows = matrix.GetLength(0);
        Columns = matrix.GetLength(1);
        this.matrix = new double[Rows, Columns];

        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                this.matrix[i, j] = matrix[i, j];
            }
        }
    }

    public double this[int row, int col] {
        get {
            if (row < 0 || row > Rows || col < 0 || col > Columns)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            return matrix[row, col];
        }
        set {
            if (row < 0 || row > Rows || col < 0 || col > Columns)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            matrix[row, col] = value;
        }
    }

    /// <summary>
    /// Return a string representation of the matrix.
    /// </summary>
    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                sb.Append(matrix[i, j]);
                sb.Append(' ');
            }
            sb.Append('\n');
        }
        return sb.ToString();
    }

    /// <summary>
    /// Determine whether two matrices have the same shape or not.
    /// </summary>
    public static bool CheckSameShape(Matrix a, Matrix b) => (a.Rows == b.Rows) && (a.Columns == b.Columns);

    /// <summary>
    /// Add two matrices together elementwise.
    /// </summary>
    public static Matrix operator +(Matrix a, Matrix b) {
        if (!CheckSameShape(a, b)) {
            throw new Exception($"Matrix shapes ({a.Rows}, {a.Columns}) and ({b.Rows}, {b.Columns}) do not correspond.");
        }

        int m = a.Rows;
        int n = a.Columns;
        Matrix newMatrix = new Matrix(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                newMatrix[i, j] = a[i, j] + b[i, j];
            }
        }
        return newMatrix;
    }
}