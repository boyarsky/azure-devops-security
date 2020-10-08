﻿

using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization.TypeInspectors;

namespace Didactic.Schema
{
    public class ProjectManifest : BaseSchema
    {
        public ProcessTemplateSchema Template { get; set; }

        protected override bool OnValidateCore()
        {
            if(Template == null || string.IsNullOrWhiteSpace(Template.Name))
            {
                return false;
            }

            return base.OnValidateCore();
        }
    }

    public class ProcessTemplateSchema
    {
        public string Name { get; set; }
        public string SourceControlType { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
