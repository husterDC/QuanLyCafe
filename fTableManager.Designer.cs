﻿namespace QuanLyCafe
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.listwBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.textTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nUDDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nUDFood = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCaterogy = new System.Windows.Forms.ComboBox();
            this.flpanelTable = new System.Windows.Forms.FlowLayoutPanel();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuẩtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiscount)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFood)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listwBill);
            this.panel3.Location = new System.Drawing.Point(477, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 253);
            this.panel3.TabIndex = 2;
            // 
            // listwBill
            // 
            this.listwBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listwBill.GridLines = true;
            this.listwBill.HideSelection = false;
            this.listwBill.Location = new System.Drawing.Point(2, 3);
            this.listwBill.Name = "listwBill";
            this.listwBill.Size = new System.Drawing.Size(327, 242);
            this.listwBill.TabIndex = 0;
            this.listwBill.UseCompatibleStateImageBehavior = false;
            this.listwBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 68;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 82;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textTotalPrice);
            this.panel5.Controls.Add(this.cbSwitchTable);
            this.panel5.Controls.Add(this.btnSwitchTable);
            this.panel5.Controls.Add(this.nUDDiscount);
            this.panel5.Controls.Add(this.btnDiscount);
            this.panel5.Controls.Add(this.btnPay);
            this.panel5.Location = new System.Drawing.Point(477, 356);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(332, 82);
            this.panel5.TabIndex = 3;
            // 
            // textTotalPrice
            // 
            this.textTotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.textTotalPrice.Location = new System.Drawing.Point(159, 46);
            this.textTotalPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textTotalPrice.Name = "textTotalPrice";
            this.textTotalPrice.ReadOnly = true;
            this.textTotalPrice.Size = new System.Drawing.Size(96, 24);
            this.textTotalPrice.TabIndex = 7;
            this.textTotalPrice.TabStop = false;
            this.textTotalPrice.Text = "0";
            this.textTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(3, 50);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(79, 21);
            this.cbSwitchTable.TabIndex = 4;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(3, 4);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(78, 41);
            this.btnSwitchTable.TabIndex = 6;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nUDDiscount
            // 
            this.nUDDiscount.Location = new System.Drawing.Point(87, 51);
            this.nUDDiscount.Name = "nUDDiscount";
            this.nUDDiscount.Size = new System.Drawing.Size(59, 20);
            this.nUDDiscount.TabIndex = 5;
            this.nUDDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(87, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(59, 41);
            this.btnDiscount.TabIndex = 4;
            this.btnDiscount.Text = "Giảm giá (%)";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(260, 4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(69, 67);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Thoanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nUDFood);
            this.panel6.Controls.Add(this.btnAddFood);
            this.panel6.Controls.Add(this.cbFood);
            this.panel6.Controls.Add(this.cbCaterogy);
            this.panel6.Location = new System.Drawing.Point(477, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(332, 66);
            this.panel6.TabIndex = 4;
            // 
            // nUDFood
            // 
            this.nUDFood.Location = new System.Drawing.Point(266, 19);
            this.nUDFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nUDFood.Name = "nUDFood";
            this.nUDFood.Size = new System.Drawing.Size(35, 20);
            this.nUDFood.TabIndex = 3;
            this.nUDFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(190, 3);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(70, 48);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 30);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(181, 21);
            this.cbFood.TabIndex = 1;
            // 
            // cbCaterogy
            // 
            this.cbCaterogy.FormattingEnabled = true;
            this.cbCaterogy.Location = new System.Drawing.Point(3, 3);
            this.cbCaterogy.Name = "cbCaterogy";
            this.cbCaterogy.Size = new System.Drawing.Size(181, 21);
            this.cbCaterogy.TabIndex = 0;
            this.cbCaterogy.SelectedIndexChanged += new System.EventHandler(this.cbFood_SelectedIndexChanged);
            // 
            // flpanelTable
            // 
            this.flpanelTable.AutoScroll = true;
            this.flpanelTable.Location = new System.Drawing.Point(12, 27);
            this.flpanelTable.Name = "flpanelTable";
            this.flpanelTable.Size = new System.Drawing.Size(440, 409);
            this.flpanelTable.TabIndex = 5;
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuẩtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuẩtToolStripMenuItem
            // 
            this.đăngXuẩtToolStripMenuItem.Name = "đăngXuẩtToolStripMenuItem";
            this.đăngXuẩtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đăngXuẩtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuẩtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuẩtToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 466);
            this.Controls.Add(this.flpanelTable);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.Text = "Phần mềm quản lí";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDiscount)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDFood)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listwBill;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCaterogy;
        private System.Windows.Forms.NumericUpDown nUDFood;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.FlowLayoutPanel flpanelTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.NumericUpDown nUDDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuẩtToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}