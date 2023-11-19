using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrix;

public partial class Matrix {
    
    // LINEAR ALGEBRA OPERATIONS

    /// <summary>
    /// Return a new matrix that is the transpose of the one passed.
    /// </summary>
    public static Matrix Transpose(Matrix mat) {
        int m = mat.Rows;
        int n = mat.Columns;
        Matrix result = new Matrix(n, m);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[j, i] = mat[i, j];
            }
        }
        return result;
    }

    public Matrix Transpose() => Transpose(this);

    public Matrix T() => Transpose(this);


    /// <summary>
    /// Return the minor of the matrix (matrix missing row i and column j)
    /// </summary>
    /// <param name="mat">Base matrix</param>
    /// <param name="r">Row that is not included</param>
    /// <param name="c">Columnn that is not included</param>
    /// <returns>The minor of the matrix.</returns>
    private static Matrix GetMinorMatrix(Matrix mat, int r, int c) {
        int m = mat.Rows;
        int n = mat.Columns;

        if (r < 0 || r >= m || c < 0 || c >= n) {
            throw new Exception("Index out of range.");
        }

        Matrix result = new Matrix(m - 1, n - 1);
        for (int i = 0; i < m - 1; i++) {
            int curRow = i < r ? i : i + 1;
            for (int j = 0; j < n - 1; j++) {
                int curCol = j < c ? j : j + 1;
                result[i, j] = mat[curRow, curCol];
            }
        }
        return result;
    }

    /// <summary>
    /// Return the determinant of the matrix.
    /// </summary>
    public static double Determinant(Matrix mat) {
        if (mat.Rows != mat.Columns) {
            throw new Exception($"Matrix is not square: shape ({mat.Rows}, {mat.Columns})");
        }

        int n = mat.Rows;

        switch (n) {
            case 0:
                throw new Exception($"Matrix size ({n}) not valid");
            case 1:
                return mat[0, 0];
            case 2:
                return mat[0, 0] * mat[1, 1] - mat[1, 0] * mat[0, 1];
            default:
                double result = 0;
                for (int i = 0; i < n; i += 2) {
                    result += mat[i, 0] * Determinant(GetMinorMatrix(mat, i, 0));
                }
                for (int i = 1; i < n; i += 2) {
                    result -= mat[i, 0] * Determinant(GetMinorMatrix(mat, i, 0));
                }
                return result;
        }
    }

    public double Determinant() => Determinant(this);

    public double Det() => Determinant(this);

    /// <summary>
    /// Return the inverse of the matrix passed.
    /// </summary>
    public static Matrix Invert(Matrix mat) {
        if (mat.Rows != mat.Columns) {
            throw new Exception($"Matrix is not square: shape ({mat.Rows}, {mat.Columns})");
        }

        int n = mat.Rows;

        if (n == 0) {
            throw new Exception($"Matrix size {n} not valid.");
        }

        double determinant = Determinant(mat);

        if (determinant == 0) {
            throw new Exception($"Determinant is 0, cannot invert");
        }

        if (n == 1) {
            return new Matrix(new double[,] {{1 / determinant}});
        }

        Matrix result = new Matrix(n, n);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                double cofactor = Determinant(GetMinorMatrix(mat, j, i));
                int sign = ((i & 1) ^ (j & 1)) == 0 ? 1 : -1;
                result[i, j] = cofactor / determinant * sign;
            }
        }

        return result;
    }

    public Matrix Invert() => Invert(this);

}