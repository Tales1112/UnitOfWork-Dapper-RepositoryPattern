using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefa.Data.Repository.Interfaces;
using Tarefa.Models;

namespace Tarefa.Data.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private DbSession _session;
        public TarefaRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<int> Add(Tarefas entity)
        {
            entity.CriadaEm = System.DateTime.Now;
            entity.ModificadaEm = null;

            var sql = "INSERT INTO Tarefas (Nome,Descricao,Status,ConcluidaEm,CriadaEm,ModificadaEm)" +
                      "Values (@Nome, @Descricao, @Status, @ConcluidaEm, @CriadaEm, @ModificadaEm);";

            var result = await _session.Connection.ExecuteAsync(sql, entity, _session.Transaction);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Tarefas WHERE Id = @id;";
            var result = await _session.Connection.ExecuteAsync(sql, new { Id = id }, _session.Transaction);
            return result;
        }

        public async Task<Tarefas> Get(int id)
        {
            var sql = "SELECT * FROM Tarefas Where Id = @id";
            var result = await _session.Connection.QueryAsync<Tarefas>(sql, new { Id = id }, _session.Transaction);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Tarefas>> GetAll()
        {
            var sql = "SELECT * FROM Tarefas;";
            var result = await _session.Connection.QueryAsync<Tarefas>(sql, _session.Transaction);
            return result;
        }

        public async Task<int> Update(Tarefas entity)
        {
            entity.ModificadaEm = System.DateTime.Now;
            var sql = "UPDATE Tarefas SET Nome = @Nome, Descricao = @Descricao, " +
                "Status = @Status, ConcluidaEm = @ConcluidaEm,ModificaEm = @ModificadaEm  WHERE Id = @id";

            var result = await _session.Connection.ExecuteAsync(sql, entity, _session.Transaction);
            return result;
        }
    }
}
