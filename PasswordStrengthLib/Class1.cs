namespace PasswordStrengthLib
{
    public static class PasswordEvaluator
    {
        public static string Evaluate(string? password)
        {
            if (string.IsNullOrEmpty(password))
                return "INELIGABLE";

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSymbol = true; // treats any non-letter/digit as symbol
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
