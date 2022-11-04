using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wuetzally.Services;
using Wuetzally.Models;
using Microsoft.EntityFrameworkCore;

namespace Wuetzally.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    

    public class AlumnoController: ControllerBase
    {
        private readonly ContenidoDbContext context;

        public AlumnoController(ContenidoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumnos>>> Get(){
            return await context.Alumnos.ToListAsync();
        }
        
          [HttpGet("{Id}")]
        public async Task<ActionResult> Get(int Id) 
        {
            var alumnos = await context.Alumnos.FindAsync(Id);
            if(alumnos == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(alumnos);
        }
        }



        [HttpPost]
        public async Task<ActionResult> Post(Alumnos alumnos){
            context.Add(alumnos);
            await context.SaveChangesAsync();
            return Ok();
        }
        

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, Alumnos alumnos)
        {
            var alumnoExiste = await AlumnoExiste(Id);
            if (!alumnoExiste)
            {
                return NotFound();
            }

            context.Update(alumnos);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var alumnoExiste = await AlumnoExiste(Id);
            if (!alumnoExiste)
            {
                return NotFound();
            }

            context.Remove(new Alumnos() { Id = Id});
            await context.SaveChangesAsync();
            return NotFound();
        }
        private async Task<bool> AlumnoExiste(int Id)
        {
            return await context.Alumnos.AnyAsync(p => p.Id == Id);
        }
        


    }

}