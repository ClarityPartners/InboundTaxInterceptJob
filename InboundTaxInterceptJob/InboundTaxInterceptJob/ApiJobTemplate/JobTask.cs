using System;
using System.Runtime.InteropServices;
using Tyler.Odyssey.JobProcessing;

namespace TaxInterceptJob
{
  [ClassInterface(ClassInterfaceType.None)]
  [Guid("c9045ff6-0d2f-490e-8a40-cda2ed783f2d")]
  [ComVisible(true)]
  public class JobTask : Task
  {
    protected override void SetupProcessor(string SiteID, string JobTaskXML)
    {
      Processor = new DataProcessor(SiteID, JobTaskXML);

      ((DataProcessor)Processor).TaskParms = this.jobTaskParms;
      ((DataProcessor)Processor).TaskUtility = this.taskUtility;
      ((DataProcessor)Processor).TaskDocument = this.taskDocument;

      UserID = ((DataProcessor)Processor).Context.UserID;
    }

    private int UserID { get; set; }
  }
}
