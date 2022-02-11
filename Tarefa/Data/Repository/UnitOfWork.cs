using Tarefa.Data.Repository.Interfaces;

namespace Tarefa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;
        public ITarefaRepository Tarefas { get; }
        public UnitOfWork(ITarefaRepository tarefaRepository, DbSession db)
        {
            Tarefas = tarefaRepository;
            _session = db;
        }
        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }
        public void Commit()
        {
            _session.Transaction.Commit();
        }
        public void Dispose() => _session.Transaction?.Dispose();
        public void RollBack()
        {
            _session.Transaction.Rollback();
            Dispose(); ;
        }
    }
}
