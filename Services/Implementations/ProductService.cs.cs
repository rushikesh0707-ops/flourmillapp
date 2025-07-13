using FlourmillAPI.Data;
using FlourmillAPI.DTOs;
using FlourmillAPI.Models;
using FlourmillAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlourmillAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, Product updatedProduct)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return false;

            existing.Name = updatedProduct.Name;
            existing.Description = updatedProduct.Description;
            existing.ImageUrl = updatedProduct.ImageUrl;
            existing.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
