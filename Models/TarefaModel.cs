using Gerenciador_de_tarefas.Enums;

namespace Gerenciador_de_tarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }

    }
}
