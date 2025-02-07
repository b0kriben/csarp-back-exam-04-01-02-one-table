
using System.Text.RegularExpressions;

namespace Kreta.Shared.Dtos.Query
{
    public readonly record struct StudentQueryDto(string NamePart, int BirthYear, int BirthMonth, bool IsWoman)
    {
        // BirthYear == 0 -> nem kell szűrni az évre
        // BirthMonth == 0 vagy >12 -> nem kell szűrni az évre
        // NamePart == string.Empty -> nem kell szűrni az évre

        public bool IsValid()
        {
            // Megadott szűrési feltételt akkor valid
            if (string.IsNullOrEmpty(NamePart))
                return false;
            if (BirthYear < 0 || BirthMonth < 0)
                return false;
            if (BirthYear>DateTime.Now.Year || BirthMonth>12)
                return false;
            if (!OnlyLetters(NamePart))
                return false;
            return true;
        }

        bool OnlyLetters(string input) => input.All(char.IsLetter);
        bool OnlyLetters2(string input) => Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}
