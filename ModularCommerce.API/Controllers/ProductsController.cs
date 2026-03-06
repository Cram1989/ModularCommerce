using Microsoft.AspNetCore.Mvc;
using ModularCommerce.Application.Interfaces;
using ModularCommerce.Domain.Entities;
using ModularCommerce.Domain.Repositories;
using ModularCommerce.Domain.ValueObjects;

namespace ModularCommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        var product = new Product(dto.Name, dto.Description, dto.Price, dto.Stock);
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(); // guarda entidad + Domain Events en Outbox
        return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
    }
}

// DTO de entrada para crear productos
public record CreateProductDto(string Name, string Description, Money Price, int Stock);