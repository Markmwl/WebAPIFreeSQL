using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_LOG", DisableSyncStructure = true)]
	public partial class XXLJOBLOG {

		[JsonProperty, Column(IsPrimary = true)]
		public ulong ID { get; set; }

		/// <summary>
		/// 告警状态：0-默认、1-无需告警、2-告警成功、3-告警失败
		/// </summary>
		[JsonProperty, Column(Name = "ALARM_STATUS")]
		public sbyte ALARMSTATUS { get; set; } = 0;

		/// <summary>
		/// 执行器地址，本次执行的地址
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_ADDRESS", StringLength = 255)]
		public string EXECUTORADDRESS { get; set; }

		/// <summary>
		/// 失败重试次数
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_FAIL_RETRY_COUNT")]
		public int EXECUTORFAILRETRYCOUNT { get; set; } = 0;

		/// <summary>
		/// 执行器任务handler
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_HANDLER", StringLength = 255)]
		public string EXECUTORHANDLER { get; set; }

		/// <summary>
		/// 执行器任务参数
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_PARAM", StringLength = 512)]
		public string EXECUTORPARAM { get; set; }

		/// <summary>
		/// 执行器任务分片参数，格式如 1/2
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_SHARDING_PARAM", StringLength = 20)]
		public string EXECUTORSHARDINGPARAM { get; set; }

		/// <summary>
		/// 执行-状态
		/// </summary>
		[JsonProperty, Column(Name = "HANDLE_CODE")]
		public int HANDLECODE { get; set; }

		/// <summary>
		/// 执行-日志
		/// </summary>
		[JsonProperty, Column(Name = "HANDLE_MSG", StringLength = -2)]
		public string HANDLEMSG { get; set; }

		/// <summary>
		/// 执行-时间
		/// </summary>
		[JsonProperty, Column(Name = "HANDLE_TIME", DbType = "DATE(7)")]
		public DateTime? HANDLETIME { get; set; }

		/// <summary>
		/// 执行器主键ID
		/// </summary>
		[JsonProperty, Column(Name = "JOB_GROUP")]
		public int JOBGROUP { get; set; }

		/// <summary>
		/// 任务，主键ID
		/// </summary>
		[JsonProperty, Column(Name = "JOB_ID")]
		public int JOBID { get; set; }

		/// <summary>
		/// 调度-结果
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_CODE")]
		public int TRIGGERCODE { get; set; }

		/// <summary>
		/// 调度-日志
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_MSG", StringLength = -2)]
		public string TRIGGERMSG { get; set; }

		/// <summary>
		/// 调度-时间
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_TIME", DbType = "DATE(7)")]
		public DateTime? TRIGGERTIME { get; set; }

	}

}
