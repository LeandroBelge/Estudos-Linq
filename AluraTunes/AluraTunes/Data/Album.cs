//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AluraTunes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public Album()
        {
            this.Faixas = new HashSet<Faixa>();
        }
    
        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }
    
        public virtual Artista Artista { get; set; }
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
