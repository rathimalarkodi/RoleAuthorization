using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db;
        public UsersController(ApplicationDbContext _db)
        { db = _db; }

        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminResult()
        {
            var getAllUsers = db.Users.ToList();
            return Ok(getAllUsers);
        }

        [Authorize(Roles="User")]
        public IActionResult GetUserDetails(int Id)
        {
            var details = db.Users.Where(x=>x.Id==Id).SingleOrDefault();
            return Ok(details);
        }

        [Route("Hashing")]
        public IActionResult PostPasswordhash(string password)
        {
            var password_Bytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] data_Input = new byte[password_Bytes.Length];
            for (int i=0;i<password_Bytes.Length;i++)
            {
                data_Input[i] = password_Bytes[i];
            }
            SHA512 sha = new SHA512Managed();
            var hashedByteArray = sha.ComputeHash(data_Input);
            string hashed_Result = Convert.ToBase64String(hashedByteArray);
            return Ok(hashed_Result);
        }
    }
}