using System;
using System.Collections.Generic;
using log4net;
using System.Reflection;

namespace Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        static List<Product> productList;
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductRepository()
        {            
            if (productList == null)
            {
                productList = new List<Product> {
                    new Product { Id = 1, Name = "Product1", Description = "Product1 description", Price = 10, Rating = 2 }
                    ,new Product { Id = 2, Name = "Product2", Description = "Product2 description", Price = 20, Rating = 3 }
                    };

            }
        }

        public Product GetById(int Id)
        {
            try
            {
                log.Info("Start:" + MethodBase.GetCurrentMethod().Name);
                return productList.Find(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                log.Info("End:" + MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<Product> GetList()
        {
            try
            {
                log.Info("Start:" + MethodBase.GetCurrentMethod().Name);
                return productList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                log.Info("End:" + MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
