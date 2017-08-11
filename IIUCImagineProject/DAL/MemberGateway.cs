using IIUCImagineProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IIUCImagineProject.DAL
{
    public class MemberGateway : CommonGateway
    {
        public List<Member> IsExistingStudentID(Member membership)
        {
            Query = "SELECT * FROM Members WHERE StudentID=@StudentID OR Email=@Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("StudentID", SqlDbType.VarChar);
            Command.Parameters["StudentID"].Value = membership.StudentID;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = membership.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Member> allMember = new List<Member>();
            while (Reader.Read())
            {
                Member aMembership = new Member();
                aMembership.Name = Reader["Name"].ToString();
                aMembership.ContactNo = Reader["ContactNo"].ToString();
                aMembership.Email = Reader["Email"].ToString();
                aMembership.StudentID = Reader["StudentID"].ToString();
                allMember.Add(aMembership);
            }
            Reader.Close();
            Connection.Close();
            return allMember;
        }

        public int Save(Member membership)
        {
            Query =
                "INSERT INTO Members(Name,ContactNo,StudentID,Email,DepartmentID,DoYouKnowID,ParticipateID,SubmitDate) VALUES(@Name,@ContactNo,@StudentID,@Email,@DepartmentID,@DoYouKnowID,@ParticipateID,@SubmitDate)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = membership.Name;
            Command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            Command.Parameters["ContactNo"].Value = membership.ContactNo;
            Command.Parameters.Add("StudentID", SqlDbType.VarChar);
            Command.Parameters["StudentID"].Value = membership.StudentID;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = membership.Email;
            Command.Parameters.Add("DepartmentID", SqlDbType.VarChar);
            Command.Parameters["DepartmentID"].Value = membership.DepartmentID;
            Command.Parameters.Add("DoYouKnowID", SqlDbType.VarChar);
            Command.Parameters["DoYouKnowID"].Value = membership.DoYouKnowID;
            Command.Parameters.Add("ParticipateID", SqlDbType.VarChar);
            Command.Parameters["ParticipateID"].Value = membership.ParticipateID;
            Command.Parameters.Add("SubmitDate", SqlDbType.VarChar);
            Command.Parameters["SubmitDate"].Value = membership.SubmitDate;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}