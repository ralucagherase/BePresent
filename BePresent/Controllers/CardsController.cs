using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BePresent.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BePresent.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardsController> _logger;

        public CardsController(ICardService cardService, ILogger<CardsController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }


    }
}