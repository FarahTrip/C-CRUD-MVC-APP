using FirstMVCApp.Models;

namespace FirstMVCApp.ViewModels
{
    public class MembershipTypesMembersViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MemberModel> members = new List<MemberModel>();
        public int Count { get; set; }
    }
}