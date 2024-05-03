
select name from sysobjects where type='U'
select * from Students;
select * from Payments;
select * from Teachers;
select * from Grades;
select * from Logins;
insert into Logins values('admin', 'admin123', 'admin');
select * from Courses;
select * from CourseTeachers;
select * from Enrollments;
update Courses set CourseName = 'Dotnet' where CourseId = 3
