namespace DesktopPart
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tcMainMenu = new TabControl();
            tabPage1 = new TabPage();
            tcProducts = new TabControl();
            Add = new TabPage();
            lblProductDetails = new Label();
            panel1 = new Panel();
            lblImage = new Label();
            tbImage = new TextBox();
            pictureBox1 = new PictureBox();
            btnAddProduct = new Button();
            lblQuantity = new Label();
            lblCategory = new Label();
            lblSize = new Label();
            lblPrice = new Label();
            lblName = new Label();
            lblBrand = new Label();
            tbQuantity = new TextBox();
            tbBrand = new TextBox();
            tbName = new TextBox();
            tbCategory = new TextBox();
            tbPrice = new TextBox();
            tbSize = new TextBox();
            dgvProducts = new DataGridView();
            Products = new TabPage();
            Orders = new TabPage();
            tcMainMenu.SuspendLayout();
            tabPage1.SuspendLayout();
            tcProducts.SuspendLayout();
            Add.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // tcMainMenu
            // 
            tcMainMenu.Controls.Add(tabPage1);
            tcMainMenu.Controls.Add(Orders);
            tcMainMenu.Dock = DockStyle.Fill;
            tcMainMenu.Location = new Point(0, 0);
            tcMainMenu.Name = "tcMainMenu";
            tcMainMenu.SelectedIndex = 0;
            tcMainMenu.Size = new Size(982, 565);
            tcMainMenu.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tcProducts);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(974, 537);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Products";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tcProducts
            // 
            tcProducts.Controls.Add(Add);
            tcProducts.Controls.Add(Products);
            tcProducts.Dock = DockStyle.Fill;
            tcProducts.Location = new Point(3, 3);
            tcProducts.Multiline = true;
            tcProducts.Name = "tcProducts";
            tcProducts.SelectedIndex = 0;
            tcProducts.Size = new Size(968, 531);
            tcProducts.TabIndex = 0;
            // 
            // Add
            // 
            Add.Controls.Add(lblProductDetails);
            Add.Controls.Add(panel1);
            Add.Controls.Add(dgvProducts);
            Add.Location = new Point(4, 24);
            Add.Name = "Add";
            Add.Padding = new Padding(3);
            Add.Size = new Size(960, 503);
            Add.TabIndex = 0;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            // 
            // lblProductDetails
            // 
            lblProductDetails.AutoSize = true;
            lblProductDetails.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblProductDetails.Location = new Point(710, 7);
            lblProductDetails.Name = "lblProductDetails";
            lblProductDetails.Size = new Size(192, 20);
            lblProductDetails.TabIndex = 6;
            lblProductDetails.Text = "Enter product details below";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblImage);
            panel1.Controls.Add(tbImage);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnAddProduct);
            panel1.Controls.Add(lblQuantity);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(lblSize);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(lblBrand);
            panel1.Controls.Add(tbQuantity);
            panel1.Controls.Add(tbBrand);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(tbCategory);
            panel1.Controls.Add(tbPrice);
            panel1.Controls.Add(tbSize);
            panel1.Location = new Point(675, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 470);
            panel1.TabIndex = 7;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(34, 382);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(65, 15);
            lblImage.TabIndex = 15;
            lblImage.Text = "Image Link";
            // 
            // tbImage
            // 
            tbImage.Location = new Point(34, 400);
            tbImage.Name = "tbImage";
            tbImage.Size = new Size(192, 23);
            tbImage.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(42, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(59, 432);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(144, 29);
            btnAddProduct.TabIndex = 12;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(34, 338);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(53, 15);
            lblQuantity.TabIndex = 11;
            lblQuantity.Text = "Quantity";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(34, 293);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "Category";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(34, 248);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(27, 15);
            lblSize.TabIndex = 9;
            lblSize.Text = "Size";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(34, 203);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(34, 158);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 7;
            lblName.Text = "Name";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(34, 113);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(38, 15);
            lblBrand.TabIndex = 6;
            lblBrand.Text = "Brand";
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(34, 356);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(192, 23);
            tbQuantity.TabIndex = 5;
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(34, 131);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(192, 23);
            tbBrand.TabIndex = 0;
            // 
            // tbName
            // 
            tbName.Location = new Point(34, 176);
            tbName.Name = "tbName";
            tbName.Size = new Size(192, 23);
            tbName.TabIndex = 1;
            // 
            // tbCategory
            // 
            tbCategory.Location = new Point(34, 311);
            tbCategory.Name = "tbCategory";
            tbCategory.Size = new Size(192, 23);
            tbCategory.TabIndex = 4;
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(34, 221);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(192, 23);
            tbPrice.TabIndex = 2;
            // 
            // tbSize
            // 
            tbSize.Location = new Point(34, 266);
            tbSize.Name = "tbSize";
            tbSize.Size = new Size(192, 23);
            tbSize.TabIndex = 3;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(15, 16);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowTemplate.Height = 25;
            dgvProducts.Size = new Size(654, 470);
            dgvProducts.TabIndex = 6;
            dgvProducts.CellContentDoubleClick += dgvProducts_CellContentDoubleClick;
            // 
            // Products
            // 
            Products.Location = new Point(4, 24);
            Products.Name = "Products";
            Products.Padding = new Padding(3);
            Products.Size = new Size(960, 503);
            Products.TabIndex = 1;
            Products.Text = "All Products";
            Products.UseVisualStyleBackColor = true;
            // 
            // Orders
            // 
            Orders.Location = new Point(4, 24);
            Orders.Name = "Orders";
            Orders.Padding = new Padding(3);
            Orders.Size = new Size(974, 537);
            Orders.TabIndex = 1;
            Orders.Text = "Orders";
            Orders.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 565);
            Controls.Add(tcMainMenu);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            tcMainMenu.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tcProducts.ResumeLayout(false);
            Add.ResumeLayout(false);
            Add.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMainMenu;
        private TabPage tabPage1;
        private TabControl tcProducts;
        private TabPage Add;
        private TabPage Products;
        private TabPage Orders;
        private TextBox tbBrand;
        private Panel panel1;
        private TextBox tbQuantity;
        private TextBox tbName;
        private TextBox tbCategory;
        private TextBox tbPrice;
        private TextBox tbSize;
        private DataGridView dgvProducts;
        private Label lblProductDetails;
        private Label lblQuantity;
        private Label lblCategory;
        private Label lblSize;
        private Label lblPrice;
        private Label lblName;
        private Label lblBrand;
        private Button btnAddProduct;
        private PictureBox pictureBox1;
        private Label lblImage;
        private TextBox tbImage;
    }
}