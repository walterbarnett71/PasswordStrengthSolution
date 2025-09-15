Namespace PasswordStrengthLib
{
    Public Static Class PasswordEvaluator
    {
        Public Static String Evaluate(String? password)
        {
            If (String.IsNullOrEmpty(password))
        Return "INELIGABLE";

            bool hasUpper = False, hasLower = False, hasDigit = False, hasSymbol = False;

            foreach (char c in password)
            {
                If (Char.IsUpper(c)) hasUpper = True;
                ElseIf (Char.IsLower(c)) hasLower = True;
                ElseIf (Char.IsDigit(c)) hasDigit = True;
                Else hasSymbol = True; // treats any non-letter/digit As symbol
            }

            int criteria = 0;
            If (hasUpper) criteria++;
            If (hasLower) criteria++;
            If (hasDigit) criteria++;
            If (hasSymbol) criteria++;

            Return criteria switch
            {
                0 => "INELIGABLE",
                1 => "WEAK",
                2 Or 3 => "MEDIUM",
                _ => "STRONG"
            };
        }
    }
}
