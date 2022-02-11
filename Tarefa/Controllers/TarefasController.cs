using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefa.Data.Repository.Interfaces;
using Tarefa.Models;

namespace Tarefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private IUnitOfWork _uow = null;
        public TarefasController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<IEnumerable<Tarefas>> GetTarefas()
        {
            var result = await _uow.Tarefas.GetAll();
            return result;
        }
        [HttpGet("{id:int}")]
        public async Task<Tarefas> GetTarefasbyId(int id)
        {
            var result = await _uow.Tarefas.Get(id);
            return result;
        }

        [HttpPost]
        public async Task<bool> AdicinarTarefa(Tarefas tarefa)
        {
            _uow.BeginTransaction();
            var result = await _uow.Tarefas.Add(tarefa);
            _uow.Commit();
            return result > 0;
        }
        [HttpPut]
        public async Task<bool> UpdateTarefa(Tarefas tarefas)
        {
            _uow.BeginTransaction();
            var result = await _uow.Tarefas.Update(tarefas);
            return result > 0;
        }
        [HttpDelete("{id:int}")]
        public async Task<bool> DeleteTarefa(int id)
        {
            _uow.BeginTransaction();
            var result = await _uow.Tarefas.Delete(id);
            _uow.Commit();
            return result > 0;
        }
    }
}
