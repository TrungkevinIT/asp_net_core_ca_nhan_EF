using BaiTapQuayVideo_EF.Database;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapQuayVideo_EF.Controllers
{
    public class AuthController : Controller
    {
        private readonly ConnectDatabase _connection;

        public AuthController(ConnectDatabase connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string hashedPassword = password;

            try
            {
                //Kiểm tra tài khoản nhân viên (Admin, Staff)
                var staff = _connection.staffs
                    .FirstOrDefault(s => s.Email == email &&
                                         s.HashedPassword == hashedPassword &&
                                         s.States == 1);

                if (staff != null)
                {
                    // Lưu thông tin vào Session
                    HttpContext.Session.SetString("username", staff.Username ?? "");
                    HttpContext.Session.SetString("Role", staff.Roles.ToString());

                    // Nếu là admin (Roles = 0)
                    if (staff.Roles == 0)
                    {
                        return RedirectToAction("ProductManagement", "Admin", new { area = "Admin" });
                    }
                }

                //Nếu không phải nhân viên, kiểm tra tài khoản khách hàng
                var customer = _connection.customers
                    .FirstOrDefault(c => c.Email == email &&
                                         c.HashedPassword == hashedPassword &&
                                         c.States == 1);

                if (customer != null)
                {
                    HttpContext.Session.SetString("Username", customer.CustomerName ?? "");
                    HttpContext.Session.SetString("Role", "Customer");

                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }

                //Nếu không tìm thấy tài khoản hợp lệ
                ViewBag.Error = "Email hoặc mật khẩu không đúng!";
                return View();
            }
            catch (Exception ex)
            {
                // Log lỗi (nếu cần)
                ViewBag.Error = "Đã xảy ra lỗi khi đăng nhập: " + ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
