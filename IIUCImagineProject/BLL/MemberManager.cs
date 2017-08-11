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
                return "Your ID or Email is already registered";
            }
            else
            {
                if (aGateway.Save(membership) > 0)
                {
                    return "Thanks For Your Interest!";
                }
                else
                {
                    return " Save Failed";
                }

            }
        }
    }
}