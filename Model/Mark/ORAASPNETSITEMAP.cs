using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "ORA_ASPNET_SITEMAP", DisableSyncStructure = true)]
	public partial class ORAASPNETSITEMAP {

		[JsonProperty, Column(DbType = "RAW(16)", IsPrimary = true)]
		public byte[] APPLICATIONID { get; set; }

		[JsonProperty, Column(IsPrimary = true)]
		public uint ID { get; set; }

		[JsonProperty, Column(StringLength = 512)]
		public string DESCRIPTION { get; set; }

		[JsonProperty]
		public uint? PARENT { get; set; }

		[JsonProperty, Column(StringLength = 512)]
		public string ROLES { get; set; }

		[JsonProperty, Column(StringLength = 32)]
		public string TITLE { get; set; }

		[JsonProperty, Column(StringLength = 512)]
		public string URL { get; set; }

	}

}
