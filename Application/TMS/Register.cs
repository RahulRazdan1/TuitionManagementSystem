using Application.Common;
using Application.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Application.TMS
{
    public class Register
    {
        public class Input
        {
            [Required(ErrorMessage = "UserType is required")]
            [Display(Name = "User Type")]
            public long UserTypeId { get; set; }

            [Required(ErrorMessage = "Name is required")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Retype Password is required")]
            [Display(Name = "Retype Password")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password and Retype Password doesn't match")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Mobile # is required")]
            [Display(Name = "Mobile #")]
            [DataType(DataType.PhoneNumber)]
            public string ContactNumber { get; set; }
        }
        public class Command : CommandAsync<Input>
        {
            private readonly UserManager<ApplicationUser> userManager;
            public Command(
                UserManager<ApplicationUser> userManager,
                Providers providers) : base(providers)
            {
                this.userManager = userManager;
            }
            public override async Task<ExecutionResult> ExecuteAsync(Input input)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email,
                    Email = input.Email,
                    FullName = input.Name,
                    PhoneNumber = input.ContactNumber
                    
                };
                var userCreationResult = await userManager.CreateAsync(user, input.Password);
                if (!userCreationResult.Succeeded)
                {
                    var errors = new List<ValidationError>();
                    foreach (var error in userCreationResult.Errors)
                    {
                        errors.Add(new ValidationError(error.Description));
                    }
                    return ExecutionResult.Failure(errors);
                }


                await userManager.AddToRoleAsync(user, input.UserTypeId == 1 ? RoleNameConstants.Tutor : RoleNameConstants.Tutee);

                var userDetail = Providers.Mapper.Map<UserDetail>(input);
                userDetail.User = user;
                Providers.Database.UserDetail.Add(userDetail);
                await Providers.Database.SaveChangesAsync();
                return ExecutionResult.Success();

            }

            public ExecutionResult ExecuteSync(Input input)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email,
                    Email = input.Email,
                    FullName = input.Name,
                    PhoneNumber = input.ContactNumber

                };
                var userCreationResult = userManager.CreateAsync(user, input.Password).Result;
                if (!userCreationResult.Succeeded)
                {
                    var errors = new List<ValidationError>();
                    foreach (var error in userCreationResult.Errors)
                    {
                        errors.Add(new ValidationError(error.Description));
                    }
                    return ExecutionResult.Failure(errors);
                }

                //userManager.AddToRoleAsync(user, input.UserTypeId == 1 ? RoleNameConstants.Tutor : RoleNameConstants.Tutee);
                var tt = userManager.AddToRoleAsync(user, input.UserTypeId == 1 ? RoleNameConstants.Tutor : RoleNameConstants.Tutee).Result;

                var userDetail = Providers.Mapper.Map<UserDetail>(input);
                userDetail.User = user;
                Providers.Database.UserDetail.Add(userDetail);
                Providers.Database.SaveChanges();
                return ExecutionResult.Success();

            }
        }
    }
}
