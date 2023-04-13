using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_LOG_REPORT", DisableSyncStructure = true)]
	public partial class XXLJOBLOGREPORT {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		/// <summary>
		/// 执行失败-日志数量
		/// </summary>
		[JsonProperty, Column(Name = "FAIL_COUNT")]
		public int FAILCOUNT { get; set; }

		/// <summary>
		/// 运行中-日志数量
		/// </summary>
		[JsonProperty, Column(Name = "RUNNING_COUNT")]
		public int RUNNINGCOUNT { get; set; }

		/// <summary>
		/// 执行成功-日志数量
		/// </summary>
		[JsonProperty, Column(Name = "SUC_COUNT")]
		public int SUCCOUNT { get; set; }

		/// <summary>
		/// 调度-时间
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_DAY", DbType = "DATE(7)")]
		public DateTime? TRIGGERDAY { get; set; }

	}

}
