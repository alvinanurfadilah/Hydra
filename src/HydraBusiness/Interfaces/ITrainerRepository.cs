using HydraDataAccess.Models;

namespace HydraBusiness.Interfaces;

public interface ITrainerRepository
{
    List<Trainer> Get();
}
