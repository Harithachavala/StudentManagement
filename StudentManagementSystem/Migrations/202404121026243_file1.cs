namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class file1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Credits = c.Int(nullable: false),
                        CourseDuration = c.String(),
                        CourseFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(maxLength: 10),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        Address = c.String(maxLength: 100),
                        City = c.String(),
                        State = c.String(),
                        EnrolledDate = c.DateTime(nullable: false),
                        EnrolledCourse = c.String(maxLength: 50),
                        FeeStatus = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseTeachers",
                c => new
                    {
                        CourseTeacherId = c.Int(nullable: false, identity: true),
                        TeacherId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseTeacherId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        TeacherName = c.String(),
                        TeacherQualification = c.String(),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        AssignedCourse = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        EnrolledId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Enrollments", t => t.EnrolledId, cascadeDelete: true)
                .Index(t => t.EnrolledId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "EnrolledId", "dbo.Enrollments");
            DropForeignKey("dbo.CourseTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseTeachers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Payments", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "EnrolledId" });
            DropIndex("dbo.CourseTeachers", new[] { "CourseId" });
            DropIndex("dbo.CourseTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Logins");
            DropTable("dbo.Grades");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseTeachers");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
