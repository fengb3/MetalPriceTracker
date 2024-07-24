using System.ComponentModel.DataAnnotations;

namespace Lib;

public record MetalMetadata
{
    /// <summary>
    /// 产品代码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 时间
    /// </summary>
    [Key]
    public long Time { get; set; }

    public double Q64  { get; set; }
    public double Q193 { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    public double Q1 { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    public double Q2 { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    public double Q3 { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    public double Q4 { get; set; }

    /// <summary>
    /// 买入价
    /// </summary>
    public double Q5 { get; set; }

    /// <summary>
    /// 卖出价
    /// </summary>
    public double Q6 { get; set; }

    /// <summary>
    /// 百分比跌幅
    /// </summary>
    public double Q70 { get; set; }

    public double Q7  { get; set; }
    public double Q8  { get; set; }
    public double Q9  { get; set; }
    public double Q10 { get; set; }
    public double Q11 { get; set; }
    public double Q12 { get; set; }
    public double Q13 { get; set; }
    public double Q14 { get; set; }
    public double Q15 { get; set; }
    public double Q16 { get; set; }

    /// <summary>
    /// 涨跌幅
    /// </summary>
    public double Q80 { get; set; }

    public double Q17 { get; set; }
    public double Q18 { get; set; }
    public double Q19 { get; set; }
    public double Q20 { get; set; }
    public double Q21 { get; set; }
    public double Q22 { get; set; }
    public double Q23 { get; set; }
    public double Q24 { get; set; }
    public double Q60 { get; set; }
    public double Q61 { get; set; }
    public double Q62 { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public double Q63 { get; set; }

    /// <summary>
    /// 单位
    /// </summary>
    public string? Unit { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string? ShowName { get; set; }

    /// <summary>
    /// 代码
    /// </summary>
    public string? ShowCode { get; set; }

    public int Digits { get; set; }
    public int Status { get; set; }
}