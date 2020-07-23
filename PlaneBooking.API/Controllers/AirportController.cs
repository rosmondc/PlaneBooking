using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaneBooking.DataAccess.Repositories.Contracts;
using PlaneBooking.Database.Models;
using PlaneBooking.Database.ViewModels;

namespace PlaneBooking.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private IGenericRepository<Airport> _repository = null;
        private IMapper _mapper;

        public AirportController(IGenericRepository<Airport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AirportViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var results = await _repository.GetAllWithInclude(x => x.Planes);

            return Ok(_mapper.Map<IEnumerable<AirportViewModel>>(results));
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(AirportViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(int id)
        {
            var results = await _repository.GetByIdWithInclude(x => x.Id == id,
                include => include.Planes);

            return Ok(_mapper.Map<AirportViewModel>(results));
        }

        [HttpPost]
        public int Create(AirportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var airport = _mapper.Map<Airport>(model);
                _repository.Insert(airport);
                return airport.Id;
            }
            return 0;
        }

        [HttpPut]
        public int Update(PlaneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var airport = _mapper.Map<Airport>(model);
                _repository.Update(airport);
                return airport.Id;
            }
            return 0;
        }
    }
}
