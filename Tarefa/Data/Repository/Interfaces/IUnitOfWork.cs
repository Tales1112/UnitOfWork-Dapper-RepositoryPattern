using System;

namespace Tarefa.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITarefaRepository Tarefas { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
