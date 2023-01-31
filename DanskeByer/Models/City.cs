using System.ComponentModel.DataAnnotations;

namespace DanskeByer.Models
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Bynavn")]
        public string Name { get; set; }

        [Display(Name = "Indbyggertal")]
        public int Population { get; set; }
    }
}
