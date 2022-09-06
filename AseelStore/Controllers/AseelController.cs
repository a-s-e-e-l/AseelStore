using AseelStore.Model;
using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AseelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseelController : ControllerBase
    {
        private StoreContext _storeContext;

        public AseelController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        // GET: api/<AseelController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var x = _storeContext.Items.ToList();
            return x;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<AseelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            WriteCsvFile();
            return "CSV File Created";
        }
        private void WriteCsvFile()
        {
            var itemList = _storeContext.Items.ToList();

            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new CsvContext();
            csvContext.Write(itemList, "category01.csv", csvFileDescription);
        }

        // POST api/<AseelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AseelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AseelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
