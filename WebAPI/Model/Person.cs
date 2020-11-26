using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WebAPI.Model {
public class Person {
    
    [Key]
    public int Id { get; set; }
    [NotNull]
    [MaxLength(50)]
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    [NotNull]
    [MaxLength(50)]
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }
    [NotNull]
    [MaxLength(50)]
    [ValidHairColor]
    public string HairColor { get; set; }
    [NotNull]
    [MaxLength(50)]
    [ValidEyeColor]
    public string EyeColor { get; set; }
    [NotNull, Range(0, 125)]
    public int Age { get; set; }
    [NotNull, Range(1, 250)]
    public float Weight { get; set; }
    [NotNull, Range(30, 250)]
    public int Height { get; set; }
    [NotNull]
    [MaxLength(6)]
    [Required(ErrorMessage = "Gender is required.")]
    public string Sex { get; set; }

    public void Update(Person toUpdate) {
        Age = toUpdate.Age;
        Height = toUpdate.Height;
        HairColor = toUpdate.HairColor;
        Sex = toUpdate.Sex;
        Weight = toUpdate.Weight;
        EyeColor = toUpdate.EyeColor;
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
    }

}

public class ValidHairColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
        if(value == null)
            return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        if (valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
    }
}

public class ValidEyeColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
        if(value == null)
            return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        if (valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
    }
}

}