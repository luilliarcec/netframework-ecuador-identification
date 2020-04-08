# Net Framework Logger

[![latest version](https://img.shields.io/nuget/v/Luilliarcec.Identification.Ecuador)](https://www.nuget.org/packages/Luilliarcec.Identification.Ecuador) 
[![downloads](https://img.shields.io/nuget/dt/Luilliarcec.Identification.Ecuador)](https://www.nuget.org/packages/Luilliarcec.Identification.Ecuador)

Validations for identifications of people and companies of Ecuador, an important requirement for electronic invoicing.

## Installation

You can install the package via nuget:

```bash
dotnet add package Luilliarcec.Identification.Ecuador
```

## Usage

You can use it by following this example

```csharp
using Luilliarcec.Identification.Ecuador;
// ...

namespace Test
{
    public class Foo
    {
        public void Save(string identification_number) 
        {
            string code;

            if ((code = Identification.ValidateAllTypeIdentification(identification_number)) != null) 
            {
                Console.WriteLine(code);
            }
        }
    }
}
```

The static class exposes the following methods.:

| Methods | Return | Description |
| -- | -- | -- |
| ValidateFinalCustomer | `string|null` | Validates the Ecuadorian Final Consumer |
| ValidatePersonalIdentification | `string|null` | Validates the Ecuadorian Identification Card |
| ValidateNaturalRuc | `string|null` | Validates the Ecuadorian RUC of Natural Person |
| ValidatePublicRuc | `string|null` | Validates the Ecuadorian RUC of Public Companies |
| ValidatePrivateRuc | `string|null` | Validates the Ecuadorian RUC of Private Companies |
| ValidateRuc | `string|null` | Validates the Ecuadorian RUC |
| ValidateIsNaturalPerson | `string|null` | Validate that the number belongs to natural persons |
| ValidateIsJuridicalPerson | `string|null` | Validate that the number belongs to juridical persons |
| ValidateAllTypeIdentification | `string|null` | Validate the number with all types of documents |

Follow these tips and have a happy code. 

### Security

If you discover any security related issues, please email luilliarcec@gmail.com instead of using the issue tracker.

## Credits

- [Luis Andrés Arce C.](https://github.com/luilliarcec)
- [All Contributors](../../contributors)

## License

The MIT License (MIT). Please see [License File](LICENSE.md) for more information.
