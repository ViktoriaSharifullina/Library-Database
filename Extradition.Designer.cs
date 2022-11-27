namespace Library
{
    partial class Extradition
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_ex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number_book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number_ticket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.назадToolStripMenuItem.Text = "Назад";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.button_download);
            this.groupBox1.Location = new System.Drawing.Point(671, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 280);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(28, 206);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(186, 34);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Удалить";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(28, 155);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(186, 34);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Изменить";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(28, 101);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(186, 34);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(28, 50);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(186, 34);
            this.button_download.TabIndex = 0;
            this.button_download.Text = "Загрузить";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.date_ex,
            this.date_return,
            this.number_book,
            this.number_ticket});
            this.dataGridView1.Location = new System.Drawing.Point(40, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(566, 280);
            this.dataGridView1.TabIndex = 2;
            // 
            // code
            // 
            this.code.HeaderText = "Код выдачи";
            this.code.MinimumWidth = 8;
            this.code.Name = "code";
            this.code.Width = 150;
            // 
            // date_ex
            // 
            this.date_ex.HeaderText = "Дата выдачи";
            this.date_ex.MinimumWidth = 8;
            this.date_ex.Name = "date_ex";
            this.date_ex.Width = 150;
            // 
            // date_return
            // 
            this.date_return.HeaderText = "Дата возврата";
            this.date_return.MinimumWidth = 8;
            this.date_return.Name = "date_return";
            this.date_return.Width = 150;
            // 
            // number_book
            // 
            this.number_book.HeaderText = "Номер книги";
            this.number_book.MinimumWidth = 8;
            this.number_book.Name = "number_book";
            this.number_book.Width = 150;
            // 
            // number_ticket
            // 
            this.number_ticket.HeaderText = "Номер билета";
            this.number_ticket.MinimumWidth = 8;
            this.number_ticket.Name = "number_ticket";
            this.number_ticket.Width = 150;
            // 
            // Extradition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Extradition";
            this.Text = "Extradition";
            this.Load += new System.EventHandler(this.Extradition_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem назадToolStripMenuItem;
        private GroupBox groupBox1;
        private Button button_delete;
        private Button button_update;
        private Button button_add;
        private Button button_download;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn date_ex;
        private DataGridViewTextBoxColumn date_return;
        private DataGridViewTextBoxColumn number_book;
        private DataGridViewTextBoxColumn number_ticket;
    }
}