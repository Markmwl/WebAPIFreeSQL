using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_GROUP", DisableSyncStructure = true)]
	public partial class XXLJOBGROUP {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		/// <summary>
		/// 执行器地址列表，多地址逗号分隔
		/// </summary>
		[JsonProperty, Column(Name = "ADDRESS_LIST", StringLength = 512)]
		public string ADDRESSLIST { get; set; }

		/// <summary>
		/// 执行器地址类型：0=自动注册、1=手动录入
		/// </summary>
		[JsonProperty, Column(Name = "ADDRESS_TYPE")]
		public sbyte ADDRESSTYPE { get; set; }

		/// <summary>
		/// 执行器AppName
		/// </summary>
		[JsonProperty, Column(Name = "APP_NAME", StringLength = 64, IsNullable = false)]
		public string APPNAME { get; set; }

		/// <summary>
		/// 执行器名称
		/// </summary>
		[JsonProperty, Column(StringLength = 12, IsNullable = false)]
		public string TITLE { get; set; }

	}

}
