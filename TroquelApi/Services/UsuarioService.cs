using TroquelApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using TroquelApi.Helpers;
using System.Security.Claims;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace TroquelApi.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        private readonly AppSettings _appSettings;

        public UsuarioService(ITroquelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }


        public List<Usuario> Get()=>
             _usuarios.Find(usuario => true).ToList();
           

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuarioIn) =>
            _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioIn);

        public void Remove(Usuario usuarioIn) =>
            _usuarios.DeleteOne(usuario => usuario.Id == usuarioIn.Id);

        public void Remove(string id) =>
            _usuarios.DeleteOne(usuario => usuario.Id == id);

        //Authenticaction


        public Usuario Authenticate(string correo, string contrasena)
        {
            var user = _usuarios.Find(usuario => usuario.correo == correo && usuario.contrasena == contrasena).SingleOrDefault();

            // return null if user not found
            if (user == null)
                return null;
            
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Role, user.rol)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.contrasena = null;

            return user;
        }

        public Usuario GetById(string id)
        {
            var usuario = _usuarios.Find(usuario => usuario.Id == id).FirstOrDefault();

            // return user without password
            if (usuario != null)
                usuario = null;

            return usuario;
        }

    }
}
