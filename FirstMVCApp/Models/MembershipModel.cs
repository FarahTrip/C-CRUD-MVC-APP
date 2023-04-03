using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipModel
    {
        [Key]
        public Guid IDMembership { get; set; }
        public MemberModel Member { get; set; }
        public MembershipTypeModel IDMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Level { get; set; }

    }
}