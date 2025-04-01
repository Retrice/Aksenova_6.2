using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1Х
    {

        [TestMethod]
        public void AuthTestSuccess()
        {
            var testUsers = new List<(string Name, string Email, string Password)>
            {
                ("John", "user1@test.com", "123456"),
                ("Alice", "user2@test.com", "123456"),
                ("Bob", "user3@test.com", "123456"),
                ("Emma", "user4@test.com", "123456"),
                ("Tom", "user5@test.com", "123456"),
                ("Lily", "user6@test.com", "123456"),
                ("Chris", "user7@test.com", "123456"),
                ("Grace", "user8@test.com", "123456"),
                ("Jack", "user9@test.com", "123456"),
                ("Sophie", "user10@test.com", "123456")
            };

            foreach (var user in testUsers) {
                try
                {

                    AuthService.TryRegisterUser(user.Name, user.Email, user.Password);
                }
                catch (Exception e)
                {
                    if(e.Message == AuthService.RegError)
                    {
                        Assert.Fail(user + " не удалось зарегестрировать");
                        return;
                    }
                }
                if (!AuthService.TryLoginUser(user.Email, user.Password))
                {
                    Assert.Fail(user + " не был авторизирован");
                }
            }
        }
    }
}
