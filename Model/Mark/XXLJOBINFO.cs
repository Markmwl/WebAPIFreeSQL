using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "XXL_JOB_INFO", DisableSyncStructure = true)]
	public partial class XXLJOBINFO {

		[JsonProperty, Column(IsPrimary = true)]
		public int ID { get; set; }

		[JsonProperty, Column(Name = "ADD_TIME", DbType = "DATE(7)")]
		public DateTime? ADDTIME { get; set; }

		/// <summary>
		/// 报警邮件
		/// </summary>
		[JsonProperty, Column(Name = "ALARM_EMAIL", StringLength = 255)]
		public string ALARMEMAIL { get; set; }

		/// <summary>
		/// 作者
		/// </summary>
		[JsonProperty, Column(StringLength = 64)]
		public string AUTHOR { get; set; }

		/// <summary>
		/// 子任务ID，多个逗号分隔
		/// </summary>
		[JsonProperty, Column(Name = "CHILD_JOBID", StringLength = 255)]
		public string CHILDJOBID { get; set; }

		/// <summary>
		/// 阻塞处理策略
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_BLOCK_STRATEGY", StringLength = 50)]
		public string EXECUTORBLOCKSTRATEGY { get; set; }

		/// <summary>
		/// 失败重试次数
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_FAIL_RETRY_COUNT")]
		public int EXECUTORFAILRETRYCOUNT { get; set; }

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
		/// 执行器路由策略
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_ROUTE_STRATEGY", StringLength = 50)]
		public string EXECUTORROUTESTRATEGY { get; set; }

		/// <summary>
		/// 任务执行超时时间，单位秒
		/// </summary>
		[JsonProperty, Column(Name = "EXECUTOR_TIMEOUT")]
		public int EXECUTORTIMEOUT { get; set; }

		/// <summary>
		/// GLUE备注
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_REMARK", StringLength = 128)]
		public string GLUEREMARK { get; set; }

		/// <summary>
		/// GLUE源代码
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_SOURCE", StringLength = -2)]
		public string GLUESOURCE { get; set; }

		/// <summary>
		/// GLUE类型
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_TYPE", StringLength = 50, IsNullable = false)]
		public string GLUETYPE { get; set; }

		/// <summary>
		/// GLUE更新时间
		/// </summary>
		[JsonProperty, Column(Name = "GLUE_UPDATETIME", DbType = "DATE(7)")]
		public DateTime? GLUEUPDATETIME { get; set; }

		/// <summary>
		/// 任务执行CRON
		/// </summary>
		[JsonProperty, Column(Name = "JOB_CRON", StringLength = 128, IsNullable = false)]
		public string JOBCRON { get; set; }

		[JsonProperty, Column(Name = "JOB_DESC", StringLength = 255, IsNullable = false)]
		public string JOBDESC { get; set; }

		/// <summary>
		/// 执行器主键ID
		/// </summary>
		[JsonProperty, Column(Name = "JOB_GROUP")]
		public int JOBGROUP { get; set; }

		/// <summary>
		/// 上次调度时间
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_LAST_TIME")]
		public ulong TRIGGERLASTTIME { get; set; }

		/// <summary>
		/// 下次调度时间
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_NEXT_TIME")]
		public ulong TRIGGERNEXTTIME { get; set; }

		/// <summary>
		/// 调度状态：0-停止，1-运行
		/// </summary>
		[JsonProperty, Column(Name = "TRIGGER_STATUS")]
		public sbyte TRIGGERSTATUS { get; set; }

		[JsonProperty, Column(Name = "UPDATE_TIME", DbType = "DATE(7)")]
		public DateTime? UPDATETIME { get; set; }

	}

}
