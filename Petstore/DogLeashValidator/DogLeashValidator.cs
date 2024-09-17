using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.DogLeashValidator
{
    public class DogLeashValidator : AbstractValidator<Product>
    {
        // We haven't gotten to the Generics part of this application, but it seems already clear what they're going to want us to do
        // We want to make this functionality available to all products including DryCatFood (so code is more reusable).
        public DogLeashValidator() 
        {
            RuleFor(DogLeash => DogLeash.Name).NotNull().NotEmpty();
            RuleFor(DogLeash => DogLeash.Quantity).GreaterThan(0);
            RuleFor(DogLeash => DogLeash.Price).GreaterThan(0);
            RuleFor(DogLeash => DogLeash.Description).MinimumLength(10).When(x => !string.IsNullOrEmpty(x.Description));
            // Validators seem alot like Services within the a Java DAO design pattern

            // To actually validate, we'll need to instantiate both the DogLeash and DogLeashValidator classes and use the Validate method which takes in a single arg
        }
    }
}
