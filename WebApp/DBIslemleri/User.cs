using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Models.Entity;

namespace WebApp.DBIslemleri
{
    public class User
    {
        WebDBEntities db = new WebDBEntities();


        public void addUye(users u)//veritabanına üye ekliyor
        {
            db.users.Add(u);
            db.SaveChanges();
        }

        public void deleteUye(int id)//veritabanından id sine göre üye siliyor.
        {
            db.users.Remove(db.users.Find(id));
            db.SaveChanges();
        }
        public users getUyeByUyeId(int id)//üye id sine göre veritabanından üye çekiyor
        {
            return db.users.Find(id);
        }
        public void updateUye(users u)//veritabanındaki üye bilgisini güncelliyor
        {
            var uye = db.users.Find(u.userID);
            uye.name = u.name;
            uye.surname = u.surname;
            uye.email = u.email;
            uye.username = u.username;
            uye.password = u.password;
            uye.statusId = u.statusId;
            uye.timestampId = u.timestampId;
            db.SaveChanges();
        }
        public users uyeKayitKontrol(users u)
        {
            return db.users.FirstOrDefault(x => x.username == u.username || x.email == u.email);
        }
        public UyeDetay getUyeByUsernameAndPassword(users u)
        {
            UyeDetay uyeDetayi = db.Database.SqlQuery<UyeDetay>("exec getUyeByUsernameAndPass @username, @pass", 
                new SqlParameter("username", u.username), 
                new SqlParameter("pass", u.password)).FirstOrDefault();
            return uyeDetayi;
        }
    }
}