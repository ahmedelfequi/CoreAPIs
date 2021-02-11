using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebGraduationProject.Models;
using WebGraduationProject.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace WebGraduationProject.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class productController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public productController(IProductRepository productRepository,
                                  IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var products = this.productRepository.GetAllProducts();

            if(products != null)
            {
                return Ok(mapper.Map<IEnumerable<ProductReadDto>>(products));
            }

            return NotFound();
        }

        // GET api/products/{Id}
        [HttpGet("{Id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int Id)
        {
            var product = this.productRepository.GetProductById(Id);

            if(product != null)
            {
                return Ok(mapper.Map<ProductReadDto>(product));
            }

            return NotFound();
        }

        //POST api/products
        [HttpPost]
        public ActionResult<ProductReadDto> CreateNewProduct (ProductCreateDto productCreateDto)
        {
            var productModel = mapper.Map<Product>(productCreateDto);
            productRepository.AddProduct(productModel);
            productRepository.SaveChanges();

            var productReadDto = mapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.productID }, productReadDto);
            // return Ok(productReadDto);
        }

        //PUT Update api/products/{Id}
        [HttpPut("{Id}")]
        public ActionResult UpdateProduct (int Id, ProductUpdateDto productUpdateDto)
        {
            var productModelFromRepo = productRepository.GetProductById(Id);

            mapper.Map(productUpdateDto, productModelFromRepo);

            productRepository.UpdateProduct(productModelFromRepo);
            productRepository.SaveChanges();

            return NoContent();
        }

        //Update PATCH api/products/{id}
        [HttpPatch("{Id}")]
        public ActionResult PartialProductUpdate (int Id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            var productFromRepository = productRepository.GetProductById(Id);

            if(productFromRepository == null)
            {
                return NotFound();
            }

            var productToPatch = mapper.Map<ProductUpdateDto>(productFromRepository);

            patchDoc.ApplyTo(productToPatch, ModelState);

            if(!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(productToPatch, productFromRepository);
            
            productRepository.UpdateProduct(productFromRepository);
            productRepository.SaveChanges();

            return NoContent();
        }


        //DELETE api/products/{id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteProduct (int Id)
        {
            var productFromRepo = productRepository.GetProductById(Id);

            productRepository.DeleteProduct(productFromRepo);
            productRepository.SaveChanges();

            return NoContent();
        }
    }
}