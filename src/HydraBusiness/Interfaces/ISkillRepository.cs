using HydraDataAccess.Models;

namespace HydraBusiness.Interfaces;

public interface ISkillRepository
{
    List<Skill> Get(int trainerId);
}
