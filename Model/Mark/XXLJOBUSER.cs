using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_USER", DisableSyncStructure = true)]
	public partial class XXLJOBUSER {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string PASSWORD { get; set; }

		/// <summary>
		/// 权限：执行器ID列表，多个逗号分割
		/// </summary>
		[JsonProperty, Column(StringLength = 255)]
		public string PERMISSION { get; set; }

		/// <summary>
		/// 角色：0-普通用户、1-管理员
		/// </summary>
		[JsonProperty]
		public sbyte ROLE { get; set; }

		/// <summary>
		/// 账号
		/// </summary>
		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string USERNAME { get; set; }

	}

}
