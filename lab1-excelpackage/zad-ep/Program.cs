// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.ThreadedComments;
using zad_ep;

string argumentPath = "../../..";
int arumentDepth = 3;

List<FileStat> sta = new List<FileStat>();

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
		string path = dir.ToString() + "/" + f.Name;
		sta.Add(new FileStat(){namePath=path, size=f.Length});
		ws.Cells[y, x+0].Value = f.Name;
		ws.Cells[y, x+1].Value = f.Extension;
		ws.Cells[y, x+2].Value = f.Length;
		ws.Cells[y, x+3].Value = f.Attributes;
		ws.Row(y).OutlineLevel = arumentDepth + 2 - depth;
		y++;
	}

	return y;
}

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
new FileInfo(@"C:\\studies\\jpdotnet\\lab\\lab1-excelpackage\\zad-ep\\lab.xlsx").Delete();
using (var ep = new ExcelPackage(new FileInfo(@"C:\\studies\\jpdotnet\\lab\\lab1-excelpackage\\zad-ep\\lab.xlsx"))) {
//using (var ep = new ExcelPackage(new FileInfo(@"C:\\lab.xlsx"))) {
	ep.Workbook.Properties.Title = "Tytuł";
	ep.Workbook.Properties.Author = "Autor";
	ep.Workbook.Properties.Comments = "Komentarz";
	ep.Workbook.Properties.Company = "Firma";
	ep.Workbook.Properties.SetCustomPropertyValue("Klucz", "Wartość");

	ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Struktura katalogu");

	PrintDirectories(ws, 1, 1, arumentDepth, new DirectoryInfo(argumentPath));

	ws.Cells.AutoFitColumns(0);
	
	sta.Sort();
	
	
	
	
	ep.Save();
	

}

