using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using EntityDTO.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using WebCourses;
using WebCourses.Authentication;

namespace Services
{
    public class ProfessorsService: GenericService<ProfessorDto, int>
    {
        
        private readonly AppSettings _appSettings;
        private readonly CoursesService _coursesService;
        
        public ProfessorsService(IRepository<ProfessorDto, int> repository, IOptions<AppSettings> appSettings, CoursesService coursesService) : base(repository)
        {
            _coursesService = coursesService;
            _appSettings = appSettings.Value;
        }
        
        public async Task<ProfessorDto> Authenticate(string email, string password)
        {
            var professor = await _repository.Get(dto => dto.Email == email && dto.Password == password);

            if (professor == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, professor.Id.ToString()),
                    new Claim(ClaimTypes.Role, Roles.Professor)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            professor.Token = tokenHandler.WriteToken(token);
            
            //TODO Move this to separate method
            professor.Password = null;
            return professor;
        }

        public async Task<IEnumerable<ProfessorDto>> GetByCourseId(int courseId)
        {
            var course = await _coursesService.GetWithAuthors(courseId);
            return course.Authors;
        }
    }
}