using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Var13
{
    public partial class Form1 : Form
    {
        Matrix A = null;
        Matrix B = null;
        Matrix C = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void msize_ValueChanged(object sender, EventArgs e)
        {
            //Строем матриц А
            int n = Convert.ToInt32(msize.Value);
            int k = Convert.ToInt32(textBoxk.Text);
            A = Matrix.getA(n);
            A.output(table1);

            //int kForB = 1;

            //
            B = Matrix.getB(A, k);
            B.output(table2);

            C = Matrix.getC(A);
            C.output(table3);
        }

        private void table3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
