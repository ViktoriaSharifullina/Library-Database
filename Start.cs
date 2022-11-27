namespace Library
{
    public partial class Start : Form
    {
        Storage s;
        Employee em;
        Library l;
        Book b;
        Extradition ex;
        Subscriber sub;

        public Start()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_storage_Click(object sender, EventArgs e)
        {
            if (s == null)
            {
                s = new Storage();   //Create form if not created
                s.FormClosed += s_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            s.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }

        void s_FormClosed(object sender, FormClosedEventArgs e)
        {
            s = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void button_employee_Click(object sender, EventArgs e)
        {
            if (em == null)
            {
                em = new Employee();   //Create form if not created
                em.FormClosed += em_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            em.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }

        void em_FormClosed(object sender, FormClosedEventArgs e)
        {
            em = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void button_library_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Library();   //Create form if not created
                l.FormClosed += l_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            l.Show(this);  //Show Form assigning this form as the forms owner
            Hide();

        }

        void l_FormClosed(object sender, FormClosedEventArgs e)
        {
            l  = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void button_book_Click(object sender, EventArgs e)
        {
            if (b == null)
            {
                b = new Book();   //Create form if not created
                b.FormClosed += b_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            b.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }

        void b_FormClosed(object sender, FormClosedEventArgs e)
        {
            b = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void button_extradition_Click(object sender, EventArgs e)
        {
            if (ex == null)
            {
                ex = new Extradition();   //Create form if not created
                ex.FormClosed += ex_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            ex.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }

        void ex_FormClosed(object sender, FormClosedEventArgs e)
        {
            ex = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button_subscriber_Click(object sender, EventArgs e)
        {
            if (sub == null)
            {
                sub = new Subscriber();   //Create form if not created
                sub.FormClosed += sub_FormClosed;  //Add eventhandler to cleanup after form closes
            }

            sub.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }

        void sub_FormClosed(object sender, FormClosedEventArgs e)
        {
            sub = null;  //If form is closed make sure reference is set to null
            Show();
        }

        private void Á‡ÔÓÒ MSysObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MSysObjects d1 = new MSysObjects();
            d1.Owner = this;
            d1.Show();
        }
    }
}