using System.ComponentModel.DataAnnotations;

public class Doctor
{
    [Key]
    public int Id { set; get; }
    public string Name { set; get; }
}