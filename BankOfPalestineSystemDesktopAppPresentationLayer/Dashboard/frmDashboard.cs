using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace BankOfPalestineSystemDesktopAppPresentationLayer.Dashboard
{
    public partial class frmDashboard : Form
    {
       

        private Color GetColorByCurrency(string codeCurrency)
        {
            switch (codeCurrency)
            {
                case "PSP":
                    return Color.Navy;
                case "USD":
                    return Color.GreenYellow;
                case "JOD":
                    return Color.Red;
                case "EUR":
                    return Color.DarkOrange;
                default:
                    return Color.Black;
            }
        }

        private void SetupDepositWithdrawalChart()
        {
            columnChart.Series.Clear();
            columnChart.ChartAreas.Clear();
            columnChart.Titles.Clear();
            columnChart.Legends.Clear();

            ChartArea chartArea1 = new ChartArea("MainChartArea");
            columnChart.ChartAreas.Add(chartArea1);

            Series depositSeries = new Series("إجمالي الإيداعات");
            depositSeries.ChartType = SeriesChartType.Column;
            depositSeries.Color = System.Drawing.Color.Green;
            depositSeries.IsValueShownAsLabel = true;
            depositSeries.LabelFormat = "{0:N0}";

            Series withdrawalSeries = new Series("إجمالي السحوبات");
            withdrawalSeries.ChartType = SeriesChartType.Column;
            withdrawalSeries.Color = System.Drawing.Color.Red;
            withdrawalSeries.IsValueShownAsLabel = true;
            withdrawalSeries.LabelFormat = "{0:N0}";

            for (int i = 1; i <= DateTime.Now.Month; i++)
            {

                DateTime fromDate = new DateTime(DateTime.Now.Year, i, 01);
                DateTime toDate = new DateTime(DateTime.Now.Year, i, 28);

                decimal totalDeposit = clsTransaction.GetTotalBalancesAccordingToPSPCurrency(1008,
                    clsTransaction.enStatus.Completed, fromDate, toDate);

                decimal totalWithdrawal = clsTransaction.GetTotalBalancesAccordingToPSPCurrency(1009,
                  clsTransaction.enStatus.Completed, fromDate, toDate);

                depositSeries.Points.AddXY(clsGlobal.GetMonthName(i), totalDeposit);
                withdrawalSeries.Points.AddXY(clsGlobal.GetMonthName(i), totalWithdrawal);
            }

            columnChart.Series.Add(depositSeries);
            columnChart.Series.Add(withdrawalSeries);

            columnChart.Titles.Add("مقارنة الإيداعات والسحوبات الشهرية");
            columnChart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

            columnChart.Legends.Add(new Legend("DefaultLegend"));
            columnChart.Legends["DefaultLegend"].Docking = Docking.Bottom; // وضع وسيلة الإيضاح في الأسفل
            columnChart.Legends["DefaultLegend"].Alignment = StringAlignment.Center; // توسيط وسيلة الإيضاح
            columnChart.Legends["DefaultLegend"].Font = new Font("Segoe UI", 9, FontStyle.Bold); // توسيط وسيلة الإيضاح

            chartArea1.AxisX.Title = "الشهر";
            chartArea1.AxisX.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            chartArea1.AxisX.MajorGrid.Enabled = false; // إخفاء خطوط الشبكة العمودية

            chartArea1.AxisY.Title = "المبلغ";
            chartArea1.AxisY.Minimum = 0;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);

            columnChart.Series["إجمالي الإيداعات"]["PointWidth"] = "0.7";
            columnChart.Series["إجمالي السحوبات"]["PointWidth"] = "0.7";

            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.ScaleView.Zoomable = false;
        }

        private void SetupPieChart()
        {
            balancesPieChart.Visible = true;


            balancesPieChart.Series.Clear();
            balancesPieChart.ChartAreas.Clear();
            balancesPieChart.Titles.Clear();
            balancesPieChart.Legends.Clear();


            ChartArea chartArea1 = new ChartArea("PieChartArea");
            balancesPieChart.ChartAreas.Add(chartArea1);


            Series pieSeries = new Series("BalancesByCurrency");
            pieSeries.ChartType = SeriesChartType.Pie; // تعيين نوع المخطط إلى دائري

            // 3. إضافة نقاط البيانات (الشرائح)
            //pieSeries.Points.AddXY("USD", 3000); // قيمة الإيجار
            //pieSeries.Points.AddXY("PSP", 2000);  // قيمة الطعام
            //pieSeries.Points.AddXY("JOD", 1000); // قيمة المواصلات
            //pieSeries.Points.AddXY("ERP", 500);   // قيمة الترفيه

            // DataPoint dataPoint = new DataPoint();
            //dataPoint.SetValueY(50000);
            //dataPoint.AxisLabel = "PSP";
            //dataPoint.Color = Color.Green;
            //pieSeries.Points.Add(dataPoint);

            DataTable dtCurrencies = clsCurrency.GetAllCurrencies();
            foreach (DataRow row in dtCurrencies.Rows)
            {
                pieSeries.Points.AddXY(row["CodeCurrency"].ToString(), clsAccount.GetTotalBalancesByCurrency((int)row["ID"], clsAccount.enStatus.Active));

            }

            // 4. عرض النسبة المئوية على الشرائح (اختياري)
            pieSeries.Label = "#VALX:#PERCENT{P0}"; // P0 يعني نسبة مئوية بدون فواصل عشرية
            pieSeries.LegendText = "#VALX: #VALY"; // عرض اسم الفئة وقيمتها في وسيلة الإيضاح



            // 5. تخصيص مظهر التسميات (اختياري)
            pieSeries.LabelForeColor = System.Drawing.Color.Black; // لون النص
            pieSeries.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold); // خط النص

            // 6. إضافة السلسلة إلى عنصر التحكم Chart
            balancesPieChart.Series.Add(pieSeries);

            // 7. إضافة عنوان للمخطط
            Title pieTitle = new Title("توزيع إجمالي الأرصدة حسب العملة", Docking.Top, new Font("Tahoma", 12, FontStyle.Bold), Color.Black);
            balancesPieChart.Titles.Add(pieTitle);

            // 8. تخصيص وسيلة الإيضاح
            balancesPieChart.Legends.Add(new Legend("DefaultLegend"));
            balancesPieChart.Legends["DefaultLegend"].Docking = Docking.Bottom; // وضع وسيلة الإيضاح في الأسفل
            balancesPieChart.Legends["DefaultLegend"].Alignment = StringAlignment.Center; // توسيط وسيلة الإيضاح

            // 9. تحسين العرض ثلاثي الأبعاد (اختياري)
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.Inclination = 15;
        }

        public frmDashboard()
        {
            InitializeComponent();

        }

        private void FillDashboardInfo()
        {
            lblTotalBalnces.Text =clsGlobal.FomatNumber(Math.Round(clsAccount.GetTotalBalancesAllCurrencies(clsAccount.enStatus.Active)));
            lblCountActiveClients.Text = clsClient.GetCountClientsByStatus(clsClient.enStatus.Active).ToString();
            lblActiveAccounts.Text = clsAccount.GetCountAccountsByStatus(clsAccount.enStatus.Active).ToString();
            DateTime dtnow = DateTime.Now;
            lblCountTransactionsToday.Text = clsTransaction.GetCountTransactions(new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 00, 00, 00), new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 23, 59, 59), clsTransaction.enStatus.Completed).ToString();
            lblCountTransactionsTomonth.Text = clsTransaction.GetCountTransactions(new DateTime(dtnow.Year, dtnow.Month, 1, 00, 00, 00), new DateTime(dtnow.Year, dtnow.Month, 28, 23, 59, 59), clsTransaction.enStatus.Completed).ToString();
            lblTotalDepositToday.Text = clsGlobal.FomatNumber(Math.Round(clsTransaction.GetTotalBalancesAccordingToPSPCurrency(1008, clsTransaction.enStatus.Completed, new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 00, 00, 00), new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 23, 59, 59))));
            lblTotalWithdrawalToday.Text = clsGlobal.FomatNumber(Math.Round(clsTransaction.GetTotalBalancesAccordingToPSPCurrency(1009, clsTransaction.enStatus.Completed, new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 00, 00, 00), new DateTime(dtnow.Year, dtnow.Month, dtnow.Day, 23, 59, 59))));
            lblCountBranches.Text = clsBranche.GetCountBranches().ToString();
            lblCountEmpolyees.Text = clsEmployee.GetCountEmployees().ToString();
            lblCountUsers.Text = clsUser.GetCountActiveUsers().ToString();

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            FillDashboardInfo();
            SetupDepositWithdrawalChart();
            SetupPieChart();
        }

    } 
}
