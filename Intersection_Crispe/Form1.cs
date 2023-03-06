using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersection_Crispe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            {
                try
                {
                    // Get the first array from the first textbox
                    int[] array1 = textBox1.Text.Split(',')
                                                   .Select(s => int.TryParse(s.Trim(), out int n) ? n : throw new FormatException("Invalid input"))
                                                   .ToArray();

                    // Get the second array from the second textbox
                    int[] array2 = textBox2.Text.Split(',')
                                                   .Select(s => int.TryParse(s.Trim(), out int n) ? n : throw new FormatException("Invalid input"))
                                                   .ToArray();

                    var intersection = array1.Intersect(array2);
                    label7.Text =  string.Join(", ", intersection);


                    var difference = array1.Except(array2);
                    label8.Text =  string.Join(", ", difference);

                    var symmetricDifference = array1.Except(array2).Union(array2.Except(array1));
                    label9.Text = string.Join(", ", symmetricDifference);

                    var union = array1.Union(array2);
                    label10.Text = string.Join(", ", union);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Invalid input: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
