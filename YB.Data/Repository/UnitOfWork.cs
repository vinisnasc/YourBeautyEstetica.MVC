using YB.Domain.Interfaces.Repository;

namespace YB.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YBContext _context;
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IClienteRepository ClienteRepository { get; set; }
        public IAgendamentoRepository AgendamentoRepository { get; set; }
        public IServicoRepository ServicoRepository { get; set; }

        public UnitOfWork(YBContext context)
        {
            _context = context;
            FuncionarioRepository = new FuncionarioRepository(context);
            ClienteRepository = new ClienteRepository(context);
            AgendamentoRepository = new AgendamentoRepository(context);
            ServicoRepository = new ServicoRepository(context);
        }
    }
}
