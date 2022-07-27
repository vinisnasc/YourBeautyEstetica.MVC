using YB.Domain.Interfaces.Repository;
using YB.Domain.Models;

namespace YB.Data.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(YBContext context) : base(context)
        { }
    }
}