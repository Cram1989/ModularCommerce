using MediatR;
using ModularCommerce.Application.DTOs;

namespace ModularCommerce.Application.Features.Products.Queries;

public record GetProductsQuery() : IRequest<List<ProductDto>>;