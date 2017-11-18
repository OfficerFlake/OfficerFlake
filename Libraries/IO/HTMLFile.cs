using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.RichTextMessages;
using String = System.String;

namespace Com.OfficerFlake.Libraries.IO
{
    public class HtmlFile : File
    {
        public class Dom
        {
            public class Head
            {
                public class Css
                {
                    public class Object
                    {
                        public string Name;

                        public class Property
                        {
                            public string Name;
                            public string Value;

                            public Property(string name, string value)
                            {
                                Name = name;
                                Value = value;
                            }

                            public override string ToString()
                            {
                                return Name + ": " + Value + ";";
                            }
                        }
                        public List<Property> Properties;

                        public Object(string name, params Property[] properties)
                        {
                            Name = name;
                            Properties = properties.ToList();
                        }

                        public override string ToString()
                        {
                            var output = new StringBuilder();
                            output.Append(Name + " {");
                            foreach (var thisProperty in Properties)
                            {
                                output.Append(thisProperty);
                            }
                            output.Append("}");
                            return output.ToString();
                        }
                    }
                    public List<Object> Objects = new List<Object>();

                    public override string ToString()
                    {
                        return String.Join("\n", Objects);
                    }
                }
                public List<Css> Stylesheets = new List<Css>();

                public override string ToString()
                {
                    List<string> output = new List<string>();
                    output.Add("<head>");
                    foreach (var thisStylesheet in Stylesheets)
                    {
                        output.Add("<style>");
                        output.Add(thisStylesheet.ToString());
                        output.Add("</style>");
                    }
                    output.Add("</head>");
                    return String.Join("\n", output);
                }
            };
            public class Body
            {
                public abstract class Element
                {
                    public string Name;
                    public List<Element> SubElements = new List<Element>();
                    public string Contents = "";

                    public abstract class Attribute
                    {
                        public string Name;
                        public string Value;

                        public override string ToString()
                        {
                            return Name + "=\"" + Value + "\"";
                        }
                    }
                    public List<Attribute> Attributes = new List<Attribute>();

                    public class Style : Attribute
                    {
                        public List<string> Classes = new List<string>();

                        public Style()
                        {
                            Name = "class";
                        }

                        public void AddClass(string className)
                        {
                            Classes.Add(className);
                        }

                        public override string ToString()
                        {
                            return Name + "=\"" + String.Join(" ", Classes) + "\"";
                        }
                    }
                    public class Class : Attribute
                    {
                        public Class(string value)
                        {
                            Name = "class";
                            Value = value;
                        }
                    }

                    public override string ToString()
                    {
                        var output = new StringBuilder();

                        //Open
                        output.Append("<" + Name);
                        foreach (var thisAttribute in Attributes)
                        {
                            output.Append(" " + thisAttribute.ToString());
                        }
                        output.Append(">");

                        //Contents
                        foreach (var thisSubElement in SubElements)
                        {
                            output.Append(thisSubElement);
                        }
                        output.Append(Contents);

                        //Close
                        output.Append("</" + Name + ">");
                        return output.ToString();
                    }
                }
                public List<Element> Elements = new List<Element>();

                public class Span : Element
                {
                    public Span(params Attribute[] attributes)
                    {
                        Name = "span";
                        Attributes = attributes.ToList();
                    }
                }
                public class Paragraph : Element
                {
                    public Paragraph()
                    {
                        Name = "p";
                    }

                    public Paragraph(RichTextMessage input)
                    {
                        Name = "p";
                        //Contents = input.ToString(); //input.AsHTMLParagraph;

                        //break elements up,
                        var output = new StringBuilder();
                        Style dateStyle = new Style();
                        dateStyle.Classes.Add("colorF");

                        Span dateSpan = new Span();
                        dateSpan.Attributes.Add(dateStyle);
                        dateSpan.Contents = input.Created.InStandardForm().YYYYMMDD_hhmmss_ + ": ";
                        output.Append(dateSpan);
                        foreach (var thisElement in input.Elements)
                        {
                            Style thisStyle = new Style();
                            thisStyle.Classes.Add("color" + thisElement.Color.Character);
                            if (thisElement.IsBold) thisStyle.Classes.Add("bold");
                            if (thisElement.IsItalic) thisStyle.Classes.Add("italic");
                            if (thisElement.IsObfuscated) thisStyle.Classes.Add("obfuscated");
                            if (thisElement.IsStrikeThrough) thisStyle.Classes.Add("strikethrough");
                            if (thisElement.IsUnderlined) thisStyle.Classes.Add("underlined");

                            Span thisSpan = new Span();
                            thisSpan.Attributes.Add(thisStyle);
                            thisSpan.Contents = thisElement.Message;
                            output.Append(thisSpan);
                        }
                        Contents = output.ToString();
                        Attributes.Add(new Class(input.GetHtmlMessageType()));
                    }
                }
                public class Table
                {
                    public class Row
                    {
                        public RichTextMessage Message;
                    }
                }

                public override string ToString()
                {
                    List<string> output = new List<string>();
                    output.Add("<body>");
                    foreach (var thisElement in Elements)
                    {
                        output.Add(thisElement.ToString());
                    }
                    output.Add("</body>");
                    return String.Join("\n", output);
                }
            };
        }
        public Dom.Head Head = new Dom.Head();
        public Dom.Body Body = new Dom.Body();

        public HtmlFile(string filename) : base(filename)
        {
        }

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add("<!DOCTYPE html>"); //html 5 compliant.
            output.Add("<html>");
            output.Add(Head.ToString());
            output.Add(Body.ToString());
            output.Add("</html>");

            return string.Join("\n", output);
        }

        public void Save()
        {
            Overwrite(ToString());
        }
        public void Load()
        {
            throw new NotImplementedException("No loading function exists yet for HTML files!");
        }
    }
}
