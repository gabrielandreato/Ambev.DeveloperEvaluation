using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// todo: Definir documentação de regras de validação
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        
    }
}