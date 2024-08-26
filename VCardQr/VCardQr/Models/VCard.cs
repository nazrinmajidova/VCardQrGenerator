using System.Text;

namespace VCardQr.Models;

public class VCard
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Mobile { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string Email { get; set; } = null!;
    public string? Company { get; set; }
    public string? Job { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? QrCode { get; set; }


    public string GenerateVCard()
    {
        var vCard = new StringBuilder();
        vCard.AppendLine("BEGIN:VCARD");
        vCard.AppendLine("VERSION:3.0");
        vCard.AppendLine($"FN:{FirstName} {LastName}");
        vCard.AppendLine($"N:{LastName};{FirstName};;;");
        vCard.AppendLine($"ORG:{Company}");
        vCard.AppendLine($"TITLE:{Job}");
        vCard.AppendLine($"EMAIL:{Email}");
        vCard.AppendLine($"TEL;TYPE=CELL:{Mobile}");
        vCard.AppendLine($"TEL;TYPE=HOME:{Phone}");
        vCard.AppendLine($"TEL;TYPE=FAX:{Fax}");
        vCard.AppendLine($"ADR:;;{Street};{City};;{Country}");
        vCard.AppendLine($"PHOTO;VALUE=URL:{QrCode}");
        vCard.AppendLine("END:VCARD");

        return vCard.ToString();

      

    }
}
