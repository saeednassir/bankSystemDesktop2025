namespace BankOfPalestineSystemDesktopAppPresentationLayer.Accounts
{
    partial class frmfrmAddUpdateAccount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmfrmAddUpdateAccount));
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbIconHeader = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitleHeader = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.CtrlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.cbCurrency = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tpAccountInfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAccountType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tcAccountInfo = new System.Windows.Forms.TabControl();
            this.tpClientInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlClientCardWithFilter1 = new BankOfPalestineSystemDesktopAppPresentationLayer.Clients.Controls.ctrlClientCardWithFilter();
            this.lblTitleBody = new System.Windows.Forms.Label();
            this.pbIconBody = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconHeader)).BeginInit();
            this.tpAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tcAccountInfo.SuspendLayout();
            this.tpClientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconBody)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pbIconHeader);
            this.guna2Panel1.Controls.Add(this.lblTitleHeader);
            this.guna2Panel1.Controls.Add(this.gunaControlBox2);
            this.guna2Panel1.Controls.Add(this.CtrlBoxClose);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(709, 45);
            this.guna2Panel1.TabIndex = 24;
            // 
            // pbIconHeader
            // 
            this.pbIconHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIconHeader.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.wallet1;
            this.pbIconHeader.Location = new System.Drawing.Point(666, 6);
            this.pbIconHeader.Name = "pbIconHeader";
            this.pbIconHeader.ShadowDecoration.Parent = this.pbIconHeader;
            this.pbIconHeader.Size = new System.Drawing.Size(32, 32);
            this.pbIconHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconHeader.TabIndex = 16;
            this.pbIconHeader.TabStop = false;
            // 
            // lblTitleHeader
            // 
            this.lblTitleHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleHeader.ForeColor = System.Drawing.Color.Black;
            this.lblTitleHeader.Location = new System.Drawing.Point(473, 12);
            this.lblTitleHeader.Name = "lblTitleHeader";
            this.lblTitleHeader.Size = new System.Drawing.Size(187, 23);
            this.lblTitleHeader.TabIndex = 15;
            this.lblTitleHeader.Text = "إضافة حساب جديد";
            this.lblTitleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Gray;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(63, 9);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 13;
            // 
            // CtrlBoxClose
            // 
            this.CtrlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlBoxClose.AnimationHoverSpeed = 0.07F;
            this.CtrlBoxClose.AnimationSpeed = 0.03F;
            this.CtrlBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.CtrlBoxClose.IconColor = System.Drawing.Color.Gray;
            this.CtrlBoxClose.IconSize = 15F;
            this.CtrlBoxClose.Location = new System.Drawing.Point(12, 9);
            this.CtrlBoxClose.Name = "CtrlBoxClose";
            this.CtrlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.CtrlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.CtrlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.CtrlBoxClose.Size = new System.Drawing.Size(45, 29);
            this.CtrlBoxClose.TabIndex = 14;
            // 
            // cbCurrency
            // 
            this.cbCurrency.AutoRoundedCorners = true;
            this.cbCurrency.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrency.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.cbCurrency.BorderRadius = 17;
            this.cbCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrency.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbCurrency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbCurrency.FocusedState.Parent = this.cbCurrency;
            this.cbCurrency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbCurrency.HoverState.Parent = this.cbCurrency;
            this.cbCurrency.ItemHeight = 30;
            this.cbCurrency.ItemsAppearance.Parent = this.cbCurrency;
            this.cbCurrency.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbCurrency.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbCurrency.Location = new System.Drawing.Point(274, 276);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.ShadowDecoration.Parent = this.cbCurrency;
            this.cbCurrency.Size = new System.Drawing.Size(215, 36);
            this.cbCurrency.TabIndex = 20;
            this.cbCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tpAccountInfo
            // 
            this.tpAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.tpAccountInfo.Controls.Add(this.cbCurrency);
            this.tpAccountInfo.Controls.Add(this.label2);
            this.tpAccountInfo.Controls.Add(this.cbAccountType);
            this.tpAccountInfo.Controls.Add(this.label12);
            this.tpAccountInfo.Controls.Add(this.lblAccountID);
            this.tpAccountInfo.Controls.Add(this.lblAccountNumber);
            this.tpAccountInfo.Controls.Add(this.label5);
            this.tpAccountInfo.Controls.Add(this.label1);
            this.tpAccountInfo.Controls.Add(this.guna2PictureBox2);
            this.tpAccountInfo.Controls.Add(this.guna2PictureBox10);
            this.tpAccountInfo.Controls.Add(this.guna2PictureBox5);
            this.tpAccountInfo.Controls.Add(this.guna2PictureBox1);
            this.tpAccountInfo.Location = new System.Drawing.Point(4, 24);
            this.tpAccountInfo.Name = "tpAccountInfo";
            this.tpAccountInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccountInfo.Size = new System.Drawing.Size(682, 562);
            this.tpAccountInfo.TabIndex = 1;
            this.tpAccountInfo.Text = "معلومات الحساب";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(536, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 30);
            this.label2.TabIndex = 21;
            this.label2.Text = "العملة :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAccountType
            // 
            this.cbAccountType.AutoRoundedCorners = true;
            this.cbAccountType.BackColor = System.Drawing.Color.Transparent;
            this.cbAccountType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.cbAccountType.BorderRadius = 17;
            this.cbAccountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbAccountType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbAccountType.FocusedState.Parent = this.cbAccountType;
            this.cbAccountType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountType.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbAccountType.HoverState.Parent = this.cbAccountType;
            this.cbAccountType.ItemHeight = 30;
            this.cbAccountType.ItemsAppearance.Parent = this.cbAccountType;
            this.cbAccountType.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbAccountType.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbAccountType.Location = new System.Drawing.Point(274, 230);
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.ShadowDecoration.Parent = this.cbAccountType;
            this.cbAccountType.Size = new System.Drawing.Size(215, 36);
            this.cbAccountType.TabIndex = 20;
            this.cbAccountType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(536, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 30);
            this.label12.TabIndex = 21;
            this.label12.Text = "نوع الحساب :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountID
            // 
            this.lblAccountID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAccountID.Location = new System.Drawing.Point(292, 150);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(201, 30);
            this.lblAccountID.TabIndex = 17;
            this.lblAccountID.Text = "؟؟؟؟";
            this.lblAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAccountNumber.Location = new System.Drawing.Point(292, 190);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(201, 30);
            this.lblAccountNumber.TabIndex = 17;
            this.lblAccountNumber.Text = "؟؟؟؟";
            this.lblAccountNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(536, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "ID :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(536, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "رقم الحساب :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.exchange__1_;
            this.guna2PictureBox2.Location = new System.Drawing.Point(499, 281);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 22;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox10.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.money_management__2_1;
            this.guna2PictureBox10.Location = new System.Drawing.Point(499, 235);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.ShadowDecoration.Parent = this.guna2PictureBox10;
            this.guna2PictureBox10.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox10.TabIndex = 22;
            this.guna2PictureBox10.TabStop = false;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.number_blocks;
            this.guna2PictureBox5.Location = new System.Drawing.Point(499, 148);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.ShadowDecoration.Parent = this.guna2PictureBox5;
            this.guna2PictureBox5.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 19;
            this.guna2PictureBox5.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.number_blocks;
            this.guna2PictureBox1.Location = new System.Drawing.Point(499, 188);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 19;
            this.guna2PictureBox1.TabStop = false;
            // 
            // tcAccountInfo
            // 
            this.tcAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAccountInfo.Controls.Add(this.tpClientInfo);
            this.tcAccountInfo.Controls.Add(this.tpAccountInfo);
            this.tcAccountInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAccountInfo.Location = new System.Drawing.Point(12, 112);
            this.tcAccountInfo.Name = "tcAccountInfo";
            this.tcAccountInfo.RightToLeftLayout = true;
            this.tcAccountInfo.SelectedIndex = 0;
            this.tcAccountInfo.Size = new System.Drawing.Size(690, 590);
            this.tcAccountInfo.TabIndex = 26;
            // 
            // tpClientInfo
            // 
            this.tpClientInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.tpClientInfo.Controls.Add(this.btnNext);
            this.tpClientInfo.Controls.Add(this.ctrlClientCardWithFilter1);
            this.tpClientInfo.Location = new System.Drawing.Point(4, 24);
            this.tpClientInfo.Name = "tpClientInfo";
            this.tpClientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClientInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tpClientInfo.Size = new System.Drawing.Size(682, 562);
            this.tpClientInfo.TabIndex = 0;
            this.tpClientInfo.Text = "معلومات العميل";
            // 
            // btnNext
            // 
            this.btnNext.AutoRoundedCorners = true;
            this.btnNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.BorderColor = System.Drawing.Color.Gray;
            this.btnNext.BorderRadius = 18;
            this.btnNext.BorderThickness = 1;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnNext.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.previous__1_;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.previous;
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNext.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnNext.ImageSize = new System.Drawing.Size(16, 16);
            this.btnNext.Location = new System.Drawing.Point(22, 515);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(137, 38);
            this.btnNext.TabIndex = 30;
            this.btnNext.Text = "التالي";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlClientCardWithFilter1
            // 
            this.ctrlClientCardWithFilter1.FilterEnabled = true;
            this.ctrlClientCardWithFilter1.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.ctrlClientCardWithFilter1.Location = new System.Drawing.Point(22, 6);
            this.ctrlClientCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlClientCardWithFilter1.Name = "ctrlClientCardWithFilter1";
            this.ctrlClientCardWithFilter1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlClientCardWithFilter1.ShowAddClient = true;
            this.ctrlClientCardWithFilter1.Size = new System.Drawing.Size(656, 498);
            this.ctrlClientCardWithFilter1.TabIndex = 21;
            // 
            // lblTitleBody
            // 
            this.lblTitleBody.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.lblTitleBody.Location = new System.Drawing.Point(0, 54);
            this.lblTitleBody.Name = "lblTitleBody";
            this.lblTitleBody.Size = new System.Drawing.Size(709, 52);
            this.lblTitleBody.TabIndex = 25;
            this.lblTitleBody.Text = "إضافة حساب جديد";
            this.lblTitleBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbIconBody
            // 
            this.pbIconBody.BackColor = System.Drawing.Color.Transparent;
            this.pbIconBody.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.wallet1;
            this.pbIconBody.Location = new System.Drawing.Point(590, 57);
            this.pbIconBody.Name = "pbIconBody";
            this.pbIconBody.ShadowDecoration.Parent = this.pbIconBody;
            this.pbIconBody.Size = new System.Drawing.Size(100, 70);
            this.pbIconBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconBody.TabIndex = 29;
            this.pbIconBody.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.BorderRadius = 17;
            this.btnSave.BorderThickness = 1;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnSave.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.diskette;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.diskette__1_;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSave.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnSave.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSave.Location = new System.Drawing.Point(413, 714);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(137, 36);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.BorderRadius = 17;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.delete2;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.delete__1_;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClose.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(560, 714);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(137, 36);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "إغلاق";
            // 
            // frmfrmAddUpdateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(709, 762);
            this.Controls.Add(this.pbIconBody);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.tcAccountInfo);
            this.Controls.Add(this.lblTitleBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 20);
            this.Name = "frmfrmAddUpdateAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "إضافة/تعديل حساب";
            this.Load += new System.EventHandler(this.frmfrmAddUpdateAccount_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconHeader)).EndInit();
            this.tpAccountInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tcAccountInfo.ResumeLayout(false);
            this.tpClientInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconBody)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2PictureBox pbIconBody;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox pbIconHeader;
        private System.Windows.Forms.Label lblTitleHeader;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox CtrlBoxClose;
        private Guna.UI2.WinForms.Guna2ComboBox cbCurrency;
        private System.Windows.Forms.TabPage tpAccountInfo;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbAccountType;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcAccountInfo;
        private System.Windows.Forms.TabPage tpClientInfo;
        private System.Windows.Forms.Label lblTitleBody;
        private Clients.Controls.ctrlClientCardWithFilter ctrlClientCardWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
    }
}