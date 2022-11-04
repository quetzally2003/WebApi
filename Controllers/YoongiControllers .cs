using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wuetzally.Models;
using Wuetzally.Services;
using Microsoft.AspNetCore.Mvc;

namespace Wuetzally.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoongiControllers : ControllerBase 
    {
    

        public YoongiControllers()
        {


        }
            [HttpGet]
             public ActionResult<List<Yoongi>> GetAll() => YoongiService.GetAll(); 
                
            [HttpGet("(id)")]
             public ActionResult<Yoongi> Get (int id )
           {
              var yoongi = YoongiService.Get(id);
              if(yoongi == null)
                 
                 return NotFound();

                 return yoongi;
            
    
            }

            [HttpPost]
            public IActionResult Create(Yoongi yoongi)
            {
                YoongiService.Add(yoongi);
                return CreatedAtAction (nameof(Create),new {id = yoongi},yoongi);
            }

            [HttpDelete("(id")]

            public IActionResult Delete (int id)
            {
                var yoongi = YoongiService.Get(id);
                if(yoongi is null)
                return NotFound();

                YoongiService.Delete(id);

                return NoContent();
            }
            [HttpPut("(id)")]
            public IActionResult Update(int id, Yoongi yoongi)
            {
                if (id !=yoongi.Id)
                return BadRequest();

                var existingyoongi = YoongiService.Get(id);
                if (existingyoongi is null)
                return NotFound();

                YoongiService.Update(yoongi)
                
                ;

                return NoContent();
            }

        



    }
    
}