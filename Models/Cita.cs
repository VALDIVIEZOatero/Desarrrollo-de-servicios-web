using System.ComponentModel.DataAnnotations;public class Cita
{
    public int id_citas{get;set;}

    [Range(1,int.MaxValue,ErrorMessage ="El id del paciente es obligatorio!")]
    public int pacienteId{get;set;}

    [Range(1,int.MaxValue,ErrorMessage ="El id del medico es obligatorio!")]
    public int medicoId{get;set;}
    [Required(ErrorMessage ="Debe ingresar la fecha para la cita!")]
    public DateTime fecha{get;set;}

    [Required(ErrorMessage ="Ingresar el motivo de la cita , es obligatorio!")]
    public string motivo{get;set;}="";

    [Required(ErrorMessage ="Ingrese el estado de la cita")]
    /*ESTADO DE LA CITA:(PENDIENTE,ATENDIDA,CANCELADA)*/
    public string estado{get;set;}="";
    
    [Required(ErrorMessage ="Ingresar la fecha creada de la cita para el paciente")]
    public DateTime fecha_creacion{get;set;}

    [Required(ErrorMessage ="Actualizar la fecha si es requerida o sino null")]
    public DateTime? fecha_actualizada{get;set;} 
}