namespace AOP.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.DataTransferObjects;
    using AutoMapper;
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects.Base;

    [ApiController]
    [Route("[controller]")]
    public class MarketsController : ControllerBase
    {
        private ILogger<MarketsController> _logger;

        private IMarketRepository _marketRepository;

        private IMapper _mapper;

        public MarketsController(ILogger<MarketsController> logger, IMarketRepository marketRepository, IMapper mapper)
        {
            this._logger = logger;
            this._marketRepository = marketRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarkets()
        {
            try
            {
                var markets = await this._marketRepository.GetAllMarketsAsync();               

                var marketsResult = new List<AllMarketsDTO>();

                var countDict = new Dictionary<int, int>();

                foreach (var market in markets)
                {
                    var marketDetails = await this._marketRepository.GetMarketByNameWithSpotsAsync(market.Name);

                    var resultModel = _mapper.Map<AllMarketsDTO>(marketDetails);

                    marketsResult.Add(resultModel);
                }

                return Ok(marketsResult);
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
                var market = await this._marketRepository.GetMarketByNameWithSpotsAsync(name);

                if (market == null)
                {
                    _logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Returned market with details for name: {0}", name);

                    var marketResult = _mapper.Map<MarketDTO>(market);
                    return Ok(marketResult);
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
                var market = await this._marketRepository.GetMarketByNameWithHeadquartersAsync(name);               

                if (market == null)
                {
                    this._logger.LogError("Market with the name: {0}, could not be found in the database", name);
                    return NotFound();
                }
                else
                {
                    this._logger.LogInformation("Returned market with the name: {0}", name);

                    var marketResult = _mapper.Map<MarketByNameDTO>(market);

                    return Ok(marketResult);
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