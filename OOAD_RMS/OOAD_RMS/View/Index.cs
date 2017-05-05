﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OOAD_RMS
{
    public partial class Index : Form
    {
        Model _model;
        public Index(Model model)
        {
            InitializeComponent();
            _model = model;

            BindingSource projectSource = new BindingSource(_model.GetProjects(), null);

            _projectComboBox.DataSource = projectSource;
            _projectComboBox.DisplayMember = "ProjectName";
            _projectComboBox.SelectedIndex = 0;

            _projectComboBoxTest.DataSource = projectSource;
            _projectComboBoxTest.DisplayMember = "ProjectName";
            _projectComboBoxTest.SelectedIndex = 0;

            DataGridViewButtonColumn editProjectBtn = new DataGridViewButtonColumn();
            _projectGridView.Columns.Add(editProjectBtn);
            _projectGridView.DataSource = projectSource;
            editProjectBtn.Text = "Edit";
            editProjectBtn.Name = "editBtn";
            editProjectBtn.UseColumnTextForButtonValue = true;
            editProjectBtn.HeaderText = "Edit";
            editProjectBtn.Width = 50;
            editProjectBtn.DisplayIndex = 2;

            DataGridViewButtonColumn editRequirementBtn = new DataGridViewButtonColumn();
            _requirementGridView.Columns.Add(editRequirementBtn);
            editRequirementBtn.Text = "Edit";
            editRequirementBtn.Name = "editBtn";
            editRequirementBtn.UseColumnTextForButtonValue = true;
            editRequirementBtn.HeaderText = "Edit";
            editRequirementBtn.Width = 50;
            editRequirementBtn.DisplayIndex = 2;

        }



        private void ClickAddProjectBtn(object sender, EventArgs e)
        {
            ShowAddProjectDialog showAddProjectDialog = new ShowAddProjectDialog();
            if (showAddProjectDialog.ShowDialog() == DialogResult.OK) {
                string projectName = showAddProjectDialog.GetProjectName();
                string projectDescription = showAddProjectDialog.GetProjectDescription();
                _model.addProject(projectName, projectDescription);

                //Project project = new Project();
                //project.ProjectName = showAddProjectDialog.GetProjectName();
                //project.ProjectDescription = showAddProjectDialog.GetProjectDescription();

                //_projectList.Add(project);

            }
        }

        private void ClickAddRequirementBtn(object sender, EventArgs e)
        {
            ShowAddRequirementDialog showAddRequirementDialog = new ShowAddRequirementDialog();
            showAddRequirementDialog.Text = _projectComboBox.Text;
            
            if (showAddRequirementDialog.ShowDialog() == DialogResult.OK)
            {
                string requirementName = showAddRequirementDialog.GetRequirementName();
                string requirementDescription = showAddRequirementDialog.GetRequirementDescription();
                _model.addRequirement(requirementName, requirementDescription);
            }
        }

        private void ClickAddTestBtn(object sender, EventArgs e)
        {
            ShowAddTestDialog showAddTestDialog = new ShowAddTestDialog();
            if (showAddTestDialog.ShowDialog() == DialogResult.OK)
            {
                string testName = showAddTestDialog.GetTestName();
                string testDescription = showAddTestDialog.GetTestDescription();
                _model.addTest(testName, testDescription);
            }
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(_projectComboBox.SelectedIndex);
            BindingSource requirementSource = new BindingSource(_model.getRequirementFromSelectProject(_projectComboBox.SelectedIndex), null);
            _requirementGridView.DataSource = requirementSource;
        }
        
        private void TestComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(_projectComboBoxTest.SelectedIndex);
            BindingSource testSource = new BindingSource(_model.getTestFromSelectProject(_projectComboBoxTest.SelectedIndex), null);
            _testGridView.DataSource = testSource;
        }

        private void EditProject(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                String getProjectNameFromDataGridView = _projectGridView.Rows[selectedRow].Cells[1].Value.ToString();
                String getProjectDescriptionFromDataGridView = _projectGridView.Rows[selectedRow].Cells[2].Value.ToString();

                ShowAddProjectDialog showAddProjectDialog = new ShowAddProjectDialog();
                showAddProjectDialog.EditProjectName(getProjectNameFromDataGridView);
                showAddProjectDialog.EditProjectDescription(getProjectDescriptionFromDataGridView);
             

                if (showAddProjectDialog.ShowDialog() == DialogResult.OK)
                {
                    _projectGridView.Rows[selectedRow].Cells[2].Value= showAddProjectDialog.GetProjectDescription();
                    _projectGridView.Rows[selectedRow].Cells[1].Value = showAddProjectDialog.GetProjectName();
                }
                
            }
        }

        private void EditRequirement(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                String getRequirementNameFromDataGridView = _requirementGridView.Rows[selectedRow].Cells[1].Value.ToString();
                String getRequirementDescriptionFromDataGridView = _requirementGridView.Rows[selectedRow].Cells[2].Value.ToString();

                ShowAddRequirementDialog requirementDialog = new ShowAddRequirementDialog();
                requirementDialog.EditRequirementName(getRequirementNameFromDataGridView);
                requirementDialog.EditRequirementDescription(getRequirementDescriptionFromDataGridView);


                if (requirementDialog.ShowDialog() == DialogResult.OK)
                {
                    _requirementGridView.Rows[selectedRow].Cells[2].Value = requirementDialog.GetRequirementDescription();
                    _requirementGridView.Rows[selectedRow].Cells[1].Value = requirementDialog.GetRequirementName();
                }

            }
        }
    }
}
