using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        public int B_ID;
        public string Title;
        public string Author;
        public int ISBN;
        public int Quantity;
        public string isAvailable;



        //public void setTitle(string title)
        //{
        //    this.Title = title;
        //}
        //public string getTitle()
        //{
        //    return this.Title;
        //}
        //public void setAuthor(string author) { 
        //    this.Author = author;
        //}
        //public string getAuthor() {
        //    return this.Author;
        //}
        //public  void setISBN(int ISBN)
        //{
        //    this.ISBN = ISBN;
        //}
        //public int getISBN() 
        //{
        //    return this.ISBN;
        //}
        //public void setisavailable(bool isavailable)
        //{
        //    this.isAvailable = isavailable;
        //}
        //public bool isavailable()
        //{
        //    return this.isAvailable;
        //}
        public void Addbook()
        {
            Book book = new Book();

            Dbsource dbsource = new Dbsource();

            Console.WriteLine("Enter  Book Name : ");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter Book Author Name : ");
            book.Author = Console.ReadLine();

            Console.WriteLine("Enter Book ISBN : ");
            book.ISBN = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Book Quantity : ");
            book.Quantity = Convert.ToInt32(Console.ReadLine());



            dbsource.Push_Book(book);

        }
        public void Edit_book()
        {
           

            Book book = new Book();

            Dbsource dbsource = new Dbsource();

            Console.WriteLine("Enter Book ID To Be Edit : ");
            book.B_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter  Book Name : ");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter Book Author Name : ");
            book.Author = Console.ReadLine();

            Console.WriteLine("Enter Book ISBN : ");
            book.ISBN = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Book Quantity : ");
            book.Quantity = Convert.ToInt32(Console.ReadLine());



            dbsource.UPDATE_BOOK(book);



        }

        public void Delete_Book()
        {
            Book book = new Book();

            Dbsource dbsource = new Dbsource();

            Console.WriteLine("Enter Book Name To Be Delete : ");
            book.Title = Console.ReadLine();

            dbsource.DELETE_BOOK(book);

        }
        public void DisplayAllBookDetails()
        {
            List<Book> books = new List<Book>();
            Dbsource dbsource = new Dbsource();
            books = dbsource.Get_Book();
            foreach (var item in books)
            {
                DisplayBook(item);
            }
        }

        public void DisplayBook(Book item)
        {
            isAvailable_book();
            Console.WriteLine("Book_ID: " + item.B_ID + " Title: " + item.Title + " Author: " + item.Author + " ISBN: " + item.ISBN + " Quantity : " + item.Quantity + " Is_Available : " + item.isAvailable);
        }

        public void isAvailable_book()
        {
          List<Book> books = new List<Book>();
            Dbsource dbsource = new Dbsource();
            books = dbsource.Get_Book();
            foreach (var book in books)
            {
                if (book.Quantity > 0)
                {

                    book.isAvailable = "Yes";

                }
                else
                {
                    book.isAvailable = "No";

                }

            }

        }
    }
}
