﻿using CQRS.Model;
using MediatR;

namespace CQRS.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;