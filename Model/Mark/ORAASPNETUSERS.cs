using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_USERS", DisableSyncStructure = true)]
	public partial class ORAASPNETUSERS {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true, InsertValueSql = "SYS_GUID()")]
		public byte[] USERID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] APPLICATIONID { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal ISANONYMOUS { get; set; } = 0M;

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTACTIVITYDATE { get; set; }

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string LOWEREDUSERNAME { get; set; }

		[JsonProperty, Column(StringLength = 16)]
		public string MOBILEALIAS { get; set; } = "NULL";

		[JsonProperty, Column(StringLength = 256, IsNullable = false)]
		public string USERNAME { get; set; }

	}

}
