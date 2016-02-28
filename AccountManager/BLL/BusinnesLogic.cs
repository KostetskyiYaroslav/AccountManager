using AccountManager.DAL;
using AccountManager.TMC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL
{
    public class BusinnesLogic
    {
        public AccountManagerDBEntities DAL = null;


        public BusinnesLogic()
        {
            this.DAL = new AccountManagerDBEntities();
        }


        public string MakeHash(string password)
        {

            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();

            return encoded;
        }


        public void AddAccount(Accounts Account)
        {
            this.DAL.Accounts.Add(Account);
            this.DAL.SaveChanges();
        }


        public void AddUser(Users User)
        {
            this.DAL.Users.Add(User);
            this.DAL.SaveChanges();
        }


        public void RemoveAccount(Accounts Account)
        {
            this.DAL.Accounts.Remove(Account);
            this.DAL.SaveChanges();
        }


        public void UpdateAccount(Accounts accounts)
        {
            var accountResponse = this.DAL.Accounts.Where(x => x.IdAccount == accounts.IdAccount);
            if (accountResponse != null)
            {
                foreach (var a in accountResponse)
                {
                    a.Login = accounts.Login;
                    a.Password = accounts.Password;
                    a.Domain = accounts.Domain;
                    a.SiteName = accounts.SiteName;
                    a.Description = accounts.Description;
                }
                this.DAL.SaveChanges();
            }
        }

        #region Get

        public IQueryable<object> GetAllAccounts()
        {
            var query = this.DAL.Accounts
               .Join(this.DAL.Category,
                  a => a.IdCategory,
                  c => c.IdCategory,
                  (a, c) => new CustumAccount { IdAccount = a.IdAccount, UserName = a.Users.UserName, Login = a.Login, Password = a.Password, Domain = a.Domain, Category = c.Name, SiteName = a.SiteName, Description = a.Description });
            return query;
        }


        public IQueryable<object> GetAccountsCurrentUser()
        {
            var query = this.DAL.Accounts
               .Join(this.DAL.Category,
                  a => a.IdCategory,
                  c => c.IdCategory,
                  (a, c) => new CustumAccount { IdAccount = a.IdAccount, UserName = a.Users.UserName, Login = a.Login, Password = a.Password, Domain = a.Domain, Category = c.Name, SiteName = a.SiteName, Description = a.Description })
                  .Where(x => x.UserName == TMC.CurrentUser.UserName);
            return query;
        }


        public List<string> GetAllCategoryNameList()
        {
            return this.DAL.Category.Select(s => s.Name).ToList();
        }



        public Accounts GetAccountById(int Id)
        {
            var res = this.DAL.Accounts.Where(x => x.IdAccount == Id);
            if (res.Count().ToString() == "1")
                foreach (var item in res)
                {
                    return item;
                }
            return null;
        }

        public IQueryable<Category> GetCategoryByName(string Name)
        {
            return this.DAL.Category.Where(w => w.Name == Name);
        }

        public List<Category> GetAllCategoryList()
        {
            return this.DAL.Category.ToList();
        }


        public List<Users> GetAuthUserList()
        {
            return this.DAL.Users.Where(w => w.IdUser == TMC.CurrentUser.IdUser).ToList();
        }


        public DbSet<Users> GetUsers()
        {
            return this.DAL.Users;
        }


        public DbSet<Accounts> GetAllAccount()
        {
            return this.DAL.Accounts;
        }


        public List<Accounts> GetAccountListCurrentUser()
        {
            return this.DAL.Accounts.Where(w => w.IdUser == TMC.CurrentUser.IdUser).ToList();
        }

        #endregion

    }
}
