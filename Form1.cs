using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_6._4
{
    public partial class Form1 : Form
    {
        BookRepository bookRepository;
        
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Assignment_6_4_BooksDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this._Assignment_6_4_BooksDataSet.Books);
            bookRepository = new BookRepository();
            bookGrid.DataSource = bookRepository.GetAllRecords();
            btnUpdate.Visible = false;
            this.Height = 380;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
   
            this.Height = 500;
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtISBN.ForeColor = System.Drawing.Color.Black;
            this.txtAuthor.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtGenre.ForeColor = System.Drawing.Color.Black;
            this.txtReleaseDate.ForeColor = System.Drawing.Color.Black;
            this.txtCopies.ForeColor = System.Drawing.Color.Black;
          

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtISBN.Text) && !string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtAuthor.Text))
            {
                var newBook = new Book();
                newBook.ISBN = txtISBN.Text;
                newBook.BookName = txtTitle.Text;
                newBook.Author= txtAuthor.Text;
                newBook.Description= txtDescription.Text;
                newBook.Genre= txtGenre.Text;
                newBook.ReleaseDate= DateTime.Parse(txtReleaseDate.Text);
                newBook.Copies= Int32.Parse(txtCopies.Text);
                bookRepository.AddRecord(newBook);
                MessageBox.Show("New book added!");
                Clear();
            }
        }
        private void Clear()
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtDescription.Clear();
            txtGenre.Clear();
            txtReleaseDate.Clear();
            txtCopies.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bookGrid.DataSource = null;
            bookGrid.DataSource = bookRepository.GetAllRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ISBN = bookGrid.CurrentRow.Cells[0].Value;
            var title = bookGrid.CurrentRow.Cells[1].Value;
            var result = MessageBox.Show($"Are you sure you want to delete: {title}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var delete = bookRepository.FindBook((string)ISBN);
                bookRepository.DeleteRecord(delete);
                MessageBox.Show("Book deleted");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            var ISBN = txtISBN.Text;
            var booktoupdate = bookRepository.FindBook((string)ISBN);
            booktoupdate.ISBN = txtISBN.Text;
            booktoupdate.BookName = txtTitle.Text;
            booktoupdate.Author = txtAuthor.Text;
            booktoupdate.Description = txtDescription.Text;
            booktoupdate.Genre = txtGenre.Text;
            booktoupdate.ReleaseDate = DateTime.Parse(txtReleaseDate.Text);
            booktoupdate.Copies = Int32.Parse(txtCopies.Text);
            bookRepository.UpdateRecord((string)ISBN, booktoupdate);
            MessageBox.Show("Record updated!");
            Clear();


        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            this.Height = 500;
            var ISBN = bookGrid.CurrentRow.Cells[0].Value;
            var booktoupdate = bookRepository.FindBook((string)ISBN);
            txtISBN.Text = booktoupdate.ISBN.ToString();
            txtTitle.Text = booktoupdate.BookName.ToString();
            txtAuthor.Text = booktoupdate.Author.ToString();
            txtDescription.Text = booktoupdate.Description.ToString();
            txtGenre.Text = booktoupdate.Genre.ToString();
            txtCopies.Text = booktoupdate.Copies.ToString();
            txtReleaseDate.Text = booktoupdate.ReleaseDate.ToString();
            btnUpdate.Visible = true;
           

            
        }
    }
}
