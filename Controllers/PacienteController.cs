

using Microsoft.AspNetCore.Mvc;

namespace PacienteController.Controllers
{
        [ApiController]
        [Route("api/pacientes")]
    public class PacienteController : ControllerBase
    {
        public static List<Paciente> pacientes = new List<Paciente>()
        {
            new Paciente{id_paciente = 1 , nombre = "Maria Fernanda Lopez",id = "123456789",fecha_nacimiento = "10-10-1974",telefono="+14157283946", correo = "ferlopez@correo.com"},
            new Paciente{id_paciente = 2 , nombre = "Jorge Luis Salcedo", id = "123456790",fecha_nacimiento = "15-08-2001",telefono="+19556677880", correo = "jorgeluis@correo.com"},
            new Paciente{id_paciente=3,nombre="Daniel Paredes Ruiz",id="123456791",fecha_nacimiento="25-10-1993",telefono="+19905559660 ",correo="dani_paredes@correo.com"},
            new Paciente{id_paciente=4,nombre="Ricardo Manuel Herrera",id="123456792",fecha_nacimiento="08-04-1996",telefono="+18006304560",correo="ricardoMh@correo.com"},
            new Paciente{id_paciente=5,nombre="Alejandra Quispe Morales",id="123456793",fecha_nacimiento="06-08-2004",telefono="+18880006312",correo="aleQuispe_more@correo.com"},
            new Paciente{id_paciente=6,nombre="Martin Alonso Cabrera",id="123456794",fecha_nacimiento="24-05-1990",telefono="+19893344550",correo="martin@correo.com"},
            new Paciente{id_paciente=7,nombre="Gabriela Julia Campos",id="123456795",fecha_nacimiento="06-07-2005",telefono="+19127788996",correo="gabiJuly@correo.com"},
            new Paciente{id_paciente=8,nombre="Renato Diego Savedra",id="123456796",fecha_nacimiento="23-07-2001",telefono="+19451122440",correo="renatoDS@correo.com"},
            new Paciente{id_paciente=9,nombre="Maria Dolores Nuñez",id="123456797",fecha_nacimiento="15-10-2006",telefono="+19984455666",correo="mari@correo.com"}
        };
        [HttpGet]
        public IActionResult GetPacientes()
        {
            try
            {
                return Ok(pacientes);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpGet("cantidad")]
        public IActionResult GetCantidadPacientes()
        {
            try{return Ok(pacientes.Count);}
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpGet("{id}")]
        public IActionResult GetPacientePorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id tiene que ser mayor a 0!");
                }
                foreach (Paciente p in pacientes)
                {
                    if (p.id_paciente == id)
                    {
                        return Ok(p);
                    }
                }
                return NotFound("Paciente no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpPost]
        public IActionResult PostPaciente([FromBody] Paciente nuevopaciente)
        {
            try
            {
                if (nuevopaciente == null)
                {
                    return BadRequest("Ingrese los datos para enviar a la lista Pacientes");
                }
                if (string.IsNullOrWhiteSpace(nuevopaciente.nombre))
                {
                    return BadRequest("El nombre del paciente es Obligatorio!");
                }
                if (string.IsNullOrWhiteSpace(nuevopaciente.id))
                {
                    return BadRequest("El ID del paciente es Obligatorio!");
                }
                if (string.IsNullOrWhiteSpace(nuevopaciente.fecha_nacimiento))
                {
                    return BadRequest("La fecha de nacimientodel paciente es Obligatorio!");
                }
                if (string.IsNullOrWhiteSpace(nuevopaciente.telefono))
                {
                    return BadRequest("El telefono del paciente es Obligatorio!");
                }
                if (string.IsNullOrWhiteSpace(nuevopaciente.correo))
                {
                    return BadRequest("El correo del paciente es Obligatorio!");
                }
                nuevopaciente.id_paciente = pacientes.Max(p=>p.id_paciente) + 1;
                pacientes.Add(nuevopaciente);
                return Created($"api/pacientes/{nuevopaciente.id_paciente}",nuevopaciente);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePacientes(int id , [FromBody] Paciente pacienteActualizado)
        {
            try
            {
                var paciente = pacientes.FirstOrDefault(p=>p.id_paciente == id);
                if (paciente == null)
                {
                    return NotFound("Paciente no encontrado");
                }
                if ( paciente.id_paciente <= 0)
                {
                    return BadRequest("El di tiene que ser mayor a 0");
                }
                paciente.nombre = pacienteActualizado.nombre;
                paciente.id = pacienteActualizado.id;
                paciente.fecha_nacimiento = pacienteActualizado.fecha_nacimiento;
                paciente.telefono = paciente.telefono;
                paciente.correo = pacienteActualizado.correo;
                return Ok(paciente);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            try
            {
                var paciente = pacientes.FirstOrDefault(p=> p.id_paciente == id);

                if(paciente == null)
                {
                    return NotFound("Paciente no encontrado");
                }
                pacientes.Remove(paciente);

                return Ok("Paciente elminado correctamente");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }

    }
}