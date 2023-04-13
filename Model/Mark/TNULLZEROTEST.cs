using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_NULLZERO_TEST", DisableSyncStructure = true)]
	public partial class TNULLZEROTEST {

		[JsonProperty, Column(DbType = "NUMBER(22)", IsPrimary = true)]
		public decimal ID { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(100 BYTE)")]
		public string ADDRESS { get; set; }

		[JsonProperty]
		public byte? AGE { get; set; }

		[JsonProperty]
		public sbyte? COUNT { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(64 BYTE)")]
		public string NAME { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(5 BYTE)")]
		public string SEX { get; set; }

	}

}
