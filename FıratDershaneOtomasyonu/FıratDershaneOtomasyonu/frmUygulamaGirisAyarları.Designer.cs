namespace FıratDershaneOtomasyonu
{
    partial class frmUygulamaGirisAyarları
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUygulamaGirisAyarları));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.adminDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parolaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ePostaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminTablosuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fıratDershaneOtomasyonDataSet3 = new FıratDershaneOtomasyonu.FıratDershaneOtomasyonDataSet3();
            this.adminTablosuTableAdapter = new FıratDershaneOtomasyonu.FıratDershaneOtomasyonDataSet3TableAdapters.AdminTablosuTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminTablosuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fıratDershaneOtomasyonDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.adminDataGridViewTextBoxColumn,
            this.parolaDataGridViewTextBoxColumn,
            this.ePostaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.adminTablosuBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(388, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(638, 563);
            this.dataGridView1.TabIndex = 0;
            // 
            // adminDataGridViewTextBoxColumn
            // 
            this.adminDataGridViewTextBoxColumn.DataPropertyName = "Admin";
            this.adminDataGridViewTextBoxColumn.HeaderText = "Admin";
            this.adminDataGridViewTextBoxColumn.Name = "adminDataGridViewTextBoxColumn";
            this.adminDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // parolaDataGridViewTextBoxColumn
            // 
            this.parolaDataGridViewTextBoxColumn.DataPropertyName = "parola";
            this.parolaDataGridViewTextBoxColumn.HeaderText = "parola";
            this.parolaDataGridViewTextBoxColumn.Name = "parolaDataGridViewTextBoxColumn";
            this.parolaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ePostaDataGridViewTextBoxColumn
            // 
            this.ePostaDataGridViewTextBoxColumn.DataPropertyName = "ePosta";
            this.ePostaDataGridViewTextBoxColumn.HeaderText = "ePosta";
            this.ePostaDataGridViewTextBoxColumn.Name = "ePostaDataGridViewTextBoxColumn";
            this.ePostaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adminTablosuBindingSource
            // 
            this.adminTablosuBindingSource.DataMember = "AdminTablosu";
            this.adminTablosuBindingSource.DataSource = this.fıratDershaneOtomasyonDataSet3;
            // 
            // fıratDershaneOtomasyonDataSet3
            // 
            this.fıratDershaneOtomasyonDataSet3.DataSetName = "FıratDershaneOtomasyonDataSet3";
            this.fıratDershaneOtomasyonDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adminTablosuTableAdapter
            // 
            this.adminTablosuTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin :";
            // 
            // txtAdmin
            // 
            this.txtAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdmin.Location = new System.Drawing.Point(127, 177);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(214, 30);
            this.txtAdmin.TabIndex = 2;
            // 
            // txtParola
            // 
            this.txtParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtParola.Location = new System.Drawing.Point(127, 235);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(214, 30);
            this.txtParola.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parola :";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEmail.Location = new System.Drawing.Point(127, 293);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 30);
            this.txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(17, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Yetkili Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(204, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "Sayfayı Yenile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(103, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fırat Dershanesi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(331, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // frmUygulamaGirisAyarları
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1024, 564);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUygulamaGirisAyarları";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ayarları";
            this.Load += new System.EventHandler(this.frmUygulamaGirisAyarları_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminTablosuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fıratDershaneOtomasyonDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private FıratDershaneOtomasyonDataSet3 fıratDershaneOtomasyonDataSet3;
        private System.Windows.Forms.BindingSource adminTablosuBindingSource;
        private FıratDershaneOtomasyonDataSet3TableAdapters.AdminTablosuTableAdapter adminTablosuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parolaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ePostaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}