namespace Library
{
    partial class Storage
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
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискХранилищаПоНомеруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискХранилищаПоВместмостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.number_storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.удалениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.выходToolStripMenuItem.Text = "Назад";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискХранилищаПоНомеруToolStripMenuItem,
            this.поискХранилищаПоВместмостиToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // поискХранилищаПоНомеруToolStripMenuItem
            // 
            this.поискХранилищаПоНомеруToolStripMenuItem.Name = "поискХранилищаПоНомеруToolStripMenuItem";
            this.поискХранилищаПоНомеруToolStripMenuItem.Size = new System.Drawing.Size(450, 34);
            this.поискХранилищаПоНомеруToolStripMenuItem.Text = "Поиск хранилища по номеру";
            this.поискХранилищаПоНомеруToolStripMenuItem.Click += new System.EventHandler(this.поискХранилищаПоНомеруToolStripMenuItem_Click);
            // 
            // поискХранилищаПоВместмостиToolStripMenuItem
            // 
            this.поискХранилищаПоВместмостиToolStripMenuItem.Name = "поискХранилищаПоВместмостиToolStripMenuItem";
            this.поискХранилищаПоВместмостиToolStripMenuItem.Size = new System.Drawing.Size(450, 34);
            this.поискХранилищаПоВместмостиToolStripMenuItem.Text = "Поиск хранилища по вместмости > 7000";
            this.поискХранилищаПоВместмостиToolStripMenuItem.Click += new System.EventHandler(this.поискХранилищаПоВместмостиToolStripMenuItem_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(104, 29);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number_storage,
            this.floor,
            this.capacity});
            this.dataGridView1.Location = new System.Drawing.Point(26, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(522, 295);
            this.dataGridView1.TabIndex = 1;
            // 
            // number_storage
            // 
            this.number_storage.HeaderText = "Номер хранилища";
            this.number_storage.MinimumWidth = 8;
            this.number_storage.Name = "number_storage";
            this.number_storage.Width = 150;
            // 
            // floor
            // 
            this.floor.HeaderText = "Этаж";
            this.floor.MinimumWidth = 8;
            this.floor.Name = "floor";
            this.floor.Width = 150;
            // 
            // capacity
            // 
            this.capacity.HeaderText = "Вместимость";
            this.capacity.MinimumWidth = 8;
            this.capacity.Name = "capacity";
            this.capacity.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.button_download);
            this.groupBox1.Location = new System.Drawing.Point(605, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(22, 217);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(158, 34);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Удалить";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(22, 158);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(158, 34);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Обновить";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(22, 101);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(158, 34);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(22, 42);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(158, 34);
            this.button_download.TabIndex = 0;
            this.button_download.Text = "Загрузить";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Storage";
            this.Text = "Хранилище";
            this.Load += new System.EventHandler(this.Storage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button button_delete;
        private Button button_update;
        private Button button_add;
        private Button button_download;
        private DataGridViewTextBoxColumn number_storage;
        private DataGridViewTextBoxColumn floor;
        private DataGridViewTextBoxColumn capacity;
        private ToolStripMenuItem поискToolStripMenuItem;
        private ToolStripMenuItem поискХранилищаПоНомеруToolStripMenuItem;
        private ToolStripMenuItem поискХранилищаПоВместмостиToolStripMenuItem;
        private ToolStripMenuItem удалениеToolStripMenuItem;
    }
}