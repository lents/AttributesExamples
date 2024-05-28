using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class IsFutureDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                DateTime.TryParse(value.ToString(), out DateTime val);
                if(val <= DateTime.Now)
                {
                    return false;
                }
            }
            return base.IsValid(value);
        }
    } 
}