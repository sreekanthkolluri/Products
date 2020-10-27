using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Repository
{
    public interface IRepository<T> where T: class
    {
        List<T> GetList();

        T GetById(int Id);
    }
}
