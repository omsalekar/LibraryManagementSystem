using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Transactions
    {
       public int BOOK_ID ;
        public int MEMBER_ID;
        public DateTime Borrow_Date;
        public DateTime Return_Date;

        public void Borrow_Book()
        {
            Transactions transactions = new Transactions();

            Dbsource dbsource = new Dbsource();

            Console.WriteLine("Enter  Book ID : ");
            transactions.BOOK_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Member ID : ");
            transactions.MEMBER_ID = Convert.ToInt32(Console.ReadLine());

            transactions.Borrow_Date = DateTime.Now;
            transactions.Return_Date = DateTime.Now.AddDays(10);

            dbsource.BOOROW_TRANSACTION(transactions);
        }
    }
}
