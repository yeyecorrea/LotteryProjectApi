using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryProject.Entities.Models
{
	/// <summary>
	/// Modelo que representara la entidad Sorteo en la base de datos
	/// </summary>
	public class Raffle
	{
		public int Id { get; set; }

		[Display(Name = "Numero sorteo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[Range(1,1000, ErrorMessage ="El rango del numero del {0} debe ser entre 1 y 1000")]
		public int NumberRaffle { get; set; }

		[Display(Name = "Fecha")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[DataType(DataType.Date)]
		[Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha del {0} debe estar entre 1900-01-01 y 2100-12-31")]
		[RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "El formato de fecha debe ser dd/mm/yyyy")]
		public DateTime Date { get; set; }

		[Display(Name = "Resultado")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public int Result { get; set; }

		[Display(Name = "Premio")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[Range(0.01, 1000000, ErrorMessage = "El premio debe estar entre 0.01 y 1,000,000")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El formato del precio no es válido")]
		[DataType(DataType.Currency)]
		public Decimal Prize { get; set; }

		public int ChanceId { get; set; }
		public Chance Chance { get; set; }

	}
}
