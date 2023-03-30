using DAL.DBs;
using Logic.Interfaces;
using Logic.Logic;
using Logic.Models;

namespace DesktopPart
{
    public partial class Form1 : Form
    {
        ProductManager productManager;
        List<Product> products;
        public Form1()
        {
            InitializeComponent();     
            productManager = new ProductManager(new ProductDataHandler());
            products = productManager.GetAll();
        }     
        
        private void Form1_Load_1(object sender, EventArgs e)
        {
            dgvProducts.ReadOnly = true;
            RefreshProductsDgv();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string brand = tbBrand.Text;
            string name = tbName.Text;
            double price = Convert.ToDouble(tbPrice.Text);
            string size = tbSize.Text;
            string category = tbCategory.Text;
            int quantity = Convert.ToInt32(tbQuantity.Text);
            string image = tbImage.Text;

            Product product = new Product(brand, name, price, size, category, quantity, image);
            productManager.AddProduct(product);

            MessageBox.Show("Product added");
            ClearProductFields();
            RefreshProductsDgv();
        }

        public void ClearProductFields()
        {
            tbBrand.Clear();
            tbName.Clear();
            tbPrice.Clear();
            tbSize.Clear();
            tbCategory.Clear();
            tbQuantity.Clear();
            tbImage.Clear();
        }
        public void RefreshProductsDgv()
        {            
            dgvProducts.DataSource = products;
            dgvProducts.Update();
            dgvProducts.Refresh();
        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvProducts.CurrentRow.Index;
            DataGridViewRow selectedRow = dgvProducts.Rows[index];
                        
            EditProduct editProduct = new EditProduct(products[index], this);
            editProduct.ShowDialog();
        }
    }
}