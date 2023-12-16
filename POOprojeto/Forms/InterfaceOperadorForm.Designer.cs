
namespace POOprojeto
{
    partial class InterfaceOperadorForm
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
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddTicket = new System.Windows.Forms.Button();
            this.listViewTicket = new System.Windows.Forms.ListView();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.AutoSize = true;
            this.linkLabelHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelHome.Location = new System.Drawing.Point(0, 0);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(176, 37);
            this.linkLabelHome.TabIndex = 0;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "Call Center";
            this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonAddTicket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 66);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(85, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 66);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add Produto";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 66);
            this.button2.TabIndex = 4;
            this.button2.Text = "Adicionar Operador";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::POOprojeto.Properties.Resources._3648091_200;
            this.pictureBox1.Location = new System.Drawing.Point(740, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(786, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 66);
            this.button1.TabIndex = 2;
            this.button1.Text = "Atribuir Operador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAddTicket
            // 
            this.buttonAddTicket.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddTicket.Location = new System.Drawing.Point(1019, 0);
            this.buttonAddTicket.Name = "buttonAddTicket";
            this.buttonAddTicket.Size = new System.Drawing.Size(245, 66);
            this.buttonAddTicket.TabIndex = 2;
            this.buttonAddTicket.Text = "Add Ticket";
            this.buttonAddTicket.UseVisualStyleBackColor = true;
            this.buttonAddTicket.Click += new System.EventHandler(this.buttonAddTicket_Click);
            // 
            // listViewTicket
            // 
            this.listViewTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTicket.HideSelection = false;
            this.listViewTicket.Location = new System.Drawing.Point(0, 109);
            this.listViewTicket.Name = "listViewTicket";
            this.listViewTicket.Size = new System.Drawing.Size(1264, 312);
            this.listViewTicket.TabIndex = 2;
            this.listViewTicket.UseCompatibleStateImageBehavior = false;
            this.listViewTicket.View = System.Windows.Forms.View.Details;
            this.listViewTicket.SelectedIndexChanged += new System.EventHandler(this.listViewTicket_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Location = new System.Drawing.Point(166, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 66);
            this.button4.TabIndex = 6;
            this.button4.Text = "Add Resolucao Problema";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // InterfaceOperadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.listViewTicket);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabelHome);
            this.Name = "InterfaceOperadorForm";
            this.Text = "InterfaceOperadorForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddTicket;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewTicket;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}