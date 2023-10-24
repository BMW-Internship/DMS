using Microsoft.AspNetCore.Mvc;

namespace DMS_Internship.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BMWManagementController : ControllerBase
    {
        private static readonly string[] models = new[]
        {
        "BMW 3 Series", "BMW X1", "BMW 7 Series", "BMW X5", "1 Series", "BMW X7", "BMW 2 Series Gran Coupe", "BMW X4", "2 Series", "BMW iX3","BMW M2 Coupe","BMW X6"
    };

        private readonly ILogger<BMWManagementController> _logger;

        public BMWManagementController(ILogger<BMWManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Dealerships> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Dealerships
            {
                //Price = models[Random.Shared.Next(models.Length)],
                
                Summary = models[Random.Shared.Next(models.Length)]
            })
            .ToArray();
        }


        [HttpPost]
        public void post()
        {
            //_reop.post(student);
        }

        [HttpPut]
        
        public void Put()
        {
        //    _reop.Put(id, student);
        }

        [HttpDelete]
        
        public void Delete(int id)
        {
        //    _reop.Delete(id);
        }
        }

    }
