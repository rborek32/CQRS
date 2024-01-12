using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Model;
using CQRS.Queries;
using CQRS.Repository;
using MediatR;

namespace CQRS.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductByIdQuery, Product>
    {
        private readonly DataStore _dataStore;

        public DeleteProductHandler(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<Product> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming your DataStore.DeleteProduct method takes an int productId
                await _dataStore.DeleteProduct(request);

                // Assuming you have a method to retrieve the deleted product or you can return Unit.Value if not needed.
                Product deletedProduct = await _dataStore.GetProductById(request.ProductId);

                if (deletedProduct != null)
                {
                    return deletedProduct;
                }
                else
                {
                    throw new Exception("Product not found after deletion");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                throw; // You can also throw a custom exception if needed.
            }
        }
    }
}