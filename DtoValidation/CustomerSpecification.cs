using EcapPipeline.Repository;
using SpecExpress;

namespace DtoValidation
{
   public class CustomerSpecification:Validates<Customer>
    {
        public CustomerSpecification()
        {
            this.IsDefaultForType();
            this.Check(u => u.Id).Required().Not.EqualTo(0);
            this.Check(u => u.Name).Required().LengthBetween(0, 100);
        }
    }
}
