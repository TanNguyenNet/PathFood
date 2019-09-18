using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Authorization
{
    public class ContantPolicy
    {
        public class Users
        {
            public static string InsertData = "";
        }

        public class Base
        {
            public const string Read = nameof(Read);

            public const string Insert = nameof(Insert);

            public const string Update = nameof(Update);

            public const string Delete = nameof(Delete);
        }

        public class User
        {
            public const string ReadUserData = nameof(Base.Read) + nameof(User);

            public const string InsertUserData = nameof(Base.Insert) + nameof(User);

            public const string UpdateUserData = nameof(Base.Update) + nameof(User);

            public const string DeleteUserData = nameof(Base.Delete) + nameof(User);

            public string ReadData { set; get; } = "ReadUserData";

            public const string InsertData = nameof(InsertUserData);

            public const string UpdateData = nameof(UpdateUserData);

            public const string DeleteData = nameof(DeleteUserData);

        }
    }
}
