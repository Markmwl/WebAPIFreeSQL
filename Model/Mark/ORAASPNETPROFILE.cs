using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_PROFILE", DisableSyncStructure = true)]
	public partial class ORAASPNETPROFILE {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] USERID { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTUPDATEDDATE { get; set; }

		[JsonProperty, Column(StringLength = -2, IsNullable = false)]
		public string PROPERTYNAMES { get; set; }

		[JsonProperty, Column(DbType = "BLOB")]
		public byte[] PROPERTYVALUESBINARY { get; set; }

		[JsonProperty, Column(StringLength = -2, IsNullable = false)]
		public string PROPERTYVALUESSTRING { get; set; }

	}

}
