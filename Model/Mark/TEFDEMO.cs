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
	/// EF测试
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_EF_DEMO", DisableSyncStructure = true)]
	public partial class TEFDEMO {

		[JsonProperty, Column(DbType = "VARCHAR2(20 BYTE)", IsPrimary = true, IsNullable = false)]
		public string ID { get; set; }

		[JsonProperty, Column(DbType = "NUMBER(22)")]
		public decimal AGE { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(30 BYTE)")]
		public string DEPT { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(30 BYTE)")]
		public string EMAIL { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(30 BYTE)")]
		public string HOBBLY { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(30 BYTE)", IsNullable = false)]
		public string NAME { get; set; }

		/// <summary>
		/// 电话号码
		/// </summary>
		[JsonProperty, Column(DbType = "VARCHAR2(20 BYTE)")]
		public string PHONE { get; set; }

		[JsonProperty, Column(DbType = "VARCHAR2(2 BYTE)", IsNullable = false)]
		public string SEX { get; set; }

		[JsonProperty, Column(DbType = "CLOB")]
		public string TEXT { get; set; }

		/// <summary>
		/// 使用FreeSQL CodeFirst 生成
		/// </summary>
		[JsonProperty, Column(DbType = "CLOB")]
		public string TEXTADDIO { get; set; }

		[JsonProperty, Column(DbType = "DATE(7)")]
		public DateTime TIME { get; set; }

	}

}
