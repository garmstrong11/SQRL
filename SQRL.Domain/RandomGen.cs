using System;
using System.Text;

namespace SQRL.Domain
{
	public static class RandomGen
	{
		private static readonly Random Global = new Random();
		[ThreadStatic] private static Random _local;

		private static int Next(int maxVal)
		{
			Random inst = _local;
			if (inst == null) {
				int seed;
				lock (Global) seed = Global.Next();
				_local = inst = new Random(seed);
			}

			return inst.Next(maxVal);
		}

		public static string RandomString(int length)
		{
			const string safeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

			var builder = new StringBuilder(Properties.Settings.Default.RandomStringLength);
			for (int i = 0; i < length; i++)
			{
				builder.Append(safeChars[Next(safeChars.Length - 1)]);
			}

			return builder.ToString();
		}
	}
}