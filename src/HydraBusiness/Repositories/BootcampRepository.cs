using HydraBusiness.Interfaces;
using HydraDataAccess.Models;

namespace HydraBusiness.Repositories;

public class BootcampRepository : IBootcampRepository
{
    private readonly HydraContext _context;

    public BootcampRepository(HydraContext context)
    {
        _context = context;
    }

    public List<BootcampClass> Get(int pageNumber, int pageSize, int id)
    {
        return _context.BootcampClasses
        .Where(bc => bc.Id == id || 0 == id)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public List<BootcampClass> Get()
    {
        return _context.BootcampClasses.ToList();
    }

    public BootcampClass GetById(int id)
    {
        return _context.BootcampClasses.Find(id);
    }

    public void Insert(BootcampClass bootcampClass)
    {
        try
        {
            _context.BootcampClasses.Add(bootcampClass);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public void Update(BootcampClass bootcampClass)
    {
        try
        {
            _context.BootcampClasses.Update(bootcampClass);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public int Count(int id)
    {
        return _context.BootcampClasses
        .Where(bc => bc.Id == id)
        .Count();
    }
}
