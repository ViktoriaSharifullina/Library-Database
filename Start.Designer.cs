namespace Library
{
    partial class Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_storage = new System.Windows.Forms.Button();
            this.button_employee = new System.Windows.Forms.Button();
            this.button_book = new System.Windows.Forms.Button();
            this.button_extradition = new System.Windows.Forms.Button();
            this.button_library = new System.Windows.Forms.Button();
            this.button_subscriber = new System.Windows.Forms.Button();
            this.запросКMSysObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.запросКMSysObjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // button_storage
            // 
            this.button_storage.Location = new System.Drawing.Point(76, 95);
            this.button_storage.Name = "button_storage";
            this.button_storage.Size = new System.Drawing.Size(159, 34);
            this.button_storage.TabIndex = 1;
            this.button_storage.Text = "Хранилище";
            this.button_storage.UseVisualStyleBackColor = true;
            this.button_storage.Click += new System.EventHandler(this.button_storage_Click);
            // 
            // button_employee
            // 
            this.button_employee.Location = new System.Drawing.Point(76, 165);
            this.button_employee.Name = "button_employee";
            this.button_employee.Size = new System.Drawing.Size(159, 34);
            this.button_employee.TabIndex = 2;
            this.button_employee.Text = "Сотрудник";
            this.button_employee.UseVisualStyleBackColor = true;
            this.button_employee.Click += new System.EventHandler(this.button_employee_Click);
            // 
            // button_book
            // 
            this.button_book.Location = new System.Drawing.Point(315, 95);
            this.button_book.Name = "button_book";
            this.button_book.Size = new System.Drawing.Size(159, 34);
            this.button_book.TabIndex = 3;
            this.button_book.Text = "Книга";
            this.button_book.UseVisualStyleBackColor = true;
            this.button_book.Click += new System.EventHandler(this.button_book_Click);
            // 
            // button_extradition
            // 
            this.button_extradition.Location = new System.Drawing.Point(315, 165);
            this.button_extradition.Name = "button_extradition";
            this.button_extradition.Size = new System.Drawing.Size(159, 34);
            this.button_extradition.TabIndex = 4;
            this.button_extradition.Text = "Выдача";
            this.button_extradition.UseVisualStyleBackColor = true;
            this.button_extradition.Click += new System.EventHandler(this.button_extradition_Click);
            // 
            // button_library
            // 
            this.button_library.Location = new System.Drawing.Point(552, 95);
            this.button_library.Name = "button_library";
            this.button_library.Size = new System.Drawing.Size(159, 34);
            this.button_library.TabIndex = 5;
            this.button_library.Text = "Библиотека";
            this.button_library.UseVisualStyleBackColor = true;
            this.button_library.Click += new System.EventHandler(this.button_library_Click);
            // 
            // button_subscriber
            // 
            this.button_subscriber.Location = new System.Drawing.Point(552, 165);
            this.button_subscriber.Name = "button_subscriber";
            this.button_subscriber.Size = new System.Drawing.Size(159, 34);
            this.button_subscriber.TabIndex = 6;
            this.button_subscriber.Text = "Абонент";
            this.button_subscriber.UseVisualStyleBackColor = true;
            this.button_subscriber.Click += new System.EventHandler(this.button_subscriber_Click);
            // 
            // запросКMSysObjectsToolStripMenuItem
            // 
            this.запросКMSysObjectsToolStripMenuItem.Name = "запросКMSysObjectsToolStripMenuItem";
            this.запросКMSysObjectsToolStripMenuItem.Size = new System.Drawing.Size(208, 29);
            this.запросКMSysObjectsToolStripMenuItem.Text = "Запрос к MSysObjects";
            this.запросКMSysObjectsToolStripMenuItem.Click += new System.EventHandler(this.запросКMSysObjectsToolStripMenuItem_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 282);
            this.Controls.Add(this.button_subscriber);
            this.Controls.Add(this.button_library);
            this.Controls.Add(this.button_extradition);
            this.Controls.Add(this.button_book);
            this.Controls.Add(this.button_employee);
            this.Controls.Add(this.button_storage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Start";
            this.Text = "Работа с базой данных";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Button button_storage;
        private Button button_employee;
        private Button button_book;
        private Button button_extradition;
        private Button button_library;
        private Button button_subscriber;
        private ToolStripMenuItem запросКMSysObjectsToolStripMenuItem;
    }
}