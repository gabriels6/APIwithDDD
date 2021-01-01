using System;
using ApiWithDDD.Domain.Entities;

namespace ApiWithDDD.Domain.Entities
{
	public class Category : BaseEntity<int>
	{
		public Category(String name, String desc)
		{
			Name = name;
			Desc = desc;

		}

		public String Name { get; }
		public String Desc { get; }
	}
}

