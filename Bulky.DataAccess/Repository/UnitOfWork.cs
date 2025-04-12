using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository;


public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _ctx;

    public ICategoryRepository Category {get; private set;}
    public IProductRepository Product {get; private set; }



    public UnitOfWork(ApplicationDBContext ctx) 
    {
        this._ctx = ctx;
        this.Category = new CategoryRepository(ctx);
        this.Product = new ProductRepository(ctx);
    }

    public void Save()
    {
        _ctx.SaveChanges();
    }
}
