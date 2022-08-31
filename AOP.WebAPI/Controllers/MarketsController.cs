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
    public class MarketsController : ControllerBase
    {
        private ILogger<MarketsController> _logger;

        private IMarketRepository _marketRepository;

        public MarketsController(ILogger<MarketsController> logger, IMarketRepository marketRepository)
        {
            this._logger = logger;
            this._marketRepository = marketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarkets()
        {
            try
            {
                var markets = await this._marketRepository.GetAllMarketsAsync();

                return Ok(markets.ToList());
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetAllMarkets action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}", Name = "MarketByName")]
        public async Task<IActionResult> GetMarketByName(string name)
        {
            try
            {
                var market = await this._marketRepository.GetMarketByNameAsync(name);
                if (market == null)
                {
                    this._logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    this._logger.LogInformation("Returned market with the name: {0}", name);
                    return Ok(market);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetMarketByName action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}/details")]
        public async Task<IActionResult> GetMarketWithDetails(string name)
        {
            try
            {
                var market = await this._marketRepository.GetMarketWithDetailsAsync(name);
                if (market == null)
                {
                    _logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Returned market with details for name: {0}", name);

                    var marketResult = new MarketDTO()
                    {
                        Id = market.Id,
                        Name = market.Name,
                        LastUpdated = market.LastUpdated,
                        Headquarters = market.Headquarters.Select(hq =>
                            new HeadquartersDTO()
                            {
                                Id = hq.Id,
                                Name = hq.Name,
                                LastUpdated = hq.LastUpdated,
                                DistributionServers = hq.DistributionServers.Select(ds =>
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
                            })
                    };

                    return Ok(marketResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetMarketWithDetails action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}