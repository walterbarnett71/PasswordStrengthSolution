using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthLib;

namespace PasswordStrengthLib.Tests
{
    [TestClass]
    public class PasswordEvaluatorTests
    {
        [TestMethod]
        public void Evaluate_Null_ReturnsIneligable()
        {
            Assert.AreEqual("INELIGABLE", PasswordEvaluator.Evaluate(null));
        }

        [DataTestMethod]
        [DataRow("", "INELIGABLE")]
        [DataRow("abc", "WEAK")]
        [DataRow("ABC", "WEAK")]
        [DataRow("123", "WEAK")]
        [DataRow("!!!", "WEAK")]
        [DataRow("Ab", "MEDIUM")]
        [DataRow("A1", "MEDIUM")]
        [DataRow("a1", "MEDIUM")]
        [DataRow("A!", "MEDIUM")]
        [DataRow("a!", "MEDIUM")]
        [DataRow("1!", "MEDIUM")]
        [DataRow("Ab1", "MEDIUM")]
        [DataRow("Ab!", "MEDIUM")]
        [DataRow("a1!", "MEDIUM")]
        [DataRow("Ab1!", "STRONG")]
        public void Evaluate_ReturnsExpected(string input, string expected)
        {
            Assert.AreEqual(expected, PasswordEvaluator.Evaluate(input));
        }
    }
}
