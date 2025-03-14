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
    /// Retrieves a list of sales from the database with optional filtering parameters.
    /// </summary>
    /// <param name="saleNumber">Optional sale number to filter results.</param>
    /// <param name="isCanceled">Optional flag to filter by canceled status.</param>
    /// <param name="branch">Optional branch to filter results by.</param>
    /// <param name="customer">Optional customer to filter results by.</param>
    /// <param name="saleDateFrom">Optional starting date to filter sales from.</param>
    /// <param name="saleDateTo">Optional end date to filter sales until.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the async operation if needed.</param>
    /// <returns>An enumerable list of sales that match the given filtering parameters, including associated items.</returns>
    /// <remarks>
    /// This method queries the database for sales records. If filtering parameters are provided,
    /// the query will apply the corresponding filters to narrow down the results. The method supports
    /// optional parameters, which when omitted, will not be applied in filtering the dataset.
    /// </remarks>
    Task<IEnumerable<Sale>> GetListAsync(string? saleNumber = null, bool? isCanceled = null,
        Branch? branch = null, Customer? customer = null, DateTime? saleDateFrom = null, DateTime? saleDateTo = null,
        CancellationToken cancellationToken = default);


}