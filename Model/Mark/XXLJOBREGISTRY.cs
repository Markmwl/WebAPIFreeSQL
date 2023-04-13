using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_REGISTRY", DisableSyncStructure = true)]
	public partial class XXLJOBREGISTRY {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		[JsonProperty, Column(Name = "REGISTRY_GROUP", StringLength = 50, IsNullable = false)]
		public string REGISTRYGROUP { get; set; }

		[JsonProperty, Column(Name = "REGISTRY_KEY", StringLength = 255, IsNullable = false)]
		public string REGISTRYKEY { get; set; }

		[JsonProperty, Column(Name = "REGISTRY_VALUE", StringLength = 255, IsNullable = false)]
		public string REGISTRYVALUE { get; set; }

		[JsonProperty, Column(Name = "UPDATE_TIME", DbType = "DATE(7)")]
		public DateTime? UPDATETIME { get; set; }

	}

}
