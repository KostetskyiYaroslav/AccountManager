using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.TMC
{
    public static class CurrentUser
    {
        public static int IdUser { set; get; }

        public static string UserName { set; get; }

        public static void Set(int Id, string Name)
        {
            CurrentUser.IdUser = Id;
            CurrentUser.UserName = Name;
        }

        public static void Unset()
        {
            CurrentUser.IdUser = 0;
            CurrentUser.UserName = "";
        }

    }
}
