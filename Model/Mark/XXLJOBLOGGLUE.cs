using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_LOGGLUE", DisableSyncStructure = true)]
	public partial class XXLJOBLOGGLUE {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		[JsonProperty, Column(Name = "ADD_TIME", DbType = "DATE(7)")]
		public DateTime? ADDTIME { get; set; }

		/// <summary>
		/// GLUE备注
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_REMARK", StringLength = 128, IsNullable = false)]
		public string GLUEREMARK { get; set; }

		/// <summary>
		/// GLUE源代码
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_SOURCE", StringLength = -2)]
		public string GLUESOURCE { get; set; }

		/// <summary>
		/// GLUE类型
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_TYPE", StringLength = 50)]
		public string GLUETYPE { get; set; }

		/// <summary>
		/// 任务，主键ID
		/// </summary>
		[JsonProperty, Column(Name = "JOB_ID")]
		public int JOBID { get; set; }

		[JsonProperty, Column(Name = "UPDATE_TIME", DbType = "DATE(7)")]
		public DateTime? UPDATETIME { get; set; }

	}

}
