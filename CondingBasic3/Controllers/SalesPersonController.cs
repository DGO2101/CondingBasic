using AutoMapper;
using CondingBasic3.DTOs;
using CondingBasic3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CondingBasic3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesPersonController : ControllerBase
    {
        private readonly AdventureWorks2022Context _context;
        private readonly IMapper _mapper;

        public SalesPersonController(AdventureWorks2022Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var salesPeople = _context.SalesPerson.ToList();
            var salesPersonDtos = _mapper.Map<List<SalesPersonDto>>(salesPeople);

            return Ok(salesPersonDtos);
        }
    }
}

