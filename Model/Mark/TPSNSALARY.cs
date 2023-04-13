using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_PSNSALARY", DisableSyncStructure = true)]
	public partial class TPSNSALARY {

		[JsonProperty, Column(DbType = "VARCHAR2(20 BYTE)")]
		public string FPSNBIRTH { get; set; } = "";

		[JsonProperty, Column(DbType = "VARCHAR2(4 BYTE)")]
		public string FPSNCODE { get; set; } = "";

		[JsonProperty, Column(DbType = "VARCHAR2(20 BYTE)")]
		public string FPSNDESC { get; set; } = "";

		[JsonProperty, Column(DbType = "NUMBER(8,2)")]
		public decimal? FPSNSALARY { get; set; }

	}

}
