using System;
namespace TimelineSort
{
	public class TimelineSort
	{

		private List<object> _pattern;
		private Dictionary<IEnumerable<object>, List<object?>> mapping;
		public List<object> Pattern => _pattern;

		public TimelineSort(IEnumerable<IEnumerable<object>> objs)
		{
            _pattern = objs.First().ToList();
            Update(objs);
			mapping = new Dictionary<IEnumerable<object>, List<object?>>();
			foreach (var o in objs)
			{
				mapping[o] = Map(o);
			}
		}

		public List<object?> Get(IEnumerable<object> o)
		{
			if (!mapping.ContainsKey(o)) throw new ArgumentOutOfRangeException();
			return mapping[o];
		}

		private List<object?> Map(IEnumerable<object> obj)
		{
			List<object> a = obj.ToList();
			int i = 0;
			int j = 0;
			int m = a.Count();
			int n = _pattern.Count();
			List<object?> res = new List<object?>();
			while (i < m && j < n)
			{
				if (a[i] != _pattern[j])
				{
					res.Add(null);
					j++;
				}
				else
				{
					res.Add(a[i]);
					i++;
					j++;
				}
			}
			while (j < n)
			{
				res.Add(null);
				j++;
			}
			return res;
		}

		private void Update(IEnumerable<IEnumerable<object>> objs)
		{
			var l = objs.ToList();
			for (int i = 1; i < l.Count(); i++)
			{
				_pattern = Update(_pattern, l[i].ToList());
			}
		}

		private List<object> Update(List<object> a, List<object> b)
		{
			int m = a.Count();
			int n = b.Count();
			int[,] dp = new int[m + 1, n + 1];
			int i;
			int j;
			for (i = 0; i <= m; i++)
			{
				for (j = 0; j <= n; j++)
				{
					if (i == 0 || j == 0) continue;
					if (a[i - 1] == b[j-1])
					{
						dp[i, j] = dp[i - 1, j - 1] + 1;
					}
					else
					{
						dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
					}
				}
			}

			i = m;
			j = n;
			List<object> res = new List<object>();

			while (i > 0 && j > 0)
			{
				if (a[i-1] == b[j-1])
				{
					res.Add(a[i - 1]);
					--i;
					--j;
				}
				else
				{
					if (dp[i - 1, j] < dp[i, j - 1])
					{
						res.Add(b[--j]);
					}
					else
					{
						res.Add(a[--i]);
					}
				}
			}
			while (i > 0) res.Add(a[--i]);
			while (j > 0) res.Add(b[--j]);

			res.Reverse();
			return res;
		}
	}
}

