using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Authorization
{
    public class ContantPolicy
    {
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

            public const string ReadData = nameof(ReadUserData);

            public const string InsertData = nameof(InsertUserData);

            public const string UpdateData = nameof(UpdateUserData);

            public const string DeleteData = nameof(DeleteUserData);

        }

        public class Admin
        {
            public const string ManageAdminData = nameof(Base.Read) + nameof(Admin);

            public const string AdminData = nameof(ManageAdminData);
        }
    }
}
