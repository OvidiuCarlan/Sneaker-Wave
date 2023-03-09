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
            this.tcMainMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tcProducts = new System.Windows.Forms.TabControl();
            this.Add = new System.Windows.Forms.TabPage();
            this.lblProductDetails = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Products = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tcMainMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tcProducts.SuspendLayout();
            this.Add.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMainMenu
            // 
            this.tcMainMenu.Controls.Add(this.tabPage1);
            this.tcMainMenu.Controls.Add(this.tabPage2);
            this.tcMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tcMainMenu.Name = "tcMainMenu";
            this.tcMainMenu.SelectedIndex = 0;
            this.tcMainMenu.Size = new System.Drawing.Size(982, 565);
            this.tcMainMenu.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tcProducts);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 537);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Products";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tcProducts
            // 
            this.tcProducts.Controls.Add(this.Add);
            this.tcProducts.Controls.Add(this.Products);
            this.tcProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProducts.Location = new System.Drawing.Point(3, 3);
            this.tcProducts.Multiline = true;
            this.tcProducts.Name = "tcProducts";
            this.tcProducts.SelectedIndex = 0;
            this.tcProducts.Size = new System.Drawing.Size(968, 531);
            this.tcProducts.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Controls.Add(this.lblProductDetails);
            this.Add.Controls.Add(this.panel1);
            this.Add.Controls.Add(this.dataGridView1);
            this.Add.Location = new System.Drawing.Point(4, 24);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(3);
            this.Add.Size = new System.Drawing.Size(960, 503);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // lblProductDetails
            // 
            this.lblProductDetails.AutoSize = true;
            this.lblProductDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductDetails.Location = new System.Drawing.Point(710, 7);
            this.lblProductDetails.Name = "lblProductDetails";
            this.lblProductDetails.Size = new System.Drawing.Size(192, 20);
            this.lblProductDetails.TabIndex = 6;
            this.lblProductDetails.Text = "Enter product details below";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Controls.Add(this.tbQuantity);
            this.panel1.Controls.Add(this.tbBrand);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.tbCategory);
            this.panel1.Controls.Add(this.tbPrice);
            this.panel1.Controls.Add(this.tbSize);
            this.panel1.Location = new System.Drawing.Point(675, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 470);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(59, 409);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(144, 29);
            this.btnAddProduct.TabIndex = 12;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(34, 340);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 15);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(34, 296);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Category";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(34, 252);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 15);
            this.lblSize.TabIndex = 9;
            this.lblSize.Text = "Size";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(34, 206);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 15);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 160);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(34, 113);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 15);
            this.lblBrand.TabIndex = 6;
            this.lblBrand.Text = "Brand";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(34, 358);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(192, 23);
            this.tbQuantity.TabIndex = 5;
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(34, 131);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(192, 23);
            this.tbBrand.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(34, 178);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(192, 23);
            this.tbName.TabIndex = 1;
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(34, 314);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(192, 23);
            this.tbCategory.TabIndex = 4;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(34, 224);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(192, 23);
            this.tbPrice.TabIndex = 2;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(34, 270);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(192, 23);
            this.tbSize.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(654, 470);
            this.dataGridView1.TabIndex = 6;
            // 
            // Products
            // 
            this.Products.Location = new System.Drawing.Point(4, 24);
            this.Products.Name = "Products";
            this.Products.Padding = new System.Windows.Forms.Padding(3);
            this.Products.Size = new System.Drawing.Size(960, 503);
            this.Products.TabIndex = 1;
            this.Products.Text = "All Products";
            this.Products.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(974, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 565);
            this.Controls.Add(this.tcMainMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tcMainMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tcProducts.ResumeLayout(false);
            this.Add.ResumeLayout(false);
            this.Add.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tcMainMenu;
        private TabPage tabPage1;
        private TabControl tcProducts;
        private TabPage Add;
        private TabPage Products;
        private TabPage tabPage2;
        private TextBox tbBrand;
        private Panel panel1;
        private TextBox tbQuantity;
        private TextBox tbName;
        private TextBox tbCategory;
        private TextBox tbPrice;
        private TextBox tbSize;
        private DataGridView dataGridView1;
        private Label lblProductDetails;
        private Label lblQuantity;
        private Label lblCategory;
        private Label lblSize;
        private Label lblPrice;
        private Label lblName;
        private Label lblBrand;
        private Button btnAddProduct;
        private PictureBox pictureBox1;
    }
}