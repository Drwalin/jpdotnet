using OfficeOpenXml.Drawing.Chart.ChartEx;

namespace zad_ep;

public class FileStat
{
	public class SorterBySize : IComparer<FileInfo>
	{
		public int Compare(FileInfo? x, FileInfo? y)
		{
			return (int)Math.Clamp(y.Length - x.Length, -1, 1);
		}
	}
}