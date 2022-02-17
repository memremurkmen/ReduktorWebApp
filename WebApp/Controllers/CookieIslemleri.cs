using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Controllers
{
    public class CookieIslemleri
    {
        private void CreateCookie(string name, string value)
        {
            HttpCookie cookieVisitor = new HttpCookie(name, value);
            // cookieVisitor.Expires = DateTime.Now.AddDays(2);
            HttpContext.Current.Response.Cookies.Add(cookieVisitor);
        }
        private string GetCookie(string name)
        {
            //Böyle bir cookie mevcut mu kontrol ediyoruz
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(name))
            {
                //böyle bir cookie varsa bize geri değeri döndürsün
                return HttpContext.Current.Request.Cookies[name].Value;
            }
            return null;
        }
        private void DeleteCookie(string name)
        {
            //Böyle bir cookie var mı kontrol ediyoruz
            if (GetCookie(name) != null)
            {
                //Varsa cookiemizi temizliyoruz
                HttpContext.Current.Response.Cookies.Remove(name);
                //ya da 
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}