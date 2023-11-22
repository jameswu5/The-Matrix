using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Vector;

public partial class Vector {

    /// <summary>
    /// Perform the dot product (or inner product).
    /// </summary>
    public static double Dot(Vector vec1, Vector vec2) {
        if (vec1.Length != vec2.Length) {
            throw new Exception("Vector lengths do not match");
        }

        double res = 0;
        for (int i = 0; i < vec1.Length; i++) {
            res += vec1[i] * vec2[i];
        }
        return res;
    }

    public double Dot(Vector vec) => Dot(this, vec);
}