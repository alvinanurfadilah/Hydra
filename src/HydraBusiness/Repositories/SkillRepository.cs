using HydraBusiness.Interfaces;
using HydraDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HydraBusiness.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly HydraContext _context;

    public SkillRepository(HydraContext context)
    {
        _context = context;
    }

    public List<Skill> Get(int trainerId)
    {
        return _context.Skills
        .Include(s => s.TrainerSkillDetails)
        .Where(s => s.TrainerSkillDetails.Any(tsd => tsd.TrainerId == trainerId))
        .ToList();
    } 
}
