using Domain.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ApplicationContext _categoryContext;
    public CategoryRepository(ApplicationContext context)
    {
        _categoryContext = context;
    }

    public async Task<Category> Create(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetById(int? id)
    {
        var category = await _categoryContext.Categories.FindAsync(id);
        return category;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    public async Task<Category> Remove(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}