﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yggdrasil.Extensions;
using Yggdrasil.Util;

namespace Yggdrasil.Test.Extensions
{
	public class RandomExtensionTests
	{
		[Fact]
		public void RandomElementFromIList()
		{
			var list = (IList<int>)new List<int>() { 11, 23, 34, 42 };
			var results = new HashSet<int>();

			for (int i = 0; i < 1000000; ++i)
			{
				var n = list.Random();
				results.Add(n);

				Assert.Contains(n, list);
			}

			Assert.Equal(list, results.OrderBy(a => a));
		}

		[Fact]
		public void RandomElementFromIEnumerable()
		{
			var list1 = new List<int>() { 11, 23, 34, 42 };
			var list2 = new List<int>() { 11, 23, 34 };
			var enumerable = list1.Where(a => a <= 34);
			var results = new HashSet<int>();

			for (int i = 0; i < 1000000; ++i)
			{
				var n = enumerable.Random();
				results.Add(n);

				Assert.Contains(n, list2);
			}

			Assert.Equal(list2, results.OrderBy(a => a));
		}

		[Fact]
		public void Between()
		{
			var rnd = RandomProvider.Get();

			for (int i = 0; i < 1000000; ++i)
				Assert.InRange(rnd.Between(10, 20), 10, 20);
		}

		[Fact]
		public void Rnd()
		{
			var list = new int[] { 101, 203, 305, 407 };
			var rnd = RandomProvider.Get();
			var results = new HashSet<int>();

			for (int i = 0; i < 1000000; ++i)
			{
				var n = rnd.Rnd(list);
				results.Add(n);

				Assert.Contains(n, list);
			}

			Assert.Equal(list, results.OrderBy(a => a));
		}
	}
}
