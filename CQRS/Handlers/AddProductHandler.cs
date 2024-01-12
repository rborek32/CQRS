using CQRS.Commands;
using CQRS.Model;
using CQRS.Repository;
using MediatR;

namespace CQRS.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly DataStore _dataStore;

    public AddProductHandler(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public async Task<Product> Handle(AddProductCommand request,
        CancellationToken cancellationToken)
    {
        await _dataStore.AddProduct(request.Product);
        return request.Product;
    }
}