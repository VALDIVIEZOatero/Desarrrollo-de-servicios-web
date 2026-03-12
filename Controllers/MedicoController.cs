using Microsoft.AspNetCore.Mvc;

namespace MedicoController.Controllers
{
    [ApiController]
    [Route("api/medicos")]

    public class MedicoController : ControllerBase
    {
        public static List<Especialidad> esp = new List<Especialidad>()
        {
          new Especialidad{id_especialidad = 1, nombre ="Cardiologia" },
          new Especialidad{id_especialidad = 2, nombre="Pediatria"},
          new Especialidad{id_especialidad= 3, nombre="Dermatologia"} ,
          new Especialidad{id_especialidad = 4, nombre ="Ginecologia"},
          new Especialidad{id_especialidad = 5, nombre ="Neurologia"},
          new Especialidad{id_especialidad= 6, nombre="Traumatologia"}
        };
        public static List<Medico> medicos = new List<Medico>()
        {
            new Medico { id_medico=1,nombre = "Dr. Sebastian Navarro Rios", id_especialidad = 1, cmp = "CMP10234" },
            new Medico { id_medico=2,nombre = "Dra.Mariana Paredes Leon", id_especialidad = 2, cmp = "CMP20456" },
            new Medico { id_medico=3,nombre = "Dr. Javier Alonso Herrera", id_especialidad = 3, cmp = "CMP30987" },
            new Medico { id_medico=4,nombre = "Dra. Daniela Fuentes Cabrera", id_especialidad = 4, cmp = "CMP41235" },
            new Medico { id_medico=5,nombre = "Dr. Martin Salcedo Vargas", id_especialidad = 5, cmp = "CMP52348" },
            new Medico { id_medico=6,nombre = "Dra. Alejandra Quispe Morales", id_especialidad = 6, cmp = "CMP63421" }
        };
        [HttpGet]
        public IActionResult GetMedicos()
        {
            try
            {
                var datos_medicos = medicos.Select(dm => new
                    {
                        dm.id_medico,
                        dm.nombre,
                        especialidad = esp.FirstOrDefault(e=>e.id_especialidad == dm.id_especialidad)?.nombre,
                        dm.cmp
                    }
                ).ToList();
                return Ok(datos_medicos);
            }catch(Exception){
                return StatusCode(500,"Error interno en el servidor");
            }
        }
        [HttpGet("cantidad")]
        public IActionResult GetCantidadMedicos()
        {
            return Ok(esp.Count);
        }
        [HttpGet("{id}")]
        public IActionResult GetMedicosPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id tiene que ser mayor a 0!");
                }
                foreach (Medico m in medicos)
                {
                    if ( m.id_medico == id)
                    {
                        return Ok(m);
                    }
                }
                return NotFound("Medico no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpPost]
        public IActionResult PostMedicos([FromBody] Medico nuevomedico)
        {
            try
            {
                if (nuevomedico == null)
                {
                    return BadRequest("Ingrese los datos para medico");
                }
                nuevomedico.id_medico = medicos.Max(m=>m.id_medico)+1;
                medicos.Add(nuevomedico);
                return Created($"api/medicos{nuevomedico.id_medico}",nuevomedico);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMedicos(int id , Medico medicoactualizado)
        {
            try
            {
               
                var medico = medicos.FirstOrDefault(m=>m.id_medico == id);
                if (medico == null)
                {
                    return NotFound("Error al actualizar");
                }
                if(medico.id_medico <= 0)
                {
                    return BadRequest("EL id medico tiene que ser  mayor a 0");
                }
                medico.nombre = medicoactualizado.nombre;
                medico.id_especialidad = medicoactualizado.id_especialidad;
                medico.cmp = medicoactualizado.cmp;
                return Ok(medico);
            }catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicos(int id)
        {
            try
            {
                var medico = medicos.FirstOrDefault(m=>m.id_medico== id);
                if (medico == null)
                {
                    return NotFound("Medico no encontrado");
                }
                medicos.Remove(medico);
                return Ok("Medico eliminado correctamente!");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }

    }
}