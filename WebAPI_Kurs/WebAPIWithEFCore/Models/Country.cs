using System.ComponentModel.DataAnnotations;

namespace WebAPIWithEFCore.Models
{
    public class Country
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }    

        public short Population { get; set; }

        [StringLength(300)]
        public string CapitalCity { get; set; }

        public int ContinentId { get; set; }

        //Navigation Conitent 
        public virtual Continent? Continent { get; set; }

    }
}
