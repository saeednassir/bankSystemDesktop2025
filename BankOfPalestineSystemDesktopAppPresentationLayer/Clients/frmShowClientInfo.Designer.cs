namespace BankOfPalestineSystemDesktopAppPresentationLayer.Clients
{
    partial class frmShowClientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowClientInfo));
            this.lblTitleBody = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbIconHeader = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitleHeader = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.CtrlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.btnclose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ctrlClientCard1 = new BankOfPalestineSystemDesktopAppPresentationLayer.Clients.Controls.ctrlClientCard();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleBody
            // 
            this.lblTitleBody.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.lblTitleBody.Location = new System.Drawing.Point(0, 48);
            this.lblTitleBody.Name = "lblTitleBody";
            this.lblTitleBody.Size = new System.Drawing.Size(660, 52);
            this.lblTitleBody.TabIndex = 19;
            this.lblTitleBody.Text = "تفاصيل العميل";
            this.lblTitleBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.guna2Panel1.Size = new System.Drawing.Size(660, 45);
            this.guna2Panel1.TabIndex = 18;
            // 
            // pbIconHeader
            // 
            this.pbIconHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIconHeader.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.id_card;
            this.pbIconHeader.Location = new System.Drawing.Point(617, 6);
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
            this.lblTitleHeader.Location = new System.Drawing.Point(424, 12);
            this.lblTitleHeader.Name = "lblTitleHeader";
            this.lblTitleHeader.Size = new System.Drawing.Size(187, 23);
            this.lblTitleHeader.TabIndex = 15;
            this.lblTitleHeader.Text = "عرض معلومات العميل";
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
            this.gunaControlBox2.Location = new System.Drawing.Point(54, 9);
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
            this.CtrlBoxClose.Location = new System.Drawing.Point(3, 6);
            this.CtrlBoxClose.Name = "CtrlBoxClose";
            this.CtrlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.CtrlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.CtrlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.CtrlBoxClose.Size = new System.Drawing.Size(45, 29);
            this.CtrlBoxClose.TabIndex = 14;
            // 
            // btnclose
            // 
            this.btnclose.AutoRoundedCorners = true;
            this.btnclose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnclose.BorderColor = System.Drawing.Color.Gray;
            this.btnclose.BorderRadius = 17;
            this.btnclose.BorderThickness = 1;
            this.btnclose.CheckedState.Parent = this.btnclose;
            this.btnclose.CustomImages.Parent = this.btnclose;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.FillColor = System.Drawing.Color.Transparent;
            this.btnclose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnclose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(112)))));
            this.btnclose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnclose.HoverState.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.delete2;
            this.btnclose.HoverState.Parent = this.btnclose;
            this.btnclose.Image = global::BankOfPalestineSystemDesktopAppPresentationLayer.Properties.Resources.delete__1_;
            this.btnclose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnclose.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnclose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnclose.Location = new System.Drawing.Point(511, 562);
            this.btnclose.Name = "btnclose";
            this.btnclose.ShadowDecoration.Parent = this.btnclose;
            this.btnclose.Size = new System.Drawing.Size(137, 36);
            this.btnclose.TabIndex = 20;
            this.btnclose.Text = "إغلاق";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            // 
            // ctrlClientCard1
            // 
            this.ctrlClientCard1.Location = new System.Drawing.Point(8, 99);
            this.ctrlClientCard1.Name = "ctrlClientCard1";
            this.ctrlClientCard1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlClientCard1.Size = new System.Drawing.Size(642, 459);
            this.ctrlClientCard1.TabIndex = 21;
            // 
            // frmShowClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(660, 603);
            this.Controls.Add(this.ctrlClientCard1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.lblTitleBody);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(250, 20);
            this.Name = "frmShowClientInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "عرض تفاصيل العميل";
            this.Load += new System.EventHandler(this.frmShowClientInfo_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitleBody;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox pbIconHeader;
        private System.Windows.Forms.Label lblTitleHeader;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox CtrlBoxClose;
        private Guna.UI2.WinForms.Guna2Button btnclose;
        private Controls.ctrlClientCard ctrlClientCard1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}