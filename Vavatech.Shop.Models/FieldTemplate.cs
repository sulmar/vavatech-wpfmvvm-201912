using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.Models
{
    public class FormTemplate
    {
        public IEnumerable<FieldTemplate> Fields { get; set; }

        public FormTemplate()
        {
            Fields = new List<FieldTemplate>
            {
                new TextFieldTemplate("First name", "John"),
                new TextFieldTemplate("Last name", "Smith"),
                new DateFieldTemplate("From", DateTime.MinValue),
                new DateFieldTemplate("To", DateTime.MaxValue),
            };
        }

    }

    public abstract class FieldTemplate : BaseEntity
    {
        protected FieldTemplate(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class DateFieldTemplate : FieldTemplate
    {
        public DateFieldTemplate(string name, DateTime value) 
            : base(name)
        {
            this.Value = value;
        }

        public DateTime Value { get; set; }
    }

    public class TextFieldTemplate : FieldTemplate
    {
        public TextFieldTemplate(string name, string value) : base(name)
        {
            this.Value = value;
        }

        public string Value { get; set; }
    }

}
