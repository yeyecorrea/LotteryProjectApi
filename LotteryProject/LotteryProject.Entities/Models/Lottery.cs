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
	/// Modelo que representara la entidad Loteria en la base de datos
	/// </summary>
	public class Lottery
	{
		public int Id { get; set; }

		[Display(Name = "Nombre")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
		[DataType(DataType.Text)]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
		public string? Name { get; set; }

		[Display(Name = "Descripcion")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
		[DataType(DataType.Text)]
		[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
		public string? Description { get; set; }

		[Display(Name = "Imagen")]
		[DataType(DataType.ImageUrl)]
		public byte[]? Image { get; set; }

		public Chance Chance { get; set; } // propiedad de navegacion inversa 1 a 1
    }
}
