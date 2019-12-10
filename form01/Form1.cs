using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLib;
using MeraPointer;

namespace form01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mydelegate pointer = new Mydelegate(SayHello);

            Student.Admitted += pointer;
            Student.DoItNow("Gudiya");

            Console.ReadLine();


        }

        private void SayHello(string msg)
        {
            MessageBox.Show("Kaisi Hai re " + msg); 
        }
    }
}
