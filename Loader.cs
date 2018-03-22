using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzed
{
    public partial class Loader : Form
    {
        private AsyncPictureBox box;
        
        public Loader()
        {
            InitializeComponent();
            
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

       
    }
}
