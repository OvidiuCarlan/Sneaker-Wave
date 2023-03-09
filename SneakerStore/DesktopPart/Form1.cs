using Logic.Logic;

namespace DesktopPart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductManager productManager = new ProductManager();

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string brand = tbBrand.Text;
            string name = tbName.Text;
            double price = Convert.ToDouble(tbPrice.Text);
            string size = tbSize.Text;
            string category = tbCategory.Text;
            int quantity = Convert.ToInt32(tbQuantity.Text);

            Product product = new Product(brand, name, price, size, category, quantity);
            productManager.AddProduct(product);

            MessageBox.Show("Product added");
            ClearProductFields();
        }

        public void ClearProductFields()
        {
            tbBrand.Text = "";
            tbName.Text = "";
            tbPrice.Text = "";
            tbSize.Text = "";
            tbCategory.Text = "";
            tbQuantity.Text = "";
        }
    }
}