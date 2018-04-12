using AngularProjectService.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace AngularProjectService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginRegisterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginRegisterService.svc or LoginRegisterService.svc.cs at the Solution Explorer and start debugging.
    public class LoginRegisterService : ILoginRegisterService
    {        
        public string Registration(UserMv user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                return "Şifreler eşleşmiyor.";
            }

            using (UserDb db = new UserDb())
            {
                User checkUser = db.User.SingleOrDefault(p => p.Name == user.Name);

                if (checkUser != null)
                {
                    return "Bu kullanıcı zaten kayıtlı bulunmaktadır.";
                }

                try
                {
                    User userEntity = new User();

                    userEntity.Name = user.Name;
                    userEntity.Password = user.Password;

                    db.User.Add(userEntity);

                    db.SaveChanges();

                    return "Kayıt başarılı.";
                }
                catch (Exception)
                {
                    return "Kayıt başarısız.";                    
                }                          
            }
        }

        public string Login(UserMv userMv)
        {
            string user = "";

            using (UserDb db = new UserDb())
            {
                User validateUser = db.User.SingleOrDefault(p => p.Name == userMv.Name && p.Password == userMv.Password);

                if (validateUser != null)
                {
                    user = validateUser.ID + "~" + validateUser.Name;
                }
            }

            return user;
        }       
    }
}