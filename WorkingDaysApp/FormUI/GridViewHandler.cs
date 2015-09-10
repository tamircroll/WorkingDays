using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;
using WorkingDaysApp.Logic;

namespace TimeWatchApp.FormUI
{
    public static class GridViewHandler
    {
        public static void SetGridHeight(DataGridView i_MonthGridView)
        {
            int totalRowHeight = i_MonthGridView.ColumnHeadersHeight;

            foreach (DataGridViewRow row in i_MonthGridView.Rows) totalRowHeight += row.Height;

            i_MonthGridView.Height = totalRowHeight + 2;
        }

        public static void setCell(int i_Column, DataGridViewRow i_NewRow, IList<string> i_DayArr)
        {
            if (i_Column == (int)eColumn.TotalTime)
            {
                setTotalTimeCell(i_Column, i_NewRow);
            }
            else
            {
                i_NewRow.Cells[i_Column].Value = i_DayArr[i_Column].Replace(TimeWatch.sr_DashReplacer,
                    TimeWatch.sr_RowSeparator.ToString());
            }

            if (i_Column == (int)eColumn.DayType)
            {
                string cellData = (string)i_NewRow.Cells[i_Column].Value;
                i_NewRow.Cells[i_Column].Style.BackColor = setDayTypeCell(cellData);
            }
        }

        public static Color setDayTypeCell(string cellData)
        {
            if (cellData == DayTypeFactory.Get(eDayType.Holiday)) return Color.DeepSkyBlue;
            if (cellData == DayTypeFactory.Get(eDayType.HalfDay)) return Color.CornflowerBlue;
            return Form.DefaultBackColor;
        }

        public static void setTotalTimeCell(int i_Column, DataGridViewRow i_NewRow)
        {
            i_NewRow.Cells[i_Column].Value = TimeHandler.calcTime(
                (string)i_NewRow.Cells[(int)eColumn.Arrival].Value,
                (string)i_NewRow.Cells[(int)eColumn.Leaving].Value);
            i_NewRow.Cells[i_Column].Style.BackColor = ((string)i_NewRow.Cells[i_Column].Value).StartsWith("-")
                ? Color.LightCoral
                : Form.DefaultBackColor;
        }

    }
}