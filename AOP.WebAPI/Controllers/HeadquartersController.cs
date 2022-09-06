namespace AOP.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;
    using AutoMapper;

    [ApiController]
    [Route("[controller]")]
    public class HeadquartersController : ControllerBase
    {
        private ILogger<HeadquartersController> _logger;

        private IHeadquartersRepository _headquartersRepository;

        private IMapper _mapper;

        public HeadquartersController(ILogger<HeadquartersController> logger, IHeadquartersRepository headquartersRepository, IMapper mapper)
        {
            this._logger = logger;
            this._headquartersRepository = headquartersRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeadquarters()
        {
            try
            {
                var headquarters = await this._headquartersRepository.GetAllHeadquartersAsync();

                return Ok(headquarters.ToList());
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetAllHeadquarters action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}", Name = "HeadquartersByName")]
        public async Task<IActionResult> GetHeadquartersByName(string name)
        {
            try
            {
                var headquarters = await this._headquartersRepository.GetHeadquartersByNameAsync(name);
                if (headquarters == null)
                {
                    this._logger.LogError("Headquarters with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    this._logger.LogInformation("Returned headquarters with the name: {0}", name);
                    return Ok(headquarters);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetHeadquartersByName action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}/details")]
        public async Task<IActionResult> GetHeadquartersWithDetails(string name)
        {
            try
            {
                var headquarters = await this._headquartersRepository.GetHeadquartersWithDetailsAsync(name);

                if (headquarters == null)
                {
                    _logger.LogError("Headquarters with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Returned headquarters with details for name: {0}", name);

                    var headquartersResult = _mapper.Map<HeadquartersWithDetailsDTO>(headquarters);
                    return Ok(headquartersResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetHeadquartersWithDetails action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}