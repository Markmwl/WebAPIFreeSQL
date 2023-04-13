# WebAPIFreeSQL

asp.net core webapi .NET6+ FreeSQL

## 1.CodeFirst

`FreeSql` 支持 `CodeFirst` 迁移结构至数据库，这应该是(`O/RM`)必须标配的一个功能。

与其他(`O/RM`)不同的是：`FreeSql`支持更多的数据库特性，而不只是支持基础的数据类型，这既是优点也是缺点，优点是充分利用数据库特性辅助开发，缺点是切换数据库变得困难。不同程序员的理念可能不太一致，`FreeSql`尽量把功能支持到极致，至于是否使用是项目组技术衡量的另一个问题。

尽管多种数据库适配逻辑非常复杂，`FreeSql`始终秉承优化程序开发习惯的原则尽量去实现，中间碰到了一些非技术无法攻克的难题，比如数据库的自定义类型，和实体类本身就是一种冲突，为了减少使用成本，诸如此类的数据库功能没有得到支持。

~~~~csharp
IFreeSql fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.MySql, connectionString)
    .UseAutoSyncStructure(true) //自动同步实体结构【开发环境必备】，FreeSql不会扫描程序集，只有CRUD时才会生成表。
    .UseMonitorCommand(cmd => Console.Write(cmd.CommandText))
    .Build(); //请务必定义成 Singleton 单例模式
~~~~

### 1.1迁移结构

| 创建数据库 | Sqlite | Sql Server                                                   | MySql                                                        | PostgreSQL                                                   | Oracle |
| ---------- | ------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------ |
|            | √      | X [参考open in new window](https://github.com/luoyunchong/lin-cms-dotnetcore/blob/master/src/LinCms.Infrastructure/FreeSql/FreeSqlExtension.cs#L153) | X [参考open in new window](https://github.com/luoyunchong/lin-cms-dotnetcore/blob/master/src/LinCms.Infrastructure/FreeSql/FreeSqlExtension.cs#L129) | X[参考open in new window](https://github.com/luoyunchong/lin-cms-dotnetcore/blob/master/src/LinCms.Infrastructure/FreeSql/FreeSqlExtension.cs#L233) | X      |

| 实体＆表对比 | 添加 | 改名 | 删除 |
| ------------ | ---- | ---- | ---- |
|              | √    | √    | X    |

| 实体属性＆字段对比 | 添加 | 修改可空 | 修改自增 | 修改类型 | 改名 | 删除 | 备注 |
| ------------------ | ---- | -------- | -------- | -------- | ---- | ---- | ---- |
|                    | √    | √        | √        | √        | √    | X    | √    |

> 为了保证安全，不提供删除字段。

警告：如果实体类属性，与数据库表字段不完整映射的时候，未映射的字段有可能发生丢失。

> 原因：某些迁移对比操作是：创建临时表、导入旧表数据、删除旧表。

### 1.2FreeSql 提供两种 CodeFirst 移迁方法，自动和手动。

**注意**：谨慎、谨慎、谨慎在生产环境中使用该功能。

**注意**：谨慎、谨慎、谨慎在生产环境中使用该功能。

**注意**：谨慎、谨慎、谨慎在生产环境中使用该功能。

### 1.3自动同步实体结构【开发环境必备】

自动同步实体结构到数据库，程序运行中检查实体表是否存在，然后迁移执行创建或修改。

```csharp
fsql.CodeFirst.IsAutoSyncDataStructure = true;
```

> 此功能默认为开启状态，发布正式环境后，请修改此设置。

> 虽然【自动同步实体结构】功能开发非常好用，但是有个坏处，就是数据库后面会很乱，没用的字段可能一大堆，应尽量控制实体或属性命名的修改。

- 注意：只有当 CURD 到此表时，才会自动生成表结构。如需系统运行时迁移表结构，请使用**SyncStructure**方法
- `FreeSql`不会帮你生成数据库，需要你手动创建数据库。**如果你使用`Mysql`、`Sql Server`,`PostgreSQL`，需要自动创建数据库.请参考此代码，自行 copy，[FreeSqlExtension.csopen in new window](https://github.com/luoyunchong/lin-cms-dotnetcore/blob/master/src/LinCms.Infrastructure/FreeSql/FreeSqlExtension.cs)**

### 1.4禁用迁移

当【实体类】对应的是数据库【视图】或者其他时，可通过 [Table(DisableSyncStructure = true)] 禁用指定的实体迁移操作。

```csharp
[Table(DisableSyncStructure = true)]
class ModelDisableSyncStructure {
    [Column(IsPrimary = false)]
    public int pkid { get; set; }
}
```

## 1.5备注

FreeSql CodeFirst 支持将 c# 代码内的注释，迁移至数据库的备注。先决条件：

1、实体类所在程序集，需要开启 xml 文档功能；

2、xml 文件必须与程序集同目录，且文件名：xxx.dll -> xxx.xml；

> v1.5.0+ 版本增加了对 Description 特性的解析，优先级低于 c# 代码注释；

# 2.DbFirst

### .NET Core CLI(推荐使用)

代码生成器`FreeSql.Generator`,是 FreeSql 的代码生成器，可生成实体类，支持将数据库实体动态生成实体，默认有二个模板，基于 Razor，可指定自定义模板

#### 1.安装

~~~~bash
dotnet tool install -g FreeSql.Generator
~~~~

#### 2.更新

~~~~bash
dotnet tool update -g FreeSql.Generator
~~~~

#### 3.帮助

~~~~bash
FreeSql.Generator --help
~~~~

~~~~shell
PS C:\Users\52841\Desktop\WebAPIFreeSQL\WebAPIFreeSQL\Model> FreeSql.Generator --help
        ____                   ____         __
       / __/  ____ ___  ___   / __/ ___ _  / /
      / _/   / __// -_)/ -_) _\ \  / _ `/ / /
     /_/    /_/   \__/ \__/ /___/  \_, / /_/
                                    /_/


  # Github # https://github.com/2881099/FreeSql v3.2.693

    FreeSql 快速生成数据库的实体类

    更新工具：dotnet tool update -g FreeSql.Generator


  # 快速开始 #

  > FreeSql.Generator -Razor 1 -NameOptions 0,0,0,0 -NameSpace MyProject -DB "MySql,Data Source=127.0.0.1;..."

     -Razor 1                  * 选择模板：实体类+特性
     -Razor 2                  * 选择模板：实体类+特性+导航属性
     -Razor "d:\diy.cshtml"    * 自定义模板文件，如乱码请修改为UTF8(不带BOM)编码格式

     -NameOptions              * 4个布尔值对应：
                                 首字母大写
                                 首字母大写，其他小写
                                 全部小写
                                 下划线转驼峰

     -NameSpace                * 命名空间

     -DB "MySql,data source=127.0.0.1;port=3306;user id=root;password=root;initial catalog=数据库;charset=utf8;sslmode=none;max pool size=2"
     -DB "SqlServer,data source=.;integrated security=True;initial catalog=数据库;pooling=true;max pool size=2"
     -DB "PostgreSQL,host=192.168.164.10;port=5432;username=postgres;password=123456;database=数据库;pooling=true;maximum pool size=2"
     -DB "Oracle,user id=user1;password=123456;data source=//127.0.0.1:1521/XE;pooling=true;max pool size=2"
     -DB "Sqlite,data source=document.db"
     -DB "Firebird,database=localhost:D:\fbdata\EXAMPLES.fdb;user=sysdba;password=123456;max pool size=2"
     -DB "Dameng,server=127.0.0.1;port=5236;user id=2user;password=123456789;database=2user;poolsize=2"
     -DB "KingbaseES,server=127.0.0.1;port=54321;uid=USER2;pwd=123456789;database=数据库"
     -DB "ShenTong,host=192.168.164.10;port=2003;database=数据库;username=SYSDBA;password=szoscar55;maxpoolsize=2"
                               * Dameng(达梦数据库)、KingbaseES(人大金仓数据库)、ShenTong(神舟通用数据库)

     -Filter                   Table+View+StoreProcedure
                               默认生成：表+视图+存储过程
                               如果不想生成视图和存储过程 -Filter View+StoreProcedure

     -Match                    表名或正则表达式，只生成匹配的表，如：dbo\.TB_.+
     -Json                     NTJ、STJ、NONE
                               Newtonsoft.Json、System.Text.Json、不生成

     -FileName                 文件名，默认：{name}.cs
     -Output                   保存路径，默认为当前 shell 所在目录
                               推荐在实体类目录创建 gen.bat，双击它重新所有实体类
~~~~

#### 4.使用

##### 1.常用选项

| 选项         | 说明                                                         |
| :----------- | :----------------------------------------------------------- |
| -Razor       | 选择模板：实体类+特性 `-Razor 1` / 实体类+特性+导航属性 `-Razor 2`/ 自定义模板文件 `-Razor "d:\diy.cshtml"` |
| -NameOptions | 生成的实体命名规范，应只设置某一个为参数为 1，其中 4 个布尔值对应：`首字母大写`/`首字母大写,其他小写`/`全部小写`/`下划线转驼`（-NameOptions 0,0,0,1） |
| -NameSpace   | 命名空间                                                     |
| -DB          | 看下文中的-DB 参数                                           |
| -Filter      | Table+View+StoreProcedure（ 默认生成：表+视图+存储过程）， 如果不想生成视图和存储过程 -Filter View+StoreProcedure |
| -Match       | 表名或正则表达式，只生成匹配的表，如：dbo.TB_.+              |
| -FileName    | 文件名，默认：{name}.cs                                      |
| -Output      | 推荐在实体类目录创建 gen.bat，双击它重新所有实体类           |

##### 2.DB 参数

~~~~bash
-DB "MySql,data source=127.0.0.1;port=3306;user id=root;password=root;initial catalog=数据库;charset=utf8;sslmode=none;max pool size=2"
-DB "SqlServer,data source=.;integrated security=True;initial catalog=数据库;pooling=true;max pool size=2"
-DB "PostgreSQL,host=192.168.164.10;port=5432;username=postgres;password=123456;database=数据库;pooling=true;maximum pool size=2"
-DB "Oracle,user id=user1;password=123456;data source=//127.0.0.1:1521/XE;pooling=true;max pool size=2"
-DB "Sqlite,data source=document.db"
-DB "Firebird,database=localhost:D:\fbdata\EXAMPLES.fdb;user=sysdba;password=123456;max pool size=2"
-DB "Dameng,server=127.0.0.1;port=5236;user id=2user;password=123456789;database=2user;poolsize=2"
-DB "KingbaseES,server=127.0.0.1;port=54321;uid=USER2;pwd=123456789;database=数据库"
-DB "ShenTong,host=192.168.164.10;port=2003;database=数据库;username=SYSDBA;password=szoscar55;maxpoolsize=2"
~~~~

##### 3.指令

在实体类目录下执行：

~~~~bash
FreeSql.Generator -Razor 1 -NameOptions 0,0,0,1 -NameSpace WebAPIFreeSQL.Model -DB "Oracle,user id=Mark;password=123456; data source=//127.0.0.1:1521/ORCL;Pooling=true;Min Pool Size=2" -FileName "{name}.cs" -Filter View+StoreProcedure
~~~~

- 数据库表名是下划线，字段也是下划线方式。
- -Razor 指定 第一个模板
- -NameOptions 0,0,0,1 最后一个 1，代表 下划线转驼峰，满足 C#命名规则
- -NameSpace 指定了命名空间 LinCms.Core.Entities
- -DB 就是数据库的相关配置
- mysql 本地地址 127.0.0.1 3306 端口 用户名 root 密码 123456 数据库 lin-cms
- -Match book 这样就能只生成 book，支持正则表达式，如 -Match lin*user 就会生成以 lin_user 开头的表。如 dbo.TB*.+，会生成以 TB 开头的表。即只生成匹配的表
