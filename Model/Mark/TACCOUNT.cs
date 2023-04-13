using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_ACCOUNT", DisableSyncStructure = true)]
	public partial class TACCOUNT {

		[JsonProperty, Column(DbType = "NUMBER(22)", IsPrimary = true)]
		public decimal ID { get; set; }

		[JsonProperty, Column(StringLength = 50, IsPrimary = true, IsNullable = false)]
		public string NAME { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal? MONEY { get; set; } = 100M;

	}

}
