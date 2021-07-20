using CleanArchMvc.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetByIdAsync(int? id);

        Task AddAsync(ProductDto productDto);

        Task UpdateAsync(ProductDto productDto);

        Task RemoveAsync(int? id);
    }
}
