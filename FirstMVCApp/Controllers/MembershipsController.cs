using FirstMVCApp.Repositories;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }
    }
}