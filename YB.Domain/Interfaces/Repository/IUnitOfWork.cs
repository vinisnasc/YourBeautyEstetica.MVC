namespace YB.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IClienteRepository ClienteRepository { get; }
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IServicoRepository ServicoRepository { get; set; }
        public IAgendamentoRepository AgendamentoRepository { get; set; }
    }
}