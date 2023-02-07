namespace OrderForm2
{
    partial class product_list
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(product_list));
            this.listView產品列表 = new System.Windows.Forms.ListView();
            this.imageList產品圖檔 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.member_Center = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel_Product_info = new System.Windows.Forms.Panel();
            this.btn_Go_cart = new System.Windows.Forms.Button();
            this.btn_Add_cart = new System.Windows.Forms.Button();
            this.back_product_list = new System.Windows.Forms.PictureBox();
            this.pinfo_Desc = new System.Windows.Forms.TextBox();
            this.cbox_Addon = new System.Windows.Forms.ComboBox();
            this.buy_Count = new System.Windows.Forms.TextBox();
            this.pinfo_Id = new System.Windows.Forms.Label();
            this.pinfo_Price = new System.Windows.Forms.Label();
            this.pinfo_Name = new System.Windows.Forms.Label();
            this.pinfo_Image = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cart_Link = new System.Windows.Forms.Label();
            this.marquee = new System.Windows.Forms.Timer(this.components);
            this.marquee_tx = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel_Product_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_product_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinfo_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // listView產品列表
            // 
            this.listView產品列表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView產品列表.HideSelection = false;
            this.listView產品列表.Location = new System.Drawing.Point(22, 308);
            this.listView產品列表.Name = "listView產品列表";
            this.listView產品列表.Size = new System.Drawing.Size(510, 441);
            this.listView產品列表.TabIndex = 0;
            this.listView產品列表.UseCompatibleStateImageBehavior = false;
            this.listView產品列表.ItemActivate += new System.EventHandler(this.listView產品列表_ItemActivate);
            // 
            // imageList產品圖檔
            // 
            this.imageList產品圖檔.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList產品圖檔.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList產品圖檔.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(535, 178);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGreen;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(535, 56);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // member_Center
            // 
            this.member_Center.BackColor = System.Drawing.Color.DarkGreen;
            this.member_Center.Cursor = System.Windows.Forms.Cursors.Hand;
            this.member_Center.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.member_Center.ForeColor = System.Drawing.Color.White;
            this.member_Center.Location = new System.Drawing.Point(425, 18);
            this.member_Center.Name = "member_Center";
            this.member_Center.Size = new System.Drawing.Size(79, 22);
            this.member_Center.TabIndex = 7;
            this.member_Center.Text = "會員中心";
            this.member_Center.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.member_Center.Click += new System.EventHandler(this.member_Center_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(30, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(144, 45);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DarkGreen;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(404, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // panel_Product_info
            // 
            this.panel_Product_info.Controls.Add(this.btn_Go_cart);
            this.panel_Product_info.Controls.Add(this.btn_Add_cart);
            this.panel_Product_info.Controls.Add(this.back_product_list);
            this.panel_Product_info.Controls.Add(this.pinfo_Desc);
            this.panel_Product_info.Controls.Add(this.cbox_Addon);
            this.panel_Product_info.Controls.Add(this.buy_Count);
            this.panel_Product_info.Controls.Add(this.pinfo_Id);
            this.panel_Product_info.Controls.Add(this.pinfo_Price);
            this.panel_Product_info.Controls.Add(this.pinfo_Name);
            this.panel_Product_info.Controls.Add(this.pinfo_Image);
            this.panel_Product_info.Location = new System.Drawing.Point(0, 269);
            this.panel_Product_info.Name = "panel_Product_info";
            this.panel_Product_info.Size = new System.Drawing.Size(535, 527);
            this.panel_Product_info.TabIndex = 10;
            this.panel_Product_info.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Product_info_Paint);
            // 
            // btn_Go_cart
            // 
            this.btn_Go_cart.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_Go_cart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Go_cart.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Go_cart.ForeColor = System.Drawing.Color.White;
            this.btn_Go_cart.Location = new System.Drawing.Point(270, 420);
            this.btn_Go_cart.Name = "btn_Go_cart";
            this.btn_Go_cart.Size = new System.Drawing.Size(201, 50);
            this.btn_Go_cart.TabIndex = 37;
            this.btn_Go_cart.Text = "查看購物車";
            this.btn_Go_cart.UseVisualStyleBackColor = false;
            this.btn_Go_cart.Click += new System.EventHandler(this.btn_Go_cart_Click);
            // 
            // btn_Add_cart
            // 
            this.btn_Add_cart.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Add_cart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add_cart.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Add_cart.ForeColor = System.Drawing.Color.White;
            this.btn_Add_cart.Location = new System.Drawing.Point(60, 420);
            this.btn_Add_cart.Name = "btn_Add_cart";
            this.btn_Add_cart.Size = new System.Drawing.Size(201, 50);
            this.btn_Add_cart.TabIndex = 36;
            this.btn_Add_cart.Text = "加入訂購單";
            this.btn_Add_cart.UseVisualStyleBackColor = false;
            this.btn_Add_cart.Click += new System.EventHandler(this.btn_Add_cart_Click);
            // 
            // back_product_list
            // 
            this.back_product_list.BackColor = System.Drawing.Color.White;
            this.back_product_list.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_product_list.BackgroundImage")));
            this.back_product_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.back_product_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_product_list.Location = new System.Drawing.Point(502, 13);
            this.back_product_list.Name = "back_product_list";
            this.back_product_list.Size = new System.Drawing.Size(20, 20);
            this.back_product_list.TabIndex = 15;
            this.back_product_list.TabStop = false;
            this.back_product_list.Click += new System.EventHandler(this.back_product_list_Click);
            // 
            // pinfo_Desc
            // 
            this.pinfo_Desc.BackColor = System.Drawing.Color.White;
            this.pinfo_Desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pinfo_Desc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pinfo_Desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pinfo_Desc.Location = new System.Drawing.Point(32, 269);
            this.pinfo_Desc.Multiline = true;
            this.pinfo_Desc.Name = "pinfo_Desc";
            this.pinfo_Desc.ReadOnly = true;
            this.pinfo_Desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pinfo_Desc.Size = new System.Drawing.Size(472, 100);
            this.pinfo_Desc.TabIndex = 23;
            this.pinfo_Desc.Text = "內文";
            // 
            // cbox_Addon
            // 
            this.cbox_Addon.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbox_Addon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbox_Addon.FormattingEnabled = true;
            this.cbox_Addon.Location = new System.Drawing.Point(254, 193);
            this.cbox_Addon.Name = "cbox_Addon";
            this.cbox_Addon.Size = new System.Drawing.Size(250, 30);
            this.cbox_Addon.TabIndex = 7;
            this.cbox_Addon.Text = "加購品項";
            this.cbox_Addon.SelectedIndexChanged += new System.EventHandler(this.cbox_Addon_SelectedIndexChanged);
            // 
            // buy_Count
            // 
            this.buy_Count.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buy_Count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buy_Count.Location = new System.Drawing.Point(254, 149);
            this.buy_Count.MaxLength = 2;
            this.buy_Count.Name = "buy_Count";
            this.buy_Count.Size = new System.Drawing.Size(250, 30);
            this.buy_Count.TabIndex = 5;
            this.buy_Count.Text = "1";
            this.buy_Count.TextChanged += new System.EventHandler(this.buy_Count_TextChanged);
            // 
            // pinfo_Id
            // 
            this.pinfo_Id.AutoSize = true;
            this.pinfo_Id.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pinfo_Id.ForeColor = System.Drawing.Color.White;
            this.pinfo_Id.Location = new System.Drawing.Point(250, 35);
            this.pinfo_Id.Name = "pinfo_Id";
            this.pinfo_Id.Size = new System.Drawing.Size(26, 20);
            this.pinfo_Id.TabIndex = 4;
            this.pinfo_Id.Text = "ID";
            // 
            // pinfo_Price
            // 
            this.pinfo_Price.AutoSize = true;
            this.pinfo_Price.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pinfo_Price.ForeColor = System.Drawing.Color.Red;
            this.pinfo_Price.Location = new System.Drawing.Point(250, 105);
            this.pinfo_Price.Name = "pinfo_Price";
            this.pinfo_Price.Size = new System.Drawing.Size(44, 22);
            this.pinfo_Price.TabIndex = 2;
            this.pinfo_Price.Text = "價格";
            // 
            // pinfo_Name
            // 
            this.pinfo_Name.AutoSize = true;
            this.pinfo_Name.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pinfo_Name.ForeColor = System.Drawing.Color.Black;
            this.pinfo_Name.Location = new System.Drawing.Point(250, 65);
            this.pinfo_Name.Name = "pinfo_Name";
            this.pinfo_Name.Size = new System.Drawing.Size(86, 24);
            this.pinfo_Name.TabIndex = 1;
            this.pinfo_Name.Text = "產品名稱";
            // 
            // pinfo_Image
            // 
            this.pinfo_Image.Location = new System.Drawing.Point(30, 44);
            this.pinfo_Image.Name = "pinfo_Image";
            this.pinfo_Image.Size = new System.Drawing.Size(200, 200);
            this.pinfo_Image.TabIndex = 0;
            this.pinfo_Image.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DarkGreen;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(300, 19);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // cart_Link
            // 
            this.cart_Link.AutoSize = true;
            this.cart_Link.BackColor = System.Drawing.Color.DarkGreen;
            this.cart_Link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cart_Link.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cart_Link.ForeColor = System.Drawing.Color.White;
            this.cart_Link.Location = new System.Drawing.Point(323, 18);
            this.cart_Link.Name = "cart_Link";
            this.cart_Link.Size = new System.Drawing.Size(61, 22);
            this.cart_Link.TabIndex = 13;
            this.cart_Link.Text = "購物車";
            this.cart_Link.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cart_Link.Click += new System.EventHandler(this.cart_Link_Click);
            // 
            // marquee
            // 
            this.marquee.Enabled = true;
            this.marquee.Tick += new System.EventHandler(this.marquee_Tick);
            // 
            // marquee_tx
            // 
            this.marquee_tx.AutoSize = true;
            this.marquee_tx.BackColor = System.Drawing.Color.DarkKhaki;
            this.marquee_tx.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.marquee_tx.ForeColor = System.Drawing.Color.White;
            this.marquee_tx.Location = new System.Drawing.Point(186, 241);
            this.marquee_tx.Name = "marquee_tx";
            this.marquee_tx.Size = new System.Drawing.Size(334, 21);
            this.marquee_tx.TabIndex = 15;
            this.marquee_tx.Text = "祕密活動進行中！！隱藏優惠等你來發現~~~";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox6.Location = new System.Drawing.Point(0, 234);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(535, 35);
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // product_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 761);
            this.Controls.Add(this.marquee_tx);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.cart_Link);
            this.Controls.Add(this.panel_Product_info);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.member_Center);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listView產品列表);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "product_list";
            this.Text = "產品列表";
            this.Load += new System.EventHandler(this.product_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel_Product_info.ResumeLayout(false);
            this.panel_Product_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_product_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinfo_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView產品列表;
        private System.Windows.Forms.ImageList imageList產品圖檔;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label member_Center;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel_Product_info;
        private System.Windows.Forms.Label pinfo_Price;
        private System.Windows.Forms.Label pinfo_Name;
        private System.Windows.Forms.PictureBox pinfo_Image;
        private System.Windows.Forms.Label pinfo_Id;
        private System.Windows.Forms.ComboBox cbox_Addon;
        private System.Windows.Forms.TextBox buy_Count;
        private System.Windows.Forms.TextBox pinfo_Desc;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label cart_Link;
        private System.Windows.Forms.PictureBox back_product_list;
        private System.Windows.Forms.Button btn_Go_cart;
        private System.Windows.Forms.Button btn_Add_cart;
        private System.Windows.Forms.Timer marquee;
        private System.Windows.Forms.Label marquee_tx;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

