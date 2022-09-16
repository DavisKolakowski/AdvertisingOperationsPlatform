namespace AOP.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities;
    using AutoMapper;
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;
    using AOP.WebAPI.Models;

    [ApiController]
    [Route("[controller]")]
    public class MarketsController : ControllerBase
    {
        private ILogger<MarketsController> _logger;

        private IRepositoryBaseWrapper _repository;

        private IMapper _mapper;

        public MarketsController(ILogger<MarketsController> logger, IRepositoryBaseWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarkets()
        {
            try
            {
                var markets = await this._repository.Market.GetAllMarketsAsync();               

                var result = new List<MarketWithSpotCountResponse>();

                var countDict = new Dictionary<int, int>();

                foreach (var market in markets)
                {
                    var marketSpots = await this._repository.Market.GetSpotsByMarketAsync(market);

                    var resultModel = new MarketWithSpotCountResponse()
                    {
                        Market = _mapper.Map<MarketDTO>(market),
                        MarketSpotCount = marketSpots.Count(),
                    };

                    result.Add(resultModel);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetAllMarkets action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}/details")]
        public async Task<IActionResult> GetMarketWithSpotDetails(string name)
        {
            try
            {
                var market = await this._repository.Market.GetMarketByNameAsync(name);

                if (market == null)
                {
                    _logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Returned market with details for name: {0}", name);

                    var marketSpots = await this._repository.Market.GetSpotsByMarketAsync(market);

                    var marketResult = _mapper.Map<MarketDTO>(market);

                    var marketSpotDetailsResult = _mapper.Map<List<SpotDTO>>(marketSpots);

                    var response = new MarketWithSpotsResponse()
                    {
                        Market = marketResult,
                        SpotsInMarket = marketSpotDetailsResult,
                    };

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetMarketWithSpotDetails action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{name}", Name = "MarketByNameWithHeadquarters")]
        public async Task<IActionResult> GetMarketByNameWithHeadquarters(string name)
        {
            try
            {
                var market = await this._repository.Market.GetMarketByNameAsync(name);                             

                if (market == null)
                {
                    this._logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    var marketDetails = await this._repository.Market.GetMarketWithDetailsAsync(market.Id);

                    this._logger.LogInformation("Returned market with the name: {0}", name);

                    var marketResult = _mapper.Map<MarketDTO>(marketDetails);

                    var headquartersResult = _mapper.Map<List<HeadquartersDTO>>(marketDetails.Headquarters);

                    var response = new MarketWithHeadquartersResponse()
                    {
                        Market = marketResult,
                        Headquarters = headquartersResult,
                    };

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Something went wrong inside GetMarketByNameWithHeadquarters action: {0}", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}