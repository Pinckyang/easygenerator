using System;
using System.Collections.Generic;
using System.Text;

namespace EasyGenerator.Studio.Model
{
    public static class ProjectAccesser
    {
        private static Project project;

        public static Project Project
        {
          get { return ProjectAccesser.project; }
          set { ProjectAccesser.project = value; }
        }
        public static void SetProject(Project project)
        {
            ProjectAccesser.Project = project;
        }
    }
}
