using System;
using Tarefa.Enums;

namespace Tarefa.Models
{
    public class Tarefas
    {
        public string Id { get;set; }
        public string Nome { get;set; }
        public string Descricao { get;set; }
        public StatusTarefa Status { get; set; }
        public DateTime ConcluidaEm { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime? ModificadaEm { get; set; }
    }
}
