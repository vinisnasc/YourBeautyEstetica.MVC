using YB.Domain.Interfaces.Repository;
using YB.Domain.Models;

namespace YB.Data.Repository
{
    public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(YBContext context) : base(context)
        { }
    }
}