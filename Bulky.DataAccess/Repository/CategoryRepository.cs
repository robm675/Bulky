using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDBContext _ctx;

    public CategoryRepository(ApplicationDBContext ctx) : base(ctx)
    {
        this._ctx = ctx;
    }

    public void Update(Category category)
    {
        _ctx.Categories.Update(category);
    }
}
