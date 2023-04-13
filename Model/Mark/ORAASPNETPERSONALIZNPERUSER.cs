using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_PERSONALIZNPERUSER", DisableSyncStructure = true)]
	public partial class ORAASPNETPERSONALIZNPERUSER {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true, InsertValueSql = "SYS_GUID()")]
		public byte[] ID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] PATHID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] USERID { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTUPDATEDDATE { get; set; }

		[JsonProperty, Column(DbType = "BLOB")]
		public byte[] PAGESETTINGS { get; set; }

	}

}
