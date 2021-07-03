using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IntakeForm
{
    [Key]
    public int Id { set; get; }
    [Required]
    [MaxLength(500, ErrorMessage = "Ailment cannot be greater than 500 chars")]
    public string Ailment { set; get; }

    [ForeignKey("DoctorId")]
    public int DoctorId { set; get; }

    [ForeignKey("PatientId")]
    public int PatientId { set; get; }
    
}