//#nullable disable
using System.ComponentModel.DataAnnotations;

namespace WebAPIWithEFCore.Models
{

    //Poco oder  Entity
    public class Continent
    {
        //keine Methode
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        //Wir verwenden hier Lazy Loading -> bedeutet wir müssen die Navigation Properties virtual markieren
        public virtual ICollection<Country>? Countries { get; set; }
    }
}
