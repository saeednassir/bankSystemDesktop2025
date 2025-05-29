namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards
{
    partial class frmMangeCards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangeCards));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddCard = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnMangeCardTpes = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNameResaultsCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.dgvCards = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsCards = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findEmployeetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AddEmployee_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ActivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNotFoundCards = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).BeginInit();
            this.cmsCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCard
            // 
            this.btnAddCard.BorderColor = System.Drawing.Color.Gray;
            this.btnAddCard.BorderThickness = 1;
            this.btnAddCard.CheckedState.Parent = this.btnAddCard;
            this.btnAddCard.CustomImages.Parent = this.btnAddCard;
            this.btnAddCard.FillColor = System.Drawing.Color.Transparent;
            this.btnAddCard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddCard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnAddCard.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddCard.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.plus__1_;
            this.btnAddCard.HoverState.Parent = this.btnAddCard;
            this.btnAddCard.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCard.Image")));
            this.btnAddCard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAddCard.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnAddCard.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAddCard.Location = new System.Drawing.Point(19, 13);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.ShadowDecoration.Parent = this.btnAddCard;
            this.btnAddCard.Size = new System.Drawing.Size(137, 36);
            this.btnAddCard.TabIndex = 3;
            this.btnAddCard.Text = "إضافة بطاقة";
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnRefresh);
            this.guna2Panel1.Controls.Add(this.btnMangeCardTpes);
            this.guna2Panel1.Controls.Add(this.txtFilterValue);
            this.guna2Panel1.Controls.Add(this.btnAddCard);
            this.guna2Panel1.Controls.Add(this.cbFilterBy);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.lblNameResaultsCount);
            this.guna2Panel1.Controls.Add(this.lblRecordsCount);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1145, 60);
            this.guna2Panel1.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.CheckedState.Parent = this.btnRefresh;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.CustomImages.Parent = this.btnRefresh;
            this.btnRefresh.FillColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.Parent = this.btnRefresh;
            this.btnRefresh.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.reloading;
            this.btnRefresh.ImageSize = new System.Drawing.Size(32, 32);
            this.btnRefresh.Location = new System.Drawing.Point(981, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.Parent = this.btnRefresh;
            this.btnRefresh.Size = new System.Drawing.Size(34, 32);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMangeCardTpes
            // 
            this.btnMangeCardTpes.BorderColor = System.Drawing.Color.Gray;
            this.btnMangeCardTpes.BorderThickness = 1;
            this.btnMangeCardTpes.CheckedState.Parent = this.btnMangeCardTpes;
            this.btnMangeCardTpes.CustomImages.Parent = this.btnMangeCardTpes;
            this.btnMangeCardTpes.FillColor = System.Drawing.Color.Transparent;
            this.btnMangeCardTpes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMangeCardTpes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMangeCardTpes.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnMangeCardTpes.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnMangeCardTpes.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.money_management__1_;
            this.btnMangeCardTpes.HoverState.Parent = this.btnMangeCardTpes;
            this.btnMangeCardTpes.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.cycle;
            this.btnMangeCardTpes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnMangeCardTpes.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnMangeCardTpes.ImageSize = new System.Drawing.Size(16, 16);
            this.btnMangeCardTpes.Location = new System.Drawing.Point(162, 13);
            this.btnMangeCardTpes.Name = "btnMangeCardTpes";
            this.btnMangeCardTpes.ShadowDecoration.Parent = this.btnMangeCardTpes;
            this.btnMangeCardTpes.Size = new System.Drawing.Size(154, 36);
            this.btnMangeCardTpes.TabIndex = 6;
            this.btnMangeCardTpes.Text = "إدارة انواع البطاقات";
            this.btnMangeCardTpes.Click += new System.EventHandler(this.btnMangeCardTpes_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.AutoRoundedCorners = true;
            this.txtFilterValue.BorderRadius = 17;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.Parent = this.txtFilterValue;
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.txtFilterValue.FocusedState.Parent = this.txtFilterValue;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.txtFilterValue.HoverState.Parent = this.txtFilterValue;
            this.txtFilterValue.IconRight = ((System.Drawing.Image)(resources.GetObject("txtFilterValue.IconRight")));
            this.txtFilterValue.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.IconRightOffset = new System.Drawing.Point(10, 0);
            this.txtFilterValue.Location = new System.Drawing.Point(488, 12);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PasswordChar = '\0';
            this.txtFilterValue.PlaceholderText = "إبحث";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.ShadowDecoration.Parent = this.txtFilterValue;
            this.txtFilterValue.Size = new System.Drawing.Size(182, 36);
            this.txtFilterValue.TabIndex = 5;
            this.txtFilterValue.TextOffset = new System.Drawing.Point(5, 0);
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.AutoRoundedCorners = true;
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderRadius = 17;
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbFilterBy.FocusedState.Parent = this.cbFilterBy;
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.HoverState.Parent = this.cbFilterBy;
            this.cbFilterBy.IntegralHeight = false;
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لا شيء",
            "ID",
            "الإسم على البطاقة",
            "اسم المستخدم"});
            this.cbFilterBy.ItemsAppearance.Parent = this.cbFilterBy;
            this.cbFilterBy.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.cbFilterBy.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbFilterBy.Location = new System.Drawing.Point(681, 13);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.ShadowDecoration.Parent = this.cbFilterBy;
            this.cbFilterBy.Size = new System.Drawing.Size(182, 36);
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.TabIndex = 2;
            this.cbFilterBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cbFilterBy.TextOffset = new System.Drawing.Point(10, 0);
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(874, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "تصفية حسب :";
            // 
            // lblNameResaultsCount
            // 
            this.lblNameResaultsCount.AutoSize = true;
            this.lblNameResaultsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameResaultsCount.Location = new System.Drawing.Point(1023, 21);
            this.lblNameResaultsCount.Name = "lblNameResaultsCount";
            this.lblNameResaultsCount.Size = new System.Drawing.Size(48, 21);
            this.lblNameResaultsCount.TabIndex = 1;
            this.lblNameResaultsCount.Text = "بطاقة";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.lblRecordsCount.Location = new System.Drawing.Point(1082, 9);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(51, 40);
            this.lblRecordsCount.TabIndex = 0;
            this.lblRecordsCount.Text = "12";
            // 
            // dgvCards
            // 
            this.dgvCards.AllowUserToAddRows = false;
            this.dgvCards.AllowUserToDeleteRows = false;
            this.dgvCards.AllowUserToResizeColumns = false;
            this.dgvCards.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCards.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCards.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCards.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCards.ColumnHeadersHeight = 40;
            this.dgvCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCards.ContextMenuStrip = this.cmsCards;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCards.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCards.EnableHeadersVisualStyles = false;
            this.dgvCards.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCards.Location = new System.Drawing.Point(19, 84);
            this.dgvCards.MultiSelect = false;
            this.dgvCards.Name = "dgvCards";
            this.dgvCards.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCards.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCards.RowHeadersVisible = false;
            this.dgvCards.RowTemplate.DividerHeight = 5;
            this.dgvCards.RowTemplate.Height = 40;
            this.dgvCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCards.Size = new System.Drawing.Size(1107, 588);
            this.dgvCards.TabIndex = 5;
            this.dgvCards.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCards.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCards.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCards.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCards.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCards.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCards.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCards.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCards.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCards.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCards.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCards.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCards.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCards.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCards.ThemeStyle.ReadOnly = true;
            this.dgvCards.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCards.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCards.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCards.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCards.ThemeStyle.RowsStyle.Height = 40;
            this.dgvCards.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.dgvCards.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // cmsCards
            // 
            this.cmsCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.cmsCards.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.findEmployeetoolStripMenuItem1,
            this.toolStripSeparator2,
            this.AddEmployee_toolStripMenuItem,
            this.toolStripSeparator1,
            this.ActivateToolStripMenuItem,
            this.CancelCardToolStripMenuItem});
            this.cmsCards.Name = "contextMenuStrip1";
            this.cmsCards.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsCards.Size = new System.Drawing.Size(179, 206);
            this.cmsCards.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCards_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.showDetailsToolStripMenuItem.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.id_card1;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.showDetailsToolStripMenuItem.Text = "عرض التفاصل";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // findEmployeetoolStripMenuItem1
            // 
            this.findEmployeetoolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.findEmployeetoolStripMenuItem1.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.magnifying_glass__1_;
            this.findEmployeetoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findEmployeetoolStripMenuItem1.Name = "findEmployeetoolStripMenuItem1";
            this.findEmployeetoolStripMenuItem1.Size = new System.Drawing.Size(178, 38);
            this.findEmployeetoolStripMenuItem1.Text = "بحث عن بطاقة";
            this.findEmployeetoolStripMenuItem1.Click += new System.EventHandler(this.findEmployeetoolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // AddEmployee_toolStripMenuItem
            // 
            this.AddEmployee_toolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.AddEmployee_toolStripMenuItem.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.add_user;
            this.AddEmployee_toolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddEmployee_toolStripMenuItem.Name = "AddEmployee_toolStripMenuItem";
            this.AddEmployee_toolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.AddEmployee_toolStripMenuItem.Text = "إضافة بطاقة جديد";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // ActivateToolStripMenuItem
            // 
            this.ActivateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ActivateToolStripMenuItem.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.delete1;
            this.ActivateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem";
            this.ActivateToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.ActivateToolStripMenuItem.Text = "تفعيل";
            this.ActivateToolStripMenuItem.Click += new System.EventHandler(this.ActivateToolStripMenuItem_Click);
            // 
            // CancelCardToolStripMenuItem
            // 
            this.CancelCardToolStripMenuItem.Name = "CancelCardToolStripMenuItem";
            this.CancelCardToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.CancelCardToolStripMenuItem.Text = "إلغاء تفعيل";
            this.CancelCardToolStripMenuItem.Click += new System.EventHandler(this.CancelCardToolStripMenuItem_Click);
            // 
            // lblNotFoundCards
            // 
            this.lblNotFoundCards.AutoSize = true;
            this.lblNotFoundCards.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotFoundCards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.lblNotFoundCards.Location = new System.Drawing.Point(460, 335);
            this.lblNotFoundCards.Name = "lblNotFoundCards";
            this.lblNotFoundCards.Size = new System.Drawing.Size(225, 30);
            this.lblNotFoundCards.TabIndex = 10;
            this.lblNotFoundCards.Text = "لا يوجد بطاقات لعرضها !";
            this.lblNotFoundCards.Visible = false;
            // 
            // frmMangeCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1145, 701);
            this.Controls.Add(this.lblNotFoundCards);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMangeCards";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إدارة البطاقات";
            this.Load += new System.EventHandler(this.frmMangeCards_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).EndInit();
            this.cmsCards.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddCard;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNameResaultsCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCards;
        private System.Windows.Forms.ContextMenuStrip cmsCards;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findEmployeetoolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AddEmployee_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActivateToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button btnMangeCardTpes;
        private System.Windows.Forms.ToolStripMenuItem CancelCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.Label lblNotFoundCards;
    }
}