using CQRS.Model;
using MediatR;

namespace CQRS.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;