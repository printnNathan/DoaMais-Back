namespace DoaMaisAPI.DTO
{
    public class ImagenPedidoDoacaoDTO
    {
        public int ID { get; set; }
        public string Link { get; set; }
        public int ID_PedidoDoacao { get; set; }
        public PedidoDoacaoDTO PedidoDoacao { get; set; }
    }
}
