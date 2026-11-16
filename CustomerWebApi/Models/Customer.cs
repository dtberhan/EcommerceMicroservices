using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWebApi.Models
{

    [Table("Customer")]
    public class Customer
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        [Key]
        public int CustomerId { get; set; }

        [Column("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [Column("mobile_number")]
        public string MobileNumber { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;
    }
}
