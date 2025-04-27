// See https://aka.ms/new-console-template for more information
using LibraryManagement;

Console.WriteLine("Hello, World!");


Book book = new Book();
book.Addbook();
book.DisplayAllBookDetails();
//book.Edit_book();
//book.Delete_Book();

Member member = new Member();
member.AddMember();
member.DisplaymemberDetails();
//member.Delete_Member();


Transactions transactions = new Transactions();
transactions.Borrow_Book();