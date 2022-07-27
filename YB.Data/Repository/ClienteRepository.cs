using YB.Domain.Interfaces.Repository;
using YB.Domain.Models;

namespace YB.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(YBContext context) : base(context)
        {}
    }
}