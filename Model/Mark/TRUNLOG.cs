using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Model.Mark {

	/// <summary>
	/// 日志表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_RUNLOG", DisableSyncStructure = true)]
	public partial class TRUNLOG {

		/// <summary>
		/// ID主键
		/// </summary>
		[JsonProperty, Column(Name = "L_ID", DbType = "NUMBER(19)", IsPrimary = true)]
		public decimal LID { get; set; }

		/// <summary>
		/// 日志内容(超长)
		/// </summary>
		[JsonProperty, Column(Name = "CL_CLOB", DbType = "CLOB")]
		public string CLCLOB { get; set; }

		/// <summary>
		/// 日期
		/// </summary>
		[JsonProperty, Column(Name = "D_DATE", DbType = "DATE(7)")]
		public DateTime DDATE { get; set; }

		/// <summary>
		/// 预留字段
		/// </summary>
		[JsonProperty, Column(Name = "L_JOBID", DbType = "NUMBER(19)")]
		public decimal? LJOBID { get; set; }

		/// <summary>
		/// 预留字段
		/// </summary>
		[JsonProperty, Column(Name = "L_MULTIJOBID", DbType = "NUMBER(19)")]
		public decimal? LMULTIJOBID { get; set; }

		/// <summary>
		/// 日志内容
		/// </summary>
		[JsonProperty, Column(Name = "VC_CONTENT", DbType = "VARCHAR2(4000 BYTE)")]
		public string VCCONTENT { get; set; }

		/// <summary>
		/// 日志级别；INFO,DEBUG,WARN,ERROR,FATAL
		/// </summary>
		[JsonProperty, Column(Name = "VC_LEVEL", DbType = "VARCHAR2(20 BYTE)")]
		public string VCLEVEL { get; set; } = "INFO";

		/// <summary>
		/// 日志类别
		/// </summary>
		[JsonProperty, Column(Name = "VC_LOGTYPE", DbType = "VARCHAR2(200 BYTE)", IsNullable = false)]
		public string VCLOGTYPE { get; set; }

	}

}
