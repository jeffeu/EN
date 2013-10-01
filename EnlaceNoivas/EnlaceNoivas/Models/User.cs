using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnlaceNoivas.Models
{
    public class User
    {
        /*
            Lembrar de por unique nos campos user-name e e-mail q eu esqueci de por por enqnto 
        */
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome de usuário é obrigatório"),
        MinLength(3, ErrorMessage = "Nome de usuário deve ter no mínimo 3 caracteres"),
        MaxLength(40, ErrorMessage = "Nome de usuário deve ter no máximo 40 caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório"),
        MinLength(3, ErrorMessage = "Senha deve ter no mínimo 3 caracteres"),
        MaxLength(40, ErrorMessage = "Senha deve ter no máximo 40 caracteres")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar senha é obrigatório"),
        Compare("Pass", ErrorMessage = "A senha não corresponde")]
        public string ConfirmPass { get; set; }
        public string codetoactive { get; set; }
        public bool Actived {get;set;}

    }
}