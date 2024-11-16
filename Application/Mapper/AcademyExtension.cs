using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;

namespace AcademyManager.Application.Mapper
{
    public static class AcademyExtension
    {
        public static AcademyDto ConvertToAcademyDto(this Academy academy) 
        {
            return new AcademyDto() 
            {
                Id = academy.Id,
                Name = academy.Name,
            };
        }
        public static List<AcademyDto> ConvertToAcademyDtos(this IEnumerable<Academy> academies) 
        {
            var result= new List<AcademyDto>();
            foreach (var academy in academies)
                result.Add(academy.ConvertToAcademyDto());
            return result;
        }

        public static CourseDto ConvertToCourseDto(this Course course)
        {
            return new CourseDto() 
            {
                AcademyId = course.AcademyId,
                Id = course.Id,
                Name = course.Name,
                IsActive = course.IsActive,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
               

            };
        }
        public static List<CourseDto> ConvertToCourseDtos(this IEnumerable<Course> courses) 
        {
            var result = new List<CourseDto>();
            foreach (var course in courses)
                result.Add(course.ConvertToCourseDto());
            return result;
        }
        public static StudentDto ConvertToStudentDto(this Student student)
        {
            return new StudentDto()
            {
                Id = student.Id,    
                Name = student.Name,    

            };
        }
        public static List<StudentDto> ConvertToStudentDtos(this IEnumerable<Student> students)
        {
            var result = new List<StudentDto>();
            foreach(var student in students)   
                result.Add(student.ConvertToStudentDto());
            return result;  
        }
        public static StudentCourseDto ConvertToStudentCourseDto(this StudentCourse studentCourse)
        {
            return new StudentCourseDto()
            {
                Name = studentCourse.Name,
                Id = studentCourse.Id,
                StudentId = studentCourse.StudentId,    
                CourseId = studentCourse.CourseId,  
            };
        }
        public static List<StudentCourseDto> ConvertToStudentCourseDtos(this IEnumerable<StudentCourse> studentCourses)
        {
            var result = new List<StudentCourseDto>(); 
            foreach (var studentCourse in studentCourses)
                result.Add(studentCourse.ConvertToStudentCourseDto());  
            return result;  
            
               
            
        }
        
        public static LoginUserDto ConvertToUserLoginDto(this UserAccount userAccount )
        {
            return new LoginUserDto()
            {
                UserName = userAccount.UserName,  
                Password = userAccount.Password,
            };
        }
        public static List<LoginUserDto> ConvertToUserLoginDtos(this IEnumerable<UserAccount> userAccounts)
        {
            var result = new List<LoginUserDto>();
            foreach (var userAccount in userAccounts)
                result.Add(userAccount.ConvertToUserLoginDto());  
            return result;
           
        }
        public static RegisterUserDto ConvertToUserRegisterDto(this UserAccount userAccount)
        {
            return new RegisterUserDto()
            {
                FirstName = userAccount.FirstName,
                LastName = userAccount.LastName,
                Email = userAccount.Email,
                UserName = userAccount.UserName,
                Password = userAccount.Password,
            };
        }
        public static List<RegisterUserDto> ConvertToUserRegisterDtos(this IEnumerable<UserAccount> userAccounts)
        {
            var result= new List<RegisterUserDto>();    
            foreach(var userAccount in userAccounts)
                result.Add(userAccount.ConvertToUserRegisterDto());
            return result;  
        }
        public static RoleDto ConvertRoleDto(this Role role)
        {
            return new RoleDto()
            {
                
                Name = role.Name,
                Displayname = role.Displayname,
            };

        }
        public static List<RoleDto> ConvertRoleDtos(this IEnumerable<Role> roles)
        {
            var result = new List<RoleDto>();
            foreach (var role in roles)
              result.Add(role.ConvertRoleDto());
            return result;
        }  
        public static UserRoleDto ConvertUserRoleDto(this UserRole userRole)
        {
            return new UserRoleDto()
            {
                
                RoleId = userRole.RoleId,
                UserId = userRole.UserId,

            };
        }
        public static List<UserRoleDto> ConvertUserRoleDtos(this IEnumerable<UserRole> userRoles)
        {
            var result  = new List<UserRoleDto>();
            foreach (var  userRole in userRoles)
                result.Add(userRole.ConvertUserRoleDto());  
            return result;
        }


    }
}
