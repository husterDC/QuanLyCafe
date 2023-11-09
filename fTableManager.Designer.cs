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
            this.listwFood = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nUDDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nUDFood = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbPrice = new System.Windows.Forms.ComboBox();
            this.cbFood = new System.Windows.Forms.ComboBox();
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
            this.panel3.Controls.Add(this.listwFood);
            this.panel3.Location = new System.Drawing.Point(636, 119);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 331);
            this.panel3.TabIndex = 2;
            // 
            // listwFood
            // 
            this.listwFood.HideSelection = false;
            this.listwFood.Location = new System.Drawing.Point(0, 4);
            this.listwFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listwFood.Name = "listwFood";
            this.listwFood.Size = new System.Drawing.Size(396, 326);
            this.listwFood.TabIndex = 0;
            this.listwFood.UseCompatibleStateImageBehavior = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbSwitchTable);
            this.panel5.Controls.Add(this.btnSwitchTable);
            this.panel5.Controls.Add(this.nUDDiscount);
            this.panel5.Controls.Add(this.btnDiscount);
            this.panel5.Controls.Add(this.btnPay);
            this.panel5.Location = new System.Drawing.Point(636, 458);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(401, 81);
            this.panel5.TabIndex = 3;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(4, 48);
            this.cbSwitchTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(103, 24);
            this.cbSwitchTable.TabIndex = 4;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(4, 5);
            this.btnSwitchTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(104, 37);
            this.btnSwitchTable.TabIndex = 6;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            // 
            // nUDDiscount
            // 
            this.nUDDiscount.Location = new System.Drawing.Point(167, 49);
            this.nUDDiscount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nUDDiscount.Name = "nUDDiscount";
            this.nUDDiscount.Size = new System.Drawing.Size(93, 22);
            this.nUDDiscount.TabIndex = 5;
            this.nUDDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(167, 5);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(93, 37);
            this.btnDiscount.TabIndex = 4;
            this.btnDiscount.Text = "Giảm giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(304, 4);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(93, 74);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Thoan toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nUDFood);
            this.panel6.Controls.Add(this.btnAddFood);
            this.panel6.Controls.Add(this.cbPrice);
            this.panel6.Controls.Add(this.cbFood);
            this.panel6.Location = new System.Drawing.Point(636, 33);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(401, 81);
            this.panel6.TabIndex = 4;
            // 
            // nUDFood
            // 
            this.nUDFood.Location = new System.Drawing.Point(355, 23);
            this.nUDFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nUDFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nUDFood.Name = "nUDFood";
            this.nUDFood.Size = new System.Drawing.Size(47, 22);
            this.nUDFood.TabIndex = 3;
            this.nUDFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(253, 4);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(93, 59);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            // 
            // cbPrice
            // 
            this.cbPrice.FormattingEnabled = true;
            this.cbPrice.Location = new System.Drawing.Point(4, 37);
            this.cbPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPrice.Name = "cbPrice";
            this.cbPrice.Size = new System.Drawing.Size(240, 24);
            this.cbPrice.TabIndex = 1;
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(4, 4);
            this.cbFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(240, 24);
            this.cbFood.TabIndex = 0;
            // 
            // flpanelTable
            // 
            this.flpanelTable.AutoScroll = true;
            this.flpanelTable.Location = new System.Drawing.Point(16, 33);
            this.flpanelTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpanelTable.Name = "flpanelTable";
            this.flpanelTable.Size = new System.Drawing.Size(612, 503);
            this.flpanelTable.TabIndex = 5;
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuẩtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuẩtToolStripMenuItem
            // 
            this.đăngXuẩtToolStripMenuItem.Name = "đăngXuẩtToolStripMenuItem";
            this.đăngXuẩtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuẩtToolStripMenuItem.Text = "Đăng xuẩt";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.flpanelTable);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fTableManager";
            this.Text = "Phần mềm quản lí";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
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
        private System.Windows.Forms.ListView listwFood;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbPrice;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.NumericUpDown nUDFood;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.FlowLayoutPanel flpanelTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.NumericUpDown nUDDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuẩtToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}