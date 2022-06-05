namespace SysPatrimonio.Models
{
    public class DtoPatrimonio
    {
        public int id { get; set; }
        public string numetiqueta { get; set; }
        public string nomepatrimonio { get; set; }
        public string descricaopatrimonio { get; set; }
        public decimal valorpatrimonio { get; set; }
        public int idcategoria { get; set; }
        public string nomecategoria { get; set; }
        public int idlocal { get; set; }
        public string nomelocal { get; set; }
        public int iddepartamento { get; set; }
        public string nomedepartamento { get; set; }
        public int idfornecedor { get; set; }
        public string nomefornecedor { get; set; }
        public string marcamodelo { get; set; }
        public int numnf { get; set; }
        public string numserie { get; set; }
        public string situacao { get; set; }
        public DateOnly dataaquisicao { get; set; }
        public DateOnly databaixa { get; set; }
        public DateOnly datagarantia { get; set; }

    }
}
