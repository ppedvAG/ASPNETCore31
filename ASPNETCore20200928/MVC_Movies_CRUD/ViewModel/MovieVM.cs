using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Movies_CRUD.ViewModel
{
    public class MovieVM
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Bitte drei Kniebeugen und dann nochmal eingeben!")]

        public string Title { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }


        [MinLength(5)]
        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime Kinobesuch { get; set; }
    }
}
