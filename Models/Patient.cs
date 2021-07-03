using System;
using System.ComponentModel.DataAnnotations;

public class Patient
{
    [Key]
    public int Id { set; get; }
    public string Name { set; get; }
    public DateTime DateOfBirth { set; get; }
    public int HealthNumber { set; get; }
    public string Address { set; get; }
    public string PhoneNumber { set; get; }

}