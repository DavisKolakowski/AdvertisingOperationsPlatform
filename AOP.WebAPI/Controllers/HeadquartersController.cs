namespace AOP.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.Core.Contracts;
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;

    [ApiController]
    [Route("[controller]")]
    public class HeadquartersController : ControllerBase
    {
        private ILogger<HeadquartersController> _logger;

        private IHeadquartersRepository _headquartersRepository;

        public HeadquartersController(ILogger<HeadquartersController> logger, IHeadquartersRepository headquartersRepository)
        {
            this._logger = logger;
            this._headquartersRepository = headquartersRepository;
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

                    var headquartersResult = new HeadquartersDetailsDTO()
                    {
                        Id = headquarters.Id,
                        Name = headquarters.Name,
                        Markets = headquarters.Markets.Select(m => 
                        new MarketDTO()
                        {
                            Id = m.Id,
                            Name = m.Name,
                            LastUpdated = m.LastUpdated,
                        }),
                        LastUpdated = headquarters.LastUpdated,
                        DistributionServers = headquarters.DistributionServers.Select(ds =>
                        new DistributionServerDTO()
                        {
                            Id = ds.Id,
                            ServerIdentity = ds.ServerIdentity,
                            LastUpdated = ds.LastUpdated,
                            ServerFolder = ds.ServerFolder,
                            SpotsLogFileName = ds.SpotsLogFileName,
                            SpotsLogLastWriteTime = ds.SpotsLogLastWriteTime,
                            LastSuccessfulDatabaseJob = ds.LastSuccessfulDatabaseJob,
                            Spots = ds.DistributionServerSpots
                                .Select(dss =>
                                new DistributionServerSpotDTO()
                                {
                                    Id = dss.Id,
                                    FirstAirDate = dss.FirstAirDate,
                                    Spot = new SpotDTO()
                                    {
                                        Id = dss.Spot.Id,
                                        SpotIdentifier = dss.Spot.SpotIdentifier,
                                        Name = dss.Spot.Name,
                                    }
                                })
                        })
                    };

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