using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbfirst_15323.Controllers
{
    public class StudentController : Controller
    {
        DatabaseContext _db = new DatabaseContext(); 
        public ActionResult StudentForm()
        {
            return View();
        }

        public void Insert(tblstudent obj)
        {
            if (obj.stnd_id > 0)
            {
                //_db.sp_update(obj.stnd_id, obj.name, obj.age, obj.rollno, obj.email, obj.password, obj.city);
                _db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                //_db.sp_insert(obj.name, obj.age, obj.rollno, obj.email, obj.password, obj.city);
                _db.tblstudents.Add(obj);
            }
            _db.SaveChanges();
        }

        public JsonResult GetData()
        {
            //var data =_db.sp_getdata().ToList();
            //var data = _db.tblstudents.ToList();
            var data = (from x in _db.tblstudents 
                        join y in _db.tblcountries on x.country equals y.cid
                        join z in _db.tblstates on x.state equals z.sid
                        select new tblstudentNew {
                           stnd_id = x.stnd_id,
                           name = x.name,
                           age = x.age,
                           rollno = x.rollno,
                           city = x.city,
                           email = x.email,
                           password = x.password,
                           cname = y.cname,
                           sname = z.sname }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void DeleteData(int A)
        {
            //_db.sp_delete(A);
            var data = _db.tblstudents.Find(A);
            _db.tblstudents.Remove(data);
            _db.SaveChanges();
        }

        public JsonResult EditData(int A)
        {
            //var data = _db.sp_edit(A).ToList();
            var data = (from x in _db.tblstudents where x.stnd_id == A select x).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountry()
        {
            //var data =_db.sp_Country().ToList();
            var data = _db.tblcountries.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetState(int S)
        {
            //var data =_db.sp_State(S).ToList();
            //var data = _db.tblstates.Where (x=>x.cid == S).ToList();
            var data = (from x in _db.tblstates where x.cid == S select x).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}