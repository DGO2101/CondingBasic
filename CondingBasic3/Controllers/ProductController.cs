using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CondingBasic3.Models;
using CondingBasic3.DTOs;

namespace CondingBasic3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AdventureWorks2022Context _context;
        private readonly IMapper _mapper;

        public ProductController(AdventureWorks2022Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var products = _context.Product.ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }

        // GET: api/Product/GetProductByName?name=ProductName
        [HttpGet("GetProductByName")]
        public IActionResult GetProductByName(string name)
        {
            var products = _context.Product
                .Where(p => p.Name.Contains(name))
                .ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }

        // GET: api/Product/GetProductByCategoryType?type=ProductCategoryType
        [HttpGet("GetProductByCategoryType")]
        public IActionResult GetProductByCategoryType(string type)
        {
            var products = _context.Product
                .Where(p => p.ProductSubcategory.ProductCategory.Name == type)
                .ToList();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            // Include ProductSubcategoryId in the mapping
            foreach (var productDto in productDtos)
            {
                productDto.ProductSubcategoryId = products
                    .FirstOrDefault(p => p.ProductId == productDto.ProductId)
                    ?.ProductSubcategoryId;
            }

            return Ok(productDtos);
        }
    }
}

