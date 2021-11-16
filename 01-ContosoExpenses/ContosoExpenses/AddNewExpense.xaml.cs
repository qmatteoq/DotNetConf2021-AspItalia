﻿// ******************************************************************

// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.

// ******************************************************************

using ContosoExpenses.Models;
using ContosoExpenses.Services;
using System;
using System.Windows;

namespace ContosoExpenses
{
    /// <summary>
    /// Interaction logic for AddNewExpense.xaml
    /// </summary>
    public partial class AddNewExpense : Window
    {
        public int EmployeeId { get; set; }

        public AddNewExpense()
        {
            InitializeComponent();
        }

        private void OnSaveExpense(object sender, RoutedEventArgs e)
        {
            try
            {
                Expense expense = new Expense
                {
                    Address = txtLocation.Text,
                    City = txtCity.Text,
                    Cost = Convert.ToDouble(txtAmount.Text),
                    Description = txtDescription.Text,
                    Type = txtType.Text,
                    Date = txtDate.SelectedDate.GetValueOrDefault(),
                };

                DatabaseService service = new DatabaseService();
                service.SaveExpense(expense, EmployeeId);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Validation error. Please check your data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
