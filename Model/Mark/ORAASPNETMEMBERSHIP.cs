using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_MEMBERSHIP", DisableSyncStructure = true)]
	public partial class ORAASPNETMEMBERSHIP {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] USERID { get; set; }

		[JsonProperty, Column(DbType = "RAW(16)")]
		public byte[] APPLICATIONID { get; set; }

		[JsonProperty, Column(StringLength = -2)]
		public string COMMENTS { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime CREATEDATE { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string EMAIL { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal FAILEDPWDANSWERATTEMPTCOUNT { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime FAILEDPWDANSWERATTEMPTWINSTART { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal FAILEDPWDATTEMPTCOUNT { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime FAILEDPWDATTEMPTWINSTART { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal ISAPPROVED { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal ISLOCKEDOUT { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTLOCKOUTDATE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTLOGINDATE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime LASTPASSWORDCHANGEDDATE { get; set; }

		[JsonProperty, Column(StringLength = 256)]
		public string LOWEREDEMAIL { get; set; }

		[JsonProperty, Column(StringLength = 16)]
		public string MOBILEPIN { get; set; }

		[JsonProperty, Column(StringLength = 128, IsNullable = false)]
		public string PASSWORD { get; set; }

		[JsonProperty, Column(StringLength = 128)]
		public string PASSWORDANSWER { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal PASSWORDFORMAT { get; set; } = 0M;

		[JsonProperty, Column(StringLength = 256)]
		public string PASSWORDQUESTION { get; set; }

		[JsonProperty, Column(StringLength = 128, IsNullable = false)]
		public string PASSWORDSALT { get; set; }

	}

}
