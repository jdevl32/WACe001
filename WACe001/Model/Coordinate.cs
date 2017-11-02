using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WACe001.Model.Interface;

namespace WACe001.Model
{

    public class Coordinate
		:
		ICoordinate
    {

		public double Latitude { get; }

		public double Longitude { get; }

	}

}
