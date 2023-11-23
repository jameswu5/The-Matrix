using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Vector;

public partial class Vector {

    public int Length { get; private set; }
    private readonly double[] vector;
    private const int MaxDecimals = 3;

    /// <summary>
    /// Create empty vector with all values set to 0.
    /// </summary>
    /// <param name="m">Number of elements in the vector</param>
    public Vector(int m) {
        vector = new double[m];
        Length = m;
    }

    /// <summary>
    /// Create vector with predefined values.
    /// </summary>
    public Vector(double[] vector) {
        this.vector = vector;
        Length = vector.Length;
    }

    /// <summary>
    /// Create vector with predefined values.
    /// </summary>
    public Vector(int[] vector) {
        Length = vector.Length;
        this.vector = new double[Length];
        for (int i = 0; i < Length; i++) {
            this.vector[i] = vector[i];
        }
    }

    public override string ToString() {
        StringBuilder sb = new();
        foreach (double d in vector) {
            sb.Append(Math.Round(d, MaxDecimals));
            sb.Append(' ');
        }
        return sb.ToString();
    }

    public double this[int index] {
        get {
            if (index < 0 || index >= Length) {
                throw new Exception("Index out of range");
            }
            return vector[index];
        }
        set {
            if (index < 0 || index >= Length) {
                throw new Exception("Index out of range");
            }
            vector[index] = value;
        }
    }

}