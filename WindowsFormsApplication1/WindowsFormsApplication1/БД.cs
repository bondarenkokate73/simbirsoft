using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class БД : Form
    {
        DatabaseEntities simbirSoft;
        
        public БД()
        {
            
            InitializeComponent();
            simbirSoft = new DatabaseEntities();
            Init();
            
        }

        public void Init()
        {
            dataGridView1.RowCount = simbirSoft.Hystory.ToList().Count + 1;

                for (int i = 0; i < simbirSoft.Hystory.ToList().Count; i++)
                {
                dataGridView1.Rows[i].SetValues (simbirSoft.Hystory.ToList()[i].Id, 
                    simbirSoft.Hystory.ToList()[i].Date,
                    simbirSoft.Hystory.ToList()[i].Player1,
                    simbirSoft.Hystory.ToList()[i].Player2,
                    simbirSoft.Hystory.ToList()[i].KolvoHod,
                    simbirSoft.Hystory.ToList()[i].Win);
            }
            
        }

        private void БД_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
