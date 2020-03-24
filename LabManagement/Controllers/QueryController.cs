﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabManagement.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LabManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QueryController : ControllerBase
    {
        private readonly ILogger<QueryController> _logger;

        public QueryController(ILogger<QueryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult QueryLabChemicals(int labId)
        {
            return Ok("Test OK!!");
        }
    }
}