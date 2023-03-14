using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace eStore.Areas.Identity.Pages.Account
{
    [Authorize]
    public class UpdateModel : PageModel
    {
        private readonly SignInManager<eStoreUser> _signInManager;
        private readonly UserManager<eStoreUser> _userManager;
        private readonly RoleManager<eStoreUser> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public UpdateModel(
            UserManager<eStoreUser> userManager,
            SignInManager<eStoreUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Current Password")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [MaxLength(100)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [MaxLength(100)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            var currentUser = _userManager.Users.FirstOrDefault(user => user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            Input = new InputModel()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.Users.FirstOrDefault(user => user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
                currentUser.FirstName = Input.FirstName;
                currentUser.LastName = Input.LastName;
                IdentityResult result = await _userManager.UpdateAsync(currentUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return BadRequest(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
