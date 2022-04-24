namespace gun1proje1
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        public string numara;

        private void grsbtn_Click(object sender, EventArgs e)
        {
            ogrencibilgileri ogrbi = new ogrencibilgileri();
            ogrbi.numara = maskedTextBox1.Text;
            ogrbi.Show();

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text=="1881")
            {
                ogretmenbil ogretmenform = new ogretmenbil();
                ogretmenform.Show();
            }
        }
    }
}