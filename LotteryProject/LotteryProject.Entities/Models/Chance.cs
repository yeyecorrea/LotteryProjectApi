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
	/// Modelo que representara la entidad Chance en la base de datos
	/// </summary>
	public class Chance
	{
		public int Id { get; set; }

		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
		[DataType(DataType.Text)]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
		public string Name { get; set; }


		public int LotteryId { get; set; }

		public Lottery Lottery { get; set; } //propiedad de navegacion con la tabla lottery

		public ICollection<Raffle> Raffles { get; set; } //propiedad de navegacion con la tabla raffle
	}
}
