namespace DoaMaisAPI.DTO
{
    public class PendentesPanelDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDaRequisicao { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string TipoDeDoacao { get; set; }
    }
}
