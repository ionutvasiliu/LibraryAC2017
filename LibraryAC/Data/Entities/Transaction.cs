using LibraryAC.Data.Entities;
using LibraryAC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAC.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}