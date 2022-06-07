using Integration1COzon.Application.Abstractions;
using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Abstractions.Ozon;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object;
using Integration1COzon.Application.Domanes.Requests.Ozon;
using Integration1COzon.Application.Domanes.Responses.Ozon;
using Integration1COzon.Application.Handler;
using Integration1COzon.Application.Handler.JsonHandlers;
using Integration1COzon.Application.Requests;
using Integration1COzon.Ozon;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Integration1COzon.WinForms
{
    public partial class Form1 : Form
    {
        StorageType storageType = StorageType.CTC;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private static IConnection1C _connection1c = new Connection1C.Connection1C();
        private static IOzonHandlerFactory _ozonFactory = new OzonHandlerFactory();
        private IntegrationHandler _integrationHandler = new IntegrationHandler(_ozonFactory, _connection1c);
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (comboBox1.SelectedIndex != 0)
            {
                storageType = StorageType.PgJeweler;
            }
            var listProduct = _integrationHandler.Handle(storageType);
            int i = 0;
            dataGridView1.Columns.Add("Column1", "Артикул");
            dataGridView1.Columns.Add("Column1", "Название");
            dataGridView1.Columns.Add("Column1", "Склад");
            dataGridView1.Columns.Add("Column1", "Кол-во 1С");
            dataGridView1.Columns.Add("Column1", "Кол-во Озон");


            foreach (var item in listProduct)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = item.Article;
                dataGridView1.Rows[i].Cells[1].Value = item.Name;
                dataGridView1.Rows[i].Cells[2].Value = item.Storage;
                dataGridView1.Rows[i].Cells[3].Value = item.Count1C;
                dataGridView1.Rows[i].Cells[4].Value = item.CountOzon;
                i++;
            }
        }
    }
}
