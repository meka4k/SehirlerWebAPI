using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models;

public class City
{
    public int Id { get; set; }
	[Display(Name = "Şehir Adı"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
	public string CityName { get; set; }
	[Display(Name = "Ülke Adı"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
	public string CountryName { get; set; }
}
