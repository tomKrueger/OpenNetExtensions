using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenNetExtensions.ExtensionMethods;
using System;

namespace OpenNetExtensions.Tests.ExtensionMethods
{
	[TestClass]
	public class StringExtensionTests
	{
		#region --- RemoveRight Tests ---

		[TestMethod]
		public void RemoveRight()
		{
			Assert.AreEqual("1234567890", "1234567890123".RemoveRight("123"));
		}

		[TestMethod]
		public void RemoveRight_RemoveValueDoesNotExistOnRight()
		{
			// The end does not end with the value to be removed
			// Expecting value to be the same.

			string startingValue = "1234567890123";
			string expectedValue = startingValue;
			string valueToRemove = "1234";

			Assert.AreEqual(expectedValue, startingValue.RemoveRight(valueToRemove));
		}

		[TestMethod]
		public void RemoveRight_Null()
		{
			string startingValue = null;
            string expectedValue = null;
			Assert.AreEqual(expectedValue, startingValue.RemoveRight("123"));
		}

		#endregion

		#region --- Right Tests ---
		
		[TestMethod]
		public void Right()
		{
			Assert.AreEqual("123", "1234567890123".Right(3));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Right_ZeroLength()
		{
			string s = "1234567890123".Right(0);
		}

		[TestMethod]
		public void Right_OnNull()
		{
			string startingValue = null;
			Assert.AreEqual(string.Empty, startingValue.Right(3));
		}

		[TestMethod]
		public void Right_OnEmptyString()
		{
			Assert.AreEqual(string.Empty, string.Empty.Right(3));
		}

		[TestMethod]
		public void Right_RequestingLongerLength()
		{
			string startingValue = "1234567890123";
			string expectedValue = startingValue;

			Assert.AreEqual(expectedValue, startingValue.Right(startingValue.Length + 1));
		}

		#endregion
	}
}
