using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_EMPLOYEE", DisableSyncStructure = true)]
	public partial class TEMPLOYEE {

		/// <summary>
		/// 员工编号
		/// </summary>
		[JsonProperty, Column(IsPrimary = true)]
		public uint ID { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		[JsonProperty, Column(Name = "N_AGE")]
		public byte? NAGE { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		[JsonProperty, Column(Name = "VC_ADDRESS", DbType = "VARCHAR2(100 BYTE)")]
		public string VCADDRESS { get; set; }

		/// <summary>
		/// 员工代码
		/// </summary>
		[JsonProperty, Column(Name = "VC_EMPCODE", DbType = "VARCHAR2(30 BYTE)")]
		public string VCEMPCODE { get; set; }

		/// <summary>
		/// 电话号码
		/// </summary>
		[JsonProperty, Column(Name = "VC_PHONENUMBER", DbType = "VARCHAR2(20 BYTE)")]
		public string VCPHONENUMBER { get; set; }

		/// <summary>
		/// 英文全名
		/// </summary>
		[JsonProperty, Column(Name = "VC_REALNAME", DbType = "VARCHAR2(50 BYTE)")]
		public string VCREALNAME { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[JsonProperty, Column(Name = "VC_SEX", DbType = "VARCHAR2(5 BYTE)")]
		public string VCSEX { get; set; }

		/// <summary>
		/// 用户登录名
		/// </summary>
		[JsonProperty, Column(Name = "VC_USERID", DbType = "VARCHAR2(30 BYTE)")]
		public string VCUSERID { get; set; }

		/// <summary>
		/// 用户姓名
		/// </summary>
		[JsonProperty, Column(Name = "VC_USERNAME", DbType = "VARCHAR2(50 BYTE)")]
		public string VCUSERNAME { get; set; }

	}

}
