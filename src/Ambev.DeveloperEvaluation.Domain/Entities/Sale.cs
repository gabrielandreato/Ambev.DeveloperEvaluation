using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
///     Represents a sales transaction in the system.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    ///     Constructor to set default parameters.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.Now;
        Validate();
    }

    /// <summary>
    ///     Unique sale number.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }


    /// <summary>
    ///     Customer name
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    ///     Branch name
    /// </summary>
    public Branch Branch { get; set; }


    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    ///     List of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    ///     Cancels the sale.
    /// </summary>
    public void CancelSale()
    {
        IsCancelled = true;
    }

    /// <summary>
    ///     Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    ///     A <see cref="ValidationResultDetail" /> containing:
    ///     - IsValid: Indicates whether all validation rules passed
    ///     - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    ///     <listheader>The validation includes checking:</listheader>
    ///     <list type="bullet">Sale number format and uniqueness</list>
    ///     <list type="bullet">Sale date validity</list>
    ///     <list type="bullet">Customer and branch verification</list>
    ///     <list type="bullet">Items validity</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}