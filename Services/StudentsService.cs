using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityDTO.Users;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using WebCourses;
using WebCourses.Authentication;

namespace Services
{
    public class StudentsService: GenericService<StudentDto, int>
    {
        private readonly AppSettings _appSettings;
        
        public StudentsService(IRepository<StudentDto, int> repository, IOptions<AppSettings> appSettings) :
            base(repository)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<StudentDto> Authenticate(string email, string password)
        {
            var student = await _repository.Get(dto => dto.Email == email && dto.Password == password);

            if (student == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, student.Id.ToString()),
                    new Claim(ClaimTypes.Role, Roles.Student)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            student.Token = tokenHandler.WriteToken(token);
            
            //TODO Move this to separate method
            student.Password = null;
            return student;
        }
    }
}