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
    /// Constructor creating an empty matrix with all values defaulted to 0.
    /// </summary>
    /// <param name="m">Number of rows of the matrix</param>
    /// <param name="n">Number of columns of the matrix</param>
    public Matrix(int m, int n) {
        Rows = m;
        Columns = n;
        matrix = new double[m, n];
    }

    /// <summary>
    /// Constructor creating a matrix with inputted values
    /// </summary>
    /// <param name="matrix">A 2D array containing the values of the matrix</param>
    public Matrix(double[,] matrix) {
        Rows = matrix.GetLength(0);
        Columns = matrix.GetLength(1);
        this.matrix = matrix;
    }

    /// <summary>
    /// Constructor creating a matrix with inputted values
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

    /// <summary>
    /// Retrieve an element from the matrix with indexing.
    /// </summary>
    /// <param name="row">Row you want to retrieve from.</param>
    /// <param name="col">Column you want to retrieve from.</param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
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
    /// Converts the matrix to a string to display in the terminal.
    /// </summary>
    /// <returns>A string representation of the matrix</returns>
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
    /// Determines whether two matrices have the same shape or not.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>true if they have the same shape, false otherwise.</returns>
    public static bool CheckSameShape(Matrix a, Matrix b) => (a.Rows == b.Rows) && (a.Columns == b.Columns);

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