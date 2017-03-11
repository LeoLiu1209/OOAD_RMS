﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOAD_RMS
{
    public class Project
    {
        private string _projectName;
        private string _projectDescription;
        private List<string> _requirements = new List<string>();

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
    }
}
