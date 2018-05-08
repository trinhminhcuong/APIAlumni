using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final.Controllers
{
    public class FinalController : ApiController
    {
        //FinalDataContext db = new FinalDataContext();
        [HttpGet]
        public List<User> GetAccList()
        {
            FinalDataContext db = new FinalDataContext();
            return db.Users.ToList();
        }

        [HttpGet]
        public Boolean Check(String name,String pass)
        {
            FinalDataContext db = new FinalDataContext();
            if ((db.Accounts.FirstOrDefault(x => x.username == name && x.password == pass)) == null)
                return false;
            return true;
        }

        [HttpGet]
        public User GetUser(String n)
        {
            FinalDataContext db = new FinalDataContext();
            return db.Users.FirstOrDefault(x => x.username == n);
        }

        [HttpGet]
        public List<Job> GetInfoList(char j)
        {
            FinalDataContext db = new FinalDataContext();
            return db.Jobs.ToList();
        }

        [HttpGet]
        public List<Topic> GetTopic(char t)
        {
            FinalDataContext db = new FinalDataContext();
            return db.Topics.ToList();
        }

        [HttpGet]
        public List<Comment> GetComment(char c)
        {
            FinalDataContext db = new FinalDataContext();
            return db.Comments.ToList();
        }

        [HttpPost]
        public Boolean InsertAccount(String username, String password)
        {
            FinalDataContext db = new FinalDataContext();
            if (db.Accounts.FirstOrDefault(x => x.username == username) != null) return false;
            Account acc = new Account();
            acc.username = username;
            acc.password = password;
            db.Accounts.InsertOnSubmit(acc);
            db.SubmitChanges();
            return true;
        }

        [HttpPost]
        public Boolean InsertInfo(String name, String dob, String job, int startyear, int endyear)
        {
            FinalDataContext db = new FinalDataContext();
            if (db.Accounts.FirstOrDefault(x => x.username == name) == null) return false;
            User inf = new User();
            inf.username = name;
            inf.dob = dob;
            inf.job = job;
            inf.startyear = startyear;
            inf.endyear =endyear;
            db.Users.InsertOnSubmit(inf);
            db.SubmitChanges();
            return true;
        }

        [HttpPost]
        public Boolean InsertJob(String jobname, String company, String info)
        {
            FinalDataContext db = new FinalDataContext();
            Job j = new Job();
            j.jobname = jobname;
            j.company = company;
            j.info = info;
            db.Jobs.InsertOnSubmit(j);
            db.SubmitChanges();
            return true;         
        }

        [HttpPost]
        public Boolean InsertTopic(String topicname, String owner, String topicinfo)
        {
            FinalDataContext db = new FinalDataContext();
            Topic top = new Topic();
            top.name = topicname;
            top.owner = owner;
            top.info = topicinfo;
            db.Topics.InsertOnSubmit(top);
            db.SubmitChanges();
            return true;
        
        }

        [HttpPost]
        public Boolean InsertComment(String com, int topicid, String usercomment)
        {
            FinalDataContext db = new FinalDataContext();
            Comment c = new Comment();
            c.com = com;
            c.topicid = topicid;
            c.usercomment = usercomment;
            db.Comments.InsertOnSubmit(c);
            db.SubmitChanges();
            return true;
        }

        [HttpPut]
        public Boolean ModPass(String username, String password)
        {
            FinalDataContext db = new FinalDataContext();
            Account acc = db.Accounts.FirstOrDefault(x => x.username == username);
            acc.password = password;
            db.SubmitChanges();//xác nhận chỉnh sửa
            return true;
        }

        [HttpPut]
        public Boolean ModUserInfo(String name, String dob, String job, int syear, int eyear)
        {
            FinalDataContext db = new FinalDataContext();
            User user = db.Users.FirstOrDefault(x => x.username == name);
            user.dob = dob;
            user.job = job;
            user.startyear = syear;
            user.endyear = eyear;
            db.SubmitChanges();
            return true;
        }
    }
}
