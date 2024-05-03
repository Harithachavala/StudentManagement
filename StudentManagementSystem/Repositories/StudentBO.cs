using BusinessLib;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Repositories
{
    public class StudentBO : IRepository<Student>
    {
        StudentContext ctx = new StudentContext();
        public bool Add(Student item)
        {
            ctx.Students.Add(item);
            return ctx.SaveChanges() > 0;
        }

        public bool Delete(Student item)
        {
            Student student = ctx.Students.Find(item.StudentId);
            if (student != null)
            {
                ctx.Students.Remove(student);
                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public Student Get(object id)
        {
            return ctx.Students.Find(id);
        }

        public List<Student> GetAll()
        {
            return ctx.Students.ToList();
        }

        public bool Update(Student item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            return ctx.SaveChanges() > 0;
        }
    }
}