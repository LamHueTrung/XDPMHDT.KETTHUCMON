using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PTMNHDT.KetThucMon.Travel.Data;
using PTMNHDT.KetThucMon.Travel.Models;

namespace PTMNHDT.KetThucMon.Travel.Utilites
{
    public class DbInitializer : IDbInitializer
    {
        private readonly TravelDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(TravelDbContext context,
                               UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            // Kiểm tra và tạo các vai trò nếu chưa tồn tại
            if (!_roleManager.RoleExistsAsync(WebsiteRoles.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Manager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.User)).GetAwaiter().GetResult();
            }

            // Tạo người dùng mặc định nếu chưa có
            var defaultUser = _userManager.FindByEmailAsync("admin@gmail.com").Result;
            if (defaultUser == null)
            {
                var user = new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "ADMIN",
                };

                var createResult = _userManager.CreateAsync(user, "Admin556669*").Result;
                if (createResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, WebsiteRoles.Admin).GetAwaiter().GetResult();
                }
                else
                {
                    Console.WriteLine("Error creating user: " + string.Join(", ", createResult.Errors.Select(e => e.Description)));
                }
            }

            // Tạo các trang mặc định
            var listOfPages = new List<Page>()
            {
                new Page { Title = "About Us", Slug = "about" },
                new Page { Title = "Contact Us", Slug = "contact" },
                new Page { Title = "Privacy Policy", Slug = "privacy" }
            };

            if (!_context.Pages.Any())
            {
                _context.Pages.AddRange(listOfPages);
            }

            // Tạo các thiết lập mặc định
            var setting = new Setting
            {
                SiteName = "Travel Trà Vinh",
                Title = "Travel Trà Vinh - Khám Phá Mỗi Ngày",
                ShortDescription = "Khám phá các địa điểm du lịch tại Trà Vinh"
            };

            if (!_context.Settings.Any())
            {
                _context.Settings.Add(setting);
            }

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
        }
    }
}
