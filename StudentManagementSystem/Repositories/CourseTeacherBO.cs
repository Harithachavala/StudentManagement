using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class CourseTeacherBO : IRepository<CourseTeacher>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(CourseTeacher item)
        {
            ctx.CourseTeachers.Add(item);
            int r = ctx.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(CourseTeacher item)
        {
            CourseTeacher ct = ctx.CourseTeachers.Find(item.CourseTeacherId);
            if (ct != null)
            {
                ctx.CourseTeachers.Remove(ct);
                int r = ctx.SaveChanges();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public CourseTeacher Get(object id)
        {
            string courseTeacherId = (string)id;
            return ctx.CourseTeachers.Find(courseTeacherId);
        }

        public List<CourseTeacher> GetAll()
        {
            return ctx.CourseTeachers.ToList();
        }

        public bool Update(CourseTeacher item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            int r = ctx.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}