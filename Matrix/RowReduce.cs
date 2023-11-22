using System;
using System.Collections.Generic;

namespace LinearAlgebra.Matrix;

public partial class Matrix {

    // ROW REDUCTION METHODS

    // ELEMENTARY ROW OPERATIONS

    /// <summary>
    /// Swap two rows of the matrix.
    /// </summary>
    public static Matrix SwapRows(Matrix mat, int a, int b, bool inPlace = false) {
        int m = mat.Rows;
        if (a < 0 || a >= m || b < 0 || b >= m) {
            throw new Exception("Row indices out of range");
        }

        // Maybe we should warn the user in some way that the two rows are the same.
        if (a == b) {
            return mat;
        }

        Matrix res = inPlace ? mat : mat.DeepCopy();

        for (int i = 0; i < res.Columns; i++) {
            (res[a, i], res[b, i]) = (res[b, i], res[a, i]);
        }

        return res;
    }

    public Matrix SwapRows(int a, int b, bool inPlace = false) => SwapRows(this, a, b, inPlace);

    /// <summary>
    /// Multiply a row by a factor
    /// </summary>
    public static Matrix MultiplyRow(Matrix mat, int row, double factor, bool inPlace = false) {
        if (row < 0 || row >= mat.Rows) {
            throw new Exception($"Row index {row} out of range.");
        }

        Matrix res = inPlace? mat : mat.DeepCopy();

        for (int i = 0; i < res.Columns; i++) {
            res[row, i] *= factor;
        }

        return res;
    }

    public Matrix MultiplyRow(int row, double factor, bool inPlace = false) => MultiplyRow(this, row, factor, inPlace);

    // TODO

    public static Matrix AddToAnotherRow(Matrix mat, int sourceRow, int destRow, double factor, bool inPlace = false) {
        throw new NotImplementedException();
    }

    public Matrix AddToAnotherRow(int sourceRow, int destRow, double factor, bool inPlace = false) 
               => AddToAnotherRow(this, sourceRow, destRow, factor, inPlace);

    
    // ROW REDUCTION

    /// <summary>
    /// Row reduce the matrix to echelon form
    /// </summary>
    public static Matrix RowReduce(Matrix mat, bool inPlace = false) {

        Matrix res = inPlace ? mat : mat.DeepCopy();

        throw new NotImplementedException();
    }

    public Matrix RowReduce(bool inPlace = false) => RowReduce(this, inPlace);

}