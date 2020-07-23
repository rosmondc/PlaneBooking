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
    public class TutorController : ControllerBase
    {
        private IGenericRepository<Tutor> _repository = null;
        private IMapper _mapper;
        public TutorController(IGenericRepository<Tutor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TutorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var results = await _repository.GetAllWithInclude(x => x.Availabilities);

            return Ok(_mapper.Map<IEnumerable<TutorViewModel>>(results));
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Tutor), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(int id)
        {
            var results = await _repository.GetByIdWithInclude(x => x.Id == id,
                include => include.Availabilities);

            return Ok(_mapper.Map<TutorViewModel>(results));
        }

        [HttpPost]
        public int Create(TutorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tutor = _mapper.Map<Tutor>(model);
                _repository.Insert(tutor);
                return tutor.Id;
            }
            return 0;
        }

        [HttpPut]
        public int Update(TutorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tutor = _mapper.Map<Tutor>(model);
                _repository.Update(tutor);
                return tutor.Id;
            }
            return 0;
        }

    }
}
