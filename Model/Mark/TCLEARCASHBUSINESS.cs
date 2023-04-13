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
	/// 现金流类业务表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "T_CLEAR_CASHBUSINESS", DisableSyncStructure = true)]
	public partial class TCLEARCASHBUSINESS {

		/// <summary>
		/// 业务序号(取值于序列号)
		/// </summary>
		[JsonProperty, Column(Name = "L_BUSIN_NO", DbType = "NUMBER(12)", IsPrimary = true)]
		public decimal LBUSINNO { get; set; }

		/// <summary>
		/// 影响开始时点(1-日初;2-日终;若调整为当天，包含0-立即生效值域)
		/// </summary>
		[JsonProperty, Column(Name = "C_BEGIN_POINT", DbType = "VARCHAR2(1 BYTE)")]
		public string CBEGINPOINT { get; set; }

		/// <summary>
		/// O32远期业务是否已处理(0-未处理；1-已处理)
		/// </summary>
		[JsonProperty, Column(Name = "C_DEAL_FLAG_O32", DbType = "VARCHAR2(1 BYTE)")]
		public string CDEALFLAGO32 { get; set; }

		/// <summary>
		/// 到期后影响可用标志(0-不影响，1-影响；默认为0.)
		/// </summary>
		[JsonProperty, Column(Name = "C_ENABLE_FLAG", DbType = "VARCHAR2(1 BYTE)")]
		public string CENABLEFLAG { get; set; } = "0";

		/// <summary>
		/// 影响结束时点(1-日初；2-日终)
		/// </summary>
		[JsonProperty, Column(Name = "C_END_POINT", DbType = "VARCHAR2(1 BYTE)")]
		public string CENDPOINT { get; set; }

		/// <summary>
		/// 操作类型(新增时需填入，1-现金流冻结；2-现金流解冻；3-现金流增加；4-现金流减少)
		/// </summary>
		[JsonProperty, Column(Name = "C_OPERATE_TYPE", DbType = "VARCHAR2(1 BYTE)")]
		public string COPERATETYPE { get; set; }

		/// <summary>
		/// 状态(1-有效；2-已取消)
		/// </summary>
		[JsonProperty, Column(Name = "C_STATUS", DbType = "VARCHAR2(1 BYTE)")]
		public string CSTATUS { get; set; }

		/// <summary>
		/// O32状态(若是否同步调整O32系统为1，2时，需填入)
		/// </summary>
		[JsonProperty, Column(Name = "C_STATUS_O32", DbType = "VARCHAR2(1 BYTE)")]
		public string CSTATUSO32 { get; set; }

		/// <summary>
		/// 是否同步调整O32系统(0-否，1-是，2-仅调整O32系统（保留），缺省为0)
		/// </summary>
		[JsonProperty, Column(Name = "C_SYNC_CHANGE_O32", DbType = "VARCHAR2(1 BYTE)")]
		public string CSYNCCHANGEO32 { get; set; }

		/// <summary>
		/// 取消时间戳(取消时，需填入时分秒)
		/// </summary>
		[JsonProperty, Column(Name = "D_CANCEL_TIME", DbType = "DATE(7)")]
		public DateTime? DCANCELTIME { get; set; }

		/// <summary>
		/// 发生时间戳(新增时，但需填入时分秒)
		/// </summary>
		[JsonProperty, Column(Name = "D_CREATE_TIME", DbType = "DATE(7)")]
		public DateTime? DCREATETIME { get; set; }

		/// <summary>
		/// 发生金额
		/// </summary>
		[JsonProperty, Column(Name = "EN_OCCUR_BALANCE", DbType = "NUMBER(20,4)")]
		public decimal? ENOCCURBALANCE { get; set; }

		/// <summary>
		/// 调整类型(操作类型为1时，1-现金流冻结，2-远期冻结；
		/// 操作类型为2时，1-现金流解冻，2-远期解冻；
		/// 操作类型为3时，101-现金流增加；
		/// 操作类型为4时，102-现金流减少)
		/// </summary>
		[JsonProperty, Column(Name = "L_ADJUST_TYPE")]
		public sbyte? LADJUSTTYPE { get; set; }

		/// <summary>
		/// 资产单元序号(新增时，但需填入)
		/// </summary>
		[JsonProperty, Column(Name = "L_ASSET_ID_O32", DbType = "NUMBER(8)")]
		public decimal? LASSETIDO32 { get; set; }

		/// <summary>
		/// 影响开始日期(冻结解冻默认当日无法修改；远期业务非当日)
		/// </summary>
		[JsonProperty, Column(Name = "L_BEGIN_DATE", DbType = "NUMBER(8)")]
		public decimal? LBEGINDATE { get; set; }

		/// <summary>
		/// O32业务序号(若是否同步调整O32系统为1，2时，需填入)
		/// </summary>
		[JsonProperty, Column(Name = "L_BUSIN_NO_O32", DbType = "NUMBER(12)")]
		public decimal? LBUSINNOO32 { get; set; }

		/// <summary>
		/// 取消人员ID(取消时，需填入)
		/// </summary>
		[JsonProperty, Column(Name = "L_CANCELLER_NO", DbType = "VARCHAR2(50 BYTE)")]
		public string LCANCELLERNO { get; set; }

		/// <summary>
		/// 业务日期
		/// </summary>
		[JsonProperty, Column(Name = "L_DATE", DbType = "NUMBER(8)")]
		public decimal? LDATE { get; set; }

		/// <summary>
		/// 影响结束日期(默认为影响开始日期，需大于等于影响开始日期)
		/// </summary>
		[JsonProperty, Column(Name = "L_END_DATE", DbType = "NUMBER(8)")]
		public decimal? LENDDATE { get; set; }

		/// <summary>
		/// O32基金编号(新增时，但需填入)
		/// </summary>
		[JsonProperty, Column(Name = "L_FUND_ID_O32", DbType = "NUMBER(8)")]
		public decimal? LFUNDIDO32 { get; set; }

		/// <summary>
		/// 操作人员ID(新增时，需填入)
		/// </summary>
		[JsonProperty, Column(Name = "L_OPERATOR_NO", DbType = "VARCHAR2(50 BYTE)")]
		public string LOPERATORNO { get; set; }

		/// <summary>
		/// 资产单元名称
		/// </summary>
		[JsonProperty, Column(Name = "VC_ASSET_NAME", DbType = "VARCHAR2(64 BYTE)")]
		public string VCASSETNAME { get; set; }

		/// <summary>
		/// 资产单元编号
		/// </summary>
		[JsonProperty, Column(Name = "VC_ASSET_NO", DbType = "VARCHAR2(20 BYTE)")]
		public string VCASSETNO { get; set; }

		/// <summary>
		/// 币种(默认带出O32系统资产单元上的币种，带不出，默认为CNY，币种可选)
		/// </summary>
		[JsonProperty, Column(Name = "VC_CURRENCY_NO", DbType = "VARCHAR2(3 BYTE)")]
		public string VCCURRENCYNO { get; set; } = "CNY";

		/// <summary>
		/// 基金代码
		/// </summary>
		[JsonProperty, Column(Name = "VC_FUND_CODE", DbType = "VARCHAR2(16 BYTE)")]
		public string VCFUNDCODE { get; set; }

		/// <summary>
		/// 基金名称
		/// </summary>
		[JsonProperty, Column(Name = "VC_FUND_NAME", DbType = "VARCHAR2(32 BYTE)")]
		public string VCFUNDNAME { get; set; }

		/// <summary>
		/// 影响范围(-1-全部；1-远期现金流；2-头寸管理；3-现金比例；缺省-1。可多选，按照1,2,3拼接填入)
		/// </summary>
		[JsonProperty, Column(Name = "VC_IMPACT_AREA", DbType = "VARCHAR2(40 BYTE)")]
		public string VCIMPACTAREA { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(Name = "VC_REMARKS", DbType = "VARCHAR2(100 BYTE)")]
		public string VCREMARKS { get; set; }

		/// <summary>
		/// UFX状态(若是否同步调整O32系统为1，2时，需填入)
		/// </summary>
		[JsonProperty, Column(Name = "VC_UFX_STATUS", DbType = "VARCHAR2(20 BYTE)")]
		public string VCUFXSTATUS { get; set; }

	}

}
