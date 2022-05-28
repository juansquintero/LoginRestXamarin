using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LoginPrueba.Models;

namespace LoginPrueba.Helpers
{
	public interface IRestService
	{
		Task<List<Challenge>> RefreshDataAsync();		
	}
}
