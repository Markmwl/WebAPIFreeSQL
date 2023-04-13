using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(DisableSyncStructure = true)]
	public partial class XXLUSER {

		[JsonProperty, Column(StringLength = 20, IsPrimary = true, IsNullable = false)]
		public string ID { get; set; }

		[JsonProperty, Column(StringLength = 50)]
		public string ADDRESS { get; set; }

		[JsonProperty, Column(StringLength = 3)]
		public string AGE { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime? CURRENTDATE { get; set; }

		[JsonProperty, Column(StringLength = 20)]
		public string NAME { get; set; }

		[JsonProperty, Column(StringLength = 15)]
		public string PHONENUMBER { get; set; }

		[JsonProperty, Column(StringLength = 2)]
		public string SEX { get; set; }

	}

}
