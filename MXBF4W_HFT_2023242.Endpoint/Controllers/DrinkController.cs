using Microsoft.AspNetCore.Mvc;
using MXBF4W_HFT_2023242.Logic;
using MXBF4W_HFT_2023242.Models;
using System.Collections.Generic;

namespace MXBF4W_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        IDrinkLogic logic;

        public DrinkController(IDrinkLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Drink> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Drink Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Drink value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Drink value)
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
