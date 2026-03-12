using Microsoft.AspNetCore.Mvc;

namespace CitaController.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitaController : ControllerBase
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
            new Paciente{id_paciente=9,nombre="Maria Dolores Nuñez",id="123456797",fecha_nacimiento="15-10-1960",telefono="+19984455666",correo="mari@correo.com"}
        };
        public static List<Medico> medicos = new List<Medico>()
        {
            new Medico { id_medico=1,nombre = "Dr. Sebastian Navarro Rios", id_especialidad = 1, cmp = "CMP10234" },
            new Medico { id_medico=2,nombre = "Dra.Mariana Paredes Leon", id_especialidad = 2, cmp = "CMP20456" },
            new Medico { id_medico=3,nombre = "Dr. Javier Alonso Herrera", id_especialidad = 3, cmp = "CMP30987" },
            new Medico { id_medico=4,nombre = "Dra. Daniela Fuentes Cabrera", id_especialidad = 4, cmp = "CMP41235" },
            new Medico { id_medico=5,nombre = "Dr. Martin Salcedo Vargas", id_especialidad =5, cmp = "CMP52348" },
            new Medico { id_medico=6,nombre = "Dra. Alejandra Quispe Morales", id_especialidad = 6, cmp = "CMP63421" }
        };
        public static List<Cita> citas = new List<Cita>()
        {
            new Cita { id_citas = 1, pacienteId = 1, medicoId = 1, fecha = new DateTime(2026,5,12) , motivo= "Dolor de pecho",estado="PENDIENTE" , fecha_creacion=DateTime.Now , fecha_actualizada = null},
            new Cita { id_citas = 2, pacienteId = 3, medicoId = 5, fecha = new DateTime(2026,4,8) , motivo= "Dolor de cabeza",estado="PENDIENTE" , fecha_creacion = new DateTime(2026,1,10), fecha_actualizada = null},
            new Cita { id_citas = 3, pacienteId = 4, medicoId = 6, fecha = new DateTime(2025,10,3) , motivo= "Dolor en la espalda",estado="ATENDIDA" , fecha_creacion = new DateTime(2026,1,10),fecha_actualizada= null},
            new Cita { id_citas = 4, pacienteId = 8, medicoId = 6, fecha = new DateTime(2025,7,10) , motivo= " Dolor de rodilla",estado="ATENDIDA",fecha_creacion= new DateTime(2025,7,2),fecha_actualizada = new DateTime(2025,7,12)},
            new Cita { id_citas = 5, pacienteId = 5, medicoId = 3, fecha = new DateTime(2025,6,26) , motivo= "Alergia cutanea",estado="PENDIENTE",fecha_creacion =new DateTime(2025,6,19) ,fecha_actualizada= null},
            new Cita { id_citas = 6, pacienteId = 9, medicoId = 5, fecha = new DateTime(2026,4,24) , motivo= "Migraña intensa",estado="PENDIENTE",fecha_creacion= new DateTime(2025,4,16),fecha_actualizada=null},
            new Cita { id_citas = 7, pacienteId = 6, medicoId = 6, fecha = new DateTime(2026,3,25) , motivo= "Dolor de brazo",estado="CANCELADA",fecha_creacion=new DateTime(2026,1,12),fecha_actualizada=new DateTime(2026,2,12)},
            new Cita { id_citas = 8, pacienteId = 7, medicoId = 3, fecha = new DateTime(2025,11,16) , motivo= "Acne severo",estado="ATENDIDA",fecha_creacion = new DateTime(2025,11,4),fecha_actualizada= new DateTime(2025,11,18)},
            new Cita { id_citas = 9, pacienteId = 2, medicoId = 1, fecha = new DateTime(2026,5,24) , motivo= "Lesion deportiva",estado="PENDIENTE",fecha_creacion= new DateTime(2026,5,20) , fecha_actualizada=null}
            
        };

        [HttpGet]
        public IActionResult GetCitas()
        {
            try
            {
                var resultado = citas.Select(c=>new
                {
                    c.id_citas,
                    paciente = pacientes.FirstOrDefault(p => p.id_paciente == c.pacienteId)?.nombre,
                    medico = medicos.FirstOrDefault(m => m.id_medico == c.medicoId)?.nombre,
                    c.fecha,
                    c.motivo,
                    c.estado,
                    c.fecha_creacion,
                    c.fecha_actualizada
                }).ToList();

                return Ok(resultado);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpGet("{id}")]
        public IActionResult GetCitasPorId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id tiene que ser mayor a 0!");
                }
                foreach (Cita c in citas)
                {
                    if (c.id_citas == id)
                    {
                        return Ok(c);
                    }
                }
                return NotFound("Cita no econtrado no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpPost]
        public IActionResult PostCitas([FromBody] Cita citanueva)
        {
            try
            {
                if (citanueva == null)
                {
                    return BadRequest("Ingresar los datos para enviar a las citas");
                }

                citanueva.id_citas = citas.Max(c => c.id_citas) + 1;
                citas.Add(citanueva);
                return Created($"api/citas/{citanueva.id_citas}",citanueva);

            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCitas(int id , Cita citaactualizada)
        {
            try
            {
                var cita = citas.FirstOrDefault(c=>c.id_citas == id);
                if (cita == null)
                {
                    return NotFound("Cita no encontrado para actualizar");
                }
                if ( cita.id_citas <= 0)
                {
                    return BadRequest("El id cita tiene que ser mayor a 0");
                }
                cita.pacienteId = citaactualizada.pacienteId;
                cita.medicoId = cita.medicoId;
                cita.fecha = citaactualizada.fecha;
                cita.motivo = citaactualizada.motivo;
                cita.estado = citaactualizada.estado;
                cita.fecha_creacion = citaactualizada.fecha_creacion;
                cita.fecha_actualizada = citaactualizada.fecha_actualizada;
                return Ok(cita);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCitas(int id)
        {
            try
            {
                var cita = citas.FirstOrDefault(c=>c.id_citas== id);

                if(cita == null)
                {
                    return NotFound("Cita no encontrado");
                }
             citas.Remove(cita);

                return Ok("Cita elminado correctamente");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }

    }
}