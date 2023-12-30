using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.User;
using My_Smart_Factory.Data.Enums;
using My_Smart_Factory.Data.Vo.User;
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
        // 회원가입 페이지 전송
        [HttpGet("signup")]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        // 회원가입 동작
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            try
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
                    // 유저 권한 부여
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Member.ToString());
                    return Redirect("/user/login");
                }
                else
                {
                    ViewData["Error"] = "중복된 사용자가 있습니다";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "회원가입에 실패하였습니다";
            }
            return View(model);
        }
        #endregion

        #region 로그인
        // 로그인 페이지 전송
        [HttpGet("login")]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        // 로그인 동작
        [HttpPost("login")]
        public async Task<IActionResult> Login(PiDto model, string? ReturnUrl)
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
                else
                {
                    ViewData["Error"] = "ID, PW가 일치하지 않습니다";
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
        [Authorize(Roles = "Admin")]
        [HttpGet("userlist")]
        public async Task<IActionResult> UserList()
        {
            try
            {
                // _dbContext에서 유저 정보들을 가져오고 List<UserVo>로 변환
                var userList = await _dbContext.UserIdentitys.ToListAsync();
                List<UserVo> userVo = new List<UserVo>();
                //userList를 userVo로 변환
                foreach (var user in userList)
                {
                    var result = await _userManager.GetRolesAsync(user);
                    userVo.Add(new UserVo
                    {
                        UserName = user.UserName,
                        Role = result[0]
                    });
                }
                return View(userList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "유저 리스트를 불러오는데 실패하였습니다";
                return View();
            }
        }
        #endregion

        #region 권한 변경
        [Authorize(Roles = "Admin")]
        [HttpPost("updaterole")]
        public async Task<IActionResult> UpdateRole(UpdateRolesDto requestDto)
        {
            try
            {
                if (requestDto.oldRole == requestDto.newRole) Redirect("/user/userlist");
                var user = await _userManager.FindByNameAsync(requestDto.userName);
                var result = await _userManager.RemoveFromRoleAsync(user, requestDto.oldRole);

                if (result.Succeeded)
                {
                    // 권한 승인
                    await _userManager.AddToRoleAsync(user, requestDto.newRole);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "권한 수정에 실패하였습니다";
            }
            return Redirect("/user/userlist");
        }
        #endregion

        #region 마이페이지
        // 로그인 된 사용자만 들어올 수 있다
        [Authorize]
        [HttpGet("mypage")]
        public async Task<IActionResult> MyPage()
        {
            // 유저 정보 가져오기
            UserIdentity user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user == null ? Redirect("/user/Login") : View(user);

        }

        [Authorize]
        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(string newUserName)
        {
            try
            {
                // 유저 정보 가져오기
                UserIdentity user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = newUserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    // 사용자 정보 업데이트 후, 사용자를 다시 로그인 시킵니다.
                    await _signInManager.RefreshSignInAsync(user);
                }
                else
                {
                    ViewData["Error"] = "유저 수정에 실패하였습니다";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "유저 수정에 실패하였습니다";
            }
            return RedirectToAction("mypage", "user");


        }

        [Authorize]
        [HttpGet("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(string userName, string oldPassword, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                IdentityResult result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("login", "user");
                }
                else
                {
                    ViewData["Error"] = "비밀번호 변경에 실패하였습니다";
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewData["Error"] = "비밀번호 변경에 실패하였습니다";
                return View();
            }

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
