﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToodeBD
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\AppData\Tooded.mdf; Integrated Security = True");
        SqlCommand command;
        SqlDataAdapter adapter;
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            connect.Open();
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM ToodeTable", connect);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();
        }

        private void ClearData()
        {
            Id = 0;
            Toodetxt.Text = "";
            Kogustxt.Text = "";
            Hindtxt.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toodedDataSet.Tootetable' table. You can move, or remove it, as needed.
            this.tootetableTableAdapter.Fill(this.toodedDataSet.Tootetable);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Toodetxt.Text!=""&&Kogustxt.Text!=""&&Hindtxt.Text!="")
            {
                command = new SqlCommand("UPDATE Tootetable(ToodeNimetus,Kogus,Hind) +" +
                    "values(@toode,@kogus,@hind)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@toode", Toodetxt);
                command.Parameters.AddWithValue("@kogus", Kogustxt);
                command.Parameters.AddWithValue("@hind", Hindtxt);
                command.ExecuteNonQuery();
                connect.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Viga");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Toodetxt.Text != "" && Kogustxt.Text != "" && Hindtxt.Text != "")
            {
                command = new SqlCommand("INSERT INTO Toodetable(ToodeNimetus,Kogus,Hind) VALUES(@toode,@kogus,@hind)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@toode", Toodetxt.Text);
                command.Parameters.AddWithValue("@kogus", Kogustxt.Text);
                command.Parameters.AddWithValue("@hind", Hindtxt.Text);
                command.ExecuteNonQuery();
                connect.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Andmed on lisatud");
            }
            else
            {
                MessageBox.Show("Viga");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Toodetxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void Hindtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                command=new SqlCommand("DELETE Tootetable WHERE Id=@id", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@toode", Id);
                command.Parameters.AddWithValue("@kogus", Id);
                command.Parameters.AddWithValue("@hind", Id);
                command.ExecuteNonQuery();
                connect.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Andmed on kustutatud");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Kogustxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Toodetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg;)";
            open.InitialDirectory = Path.GetFullPath(@"C:\Users\opilane\source\repos\ToodeBD");
        }
    }
}
