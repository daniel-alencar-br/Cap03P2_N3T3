using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cap03P2_N3T3.Models
{
    public class Alunos   // Entidade = Tabela BD
    {
        //[Range(1, 100)]
        //[Compare()]
        //[DisplayFormat()]
        //[Remote("")] -- .Net Core

        [Required]
        [Display(Name="Codigo do Aluno")]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [RegularExpression("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}", 
                           ErrorMessage ="Formato do CPF Inválido")]
        public string CPF { get; set; }

    }
}