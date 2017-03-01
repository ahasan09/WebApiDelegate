
using System.ComponentModel.DataAnnotations;

namespace EcapPipeline.Repository
{
    public class Customer
    {
        [Required(ErrorMessage = "Id is Must")]
        public int Id { get; set; }
        [Required(ErrorMessage = "CustomerName is Must")]
        public string Name { get; set; }
    }
}