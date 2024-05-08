using HydraApi.DTOs.Bootcamps;
using HydraBusiness.Interfaces;
using HydraDataAccess.Models;

namespace HydraApi.Services;

public class BootcampService
{
    private readonly IBootcampRepository _repository;

    public BootcampService(IBootcampRepository repository)
    {
        _repository = repository;
    }

    public List<BootcampResponseDTO> Get(int pageNumber, int pageSize, int id)
    {
        return _repository.Get(pageNumber, pageSize, id)
        .Select(bc => new BootcampResponseDTO()
        {
            Id = bc.Id,
            Description = bc.Description,
            StartDate = bc.StartDate,
            EndDate = bc.EndDate
        }).ToList();
    }

    public void Insert(BootcampInsertDTO dto)
    {
        var bc = new BootcampClass()
        {
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        _repository.Insert(bc);
    }

    public void Update(BootcampUpdateDTO dto)
    {
        var bc = _repository.GetById(dto.Id);
        bc.Description = dto.Description;
        bc.StartDate = dto.StartDate;
        bc.EndDate = dto.EndDate;

        _repository.Update(bc);
    }

    public int Count(int id)
    {
        return _repository.Count(id);
    }

    public void UpdatePlan(BootcampUpdatePlanDTO dto)
    {
        var bc = _repository.GetById(dto.Id);
        bc.Progress = dto.Progress;

        _repository.Update(bc);
    }

    public List<BootcampResponseSubPageDTO> GetSubPage(int pageNumber, int pageSize, int progress)
    {
        return _repository.GetSubPage(pageNumber, pageSize, progress)
        .Select(bc => new BootcampResponseSubPageDTO()
        {
            Id = bc.Id,
            Description = bc.Description,
            StartDate = bc.StartDate,
            EndDate = bc.EndDate,
            TrainerName = bc.Courses.Select(c => c.TrainerSkillDetail.Trainer.FirstName + c.TrainerSkillDetail.Trainer.LastName).FirstOrDefault(),
            SkillName = bc.Courses.Select(c => c.TrainerSkillDetail.Skill.Name).FirstOrDefault(),
            TotalCandidate = _repository.CountCandidate(bc.Id)
        }).ToList();

    }

    public int CountCandidate(int progress)
    {
        return _repository.CountCandidate(progress);
    }
}
