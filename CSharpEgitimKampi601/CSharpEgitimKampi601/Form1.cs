using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        CustomerOperations customerOperations = new CustomerOperations();
        private void txtCustomerCreate_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text)
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Müşteri Ekleme İşlemi Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
           string customerId = txtCustomerId.Text;
           customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Müşteri Başarıyla Silindi");
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var updateCustomer = new Customer()
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerShoppingCount = int.Parse(txtCustomerShoppingCount.Text)
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Müşteri Bilgileri Başarıyla Güncellendi");
        }

        private void btnGetByCustomerId_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers };
        }
    }
}
