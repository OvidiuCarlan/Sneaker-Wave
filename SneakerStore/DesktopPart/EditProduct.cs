using DAL.DBs;
using Logic.Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopPart
{
    public partial class EditProduct : Form
    {
        private Form1 _form1;

        ProductManager productManager;
        int productId;
        public EditProduct(Product product, Form1 form1)
        {
            InitializeComponent();

            productManager = new ProductManager(new ProductDataHandler());

            tbBrand.Text = product.Brand;
            tbName.Text = product.Name;
            tbPrice.Text = product.Price.ToString();
            //tbSize.Text = product.Size;
            tbCategory.Text = product.Category;
            //tbQuantity.Text = product.Quantity.ToString();
            tbImage.Text = product.Image;
            productId = product.Id;

            _form1 = form1;
        }
        
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            string brand = tbBrand.Text;
            string name = tbName.Text;
            double price = Convert.ToDouble(tbPrice.Text);
            string size = tbSize.Text;
            string category = tbCategory.Text;
            int quantity = Convert.ToInt32(tbQuantity.Text);
            string image = tbImage.Text;

            Product newProduct = new Product(productId ,brand, name, price, category, image);

            productManager.EditProduct(newProduct);
            _form1.RefreshProductsDgv();
            this.Close();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            productManager.RemoveProduct(productId);
            _form1.RefreshProductsDgv();
            this.Close();
        }
    }
}
