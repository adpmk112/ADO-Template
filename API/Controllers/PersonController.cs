using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories.PersonRepo;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepo _personRepo;

        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        //[HttpGet]
        //public dynamic Test()
        //{
        //    Person person = new Person();
        //    person.Name = "Hpring";
        //    person.Age = 25;

        //    return _personRepo.Create(person);
        //}

        [HttpGet]
        public dynamic Test()
        {
            return _personRepo.GetAll();
        }

    }
}
