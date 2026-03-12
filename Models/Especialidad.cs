using System.ComponentModel.DataAnnotations;

public class Especialidad{

    public int id_especialidad{get;set;}
    [Required(ErrorMessage ="La especialidad es OBLIGATORIA!!")]
    public string nombre{get;set;}="";
}