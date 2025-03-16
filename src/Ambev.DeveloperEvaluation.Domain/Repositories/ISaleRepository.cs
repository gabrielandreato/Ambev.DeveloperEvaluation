using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
///     Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    ///     Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all sales from the repository
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of all sales</returns>
    Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing sale in the repository
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    // <summary>
    /// Retrieves a sale by its sale number
    /// </summary>
    /// <param name="saleNumber">Sale identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Sale?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a list of sales from the database with optional filtering, pagination, and sorting parameters.
    /// </summary>
    /// <param name="saleNumber">Optional sale number to filter results.</param>
    /// <param name="isCanceled">Optional flag to filter by canceled status.</param>
    /// <param name="branch">Optional branch to filter results by.</param>
    /// <param name="customer">Optional customer to filter results by.</param>
    /// <param name="saleDateFrom">Optional starting date to filter sales from.</param>
    /// <param name="saleDateTo">Optional end date to filter sales until.</param>
    /// <param name="page">The page number for pagination (default is 0, which returns all results).</param>
    /// <param name="pageSize">The number of items per page (default is 0, which returns all results).</param>
    /// <param name="sortBy">Optional field name to sort results by. If null, no sorting is applied.</param>
    /// <param name="isDesc">Indicates whether sorting should be descending (true) or ascending (false). Default is false.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the async operation if needed.</param>
    /// <returns>
    ///     A paginated list of sales that match the given filtering parameters, including associated items.
    /// </returns>
    /// <remarks>
    ///     This method queries the database for sales records. If filtering parameters are provided,
    ///     the query will apply the corresponding filters to narrow down the results. 
    ///     Additionally, sorting and pagination can be applied to organize and limit the dataset.
    /// </remarks>
    Task<PagedList<Sale>> GetListAsync(string? saleNumber = null, bool? isCanceled = null,
        Branch? branch = null, Customer? customer = null, DateTime? saleDateFrom = null, DateTime? saleDateTo = null,
        int page = 0, int pageSize = 0, string? sortBy = null, bool isDesc = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a sale item from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale item was deleted, false if not found</returns>
    Task<bool> DeleteItemAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a sale item by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, null otherwise</returns>
    Task<SaleItem?> GetItemByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing sale item in the database
    /// </summary>
    /// <param name="saleItem">The sale item to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task UpdateItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
}