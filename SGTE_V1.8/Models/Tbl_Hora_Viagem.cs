//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGTE_V1._8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Hora_Viagem
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string HoraReal_Embarque { get; set; }
        public string HoraReal_Desembarque { get; set; }
        public string HoraPrev_Embarque { get; set; }
        public string HoraPrev_Desembarque { get; set; }
        public Nullable<int> Viagem_ID { get; set; }
        public Nullable<int> Aluno_ID { get; set; }
    
        public virtual Tbl_Aluno Tbl_Aluno { get; set; }
        public virtual Tbl_Viagem Tbl_Viagem { get; set; }
    }
}
