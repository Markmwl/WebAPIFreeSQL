using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Model.Mark;
using Service.User;
using Service.User.Impl;

namespace WebAPIFreeSQL.Controllers
{
    /// <summary>
    /// 用户表接口
    /// </summary>
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private UserService Service = new UserServiceImpl();

        /// <summary>
        /// 获取所有用户表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetUserAll")]
        public IActionResult GetUserAll()
        {
            try
            {
                List<用户表> users = Service.GetUserAll();
                if (users == null)
                {
                    return Ok(new RestResult(ResultStatus.NG, "查无数据"));
                }
                return Ok(new RestResult(ResultStatus.OK, "查询成功", users));
            }
            catch (Exception ex)
            {

                return NotFound(new RestResult(ResultStatus.NG, "查询失败，原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 根据ID获取用户表信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet, Route("GetUserByID")]
        public IActionResult GetUserByID(string id)
        {
            try
            {
                用户表 user = Service.GetUserByID(id);
                if (user == null)
                {
                    return Ok(new RestResult(ResultStatus.NG, "查无此人"));
                }
                return Ok(new RestResult(ResultStatus.OK, "查询成功", user));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.NG, "查询失败，原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 获取ID集合获取用户表信息
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns></returns>
        [HttpPost, Route("GetUserByIDs")]
        public IActionResult GetUserByIDs(List<string> ids)
        {
            try
            {
                List<用户表> users = Service.GetUserByIDs(ids);
                if (users == null)
                {
                    return Ok(new RestResult(ResultStatus.NG, "查无数据"));
                }
                return Ok(new RestResult(ResultStatus.OK, "查询成功", users));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.NG, "查询失败，原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 分页查询用户表信息
        /// </summary>
        /// <param name="PageNumber">页数</param>
        /// <param name="PageCount">每页显示条数</param>
        /// <returns></returns>
        [HttpGet, Route("GetUserByPage")]
        public IActionResult GetUserByPage(int PageNumber, int PageCount)
        {
            try
            {
                List<用户表> users = Service.GetUserByPage(PageNumber, PageCount);
                if (users == null)
                {
                    return Ok(new RestResult(ResultStatus.NG, "查无数据"));
                }
                return Ok(new RestResult(ResultStatus.OK, "查询成功", users));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.NG, "查询失败，原因：" + ex.Message));
            }
        }

        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("InsertUser")]
        public IActionResult InsertUser(用户表 user)
        {
            try
            {
                int count = Service.InsertUser(user);
                return Ok(new RestResult(ResultStatus.OK, "插入单条数据 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "插入单条数据失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("InsertUsers")]
        public IActionResult InsertUsers(List<用户表> users)
        {
            try
            {
                int count = Service.InsertUsers(users);
                return Ok(new RestResult(ResultStatus.OK, "插入多条数据 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "插入多条数据失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 删除单条数据-ID
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回受影响行数</returns>
        [HttpGet, Route("DeleteUserByID")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                int count = Service.DeleteUser(id);
                return Ok(new RestResult(ResultStatus.OK, "删除单条数据-ID - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "删除单条数据-ID失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 删除多条数据-ID
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("DeleteUsersByIDs")]
        public IActionResult DeleteUsers(List<string> ids)
        {
            try
            {
                int count = Service.DeleteUsers(ids);
                return Ok(new RestResult(ResultStatus.OK, "删除多条数据-ID - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "删除多条数据-ID失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 删除单条数据-模型
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("DeleteUser")]
        public IActionResult DeleteUser(用户表 user)
        {
            try
            {
                int count = Service.DeleteUser(user);
                return Ok(new RestResult(ResultStatus.OK, "删除单条数据-模型 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "删除单条数据-模型失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 删除多条数据-模型
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("DeleteUsers")]
        public IActionResult DeleteUsers(List<用户表> users)
        {
            try
            {
                int count = Service.DeleteUsers(users);
                return Ok(new RestResult(ResultStatus.OK, "删除多条数据-模型 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "删除多条数据-模型失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("UpdateUser")]
        public IActionResult UpdateUser(用户表 user)
        {
            try
            {
                int count = Service.UpdateUser(user);
                return Ok(new RestResult(ResultStatus.OK, "更新单条数据 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "更新单条数据失败，原因： " + ex.Message));
            }
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        [HttpPost, Route("UpdateUsers")]
        public IActionResult UpdateUsers(List<用户表> users)
        {
            try
            {
                int count = Service.UpdateUsers(users);
                return Ok(new RestResult(ResultStatus.OK, "更新多条数据 - 受影响行数", count));
            }
            catch (Exception ex)
            {
                return NotFound(new RestResult(ResultStatus.ER, "更新多条数据失败，原因： " + ex.Message));
            }
        }
    }
}
