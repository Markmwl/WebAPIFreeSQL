using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_PERSONALIZNALLUSERS", DisableSyncStructure = true)]
	public partial class ORAASPNETPERSONALIZNALLUSERS {

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] PATHID { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTUPDATEDDATE { get; set; }

		[JsonProperty, Column(DbType = "BLOB")]
		public byte[] PAGESETTINGS { get; set; }

	}

}
