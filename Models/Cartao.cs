using System.ComponentModel.DataAnnotations;

namespace GeradorCartao.Models
{
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string CodigoCartao { get; set; }
    }
}