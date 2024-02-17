using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
	public CityRepository(AppDbContext context) : base(context)
	{
	}
}
