using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_SESSIONS", DisableSyncStructure = true)]
	public partial class ORAASPNETSESSIONS {

		[JsonProperty, Column(StringLength = 116, IsPrimary = true, IsNullable = false)]
		public string SESSIONID { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)", InsertValueSql = "SYS_EXTRACT_UTC(SYSTIMESTAMP)")]
		public DateTime CREATED { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime EXPIRES { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal FLAGS { get; set; } = 0M;

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal LOCKCOOKIE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LOCKDATE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LOCKDATELOCAL { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal LOCKED { get; set; }

		[JsonProperty, Column(DbType = "BLOB")]
		public byte[] SESSIONITEMLONG { get; set; }

		[JsonProperty, Column(DbType = "RAW(2000)")]
		public byte[] SESSIONITEMSHORT { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal TIMEOUT { get; set; }

	}

}
