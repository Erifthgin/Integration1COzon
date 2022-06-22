using Integration1COzon.Application.Abstractions.Connection1C;
using Integration1COzon.Application.Abstractions.Ozon;
using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Domanes.Object;
using Integration1COzon.Application.Handler;
using Integration1COzon.Ozon;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Integration1COzon.WinForms
{
    public partial class Form1 : Form
    {
        StorageType storageType = StorageType.CTC;
        private static IConnection1C _connection1c = new Connection1C.Connection1C();
        private static IOzonHandlerFactory _ozonFactory = new OzonHandlerFactory();
        private IntegrationHandler _integrationHandler = new IntegrationHandler(_ozonFactory, _connection1c);
        private static List<IntegrationData> ListProd=new List<IntegrationData>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            colCB.HeaderText = "Обновить";
            dataGridView1.Columns.Add(colCB);

            dataGridView1.Columns.Add("Column1", "Артикул");
            dataGridView1.Columns.Add("Column1", "Склад");
            dataGridView1.Columns.Add("Column1", "Кол-во 1С");
            dataGridView1.Columns.Add("Column1", "Кол-во Озон");
            dataGridView1.Columns.Add("Column1", "Название");
            dataGridView1.Columns.Add("Column1", "Offerid");
            dataGridView1.Columns.Add("Column1", "ProductId");
            dataGridView1.Columns.Add("Column1", "WarehouseId");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 1000;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();

            if (comboBox1.SelectedIndex != 0)
            {
                storageType = StorageType.PgJeweler;
            }
            var listProduct = _integrationHandler.Handle(storageType);
            int i = 0;

            foreach (var item in listProduct)
            {
                ListProd.Add(new IntegrationData { Article = item.Article, Count1C = item.Count1C, CountOzon = item.CountOzon, Name = item.Name, Offerid = item.Offerid, ProductId = item.ProductId, Storage = item.Storage, WarehouseId = item.WarehouseId });
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = item.Article;
                dataGridView1.Rows[i].Cells[2].Value = item.Storage;
                dataGridView1.Rows[i].Cells[3].Value = item.Count1C;
                dataGridView1.Rows[i].Cells[4].Value = item.CountOzon;
                dataGridView1.Rows[i].Cells[5].Value = item.Name;

                dataGridView1.Rows[i].Cells[6].Value = item.Offerid;
                dataGridView1.Rows[i].Cells[7].Value = item.ProductId;
                dataGridView1.Rows[i].Cells[8].Value = item.WarehouseId;
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            if (comboBox1.SelectedIndex != 0)
            {
                storageType = StorageType.PgJeweler;
            }

            var listProduct = _integrationHandler.Handle(storageType);
            int i = 0;

            foreach (var item in listProduct)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = item.Article;
                dataGridView1.Rows[i].Cells[2].Value = item.Storage;
                dataGridView1.Rows[i].Cells[3].Value = item.Count1C;
                dataGridView1.Rows[i].Cells[4].Value = item.CountOzon;
                dataGridView1.Rows[i].Cells[5].Value = item.Name;
                i++;
            }

        }

        private bool isChecked = true;
        private void button3_Click(object sender, EventArgs e)
        {
            if (isChecked)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = isChecked;
                }
                isChecked = false;
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = isChecked;
                }
                isChecked = true;
            }
        }
    }
}
