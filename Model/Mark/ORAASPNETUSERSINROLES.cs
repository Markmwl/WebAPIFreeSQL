using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_USERSINROLES", DisableSyncStructure = true)]
	public partial class ORAASPNETUSERSINROLES {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] ROLEID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] USERID { get; set; }

	}

}
