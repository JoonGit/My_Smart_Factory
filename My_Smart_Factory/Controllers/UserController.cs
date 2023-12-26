using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.User;
using My_Smart_Factory.Data.Enums;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyDbContext _dbContext;

        public UserController(
            UserManager<UserIdentity> userManager
            , SignInManager<UserIdentity> signInManager
            , RoleManager<IdentityRole> roleManager
            , MyDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        #region 회원가입
        [HttpGet("signup")]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            // 유저 정보 입력
            var newUser = new UserIdentity
            {
                Id = model.Id,
                UserName = model.UserName,
            };

            // 유저 생성
                var newUserResponse = await _userManager.CreateAsync(newUser, model.Password);
                if (newUserResponse.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(UserRoles.Membaer.ToString());
                    if (!roleExists)
                    {
                        var role = new IdentityRole(UserRoles.Membaer.ToString());
                        await _roleManager.CreateAsync(role);
                    }
                return Redirect("/user/login");
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(model);
        }
        #endregion

        #region 로그인
        [HttpGet("login")]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model, string? ReturnUrl)
        {
            try
            {
                // 유저 정보 입력
                var loginUser = await _userManager.FindByIdAsync(model.Id);
                // 유저 로그인
                var user = await _signInManager.PasswordSignInAsync(loginUser, model.Password, false, false);
                if (user.Succeeded)
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "로그인에 실패하였습니다";
            }
            return View();
        }
        #endregion

        #region 로그아웃
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region 유저리스트
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet("userlist")]
        public async Task<IActionResult> UserList()
        {
            // _dbContext에서 유저 정보들을 가져오고 List<UserVo>로 변환
            List<UserVo> userList = await _dbContext.UserIdentities.Select(u => new UserVo
            {
                UserName = u.UserName,
                Role = _userManager.GetRolesAsync(u).Result.FirstOrDefault(),
            }).ToListAsync();
            ViewBag.userList = userList;
            return View(userList);
        }
        #endregion

        #region 권한 승인
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost("updaterole")]
        public async Task<IActionResult> RollAccept(UpdateRolesDto requestDto)
        {

            for (int i = 0; i < requestDto.UserId.Length; i++)
            {
                if (requestDto.Role[i] == requestDto.BeforeRole[i]) continue;
                // 권한 변경
                // 권한 변경 전 권한 삭제
                var user = await _userManager.FindByIdAsync(requestDto.UserId[i]);
                var result = await _userManager.RemoveFromRoleAsync(user, requestDto.BeforeRole[i]);
                // 권한 삭제 후 권한 추가
                if (result.Succeeded)
                {
                    // 권한 승인
                    await _userManager.AddToRoleAsync(user, requestDto.Role[i]);
                }
            }
            // 로그인 페이지 이동
            return Redirect("/user/login");
        }
        #endregion

        #region 마이페이지
        // 로그인 된 사용자만 들어올 수 있다
        [HttpGet("mypage")]
        public async Task<IActionResult> MyPage()
        {
            // 유저 정보 가져오기
            UserIdentity user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user == null ? Redirect("/user/Login") : View(user);
            
        }

        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(String userName)
        {
            // 유저 정보 가져오기
            UserIdentity user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.UserName = userName;
            await _userManager.UpdateAsync(user);
            return View(user);
        }

        [HttpGet("changepassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            IdentityResult result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            ViewData["Error"] = result.Succeeded ? null : result.Errors;
            return View(result.Succeeded ? "/user/login" : user);
        }
        #endregion        

        #region 회원탈퇴
        [HttpGet("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            ViewData["Error"] = result.Succeeded ? null : result.Errors;
            return result.Succeeded ? Redirect("/user/login") : View(user);
        }
        #endregion

        #region 권한 없는 사용자가 접근했을 때 보내지는 페이지
        [HttpGet("accessdenied")]
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
        #endregion
    }



}
