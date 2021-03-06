﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OOAD_RMS
{
    public class Project
    {
        private string _projectName;
        private string _projectDescription;
        private List<Requirement> _requirements = new List<Requirement>();
        private List<Test> _tests = new List<Test>();

        //example set,get projectName
        //public void setProjectName(string name) {
        //    _projectName = name;
        //}

        //public string getProjectName() {
        //    return _projectName;
        //}
        public string ProjectName {
            get {
                return _projectName;
            }
            set {
                _projectName = value;
            }    
        }

        public string ProjectDescription
        {
            get
            {
                return _projectDescription;
            }
            set
            {
                _projectDescription = value;
            }
        }

       

        public void AddRequirement(Requirement requirement)
        {
            _requirements.Add(requirement);
        }

        public void AddTest(Test test)
        {
            _tests.Add(test);
        }

        public List<Requirement> GetRequirements()
        {
            return _requirements;
        }

        public List<Test> GetTests()
        {
            return _tests;
        }
    }
}