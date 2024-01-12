using CQRS.Model;
using MediatR;

namespace CQRS.Queries;

public record DeleteProductByIdQuery(int ProductId) : IRequest<Product>;
