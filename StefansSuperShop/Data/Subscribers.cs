using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data
{
    public class Subscribers
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAdress { get; set; }
        [ForeignKey("NewsLettersId")]
        public int NewsLettersId { get; set; }
        public NewsLetters NewsLetters { get; set; }

    }
}
