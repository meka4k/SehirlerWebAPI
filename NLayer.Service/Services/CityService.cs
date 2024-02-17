using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services;

public class CityService : GenericService<City>, ICityService
{
	public CityService(IGenericRepository<City> repository) : base(repository)
	{
	}
}
