﻿using CrudASP_NET_CORE.Buseness;
using Microsoft.AspNetCore.Mvc;
using CrudASP_NET_CORE.Controllers.Data.VO;
using Tapioca.HATEOAS;

namespace CrudASP_NET_CORE.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {

        private IPersonBuseness _ipersonBuseness;

        public PersonsController(IPersonBuseness ipersonBuseness) => _ipersonBuseness = ipersonBuseness;

        // GET api/values
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            return Ok(_ipersonBuseness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _ipersonBuseness.FindByI(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_ipersonBuseness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _ipersonBuseness.Update(person);
            if (updatePerson == null) return NoContent();
            return new ObjectResult(_ipersonBuseness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(int id)
        {
            _ipersonBuseness.Delete(id);
            return NoContent();
        }
    }
}
