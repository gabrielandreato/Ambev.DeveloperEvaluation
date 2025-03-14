using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetListSale
{
    /// <summary>
    /// Represents a request to get a list of sales in the system with optional filters.
    /// </summary>
    public class GetListSaleRequest
    {
        /// <summary>
        /// Optional sale number to filter results.
        /// </summary>
        public string? SaleNumber { get; set; }

        /// <summary>
        /// Optional flag to filter by canceled status.
        /// </summary>
        public bool? IsCanceled { get; set; }

        /// <summary>
        /// Optional branch to filter results by.
        /// </summary>
        public Branch? Branch { get; set; }

        /// <summary>
        /// Optional customer to filter results by.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// Optional starting date to filter sales from.
        /// </summary>
        public DateTime? SaleDateFrom { get; set; }

        /// <summary>
        /// Optional end date to filter sales until.
        /// </summary>
        public DateTime? SaleDateTo { get; set; }
    }
}