using System.ComponentModel.DataAnnotations;

public class Paciente
{
    public int id_paciente{get;set;}
    
    [Required(ErrorMessage ="El nombre del paciente es obligatorio!")]
    public string nombre{get;set;}="";

    [MaxLength(9,ErrorMessage ="El dni del paciente es obligatorio!!")]
    public string id{get;set;}="";

    [Required(ErrorMessage ="Ingresar la fecha de nacimiento")]
    public string fecha_nacimiento{get;set;}="";

    [MaxLength(12,ErrorMessage ="El telefono del paciente es obligatorio!!")]
    public string telefono{get;set;}="";

    [Required(ErrorMessage ="El correo es obligatorio!!")]
    public string correo{get;set;}="";

}