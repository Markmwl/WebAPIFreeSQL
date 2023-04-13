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
	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class 用户表 {

		/// <summary>
		/// 用户ID
		/// </summary>
		[JsonProperty, Column(StringLength = 20, IsPrimary = true, IsNullable = false)]
		public string ID { get; set; }

		/// <summary>
		/// 用户地址
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string ADDRESS { get; set; }

		/// <summary>
		/// 年龄
		/// </summary>
		[JsonProperty, Column(StringLength = 3)]
		public string AGE { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		[JsonProperty, Column(StringLength = 20)]
		public string NAME { get; set; }

		/// <summary>
		/// 电话号码
		/// </summary>
		[JsonProperty, Column(StringLength = 15)]
		public string PHONENUMBER { get; set; }

		/// <summary>
		/// 性别
		/// </summary>
		[JsonProperty, Column(StringLength = 2)]
		public string SEX { get; set; }

	}

}
