using Microsoft.AspNetCore.Mvc;
using MXBF4W_HFT_2023242.Logic;
using MXBF4W_HFT_2023242.Models;
using System.Collections.Generic;

namespace MXBF4W_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PubController : ControllerBase
    {
        IPubLogic logic;

        public PubController(IPubLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Pub> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Pub Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Pub value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Pub value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
