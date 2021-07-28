// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading.Tasks;

namespace JEasthamDev.Api.Domain.Entity
{
	public interface Orders
	{
		Task Store(Order order);
	}
}