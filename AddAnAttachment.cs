using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text;
namespace Command
{
    public class AddAnAttachment : CodeActivity
    {
        [RequiredArgument]
        [Input("Title")]
        public InArgument<string> Title { get; set; }

        [RequiredArgument]
        [Input("File Name")]
        public InArgument<string> FileName { get; set; }

        [Input("File Type")]
        public InArgument<string> FileType { get; set; }

        [RequiredArgument]
        [Input("File Content")]
        public InArgument<string> FileContent { get; set; }


        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            //byte[] fileContent = Encoding.ASCII.GetBytes(FileContent.Get(executionContext));
            //string encodedData = System.Convert.ToBase64String(fileContent);

            Entity annotation = new Entity("annotation");
            annotation["subject"] = Title.Get(executionContext);
            annotation["filename"] = FileName.Get(executionContext);
            annotation["mimetype"] = FileType.Get(executionContext);
            annotation["documentbody"] = FileContent.Get(executionContext);
            annotation["objectid"] = new EntityReference(context.PrimaryEntityName, context.PrimaryEntityId);
            annotation["objecttypecode"] = context.PrimaryEntityName;

            service.Create(annotation);

            //DateTime DateStart = DateTime.Now;
            //DateTime DateEnd = DateStart.AddMinutes(105);
            //string Summary = "An appointment with Clofly";
            //string Location = "Shang Hai";
            //string Description = "I want to test whether I can create a calendar as attachment";
            //string FileName = "Calendar01";

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("BEGIN:VCALENDAR");
            //sb.AppendLine("VERSION:2.0");
            //sb.AppendLine("PRODID:maoalex.best");
            //sb.AppendLine("CALSCALE:GREGORIAN");
            //sb.AppendLine("METHOD:PUBLISH");

            //sb.AppendLine("BEGIN:VTIMEZONE");
            //sb.AppendLine("TZID:Asia/Shanghai");
            //sb.AppendLine("BEGIN:STANDARD");
            //sb.AppendLine("TZOFFSETTO:+0100");
            //sb.AppendLine("TZOFFSETFROM:+0100");
            //sb.AppendLine("END:STANDARD");
            //sb.AppendLine("END:VTIMEZONE");

            //sb.AppendLine("BEGIN:VEVENT");
            //sb.AppendLine("DTSTART;TZID=Asia/Shanghai:" + DateStart.ToString("yyyyMMddTHHmm00"));
            //sb.AppendLine("DTEND;TZID=Asia/Shanghai:" + DateEnd.ToString("yyyyMMddTHHmm00"));
            ////or without
            //sb.AppendLine("DTSTART:" + DateStart.ToString("yyyyMMddTHHmm00"));
            //sb.AppendLine("DTEND:" + DateEnd.ToString("yyyyMMddTHHmm00"));

            //sb.AppendLine("SUMMARY:" + Summary + "");
            //sb.AppendLine("LOCATION:" + Location + "");
            //sb.AppendLine("DESCRIPTION:" + Description + "");
            //sb.AppendLine("PRIORITY:3");
            //sb.AppendLine("END:VEVENT");

            ////end calendar item
            //sb.AppendLine("END:VCALENDAR");

            //String content = sb.ToString();

            //byte[] fileContent = Encoding.ASCII.GetBytes(content);
            //string encodedData = System.Convert.ToBase64String(fileContent);

            //Entity annotation = new Entity("annotation");
            //annotation["filename"] = FileName;
            //annotation["documentbody"] = encodedData;
            //annotation["subject"] = Summary;
            //annotation["objectid"] = new EntityReference("account", Guid.Parse("1ece5cd4-ae56-e711-abaa-00155d701c02"));
            //annotation["objecttypecode"] = "account";
            //annotation["mimetype"] = @"text/calendar";
            //service.Create(annotation);

        }
    }
}
