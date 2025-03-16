﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSaleItem;

/// <summary>
///     Validator for UpdateSaleItemCommand that defines validation rules for sale creation command.
/// </summary>
public class UpdateSaleItemCommandValidator : AbstractValidator<UpdateSaleItemCommand>
{
    /// <summary>
    ///     Validates instances of <see cref="UpdateSaleItemCommand" />.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Product: Must be a valid enumeration value.
    ///     - Quantity: Must be greater than zero and less than 20.
    ///     - UnitPrice: Must be greater than or equal to zero.
    /// </remarks>
    public UpdateSaleItemCommandValidator()
    {
        RuleFor(item => item.Product).IsInEnum();
        RuleFor(item => item.Quantity).GreaterThan(0).LessThan(20);
        RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
    }
}