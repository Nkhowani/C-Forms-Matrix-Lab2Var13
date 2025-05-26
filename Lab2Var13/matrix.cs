using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2Var13
{
    public class Matrix
    {
        // Fields
        double[,] Array = null;

        // Property
        public int N
        {
            get
            {
                if (Array == null)
                    return 0;
                else
                    return Array.GetLength(0);
            }
        }

        // Constructor
        public Matrix(int k = 2)
        {
            k = Math.Max(2, k);
            Array = new double[k, k];
        }

        // Randomly populate the matrix (not used in this example)
        public void random(int a = 0, int b = 10)
        {
            Random R = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    Array[i, j] = R.Next(a, b) + R.NextDouble();
        }

        // Output the matrix to a DataGridView
        public void output(DataGridView table)
        {
            // Configure table to match matrix dimensions
            table.RowCount = table.ColumnCount = N;

            // Populate the DataGridView with matrix values
            for (int i = 0; i < N; i++)
            {
                table.Rows[i].HeaderCell.Value = $"{i}";
                table.Columns[i].HeaderCell.Value = $"{i}";

                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                        table.Rows[i].Cells[j].Style.ForeColor = Color.Purple;
                    else
                        table.Rows[i].Cells[j].Style.BackColor = Color.Gray;

                    table.Rows[i].Cells[j].Value = $"{Array[i, j]:F0}";
                }
            }

            // Adjust column and row sizes
            table.AutoResizeColumns();
            table.AutoResizeRows();
        }

        public static void Clear(DataGridView table)
        {
            if (table == null)
                return;

            for (int i = 0; i < table.RowCount; i++)
                for (int j = 0; j < table.ColumnCount; i++)
                    table.Rows[i].Cells[j].Value = "";
        }

        // Transpose the matrix
        public static Matrix transform(Matrix A)
        {
            if (A == null || A.N == 0)
                return new Matrix(2);

            Matrix C = new Matrix(A.N);
            for (int i = 0; i < C.N; i++)
                for (int j = 0; j < C.N; j++)
                    C.Array[i, j] = A.Array[j, i];

            return C;
        }

        // Save the matrix from a DataGridView
        public void save(DataGridView table)
        {
            if (Array == null || N == 0 || table == null)
                return;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (Double.TryParse(table.Rows[i].Cells[j].Value.ToString(), out Array[i, j])) ;
                    else Array[i, j] = 0.0;
        }

        // Indexer
        public double this[int i, int j]
        {
            set
            {
                if (i >= 0 && j >= 0 && i < N && j < N)
                    Array[i, j] = value;
            }
            get
            {
                if (i >= 0 && j >= 0 && i < N && j < N)
                    return Array[i, j];
                else return Array[0, 0];
            }
        }

        // Addition operator
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A == null || B == null || A.N != B.N)
                return new Matrix(2);

            Matrix C = new Matrix(A.N);
            for (int i = 0; i < C.N; i++)
                for (int j = 0; j < C.N; j++)
                    C[i, j] = A[i, j] + B[i, j];

            return C;
        }

        // Multiplication operator
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A == null || B == null || A.N != B.N)
                return new Matrix(2);

            Matrix C = new Matrix(A.N);
            for (int i = 0; i < C.N; i++)
                for (int j = 0; j < C.N; j++)
                {
                    C[i, j] = 0.0;
                    for (int k = 0; k < C.N; k++)
                        C[i, j] += A[i, k] * B[k, j];
                }

            return C;
        }

        // Method to create matrix A as specified
        public static Matrix getA(int n)
        {
            n = Math.Max(2, n);
            Matrix A = new Matrix(n);
            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    if (i == j)
                    {
                        A[i, j] = n - 1;
                    }
                    else if (j == i - 1)
                    {
                        A[i, j] = n;
                    }
                    else
                    {
                        A[i, j] = 0.0;
                    }
                }
            }
            return A;
        }

        public static Matrix getB(Matrix A, int k)
        {
            if (A == null || A.N == 0)
                return new Matrix(2);

            Matrix B = new Matrix(A.N);
            Random rnd = new Random();

            for (int i = 0; i < B.N; i++)
            {
                for (int j = 0; j < B.N; j++)
                {
                    if (i == k || j == k)
                        B[i, j] = rnd.Next(-10,10);
                    else
                        B[i, j] = A[i, j];
                }
            }
            //
            for (int i = 0; i < B.N; i++)
            {
                if (i != k)
                    B[k, i] += k;
            }
            return B;
        }

        public static Matrix getC(Matrix A)
        {
            if (A == null || A.N == 0)
                return new Matrix(2);

            Matrix C = new Matrix(A.N);
            for (int j = 0; j < C.N; j++)
            {
                for (int i = 0; i < C.N; i++)
                {
                    C[i, j] = A[i, j] + j;
                }
            }
            return C;


        }
    }
}
