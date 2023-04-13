using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_PATHS", DisableSyncStructure = true)]
	public partial class ORAASPNETPATHS {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true, InsertValueSql = "SYS_GUID()")]
		public byte[] PATHID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] APPLICATIONID { get; set; }

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string LOWEREDPATH { get; set; }

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string PATH { get; set; }

	}

}
