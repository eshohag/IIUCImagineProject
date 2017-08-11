using IIUCImagineProject.DAL;
using IIUCImagineProject.Models;

namespace IIUCImagineProject.BLL
{
    public class MemberManager
    {
        MemberGateway aGateway = new MemberGateway();
        public string Save(Member membership)
        {
            if (aGateway.IsExistingStudentID(membership).Count > 0)
            {
                return "Student ID or Email Already Entered Our database";
            }
            else
            {
                if (aGateway.Save(membership) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return " Save Failed";
                }

            }
        }
    }
}