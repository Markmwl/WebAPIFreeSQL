using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_SYSUSER", DisableSyncStructure = true)]
	public partial class TSYSUSER {

		[JsonProperty, Column(DbType = "NUMBER(8)", IsPrimary = true)]
		public decimal ID { get; set; }

		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string NAME { get; set; }

		[JsonProperty, Column(StringLength = 50, IsNullable = false)]
		public string PASSWORD { get; set; }

	}

}
