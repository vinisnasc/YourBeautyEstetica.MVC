using YB.Domain.Interfaces.Repository;
using YB.Domain.Models;

namespace YB.Data.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(YBContext context) : base(context)
        { }
    }
}