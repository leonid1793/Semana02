﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Session_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Leonid"].ConnectionString);

        public void ListaAnios()
        {
            using(SqlCommand cmd = new SqlCommand ("Usp_ListaAnios",cn))
            {
                using(SqlDataAdapter da= new SqlDataAdapter())
                {
                        da.SelectCommand = cmd;
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        using(DataSet df=new DataSet())
                        {
                            //El metodo fill cargara los datos del procedimiento almacenado
                            da.Fill(df, "ListaAnios");
                        //enviar los datos al conbobox
                        CboAnios.DataSource = df.Tables["ListaAnios"];
                        CboAnios.DisplayMember = "Anios";
                        CboAnios.ValueMember = "Anios"; 
                        }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

  

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaAnios();
        }
    }
}
