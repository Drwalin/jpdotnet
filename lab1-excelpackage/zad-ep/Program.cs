// See https://aka.ms/new-console-template for more information

using System.Drawing;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.ThreadedComments;
using zad_ep;

string argumentPath = "../../..";
int arumentDepth = 3;

List<FileInfo> sta = new List<FileInfo>();

void PrintFile(ExcelWorksheet ws, int x, int y, FileInfo file)
{
	ws.Cells[y, x+0].Value = file.Name;
	ws.Cells[y, x+1].Value = file.Extension;
	ws.Cells[y, x+2].Value = file.Length;
	ws.Cells[y, x+3].Value = file.Attributes;
}

int PrintDirectories(ExcelWorksheet ws, int x, int y, int depth, DirectoryInfo dir)
{
	ws.Row(y).OutlineLevel = arumentDepth + 1 - depth;
	ws.Cells[y, x].Value = dir.Name;
	y++;

	if (depth > 0)
	{
		foreach (var d in dir.GetDirectories())
		{
			y = PrintDirectories(ws, x, y, depth - 1, d);
		}
	}

	foreach (var f in dir.GetFiles())
	{
		sta.Add(f);
		PrintFile(ws, x, y, f);
		ws.Row(y).OutlineLevel = arumentDepth + 2 - depth;
		y++;
	}

	return y;
}

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
FileInfo excelFile = new FileInfo("..\\..\\..\\lab.xlsx");
excelFile.Delete();
using (var ep = new ExcelPackage(excelFile)) {
	ep.Workbook.Properties.Title = "Tytuł";
	ep.Workbook.Properties.Author = "Autor";
	ep.Workbook.Properties.Comments = "Komentarz";
	ep.Workbook.Properties.Company = "Firma";
	ep.Workbook.Properties.SetCustomPropertyValue("Klucz", "Wartość");

	ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Struktura katalogu");

	PrintDirectories(ws, 1, 1, arumentDepth, new DirectoryInfo(argumentPath));

	ws.Cells.AutoFitColumns(0);
	
	sta.Sort(new FileStat.SorterBySize());

	ExcelWorksheet ws2 = ep.Workbook.Worksheets.Add("Statystyki");
	for (int i = 0; i < 10 && i < sta.Count; ++i)
	{
		PrintFile(ws2, 1, i+1, sta[i]);
	}

		Dictionary<string, long> sizes = new Dictionary<string, long>();
		Dictionary<string, long> counts = new Dictionary<string, long>();

		foreach (var e in sta)
		{
			if(sizes.TryAdd(e.Extension, 1) == false)
				sizes[e.Extension] += e.Length;
			if(counts.TryAdd(e.Extension, 1) == false)
				counts[e.Extension] += 1;
		}

		int j = 1;
		foreach (var it in sizes)
		{
			ws2.Cells[j, 6].Value = it.Key;
			ws2.Cells[j, 7].Value = it.Value;
			j++;
		}
		
		j = 1;
		foreach (var it in counts)
		{
			ws2.Cells[j, 8].Value = it.Key;
			ws2.Cells[j, 9].Value = it.Value;
			j++;
		}
	
	{
		var chart = ws2.Drawings.AddChart("PieChart", eChartType.Pie3D) as ExcelPieChart;
		chart.Title.Text = "% rozszerzeń ilościowo";
		
		chart.SetPosition(1, 5, 5, 5);
		chart.SetSize(600, 300);
		
		ExcelAddress valAdd = new ExcelAddress(1, 8, counts.Count, 8);
		ExcelAddress valAdd2 = new ExcelAddress(1, 9, counts.Count, 9);
		var ser = (chart.Series.Add(valAdd2.Address, valAdd.Address) as ExcelPieChartSerie);
		
		chart.DataLabel.ShowCategory = true;
		chart.DataLabel.ShowPercent = true;
		chart.Legend.Border.LineStyle = eLineStyle.Solid;
		chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
		chart.Legend.Border.Fill.Color = Color.DarkBlue;
	}
	
	{
		var chart = ws2.Drawings.AddChart("PieChart2", eChartType.Pie3D) as ExcelPieChart;
		chart.Title.Text = "% rozszerzeń objętością";
		
		chart.SetPosition(17, 5, 5, 5);
		chart.SetSize(600, 300);
		
		ExcelAddress valAdd = new ExcelAddress(1, 6, counts.Count, 6);
		ExcelAddress valAdd2 = new ExcelAddress(1, 7, counts.Count, 7);
		var ser = (chart.Series.Add(valAdd2.Address, valAdd.Address) as ExcelPieChartSerie);
		
		chart.DataLabel.ShowCategory = true;
		chart.DataLabel.ShowPercent = true;
		chart.Legend.Border.LineStyle = eLineStyle.Solid;
		chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
		chart.Legend.Border.Fill.Color = Color.DarkBlue;
	}
	
	ep.Save();
}

