using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LinearAlgebra.Matrix;

public partial class Matrix {

    // ROW REDUCTION METHODS

    /// <summary>
    /// Return a new matrix of the two rows swapped.
    /// </summary>
    public static Matrix SwapRows(Matrix mat, int a, int b) {
        int m = mat.Rows;
        if (a < 0 || a >= m || b < 0 || b >= m) {
            throw new Exception("Row indices out of range");
        }

        // Maybe we should warn the user in some way that the two rows are the same.
        if (a == b) {
            return mat;
        }

        Matrix res = mat.DeepCopy();
        for (int i = 0; i < res.Columns; i++) {
            (res[a, i], res[b, i]) = (res[b, i], res[a, i]);
        }

        return res;
    }

    public Matrix SwapRows(int a, int b) => SwapRows(this, a, b);

    /// <summary>
    /// Multiply a row by a factor
    /// </summary>
    public Matrix MultiplyRow(Matrix mat, int row, double factor) {
        if (row < 0 || row >= mat.Rows) {
            throw new Exception($"Row index {row} out of range.");
        }

        Matrix res = mat.DeepCopy();

        for (int i = 0; i < res.Columns; i++) {
            res[row, i] *= factor;
        }

        return res;
    }

    public Matrix MultiplyRow(int row, double factor) => MultiplyRow(this, row, factor);

}