using System;
using WpfAuthApp;

namespace WpfApp1
{
    public static class AuthService
    {

        public static String RegUserIsExistsError = "Пользователь уже зарегистрирован";
        public static String RegError = "Ошибка при регистрации пользователя";
        public static bool TryLoginUser(string email, string plainPassword)
        {
            string password = Utils.HashPassword(plainPassword);
            return DatabaseHelper.CheckUser(email, password);
        }

        public static bool TryRegisterUser(string nickname, string email, string plainPassword, string name = null, string surname = null, string description = null, string institution = null)
        {
            if (DatabaseHelper.UserExists(email))
            {
                throw new InvalidOperationException(RegUserIsExistsError);
            }

            string password = Utils.HashPassword(plainPassword);
            bool result = DatabaseHelper.RegisterUser(nickname, email, password, name, surname, description, institution);
            if (!result)
            {
                throw new InvalidOperationException(RegError);
            }
            return true;
        }
    }
}
