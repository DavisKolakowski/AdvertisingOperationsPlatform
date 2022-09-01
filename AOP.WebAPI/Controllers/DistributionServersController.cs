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
    public class DistributionServersController : ControllerBase
    {
        private ILogger<DistributionServersController> _logger;

        private IDistributionServerRepository _distributionServerRepository;

        public DistributionServersController(ILogger<DistributionServersController> logger, IDistributionServerRepository distributionServerRepository)
        {
            this._logger = logger;
            this._distributionServerRepository = distributionServerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistributionServers()
        {
            try
            {
                var distributionServers = await this._distributionServerRepository.GetAllDistributionServersAsync();

                return Ok(distributionServers.ToList());
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetAllDistributionServers action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{serverIdentity}", Name = "DistributionServerByServerIdentity")]
        public async Task<IActionResult> GetDistributionServerByServerIdentity(string serverIdentity)
        {
            try
            {
                var distributionServer = await this._distributionServerRepository.GetDistributionServerByServerIdentityAsync(serverIdentity);
                if (distributionServer == null)
                {
                    this._logger.LogError("Distribution server with the identity: {0}, could not be found in the database", serverIdentity);
                    return NotFound();
                }
                else
                {
                    this._logger.LogInformation("Returned distribution server with the identity: {0}", serverIdentity);
                    return Ok(distributionServer);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetHeadquartersByName action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{serverIdentity}/details")]
        public async Task<IActionResult> GetDistributionServerWithDetails(string serverIdentity)
        {
            try
            {
                var distributionServer = await this._distributionServerRepository.GetDistributionServerWithDetailsAsync(serverIdentity);

                if (distributionServer == null)
                {
                    _logger.LogError("Distribution server with the identity: {0}, could not be found in the database", serverIdentity);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Returned distribution server with details for identity: {0}", serverIdentity);

                    var distributionServerResult = new DistributionServerDetailsDTO()
                    {
                        Id = distributionServer.Id,
                        ServerIdentity = distributionServer.ServerIdentity,
                        LastUpdated = distributionServer.LastUpdated,
                        ServerFolder = distributionServer.ServerFolder,
                        SpotsLogFileName = distributionServer.SpotsLogFileName,
                        SpotsLogLastWriteTime = distributionServer.SpotsLogLastWriteTime,
                        LastSuccessfulDatabaseJob = distributionServer.LastSuccessfulDatabaseJob,
                        HeadquartersId = distributionServer.HeadquartersId,
                        HeadquartersName = distributionServer.Headquarters.Name,
                        HeadquartersLastUpdated = distributionServer.Headquarters.LastUpdated,
                        Spots = distributionServer.DistributionServerSpots
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
                    };

                    return Ok(distributionServerResult);
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