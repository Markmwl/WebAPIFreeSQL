using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_CDC_DEMO", DisableSyncStructure = true)]
	public partial class TCDCDEMO {

		[JsonProperty, Column(Name = "L_ID", DbType = "NUMBER(22)", IsPrimary = true)]
		public decimal LID { get; set; }

		[JsonProperty, Column(Name = "D_DATE", DbType = "DATE(7)")]
		public DateTime DDATE { get; set; }

		[JsonProperty, Column(Name = "VC_CONTENT", DbType = "VARCHAR2(50 BYTE)")]
		public string VCCONTENT { get; set; }

		[JsonProperty, Column(Name = "VC_DESC", DbType = "VARCHAR2(50 BYTE)")]
		public string VCDESC { get; set; }

	}

}
