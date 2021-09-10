using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {

        public int idUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }

        [Required(ErrorMessage = "Insira um email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha de 10 caracteres.")]
        public string Senha { get; set; }
    }
}
