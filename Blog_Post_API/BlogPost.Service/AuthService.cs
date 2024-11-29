using AutoMapper;
using BlogPost.Application.AppSettings;
using BlogPost.Application.CustomExceptions;
using BlogPost.Application.Dto.Request;
using BlogPost.Application.Dto.Response;
using BlogPost.Application.Interfaces.Auth;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Service
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jWTSettings;
        private const int TokenExpiryTimeInMinute = 1440;
        private const string SecretKeyForResetPass = "Yjok123KjdflkLhjkl90483iujokkl904fdedmHjHJDKJF";
        public AuthService(
          IAuthRepository authRepository,
          IMapper mapper,
          JWTSettings jWTSettings
          )
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _jWTSettings = jWTSettings;
        }


        //private methods
        private string GenerateToken(UserLoginResponse user, int userId, int? val)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.SecretKey));

            if (val == 2)
            {
                key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKeyForResetPass));
            }
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", userId.ToString()),
                new Claim("Email", user.Email),

            };

            var token = new JwtSecurityToken(
                _jWTSettings.Issuer,
                _jWTSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(TokenExpiryTimeInMinute),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        public async Task<UserLoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _authRepository.userLoginAsync(loginRequest.Email);

            if (user is null)
            {
                throw new ClientCustomException("Email is not correct", new()
                {
                    { "Email", "User not found with this email" }
                });
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                throw new ClientCustomException("Password is not correct", new()
                {
                    { "Password", "Password is not correct" }
                });
            }

            var response = _mapper.Map<UserLoginResponse>(user);
            response.Token = GenerateToken(response, user.Id, 1);

            return response;
        }

        private async Task ValidateRequest(UserRequest userRequest)
        {
            var response = await GetUserByEmail(userRequest.Email);

            if (response != null)
            {
                throw new UserRegistrationException("Email already exist", new()
                {
                    { "Email", "Email already exist" }
                });
            }
        }

        public async Task<UserResponse> Register(UserRequest request)
        {
            try
            {
                await ValidateRequest(request);

                var user = _mapper.Map<User>(request);
                var savedUser = await _authRepository.userRegisterAsync(user);
                var userRes = _mapper.Map<UserLoginResponse>(savedUser);
                return userRes;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserLoginResponse> GetUserByEmail(string email)
        {
            var user = await _authRepository.userLoginAsync(email);
            var response = _mapper.Map<UserLoginResponse>(user);
            return response;
        }
    }
}
