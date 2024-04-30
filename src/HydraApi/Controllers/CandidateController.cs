using HydraApi.DTOs.Candidates;
using HydraApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HydraApi.Controllers;

[ApiController]
[Route("api/v1/candidate")]
public class CandidateController : ControllerBase
{
    private readonly CandidateService _service;

    public CandidateController(CandidateService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(int pageNumber, int pageSize, string? fullName = "", int bootcampId = 0)
    {
        try
        {
            var candidate = _service.Get(pageNumber, pageSize, fullName, bootcampId);
            if (candidate.Count == 0)
            {
                return NotFound(new ResponseDTO<string[]>()
                {
                    Message = ConstantConfigs.MESSAGE_NOT_FOUND("kandidat"),
                    Status = ConstantConfigs.STATUS_NOT_FOUND,
                    Data = Array.Empty<string>()
                });
            }

            return Ok(new ResponseWithPaginationDTO<List<CandidateResponseDTO>>()
            {
                Message = ConstantConfigs.MESSAGE_GET("kandidat"),
                Status = ConstantConfigs.STATUS_OK,
                Data = candidate,
                Pagination = new PaginationDTO()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalData = _service.Count(fullName, bootcampId)
                }
            });
        }
        catch (System.Exception)
        {
            return BadRequest(new ResponseDTO<string>()
            {
                Message = ConstantConfigs.MESSAGE_FAILED,
                Status = ConstantConfigs.STATUS_FAILED
            });
        }
    }

    [HttpPost]
    public IActionResult Insert(CandidateInsertDTO dto)
    {
        try
        {
            _service.Insert(dto);

            return Ok(new ResponseDTO<string>()
            {
                Message = ConstantConfigs.MESSAGE_POST("kandidat"),
                Status = ConstantConfigs.STATUS_OK
            });
        }
        catch (System.Exception)
        {
            return BadRequest(new ResponseDTO<string>()
            {
                Message = ConstantConfigs.MESSAGE_FAILED,
                Status = ConstantConfigs.STATUS_FAILED
            });
            throw;
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(CandidateUpdateDTO dto)
    {
        try
        {
            _service.Update(dto);

            return Ok(new ResponseDTO<string>()
            {
                Message = ConstantConfigs.MESSAGE_PUT("kandidat"),
                Status = ConstantConfigs.STATUS_OK
            });
        }
        catch (System.Exception)
        {
            return BadRequest(new ResponseDTO<string>()
            {
                Message = ConstantConfigs.MESSAGE_FAILED,
                Status = ConstantConfigs.STATUS_FAILED
            });
        }
    }
}
