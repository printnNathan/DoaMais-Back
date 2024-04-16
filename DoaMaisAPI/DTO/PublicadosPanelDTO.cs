using Microsoft.AspNetCore.Mvc;

namespace DoaMaisAPI.DTO
{
    public class PublicadosPanelDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDaRequisicao { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }
        public string Obeservacoes { get; set; }
        public string TipoDeDoacao { get; set; }

    }
}
