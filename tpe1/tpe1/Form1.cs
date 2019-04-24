using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpe1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Convert.ToInt32(textBox1.Text);

            for (int i =0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "z" + i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidth = 60;

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderCell.Value = "z_i = +1";
            dataGridView1.Columns[1].HeaderCell.Value = "z_i = -1";
            dataGridView1.Columns[2].HeaderCell.Value = "z_i = 0";
            dataGridView1.Columns[3].HeaderCell.Value = "lambda_i";
            dataGridView1.Columns[4].HeaderCell.Value = "dependence";
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Columns[i].Width = 90;
            }
            dataGridView1.Columns[4].Width = 150;
        }


        static string in_sec_system(int num)
        {
            var stack = new Stack<int>();
            if (num == 0)
            {
                return num.ToString();
            }
            else
            {
                while (num > 0)
                {
                    stack.Push(num % 2);
                    num /= 2;
                }

                string rez = "";

                foreach (int i in stack)
                {
                    rez = rez + i;
                }
                return rez;
            }
        }
        static long Fact(long x)
        {
            return (x == 0) ? 1 : x * Fact(x - 1);
        }

        static int Combination (int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += (int)(Fact(n) / (Fact(i) * Fact(n - i)));
            }
            return sum;
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value)) / 2;
                dataGridView1.Rows[i].Cells[3].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value) - Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value)) / 2;
                dataGridView1.Rows[i].Cells[4].Value = "x" + i.ToString() + "= " + "(z" + i.ToString() + " - " + dataGridView1.Rows[i].Cells[2].Value.ToString() + ") / " + dataGridView1.Rows[i].Cells[3].Value.ToString();
            }

            //full factors exspiriments

            int M = (int)Math.Pow(2, Convert.ToInt32(textBox1.Text));

            dataGridView2.RowCount = M;
            dataGridView2.ColumnCount = Convert.ToInt32(textBox1.Text);

            //zagolovki
            dataGridView2.RowHeadersWidth = 60;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].HeaderCell.Value = (i+1).ToString();
            }

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].HeaderCell.Value = "x" + (i + 1).ToString();
                dataGridView2.Columns[i].Width = 40;
            }

            //
           

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                string tmp;
                int a = Convert.ToInt32(textBox1.Text);
                tmp = in_sec_system(i);
                if (tmp.Length != Convert.ToInt32(textBox1.Text))
                {
                    a -= tmp.Length;
                    for (int k = 0; k < a; k++)
                    {
                        tmp = "0" + tmp;
                    }
                }
                else
                    
                    tmp = in_sec_system(i); 
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    char[] tmp_2 = tmp.ToCharArray();
                    dataGridView2.Rows[i].Cells[j].Value = tmp_2[j];
                }
            }

            //change 0 on +1 and change 1 on -1
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value.ToString() == 0.ToString())
                    {
                        dataGridView2.Rows[i].Cells[j].Value = "+1";
                    }
                    else
                        dataGridView2.Rows[i].Cells[j].Value = "-1";
                }
            }
            //end 

            //dfe and p[2,4,8]
            int p = 0;
            if (Convert.ToUInt32(textBox2.Text) < Convert.ToUInt32(textBox2.Text) && Convert.ToUInt32(textBox2.Text) > 0)
            {
                p = Convert.ToUInt16(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Invalid Value");
            }
            //end 

            double dfe_M = Math.Pow((double)2, (Convert.ToUInt32(textBox1.Text) - Convert.ToUInt32(textBox2.Text)));

            label4.Text = "1/" +(M / dfe_M).ToString();


            //dfe
            dataGridView3.RowCount = M;
            dataGridView3.ColumnCount = Convert.ToUInt16(textBox1.Text);
            //give name handle table 
            dataGridView3.RowHeadersWidth = 60;

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                dataGridView3.Columns[i].HeaderCell.Value = "x" + (i + 1).ToString();
                dataGridView3.Columns[i].Width = 40;
            }
            //


            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = dataGridView2.Rows[i].Cells[j].Value;
                }
            }

            // delete 2^n-p rows
            Random rnd = new Random();
            for (int i = 0; i < M-dfe_M; i++)
            {
                dataGridView3.Rows.RemoveAt(rnd.Next(0, dataGridView3.Rows.Count-1));
            }

            //add p col 
            //generation plan
            //посчитаем количество столбцов которых необходимо добавить 
            int add_col = Convert.ToInt32(textBox1.Text) + (int)(Fact(Convert.ToInt32(textBox1.Text)) / (Fact(2) * Fact(Convert.ToInt32(textBox1.Text) - 2))); ; 
            dataGridView3.ColumnCount = add_col;


            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                dataGridView3.Columns[i].Width = 40;
            }

            int schet = Convert.ToInt32(textBox1.Text);
            int pred = add_col;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text) - 1; i++)
            {
                for (int j = 1; j < Convert.ToInt32(textBox1.Text); j++ )
                {
                    if (schet < pred && i!=j && i < j)
                    {
                        dataGridView3.Columns[schet].HeaderCell.Value = "x" + (i+1).ToString() + "x" + (j+1).ToString();
                        for (int r = 0; r < dataGridView3.RowCount; r++)
                        {
                            dataGridView3.Rows[r].Cells[schet].Value = Convert.ToInt16(dataGridView3.Rows[r].Cells[i].Value) * Convert.ToInt16(dataGridView3.Rows[r].Cells[j].Value);
                        }
                        schet++;
                    }
                }
            }

            //stay p columns 
            Random rnd2 = new Random();
            int stay = (dataGridView3.Columns.Count - Convert.ToInt16(textBox2.Text));
            for (int i = Convert.ToInt16(textBox1.Text); i < stay; i++)
            {
                dataGridView3.Columns.RemoveAt(rnd2.Next(Convert.ToInt16(textBox1.Text), dataGridView3.Columns.Count));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
