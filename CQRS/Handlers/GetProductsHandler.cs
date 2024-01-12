using CQRS.Model;
using CQRS.Queries;
using CQRS.Repository;
using MediatR;

namespace CQRS.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly DataStore _dataStore;

    public GetProductsHandler(DataStore fakeDataStore) => _dataStore = fakeDataStore;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken) => await _dataStore.GetAllProducts();
    
    
    
    
}