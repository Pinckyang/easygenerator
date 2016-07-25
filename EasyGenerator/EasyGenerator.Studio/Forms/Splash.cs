using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace EasyGenerator.Studio
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();     // Se para el timer.
            this.Close();      // Cerramos el formulario.
        }
    }
}