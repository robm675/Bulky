using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository;


public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDBContext _ctx;

    public ProductRepository(ApplicationDBContext ctx) : base(ctx)
    {
        this._ctx = ctx;
    }

    public void Update(Product product)
    {
        _ctx.Products.Update(product);
    }
}
