using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;

namespace EspecialidadController.Controllers
{
    [ApiController]
    [Route("api/especialidades")]

    public class EspecialidadController : ControllerBase
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

        [HttpGet]
        public IActionResult GetEspecialidad()
        {
            try
            {
                return Ok(esp);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetEspecialidadPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID tiene que ser mayor a 0");
            }
            foreach (Especialidad e in esp)
            {
                if (e.id_especialidad == id)
                {
                    return Ok(e);
                }
            }

            return NotFound("La especialidad no fue encontrada");
        }
        [HttpPost]
        public IActionResult PostEspecialidad([FromBody] Especialidad  espNuevo)
        {
            try
            {
                if (espNuevo == null)
                {
                    return BadRequest("Hubo un problema al ingresar una nueva especialidad!!");
                }
                espNuevo.id_especialidad = esp.Max(e=>e.id_especialidad)+1;
                esp.Add(espNuevo);
                return Created($"api/especialidades/{espNuevo.id_especialidad}",espNuevo);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEspecialidad(int id , Especialidad espActualizada)
        {
            try
            {
                var especialidad = esp.FirstOrDefault(e => e.id_especialidad == id);
                if (especialidad == null)
                {
                    return NotFound("Especialidad no encontrado");
                }
                if (especialidad.id_especialidad <= 0)
                {
                    return BadRequest("El id_especialidad tiene que ser mayor a 0");
                }
                especialidad.nombre = espActualizada.nombre;
                return Ok(especialidad);
            }
            catch(Exception){return StatusCode(500,"Error interno al servidor");}
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidad(int id)
        {
            try
            {
                var especialidad = esp.FirstOrDefault(e=>e.id_especialidad == id);
                if (especialidad == null)
                {
                    return NotFound("Error al eliminar la especialidad ");
                }
                esp.Remove(especialidad);
                return Ok("Especialidad eliminado correctamente!");
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
    }
}