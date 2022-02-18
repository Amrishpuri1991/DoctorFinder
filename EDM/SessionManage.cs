using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorFinder.EDM
{
    public class SessionManage : ISessionManage
    {
        private readonly IHttpContextAccessor Context;

        public SessionManage(IHttpContextAccessor httpContext)
        {
            Context = httpContext;

        }
        public Boolean hasSession { get; set; }

        public string currentUserName { get; set; }

        public string userEmail { get; set; }



        public void SetSession(TblAdmin tblAdmin)
        {
            Context.HttpContext.Session.SetString("loginUser", JsonConvert.SerializeObject(tblAdmin));
            hasSession = true;
        }

        public TblAdmin GetSession()
        {
            if (hasSession)
            {
                var result = JsonConvert.DeserializeObject<TblAdmin>(Context.HttpContext.Session.GetString("loginUser"));
                //hasSession = true;
                currentUserName = result.AdminFname;
                userEmail = result.AdminEmail;
                return result;
            }
            else
            {
                var result1 = new TblAdmin()
                {
                    AdminId = 0,
                };
                hasSession = false;
                return result1;
            }

        }
        public void KillSession()
        {
            Context.HttpContext.Session.Remove("loginUser");
            Context.HttpContext.Session.Clear();
            hasSession = false;
        }



    }
}
