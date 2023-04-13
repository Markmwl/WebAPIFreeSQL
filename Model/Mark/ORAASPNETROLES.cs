using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_ROLES", DisableSyncStructure = true)]
	public partial class ORAASPNETROLES {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true, InsertValueSql = "SYS_GUID()")]
		public byte[] ROLEID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] APPLICATIONID { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string DESCRIPTION { get; set; }

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string LOWEREDROLENAME { get; set; }

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string ROLENAME { get; set; }

	}

}
