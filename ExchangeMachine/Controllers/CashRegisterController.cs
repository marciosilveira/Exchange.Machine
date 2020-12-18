using Exchange.Machine.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Dto = Exchange.Machine.Dto;

namespace ChangeMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashRegisterController : ControllerBase
    {
        private readonly ILogger<CashRegisterController> _logger;
        private readonly ICashRegister _cashRegister;

        public CashRegisterController(ILogger<CashRegisterController> logger, ICashRegister cashRegister)
        {
            _logger = logger;
            _cashRegister = cashRegister;
        }

        [HttpGet]
        public ICoin[] GetAll()
        {
            try
            {
                return _cashRegister.Box.Coins;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data from server");
                return Coin.New();
            }
        }

        [HttpPost("IncreaseQuantity")]
        public ActionResult<ICoin[]> IncreaseQuantity([FromBody] Dto.Coin[] coins)
        {
            try
            {
                _cashRegister.SupplyCoins(coins);
                return Ok(_cashRegister.Box.Coins);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data from server");
                return BadRequest();
            }
        }

        [HttpPost("DecreaseQuantity")]
        public ActionResult<ICoin[]> DecreaseQuantity([FromBody] Dto.Coin[] coins)
        {
            try
            {
                _cashRegister.Bloodletting(coins);
                return Ok(_cashRegister.Box.Coins);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data from server");
                return BadRequest(_cashRegister.Box.Coins);
            }
        }

        [HttpPost("ToExchange/{cents}")]
        public ActionResult<IChange> ToExchange(int cents)
        {
            try
            {
                return Ok(_cashRegister.ToExchange(cents));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data from server");
                return BadRequest();
            }
        }
    }
}
