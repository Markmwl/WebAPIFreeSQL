using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_LOCK", DisableSyncStructure = true)]
	public partial class XXLJOBLOCK {

		/// <summary>
		/// 锁名称
		/// </summary>
		[JsonProperty, Column(Name = "LOCK_NAME", StringLength = 50, IsPrimary = true, IsNullable = false)]
		public string LOCKNAME { get; set; }

	}

}
