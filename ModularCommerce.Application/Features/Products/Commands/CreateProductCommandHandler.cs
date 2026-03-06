using MediatR;
using ModularCommerce.Domain.Entities;
using ModularCommerce.Domain.Repositories;
using ModularCommerce.Domain.ValueObjects;

namespace ModularCommerce.Application.Features.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Description,
            Money.Eur(request.Price),
            request.Stock
        );

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}