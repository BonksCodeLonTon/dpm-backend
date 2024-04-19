using DevExpress.Pdf;

namespace DPM.Domain.Common.Models;
public class PdfSignature
{
    public string FullName { get; set; }
    public string FieldName { get; set; }
    public PdfRectangle Location { get; set; }
    public string Reason { get; set; }
    public byte[] ImageData { get; set; }
}
