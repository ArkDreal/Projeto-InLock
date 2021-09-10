using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public EstudioDomain Estudio { get; set; }

        [Required(ErrorMessage = "Informe o nome do jogo.")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento do jogo.")]
        [DataType(DataType.Date)]
        public DateTime DataLan { get; set; }

        [Required(ErrorMessage = "Informe o valor do jogo.")]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para esse jogo.")]
        public  string Descricao { get; set; }

    }
}
