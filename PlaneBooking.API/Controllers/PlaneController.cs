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
    public class PlaneController : ControllerBase
    {
        private IGenericRepository<Plane> _repository = null;
        private IMapper _mapper;
        
        public PlaneController(IGenericRepository<Plane> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlaneViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var results = await _repository.GetAllWithInclude(x => x.PlaneDepartures);

            return Ok(_mapper.Map<IEnumerable<PlaneViewModel>>(results));
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Plane), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(int id)
        {
            var results = await _repository.GetByIdWithInclude(x => x.Id == id,
                include => include.PlaneDepartures);

            return Ok(_mapper.Map<PlaneViewModel>(results));
        }

        [HttpPost]
        public int Create(PlaneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var plane = _mapper.Map<Plane>(model);
                _repository.Insert(plane);
                return plane.Id;
            }
            return 0;
        }

        [HttpPut]
        public int Update(PlaneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var plane = _mapper.Map<Plane>(model);
                _repository.Update(plane);
                return plane.Id;
            }
            return 0;
        }
    }
}
