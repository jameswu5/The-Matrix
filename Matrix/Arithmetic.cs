using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrix;

public partial class Matrix {

    // MATRIX OPERATIONS

    /// <summary>
    /// Add two matrices together elementwise.
    /// </summary>
    public static Matrix operator +(Matrix a, Matrix b) {
        if (!CheckSameShape(a, b)) {
            throw new Exception($"Matrix shapes ({a.Rows}, {a.Columns}) and ({b.Rows}, {b.Columns}) do not correspond.");
        }

        int m = a.Rows;
        int n = a.Columns;
        Matrix result = new Matrix(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    /// <summary>
    /// Subtract first matrix from second matrix elementwise.
    /// </summary>
    public static Matrix operator -(Matrix a, Matrix b) {
        if (!CheckSameShape(a, b)) {
            throw new Exception($"Matrix shapes ({a.Rows}, {a.Columns}) and ({b.Rows}, {b.Columns}) do not correspond.");
        }

        int m = a.Rows;
        int n = a.Columns;
        Matrix result = new Matrix(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    /// <summary>
    /// Performs the dot product on two matrices.
    /// </summary>
    public static Matrix operator *(Matrix a, Matrix b) {
        if (a.Columns != b.Rows) {
            throw new Exception($"Columns of first matrix {a.Columns} not equal to Rows of second matrix {b.Rows}");
        }

        int m = a.Rows;
        int n = b.Columns;

        Matrix result = new Matrix(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < a.Columns; k++) {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Performs scalar multiplcation.
    /// </summary>
    public static Matrix operator *(double value, Matrix mat) {
        int m = mat.Rows;
        int n = mat.Columns;
        Matrix result = new Matrix(m, n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                result[i, j] = mat[i, j] * value;
            }
        }
        return result;
    }

    public static Matrix operator *(int value, Matrix mat) => (double)value * mat;

    public static Matrix operator *(Matrix mat, double value) => value * mat;

    public static Matrix operator *(Matrix mat, int value) => (double)value * mat;

    public static Matrix operator /(Matrix mat, double value) => 1.0 / value * mat;

    public static Matrix operator /(Matrix mat, int value) => 1.0 / value * mat;
}