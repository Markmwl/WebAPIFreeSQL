using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_WEBEVENTS", DisableSyncStructure = true)]
	public partial class ORAASPNETWEBEVENTS {

		[JsonProperty, Column(StringLength = 256)]
		public string APPLICATIONPATH { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string APPLICATIONVIRTUALPATH { get; set; }

		[JsonProperty, Column(StringLength = -2)]
		public string DETAILS { get; set; }

		[JsonProperty]
		public uint? EVENTCODE { get; set; }

		[JsonProperty]
		public uint? EVENTDETAILCODE { get; set; }

		[JsonProperty, Column(DbType = "CHAR(32 BYTE)")]
		public string EVENTID { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(19)")]
		public decimal? EVENTOCCURENCE { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(19)")]
		public decimal? EVENTSEQUENCE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime? EVENTTIME { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime? EVENTTIMEUTC { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string EVENTTYPE { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string EXCEPTIONTYPE { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string MACHINENAME { get; set; }

		[JsonProperty, Column(StringLength = 1000)]
		public string MESSAGE { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string REQUESTURL { get; set; }

	}

}
