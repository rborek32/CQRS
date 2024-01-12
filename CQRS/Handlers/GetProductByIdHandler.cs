using CQRS.Model;
using CQRS.Queries;
using CQRS.Repository;
using MediatR;

namespace CQRS.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly DataStore _dataStore;

    public GetProductByIdHandler(DataStore dataStore) => _dataStore = dataStore;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _dataStore.GetProductById(request.Id);
        
}