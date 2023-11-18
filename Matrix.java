
class Matrix {
    private int m;
    private int n;
    private double[][] matrix;

    public Matrix(int m, int n) {
        this.m = m;
        this.n = n;
        matrix = new double[m][n];
    }

    public Matrix(double[][] matrix) {
        m = matrix.length;
        n = matrix[0].length;
        this.matrix = matrix;
    }

    public Matrix(int[][] matrix) {
        m = matrix.length;
        n = matrix[0].length;
        this.matrix = new double[m][n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                this.matrix[i][j] = (double)matrix[i][j];
            }
        }
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sb.append(matrix[i][j]);
                sb.append(" ");
            }
            sb.append("\n");
        }

        return sb.toString();
    }
}