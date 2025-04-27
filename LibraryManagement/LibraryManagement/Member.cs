using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Member
    {
        public int M_ID;
        public string Mem_Name;

        public string Joindate;



        //public List<Borrow_log> Borrow_log = [];

        //public void Add_trasaction(Borrow_log getTrasaction)
        //{
        //    Borrow_log.Add(getTrasaction);
        //}


        public void AddMember()
        {
            Member member = new Member();
            Dbsource dbsource = new Dbsource();


            Console.WriteLine(" Enter Your name : ");
            member.Mem_Name = Console.ReadLine();



            Console.WriteLine(" Enter Your Joindate : dd/mm/yy");
            member.Joindate = Console.ReadLine();



            dbsource.Push_Member(member);


        }

        //public void Edit_member()
        //{
        //    Console.WriteLine("Enter Member ID To Be Edit : ");
        //    int ID = Convert.ToInt32(Console.ReadLine());

        //    var member13 = DBsource.Lmwember;

        //    foreach (var member in member13)
        //    {
        //        if (member.M_ID == ID)
        //        {

        //            Console.WriteLine("Insert Name : ");
        //            member.Mem_Name = Console.ReadLine();
        //            Console.WriteLine("Insert Joindate : dd/mm/yy");
        //            member.Joindate = Console.ReadLine();
        //        }

        //    }
        //}
        public void Delete_Member()
        {
            Member member = new Member();
            Dbsource dbsource = new Dbsource();

            Console.WriteLine("Enter Member Name To Be Delete : ");
            member.Mem_Name = Console.ReadLine();

            dbsource.DELETE_MEMBER(member);


        }
        public void DisplaymemberDetails()
        {
            List<Member> members = new List<Member>();
            Dbsource dbsource = new Dbsource();
            members = dbsource.Get_Member();
            foreach (var item in members)
            {
                //foreach (var bl in item.Borrow_log)
                //{
                //    int calculate = (System.DateTime.Today - bl.Return_date).Days;
                //    item.Total_Penalty += calculate * 10;
                //}
                Console.WriteLine(" Member_ID : " + item.M_ID + " Name : " + item.Mem_Name + " JoinDate : " + item.Joindate );

            }
        }
    }
}
