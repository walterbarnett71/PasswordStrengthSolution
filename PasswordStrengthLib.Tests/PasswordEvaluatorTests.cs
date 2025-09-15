using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthLib;

namespace PasswordStrengthLib
{
    public static class PasswordEvaluator
    {
        public static string Evaluate(string? password)
        {
            // 1) null/empty -> INELIGABLE
            if (string.IsNullOrEmpty(password))
                return "INELIGABLE";

            // 2) NEW RULE: length < 8 -> INELIGABLE
            if (password.Length < 8)
                return "INELIGABLE";

            // 3) original criteria counting
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSymbol = true;
            }

            int criteria = 0;
            if (hasUpper) criteria++;
            if (hasLower) criteria++;
            if (hasDigit) criteria++;
            if (hasSymbol) criteria++;

            return criteria switch
            {
                0 => "INELIGABLE",
                1 => "WEAK",
                2 or 3 => "MEDIUM",
                _ => "STRONG"
            };
        }
    }
}


namespace PasswordStrengthLib.Tests
{
    [TestClass]
    public class PasswordEvaluatorTests
    {
        [TestMethod]
        public void Evaluate_ShortButComplex_ReturnsIneligable()
        {
            Assert.AreEqual("INELIGABLE", PasswordEvaluator.Evaluate("Ab1!"));
        }

        [TestMethod]
        public void Evaluate_Exactly8Strong_ReturnsStrong()
        {
            Assert.AreEqual("STRONG", PasswordEvaluator.Evaluate("Ab1!xxxx"));
        }

        [TestMethod]
        public void Evaluate_Exactly8Medium_ReturnsMedium()
        {
            Assert.AreEqual("MEDIUM", PasswordEvaluator.Evaluate("Abcdefg1"));
        }

        [TestMethod]
        public void Evaluate_SevenLower_ReturnsIneligable()
        {
            Assert.AreEqual("INELIGABLE", PasswordEvaluator.Evaluate("abcdefg"));
        }
    }
}
