using BusinessLogicLayer;
using DataAccessLayer;
using FoiFitness.charts;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for ShowProgressWindow.xaml
    /// </summary>
    public partial class ShowProgressWindow : Window
    {
        public ShowProgressWindow()
        {
            InitializeComponent();
        }

        private void btnShowUserWeight_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if (dpStartDateWeight.SelectedDate.HasValue && dpEndDateWeight.SelectedDate.HasValue)
            {
                startDate = dpStartDateWeight.SelectedDate.Value.Date;
                endDate = dpEndDateWeight.SelectedDate.Value.Date;

                var weightProgress = new WeightProgress(startDate, endDate);
                lblValidationMessageUserWeight.Content = DateInputValidation(dpStartDateWeight, dpEndDateWeight);
                contentUserWeight.Content = weightProgress;
                contentUserWeight.Height = 300;
            }
            else
            {
                lblValidationMessageUserWeight.Content = DateInputValidation(dpStartDateWeight, dpEndDateWeight);
                contentUserWeight.Content = null;
                contentUserWeight.Height = 0;
            }
        }

        private void btnShowCaloricIntake_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if (dpStartDateCalories.SelectedDate.HasValue && dpEndDateCalories.SelectedDate.HasValue)
            {
                startDate = dpStartDateCalories.SelectedDate.Value.Date;
                endDate = dpEndDateCalories.SelectedDate.Value.Date;

                var caloricIntake = new CaloricIntakeChart(startDate, endDate);
                lblValidationMessageCaloricIntake.Content = DateInputValidation(dpStartDateCalories, dpEndDateCalories);
                contentCaloricIntake.Content = caloricIntake;
                contentCaloricIntake.Height = 300;
            }
            else
            {
                lblValidationMessageCaloricIntake.Content = DateInputValidation(dpStartDateCalories, dpEndDateCalories);
                contentCaloricIntake.Content = null;
                contentCaloricIntake.Height = 0;
            }
        }

        private void btnCleanUserWeightChart_Click(object sender, RoutedEventArgs e)
        {
            dpStartDateWeight.SelectedDate = null;
            dpEndDateWeight.SelectedDate = null;
            lblValidationMessageUserWeight.Content = null;
            contentUserWeight.Content = null;
            contentUserWeight.Height = 0;
        }

        private void btnCleanCaloricIntakeChart_Click(object sender, RoutedEventArgs e)
        {
            dpStartDateCalories.SelectedDate = null;
            dpEndDateCalories.SelectedDate = null;
            lblValidationMessageCaloricIntake.Content = null;
            contentCaloricIntake.Content = null;
            contentCaloricIntake.Height = 0;
        }

        private string? DateInputValidation(DatePicker dpStartDate, DatePicker dpEndDate)
        {
            if (!dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                return "You have to enter Start date!";
            }
            else if (dpStartDate.SelectedDate.HasValue && !dpEndDate.SelectedDate.HasValue)
            {
                return "You have to enter End date!";
            }
            else if (!dpStartDate.SelectedDate.HasValue && !dpEndDate.SelectedDate.HasValue)
            {
                return "You have to enter Start and End date!";
            }
            return null;
        }
    }
}
