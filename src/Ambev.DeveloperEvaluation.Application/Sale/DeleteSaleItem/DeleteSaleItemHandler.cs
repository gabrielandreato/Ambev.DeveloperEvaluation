using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSaleItem
{
    /// <summary>
    /// Handler for processing DeleteSaleItemCommand requests
    /// </summary>
    public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, bool>
    {
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of DeleteSaleItemHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        public DeleteSaleItemHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the DeleteSaleItemCommand request
        /// </summary>
        /// <param name="request">The DeleteSaleItem command providing SaleItem Id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An object with the deleted id</returns>
        public async Task<bool> Handle(DeleteSaleItemCommand request, CancellationToken cancellationToken)
        {
            return await _saleRepository.DeleteItemAsync(request.Id, cancellationToken);
        }
    }
}