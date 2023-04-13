using Model.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User.Impl
{
    public class UserServiceImpl : UserService
    {
        private IFreeSql fsql = FreeSQLFactory.freeSql;


        List<用户表> UserService.GetUserAll()
        {
            return fsql.Select<用户表>().ToList();
        }

        用户表 UserService.GetUserByID(string id)
        {
            return fsql.Select<用户表>().Where(o => o.ID == id).First();
        }

        List<用户表> UserService.GetUserByIDs(List<string> ids)
        {
            return fsql.Select<用户表>().Where(o => ids.Contains(o.ID)).ToList();
        }

        List<用户表> UserService.GetUserByPage(int PageNumber, int PageCount)
        {
            return fsql.Select<用户表>()
                   //.Where(a => a.ID > 10)
                   .Count(out var total) //总记录数量
                   .Page(PageNumber, PageCount)
                   .ToList();
        }

        int UserService.InsertUser(用户表 user)
        {
            return fsql.Insert(user).ExecuteAffrows();
        }

        int UserService.InsertUsers(List<用户表> users)
        {
            return fsql.Insert(users).ExecuteAffrows();
        }

        int UserService.UpdateUser(用户表 user)
        {
            return fsql.Update<用户表>().SetSource(user).ExecuteAffrows();
        }

        int UserService.UpdateUsers(List<用户表> users)
        {
            //必须要有主键。没主键需要添加临时主键
            return fsql.Update<用户表>().SetSource(users).ExecuteAffrows();
            //例如 根据临时主键更新，a => a.Name | a => new{a.Name,a.Time} | a => new[]{"name","time"}
            //return fsql.Update<用户表>().SetSource(users, a =>a.ID).ExecuteAffrows();
        }

        int UserService.DeleteUser(string id)
        {
            //删除是一个非常危险的操作，FreeSql 对删除支持并不强大，默认仅支持单表、且有条件的删除方法。
            //若 Where 条件为空的时候执行，仅返回 0 或默认值，不执行真正的 SQL 删除操作。
            //出于安全考虑，没有条件不执行删除动作，避免误删除全表数据。删除全表数据：fsql.Delete<T>().Where("1=1").ExecuteAffrows()
            return fsql.Delete<用户表>().Where(o=>o.ID == id).ExecuteAffrows();
        }

        int UserService.DeleteUser(用户表 user)
        {
            return fsql.Delete<用户表>().Where(user).ExecuteAffrows();
        }

        int UserService.DeleteUsers(List<string> ids)
        {
            return fsql.Delete<用户表>().Where(o=>ids.Contains(o.ID)).ExecuteAffrows();
        }

        int UserService.DeleteUsers(List<用户表> users)
        {
            return fsql.Delete<用户表>().Where(users).ExecuteAffrows();
        }
    }
}
