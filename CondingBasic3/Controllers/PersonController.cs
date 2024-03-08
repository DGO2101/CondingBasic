using AutoMapper;
using CondingBasic3.DTOs;
using CondingBasic3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondingBasic3.Controllers
{
    public class PersonController : Controller
    {
        private readonly AdventureWorks2022Context _context;
        private readonly IMapper _mapper;
        public PersonController(AdventureWorks2022Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPersonAttributes()
        {
            var people = _context.Person.ToList();
            var personDtos = _mapper.Map<List<PersonDto>>(people);

            return Ok(personDtos);
        }

        [HttpGet("ByName")]
        public IActionResult GetPersonByName(string name)
        {
            var people = _context.Person
                .Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name))
                .ToList();

            var personDtos = _mapper.Map<List<PersonDto>>(people);

            return Ok(personDtos);
        }

        [HttpGet("ByPersonType")]
        public IActionResult GetPersonByPersonType(string personType)
        {
            var people = _context.Person
                .Where(p => p.PersonType == personType)
                .ToList();

            var personDtos = _mapper.Map<List<PersonDto>>(people);

            return Ok(personDtos);
        }
        [HttpGet("ByNameAndPersonType")]
        public IActionResult GetPersonByNameAndPersonType(string name, string personType)
        {
            var people = _context.Person
                .Where(p => (p.FirstName.Contains(name) || p.LastName.Contains(name)) && p.PersonType == personType)
                .ToList();

            var personDtos = _mapper.Map<List<PersonDto>>(people);

            return Ok(personDtos);
        }


    }
}
