using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public  class Dbsource
    {
        public void Push_Book(Book book )
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "ADDBOOK";
                SqlCommand command = new SqlCommand("ADDBOOK", connection);

                 command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author); 
                command.Parameters.AddWithValue("@ISBN", book.ISBN); 
                command.Parameters.AddWithValue("@Quantity", book.Quantity);
                command.Parameters.AddWithValue("@isAvailable", SqlDbType.Bit);

                command.ExecuteNonQuery();
            }
        }


        public void Push_Member(Member member)
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "ADDMEMBER";
                SqlCommand command = new SqlCommand("ADDMEMBER", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Mem_Name", member.Mem_Name);
                command.Parameters.AddWithValue("@Joindate", member.Joindate);
               
                

                command.ExecuteNonQuery();
            }
        }

        public List<Book> Get_Book()
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "DISPLAYBOOK";
                using (SqlCommand command = new SqlCommand("DISPLAYBOOK", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.B_ID = Convert.ToInt32(reader["B_ID"]);
                            book.Title = Convert.ToString(reader["Title"]);
                            book.Author = Convert.ToString(reader["Author"]);
                            book.Quantity = Convert.ToInt32(reader["Quantity"]);
                            book.isAvailable = Convert.ToString(reader["isAvailable"]);



                            books.Add(book);

                        }
                    }
                   
                }

                    
            }
            return books;
        }


        public List<Member> Get_Member()
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            List<Member> memberlist = new List<Member>();

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "DISPLAYMEMBER";
                using (SqlCommand command = new SqlCommand("DISPLAYMEMBER", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Member member = new Member();
                            member.M_ID = Convert.ToInt32(reader["M_ID"]);
                            member.Mem_Name = Convert.ToString(reader["Mem_Name"]);
                            member.Joindate = Convert.ToString(reader["Joindate"]);
                            memberlist.Add(member);

                        }
                    }

                }


            }
            return memberlist;
        }

        public void DELETE_BOOK(Book book)
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "DELETEBOOK";
                SqlCommand command = new SqlCommand("DELETEBOOK", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Title", book.Title);
           

                command.ExecuteNonQuery();
            }
        }


        
        public void DELETE_MEMBER(Member member)
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "DELETEMEMBER";
                SqlCommand command = new SqlCommand("DELETEMEMBER", connection);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Mem_Name", member.Mem_Name);
     
                command.ExecuteNonQuery();
            }
        }

        public void UPDATE_BOOK(Book book)
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "EDIT_BOOK";
                SqlCommand command = new SqlCommand("EDIT_BOOK", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@B_ID", book.B_ID);

                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@Quantity", book.Quantity);
                command.Parameters.AddWithValue("@isAvailable", SqlDbType.Bit);

                command.ExecuteNonQuery();
            }
        }

        public void BOOROW_TRANSACTION(Transactions transactions)
        {
            string ConString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                string query = "BORROW_BOOK";
                using (SqlCommand command = new SqlCommand("BORROW_BOOK", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@B_ID", transactions.BOOK_ID);
                    command.Parameters.AddWithValue("@M_ID", transactions.MEMBER_ID);
                    command.Parameters.AddWithValue("@BORROW_DATE", transactions.Borrow_Date);
                    command.Parameters.AddWithValue("@RETURN_DATE", transactions.Return_Date);

                    command.ExecuteNonQuery();
                }
                    
               

                
            }
        }



    }
}
