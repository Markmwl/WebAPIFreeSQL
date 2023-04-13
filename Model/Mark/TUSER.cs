using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	/// <summary>
	/// 用户表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_USER", DisableSyncStructure = true)]
	public partial class TUSER {

		/// <summary>
		/// 主键
		/// </summary>
		[JsonProperty, Column(Name = "VC_ID", DbType = "VARCHAR2(256 BYTE)", IsPrimary = true, IsNullable = false)]
		public string VCID { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty, Column(Name = "D_CDATE", DbType = "DATE(7)")]
		public DateTime DCDATE { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonProperty, Column(Name = "D_MDATE", DbType = "DATE(7)")]
		public DateTime DMDATE { get; set; }

		/// <summary>
		/// 创建者
		/// </summary>
		[JsonProperty, Column(Name = "VC_CID", DbType = "VARCHAR2(256 BYTE)", IsNullable = false)]
		public string VCCID { get; set; }

		/// <summary>
		/// 部门
		/// </summary>
		[JsonProperty, Column(Name = "VC_DEPNAME", DbType = "VARCHAR2(256 BYTE)")]
		public string VCDEPNAME { get; set; }

		/// <summary>
		/// 是否管理员
		/// </summary>
		[JsonProperty, Column(Name = "VC_ISADMIN", DbType = "VARCHAR2(1 BYTE)", IsNullable = false)]
		public string VCISADMIN { get; set; } = "0";

		/// <summary>
		/// 删除标识
		/// </summary>
		[JsonProperty, Column(Name = "VC_ISDEL", DbType = "VARCHAR2(1 BYTE)", IsNullable = false)]
		public string VCISDEL { get; set; } = "0";

		/// <summary>
		/// 修改者
		/// </summary>
		[JsonProperty, Column(Name = "VC_MID", DbType = "VARCHAR2(256 BYTE)", IsNullable = false)]
		public string VCMID { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		[JsonProperty, Column(Name = "VC_USERNAME", DbType = "VARCHAR2(256 BYTE)", IsNullable = false)]
		public string VCUSERNAME { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[JsonProperty, Column(Name = "VC_USERPASS", DbType = "VARCHAR2(256 BYTE)", IsNullable = false)]
		public string VCUSERPASS { get; set; }

	}

}
