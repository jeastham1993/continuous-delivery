// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;

namespace JEasthamDev.AcceptanceTests.Drivers
{
	public class TestConstants
	{
		public static string ApiUrl => Environment.GetEnvironmentVariable("API_URL") ?? "http://localhost:5000";
	}
}