using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AngularProjectService.DbContext;

namespace AngularProjectService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginRegisterService" in both code and config file together.
    [ServiceContract]
    public interface ILoginRegisterService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/user/registration", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Registration(UserMv user);
   
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/user/login", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]        
        string Login(UserMv user);       
    }
}
