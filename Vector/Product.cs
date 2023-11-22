using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
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


    /// <summary>
    /// Perform the cross product on two dimension 3 vectors.
    /// </summary>
    public static Vector Cross(Vector vec1, Vector vec2) {
        if (vec1.Length != 3 || vec2.Length != 3) {
            throw new Exception("Vector sizes must both be 3");
        }

        Vector res = new Vector(3);

        res[0] = vec1[1] * vec2[2] - vec1[2] * vec2[1];
        res[1] = vec1[2] * vec2[0] - vec1[0] * vec2[2];
        res[2] = vec1[0] * vec2[1] - vec1[1] * vec2[0];

        return res;
    }

    public Vector Cross(Vector vec) => Cross(this, vec);
}