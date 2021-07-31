// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;

namespace JEasthamDev.Infrastructure
{
	public static class Settings
	{
		public static bool IsLocal { get; set; }

		public static bool IsDocker => Environment.GetEnvironmentVariable("IS_DOCKER") != null;

		public static string TableName =>
			IsLocal || IsDocker ? "jeasthamdev-api-events" : Environment.GetEnvironmentVariable("TABLE_NAME");
	}
}