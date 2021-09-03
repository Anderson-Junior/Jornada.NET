using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;
            var productViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel addProductInputModel)
        {
            var product = new Product(addProductInputModel.Title, addProductInputModel.Description, addProductInputModel.Price);
            _dbContext.Products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, addProductInputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel updateProductInputModel)
        {
            if(updateProductInputModel.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            product.Update(updateProductInputModel.Description, updateProductInputModel.Price);
            return NoContent();
        }
    }
}
