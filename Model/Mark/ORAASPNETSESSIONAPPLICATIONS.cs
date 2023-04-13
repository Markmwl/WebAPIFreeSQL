using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_SESSIONAPPLICATIONS", DisableSyncStructure = true)]
	public partial class ORAASPNETSESSIONAPPLICATIONS {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] APPID { get; set; }

		[JsonProperty, Column(StringLength = 280, IsNullable = false)]
		public string APPNAME { get; set; }

	}

}
