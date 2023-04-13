using Model.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public interface UserService
    {
        /// <summary>
        /// 获取所有用户表信息
        /// </summary>
        /// <returns></returns>
        public List<用户表> GetUserAll();

        /// <summary>
        /// 根据ID获取用户表信息
        /// </summary>
        /// <param name="id">用户id</param>
        public 用户表 GetUserByID(string id);

        /// <summary>
        /// 获取ID集合获取用户表信息
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns></returns>
        public List<用户表> GetUserByIDs(List<string> ids);

        /// <summary>
        /// 分页查询用户表信息
        /// </summary>
        /// <param name="PageNumber">页数</param>
        /// <param name="PageCount">每页显示条数</param>
        /// <returns></returns>
        public List<用户表> GetUserByPage(int PageNumber,int PageCount);

        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        public int InsertUser(用户表 user);

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        public int InsertUsers(List<用户表> users);

        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回受影响行数</returns>
        public int DeleteUser(string id);

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="ids">用户id集合</param>
        /// <returns>返回受影响行数</returns>
        public int DeleteUsers(List<string> ids);

        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        public int DeleteUser(用户表 user);

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        public int DeleteUsers(List<用户表> users);

        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns>返回受影响行数</returns>
        public int UpdateUser(用户表 user);

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="users">用户模型集合</param>
        /// <returns>返回受影响行数</returns>
        public int UpdateUsers(List<用户表> users);




    }
}
