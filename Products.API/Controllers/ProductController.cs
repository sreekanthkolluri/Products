using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using log4net;
using Products.Repository;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : ControllerBase
    {
        readonly IProductRepository _productRepo;
        readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Constructor
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("api/GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            _logger.Info("Start Getist");
            return (_productRepo.GetList());
        }

        [HttpGet]
        [Route("api/GetProduct")]
        public Product GetProduct(int id)
        {
            _logger.Info("Start GetById");
            return (_productRepo.GetById(id));
        }
    }
}
