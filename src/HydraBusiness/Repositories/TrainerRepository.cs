using HydraBusiness.Interfaces;
using HydraDataAccess.Models;

namespace HydraBusiness.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private readonly HydraContext _context;

    public TrainerRepository(HydraContext context)
    {
        _context = context;
    }

    public List<Trainer> Get()
    {
        return _context.Trainers.ToList();
    }
}
