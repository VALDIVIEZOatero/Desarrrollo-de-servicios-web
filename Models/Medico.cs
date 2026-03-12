using System.ComponentModel.DataAnnotations;

public class Medico
{
    public int id_medico{get;set;}

    [Required(ErrorMessage ="El nombre del medico es obligatorio!")]
    public string nombre {get;set;}="";
    [Required(ErrorMessage ="La especialidad es obligatoria!")]
    public int id_especialidad{get;set;}

    [Required(ErrorMessage ="El numero de colegiatura es obligatoria!")]
    public string cmp{get;set;}="";
}