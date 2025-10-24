using Microsoft.AspNetCore.Identity;  // ✅ Use this (not Microsoft.AspNet.Identity.EntityFramework)
using System;
using System.Collections.Generic;

namespace BEAUTIFY.DOMAIN.MODELS
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Audit Fields
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
