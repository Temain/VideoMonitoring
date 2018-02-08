﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
	public class User : IdentityUser<long> { }
	public class UserLogin : IdentityUserLogin<long> { }
	public class UserRole : IdentityUserRole<long> { }
	public class UserClaim : IdentityUserClaim<long> { }
	public class Role : IdentityRole<long> { }
	public class RoleClaim : IdentityRoleClaim<long> { }
	public class UserToken : IdentityUserToken<long> { }
}
